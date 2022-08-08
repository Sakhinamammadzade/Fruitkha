using Entities.Concrete;

namespace WebUI.Areas.Admin.HomeVM
{
    public class ProductVm
    {
        public Product product{ get; set; }
        public List<Category> categories { get;set;}
        public List<int> productCategories { get;set;}   
    }
}
