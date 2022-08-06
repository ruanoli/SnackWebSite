using Microsoft.AspNetCore.Mvc;
using SnackWebSite.Models;
using SnackWebSite.Repositories.Interfaces;
using SnackWebSite.ViewModels;

namespace SnackWebSite.Controllers
{
    public class SnackController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        public SnackController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        //Filtrar pelo nome da categoria.
        public IActionResult List( string category)
        {
            IEnumerable<Snack> snack;
            string currentCategory = String.Empty;

            //Se categoria for nula ou vazia será retornada todos os lanches.
            if (string.IsNullOrEmpty(category))
            {
                snack = _snackRepository.Snacks.OrderBy(x => x.SnackId);
                currentCategory = "Todos os Lanches";
            }
            else
            {
                 snack = _snackRepository.Snacks
                            .Where(x => x.Category.Name.Equals(category))
                            .OrderBy(x => x.Name);
                

                currentCategory = category;
            }

            var snackListVM = new SnackListViewModel
            {
                Snacks = snack,
                CurrentCategory = currentCategory
            };

            return View(snackListVM);
        }

        public IActionResult Details(int id)
        {
            var snack = _snackRepository.Snacks.FirstOrDefault(x => x.SnackId == id);

            return View(snack);
        }
    }
}
