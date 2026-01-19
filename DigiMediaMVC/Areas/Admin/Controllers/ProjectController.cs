using System.Threading.Tasks;
using DigiMediaMVC.Contexts;
using DigiMediaMVC.Helpers;
using DigiMediaMVC.Models;
using DigiMediaMVC.ViewModels.ProjectViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DigiMediaMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AutoValidateAntiforgeryToken]
    public class ProjectController : Controller
    {
        private readonly DigiMediaDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _folderPath;

        public ProjectController(DigiMediaDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images");
        }

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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await _sendSpecialitiesWithViewBag();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectCreateVM vm)
        {
            await _sendSpecialitiesWithViewBag();

            if (!ModelState.IsValid)
                return View(vm);

            var isExistSpecialities = await _context.Specialities.AnyAsync(x => x.Id == vm.SpecialityId);

            if (!isExistSpecialities)
            {
                ModelState.AddModelError("SpecialityId", "This Speciality is not found!");
                return View(vm);
            }

            if (!vm.Image.CheckSize(2))
            {
                ModelState.AddModelError("Image", "Image size must be maximum 2MB!");
                return View(vm);
            }

            if (!vm.Image.CheckType("image"))
            {
                ModelState.AddModelError("Image", "Image format is invalid!");
                return View(vm);
            }

            string uniqueFileName = await vm.Image.FileUploadAsync(_folderPath);

            Project project = new Project()
            {
                Id = vm.Id,
                Name = vm.Name,
                ImagePath = uniqueFileName,
                SpecialityId = vm.SpecialityId
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                return BadRequest();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            string deletedPath = Path.Combine(_folderPath, project.ImagePath);

            FileHelper.FileDelete(deletedPath);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                return BadRequest();

            ProjectUpdateVM vm = new ProjectUpdateVM()
            {
                Id = project.Id,
                Name = project.Name,
                SpecialityId = project.SpecialityId
            };

            await _sendSpecialitiesWithViewBag();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProjectUpdateVM vm)
        {
            await _sendSpecialitiesWithViewBag();

            if (!ModelState.IsValid)
                return View(vm);

            var isExistSpecialities = await _context.Specialities.AnyAsync(x => x.Id == vm.SpecialityId);

            if (!isExistSpecialities)
            {
                ModelState.AddModelError("SpecialityId", "This Speciality is not found!");
                return View(vm);
            }

            if (!vm.Image?.CheckSize(2) ?? false)
            {
                ModelState.AddModelError("Image", "Image size must be maximum 2MB!");
                return View(vm);
            }

            if (!vm.Image?.CheckType("image") ?? false)
            {
                ModelState.AddModelError("Image", "Image format is invalid!");
                return View(vm);
            }

            var existProject = await _context.Projects.FindAsync(vm.Id);

            if (existProject == null)
                return BadRequest();

            existProject.Id = vm.Id;
            existProject.Name = vm.Name;
            existProject.SpecialityId = vm.SpecialityId;

            if (vm.Image is { })
            {
                string newImagePath = await vm.Image.FileUploadAsync(_folderPath);

                string deletedImagePath = Path.Combine(_folderPath, existProject.ImagePath);
                FileHelper.FileDelete(deletedImagePath);

                existProject.ImagePath = newImagePath;
            }

            _context.Projects.Update(existProject);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }



        public async Task _sendSpecialitiesWithViewBag()
        {
            var specialities = await _context.Specialities.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToListAsync();

            ViewBag.Specialities = specialities;
        }
    }
}
