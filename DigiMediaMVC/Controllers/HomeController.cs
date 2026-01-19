using System.Diagnostics;
using System.Threading.Tasks;
using DigiMediaMVC.Contexts;
using DigiMediaMVC.Models;
using DigiMediaMVC.ViewModels.ProjectViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigiMediaMVC.Controllers
{
    public class HomeController(DigiMediaDbContext _context, ILogger<HomeController> _logger) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var projects = await _context.Projects.Select(x => new ProjectGetVM()
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                SpecialityName = x.Speciality.Name

            }).ToListAsync();

            return View(projects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
