﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    { 
        Product Add(Product product);
        void Update(Product product);
        void Delete(int productId);   
        void Return(int productId);
        List<Product> GetAll();
        List<Product> GetShopProducts();
        List<Product> GetHomeProducts();
        List<Product> GetProductsByCategory(int categoryId);
        Product GetById(int id);
        
        ProductDetailDto GetProductById(int id);
        List<Product> GetSliderProducts();
        List<Product> RelatedProducts(List<int> catergoryId, int productId);


    }
}
