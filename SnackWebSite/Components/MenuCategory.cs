using Microsoft.AspNetCore.Mvc;
using SnackWebSite.Repositories.Interfaces;

namespace SnackWebSite.Components
{
    public class MenuCategory : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public MenuCategory(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var category = _categoryRepository.Categories.OrderBy(x => x.Name);

            return View(category);
        }
    }
}
