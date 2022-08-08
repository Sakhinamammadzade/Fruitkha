using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProductDal : EfEntityRepositoryBase<Product, ShopDbContext>, IProductDal
    {
       

        public Product AddProduct(Product product)
        {
            using ShopDbContext _context = new();
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            using ShopDbContext context = new();
            var productCategory=context.productCategories.Where(c=>c.CategoryId==categoryId).ToList();
            List<Product> products = new List<Product>();
            foreach (var pC in productCategory)
            {
                var findedProduct=context.Products.FirstOrDefault(x=>x.Id==pC.Id);
                products.Add(findedProduct);
            }
            return products;
        }
    }
}
