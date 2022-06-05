using Business.Abstract;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryManager
    {

        private readonly FreshDbContext _context;

        public CategoryManager(FreshDbContext context)
        {
            _context = context;
        }

        public void Create(Category Category)
        {

            _context.Categories.Add(Category);
            _context.SaveChanges();
        }

        public void Delete(Category Category)
        {
            _context.Categories.Remove(Category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            var Category = _context.Categories.ToList();
            return Category;
        }

        public Category GetById(int? id)
        {
            var Category = _context.Categories.FirstOrDefault(x => x.Id == id);

            return Category;
        }

        public void Update(Category Category)
        {
            _context.Categories.Update(Category);
            _context.SaveChanges();
        }
    }
}
