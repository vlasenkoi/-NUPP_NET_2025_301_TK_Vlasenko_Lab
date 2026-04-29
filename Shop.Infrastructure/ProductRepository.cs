using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Shop.Infrastructure
{
    public class ProductRepository : IRepository<ProductModel>
    {
        private readonly ShopContext _context = new ShopContext();

        public async Task AddAsync(ProductModel entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ProductModel entity)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(ProductModel entity)
        {
            _context.Products.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}