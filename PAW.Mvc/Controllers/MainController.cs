using Microsoft.AspNetCore.Mvc;
using PAW.Business;
using PAW.Models;

namespace PAW.Mvc.Controllers
{
    public abstract class MainController : Controller
    {
        protected readonly IProductManager _productManager; 
        //protected readonly ICategoriesManager _categoriesManager;
        //protected readonly ISuppliersManager _suppliersManager;

        public MainController(IProductManager productManager/* ICategoriesManager categoriesManager, ISuppliersManager suppliersManager*/)
        {
            _productManager = productManager;
            //_categoriesManager = categoriesManager;
            //_suppliersManager = suppliersManager;
        }

        public async Task<IEnumerable<Product>> GetMyProductAsync()
        {
            return await _productManager.GetAllAsync();
        }
        
        //public IEnumerable<Categories> GetMyCategories => _categoriesManager.GetCategories();
        //public IEnumerable<Suppliers> GetMySuppliers => _suppliersManager.GetSuppliers();
    }
}