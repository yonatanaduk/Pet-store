using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;
using Store.Repository;
using System.Diagnostics;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        public AnimalsContext _context { get; set; }
        public AnimalServices _animalServices { get; set; }


        public HomeController(AnimalsContext context)
        {
            _context = context;
            _animalServices = new AnimalRepository(context);

        }

        public IActionResult Index()
        {
          
            return View(_context.Animals!.OrderByDescending(a => a.Comments!.Count).Take(2));
        }
        public IActionResult AllAnimalUser(string Category)
        {

            return View(_animalServices.FilterAnimalByTheCategory(Category));
        }

        public IActionResult ShowDetailsForUser(int id)
        {
            return View("ShowDetailsForUser", _animalServices.FindeAnimalById(id));
        }  
        public IActionResult AddNewComment(Animal animal , string comment)
        {
            _animalServices.AddComment((int)animal.AnimalId!, comment);
            return RedirectToAction("Index");
        }

    }
}