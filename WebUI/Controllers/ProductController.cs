using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IActionResult Index()
        {
          return View();
        }
        public IActionResult Detail(int id)
        {
            try
            {
                var product = _productManager.GetProductById(id);
                ProductDetailVM productDetail = new()
                {
                    Product=product
                };

                return View(productDetail);

            }
            catch (Exception)
            {

                return NotFound();
            }
         
        }
    }
}
