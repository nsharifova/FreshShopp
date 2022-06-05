using Business.Abstract;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class ProductManager : IProductManager
    {
        private readonly FreshDbContext _context;

        public ProductManager(FreshDbContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
           
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();     
        }
        public List<Product> GetAll()
        {
            var product = _context.Products.Include(x => x.Category).ToList();
            return product;
        }

        public Product GetById(int? id)
        {
            var product = _context.Products.Include(x => x.Category).FirstOrDefault(x => x.Id == id);

            return product;
        }
        public Product GetByDisc(int? id)
        {
            var Product = _context.Products.Include(x => x.Category).Where(x => x.IsDiscount == true).FirstOrDefault(x => x.Id == id);

            return Product;
        }
      
        public List<Product> GetDiscount()
        {
            var discount = _context.Products.
                Where(x => x.Discount != null).ToList();
            return discount;
        }
        public List<Product> Similar(int catId, int proId)
        {
            var pros = _context.Products
                .Include(x => x.Category)
                .Where(x => x.CategoryId == catId & x.Id != proId)
                .ToList();

            return pros;
        }   


        public async Task<List<Product>>? GetByIds(IEnumerable<int> ids)
        {
            return await _context.Products
           .Include(c => c.Category)
               .Where(c => ids.Contains(c.Id))
               .ToListAsync();
        }

        public List<Product> GetFeatured()
        {
            var featuredproduct = _context.Products
                 .Where(x => x.IsFeatured == true && x.Available == true)
                .Take(3).ToList();
            return featuredproduct;
        }

    }
}
        