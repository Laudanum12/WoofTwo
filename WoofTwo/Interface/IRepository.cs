using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Classes;

namespace WoofTwo
{
    public interface IRepository
    {
        List<User> Users { get; }
        List<Animal> Animals { get; }
        List<Species> Species { get; }
        User CurrentUser { get; set; }

        bool CanAddUser(string name);
        void AddUSer(string _city, DateTime _dateOfRegistration, string _email, string _password, string _name);
        User UserInStorage(string name, string password);
        Species FindSpecies(string name);
        Animal FindAnimal(User us);

        void RestoreInfo();
        string FindImages();
        void AddAnAnimal(Animal animal);
        string GetAPath(string species);
        string GetImageHelper(Animal an);



    }
}
