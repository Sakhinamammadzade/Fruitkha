using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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

        public List<Product> GetAllHomeProducts()
        {
            using ShopDbContext _context = new();
            return _context.Products.Where(x=>x.IsDelete==false).Take(3).ToList();
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

      

        public ProductDetailDto GetProductById(int productId)
        {
            using ShopDbContext _context = new();
            var productCategory = _context.productCategories.Include(x=>x.Category).Where(p => p.ProductId == productId).ToList();
            var product=_context.Products.FirstOrDefault(x=>x.Id==productId);
            List<Category> categoryList = new();
            foreach (var item in productCategory)
            {
                categoryList.Add(item.Category);
            }

            ProductDetailDto result = new()
            {
                Id=product.Id,
                Name=product.Name,
                CoverPhoto=product.CoverPhoto,
                Description=product.Description,
                DisCount=product.DisCount,
                PhotoUrl=product.PhotoUrl,
                Price=product.Price,
                Quantity=product.Quantity,
                Categories=categoryList
            };
            return result;

        }

        public List<Product> RelatedProducts(List<int> CategoryId,int productId)
        {
            using ShopDbContext _context = new();
            var productCategories = _context.productCategories.Where(x=>x.CategoryId== CategoryId[0]).Include(x=>x.Product);
            List<Product> products = new();
            for (int i = 0; i < productCategories.ToList().Count; i++)
            {
                products.Add(productCategories.Skip(i).FirstOrDefault().Product);
            }


            return products.Where(x=>x.Id!=productId).Take(3).ToList();
        }
    }
}