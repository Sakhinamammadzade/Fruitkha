﻿using Entities.Concrete;
using Entities.DTOs;

namespace WebUI.ViewModels
{
    public class ProductDetailVM
    {
        public ProductDetailDto Product { get; set; }
        public List<Product> Products { get; set; }

    }
}
