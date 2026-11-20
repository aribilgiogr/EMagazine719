using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using PL.Web.Models;

namespace PL.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICategoryService categoryService;

        public DashboardController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories(int? id = null)
        {
            var model = new CategoriesViewModel
            {
                Categories = categoryService.GetList(false),
            };

            if (id != null)
            {
                model.EditCategory = categoryService.GetForEdit((int)id);
            }

            return View(model);
        }
    }
}
