using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using productlib;

namespace ProductAPI
{
    public static class EntityExtensions
    {
        public static EntityTypeBuilder<T> ConfigIdentity<T>(this EntityTypeBuilder<T> builder)
               where T : class, IKeyIdentity
        {
            builder.Property(x => x.Id)
                .IsRequired(true)
                .HasColumnType("varchar")
                .HasColumnName(nameof(IKeyIdentity.Id))
                .HasMaxLength(36)
                .IsUnicode(false)
                ;
            return builder;
        }
    }
}
