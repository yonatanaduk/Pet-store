using Store.Models;

namespace Store.Repository
{
    public interface AnimalServices
    {
        void Deleteservice(int id);
        void Updateservice(int id , string _name, int _age, string _pictureSrc, string _description);
        void AddnewAnimal(Animal animal);
        List<Animal> FilterAnimalByTheCategory(string str);
        Animal FindeAnimalById(int id);

        bool Login(string username, string password);
        void AddComment(int id , string name);

        void DeleteComment(int id);
    }
}
