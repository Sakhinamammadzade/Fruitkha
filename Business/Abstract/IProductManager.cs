using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    { 
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);   
        List<Product> GetAll(); 
        List<Product> GetProductsByCategory(int categoryId);
        Product GetById(int id);


    }
}
