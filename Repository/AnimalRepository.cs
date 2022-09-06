using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;

namespace Store.Repository
{
    public class AnimalRepository : AnimalServices
    {
        public AnimalsContext _context { get; set; }

        public AnimalRepository(AnimalsContext context)
        {
            _context = context;
        }

        public void Deleteservice(int id)
        {
            var animal = _context.Animals!.Single(m => m.AnimalId == id);
            _context.Animals!.Remove(animal);
            _context.SaveChanges();
        }
        public void Updateservice(int id, string _name, int _age, string _pictureSrc, string _description)
        {
            var animal = _context.Animals!.Single(m => m.AnimalId == id);
            if (_name != null)
            {
                animal.Name = _name;
            }
            if (_age != 0)
            {
                animal.Age = _age;
            }
            if (_pictureSrc != null)
            {
                animal.PictureSrc = _pictureSrc;
            }
            if (_description != null)
            {
                animal.Description = _description;
            }
            _context.SaveChanges();

        }


        public void AddnewAnimal(Animal animal)
        {
            _context.Animals!.Add(animal);
            if (animal != null) _context.SaveChanges();
        }

        public List<Animal> FilterAnimalByTheCategory(string category)
        {
            var animalComment = _context.Animals!.Include(c => c.Comments!);

            var categories = _context.Animals!.Include(c => c.Categories)
                .ThenInclude(c => c.Animals!)
                .ThenInclude(c => c.Comments);
            var animal = categories!.Where(m => m.Categories!.Name == category);

            if (category != null) return animal.ToList();
            else
            {
                return _context.Animals!.Include(c => c.Comments!).ToList();

            }
        }

        public Animal FindeAnimalById(int id)
        {
            var animal = _context.Animals!.Include(c => c.Comments).Single(m => m.AnimalId == id);
            return animal;

        }

        public bool Login(string username, string password)
        {
            var name = _context.Admins!.FirstOrDefault(m => m.UserName == username);
            var pass = _context.Admins!.FirstOrDefault(m => m.Password == password);

            if (name == default || pass == default)
            {
                return false;
            }
            else
                return true;

        }

        public void AddComment(int id, string comment)
        {
            var animal = _context.Animals!.Include(c => c.Comments).Single(m => m.AnimalId == id);
            if (comment != null)
            {
                animal.Comments!.Add(new Comment { Content = comment });
            }
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            //this func is infrastructure for delete comment if in the future me or someone else one to adding

            throw new NotImplementedException();
        }
    }
}
