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
    public class ProductCategoryManager:IProductCategoryManager
    {
        private readonly IProductCategoryDal _productCategoryDal;
        public ProductCategoryManager(IProductCategoryDal productCategoryDal)
        {
            _productCategoryDal = productCategoryDal;
        }

        public void AddProductCategory(ProductCategory productCategory)
        {
            _productCategoryDal.Add(productCategory);


        }

        public List<ProductCategory> GetProductCategoryById(int productId)
        {
            return _productCategoryDal.GetAll(x=>x.ProductId==productId);

        }
    }
}
