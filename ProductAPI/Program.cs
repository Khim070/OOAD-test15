
namespace ProductAPI;

using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using productlib;

public class Program
{
    public static void Main(string[] args)
    {
        const string CORS_POLICY = "CORS_Policy";
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(option =>
        {
            option.AddPolicy(CORS_POLICY, builder =>
            {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });

        builder.Services.AddDbContext<IDbContext, SqlDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
        });

        builder.Services.AddTransient<ProductRepo>();
        builder.Services.AddTransient<ProductService>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseCors(CORS_POLICY);
        app.MapProductEndpoints("Products", CORS_POLICY);

        app.UseHttpsRedirection();

        app.Run();
    }
}
