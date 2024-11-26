using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace productlib
{
    public class ProductRepo
    {
        private readonly IDbContext _context;

        public ProductRepo(IDbContext context)
        {
            _context = context;
        }

        public Task<int> CreateAsync(Product entity)
        {
            var result = _context.Set<Product>().Add(entity.Clone());
            if(result.State == EntityState.Added)
            {
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(0);
        }

        public Task<int> CreateAsync(List<Product> products)
        {
            _context.Set<Product>().AddRange(products);
            var entries = _context.ChangeTracker.Entries<Product>().Where(e => e.State == EntityState.Added);
            if(entries.Any())
            {
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(0);
        }

        public IQueryable<Product> GetQueryable() => _context.Set<Product>().AsQueryable();

        public Task<int> UpdateAsync(Product entity)
        {
            var result = _context.Set<Product>().Update(entity);
            if (result.State == EntityState.Modified)
            { 
                return _context.SaveChangesAsync();
            }
            return Task.FromResult(0);
        }

        public Task<int> DeleteAsync(Product entity)
        {
            var result = _context.Set<Product>().Remove(entity);
            if(result.State == EntityState.Deleted)
            {
                return _context.SaveChangesAsync();
                
            }
            return Task.FromResult(0);
        }
    }
}
