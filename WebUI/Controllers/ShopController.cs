using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
      

        public ShopController(IProductManager productManager, ICategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
           
        }

        public IActionResult Index()
        {
            var products=_productManager.GetShopProducts();
            var categories = _categoryManager.GetAll();
            ShopVM shopVM = new()
            {
                Products=products,
                Categories= categories

            };
            return View(shopVM);
        }
    }
}
