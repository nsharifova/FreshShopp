
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    {

        List<Product> GetAll();
        List<Product> GetDiscount();
        List<Product> GetFeatured();
        List<Product> Similar(int catId, int proId);


        Task<List<Product>>? GetByIds(IEnumerable<int> ids);
         Product GetByDisc(int? id);
        void Create(Product product);
        Product GetById(int? id);
        void Update(Product product);

        void Delete(Product product);
    }
}
