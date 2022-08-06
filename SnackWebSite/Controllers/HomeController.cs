using Microsoft.AspNetCore.Mvc;
using SnackWebSite.Models;
using SnackWebSite.Repositories.Interfaces;
using SnackWebSite.ViewModels;
using System.Diagnostics;

namespace SnackWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        public HomeController(ISnackRepository snackRepository)
        {
            _snackRepository = snackRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                SnacksPrefer = _snackRepository.MySnackPrefer
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}