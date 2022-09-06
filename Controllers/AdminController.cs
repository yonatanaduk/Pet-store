using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Repository;

namespace Store.Controllers
{
    public class AdminController : Controller
    {
        public AnimalsContext _context { get; set; }
        public AnimalServices _animalServices { get; set; }

        public AdminController(AnimalsContext context)
        {
            _context = context;
            _animalServices = new AnimalRepository(context);

        }
        public IActionResult Index(string Category)
        {

            return View(_animalServices.FilterAnimalByTheCategory(Category));
        }
        public IActionResult Delete(int id)
        {
            _animalServices.Deleteservice(id);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateAnimal(Animal animal)
        {
            _animalServices.Updateservice((int)animal.AnimalId!,  animal.Name!, (int)animal.Age!,  animal.PictureSrc!,  animal.Description!);;
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {

            return View("Update", _animalServices.FindeAnimalById(id));
        }


        public IActionResult AddNew(Animal animal)
        {
            var Allanimals = _context.Animals!.ToArray();
            var id = Allanimals[Allanimals.Length - 1].AnimalId + 1;

            var newAnimal = new Animal { AnimalId = id, Name = animal.Name, Age = animal.Age, PictureSrc = animal.PictureSrc, Description = animal.Description, CategoryId = animal.CategoryId };
            _animalServices.AddnewAnimal(newAnimal);
            return RedirectToAction("Index");
        }

        public IActionResult NevigatToForm()
        {
            return View("Add");
        }

        public IActionResult Details(int id)
        {
            return View("Details", _animalServices.FindeAnimalById(id));
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult NevigatToAdnimPage(string username , string password)
        {
            if (_animalServices.Login(username, password))
            {
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Login");
        }

    }
}
