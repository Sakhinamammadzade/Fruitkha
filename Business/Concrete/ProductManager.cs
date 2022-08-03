using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
           _productDal = productDal;
        }

        public void Add(Product product)
        {
         _productDal.Add(product);
        }

        public void Delete(Product product)
        {
           _productDal.Delete(product);
        }

        public List<Product> GetAll()
        {
           return _productDal.GetAll();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
           return  _productDal.Get(x => x.Id == id);  
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetByCategory(categoryId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
