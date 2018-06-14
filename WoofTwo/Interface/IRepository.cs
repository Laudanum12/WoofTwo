using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoofTwo.Additions;
using WoofTwo.Classes;

namespace WoofTwo
{
    public interface IRepository
    {
        List<User> Users { get; }
        List<Animal> Animals { get; }
        List<Species> Species { get; }
        List<City> Cities { get; }

        User CurrentUser { get; set; }
        bool CanAddUser(string name);
        void AddUSer(string _city, DateTime _dateOfRegistration, string _email, string _password, string _name);
        User UserInStorage(string name, string password);
        Species FindSpecies(string name);
        Animal FindAnimal(User us);

        Animal AddIncompleteAnimal(string name);
        void DecreaseNeeds();

        void RestoreInfo();
        //string FindImages();
        void AddAnAnimal(Animal animal);
        string GetAPath(string species);
        string GetImageHelper(Animal an);

        void IncreaseFoodValue(int points);
        void Poop_Decrease(object sender, EventArgs e);
        void Sleep_Increase(object sender, EventArgs e);
        bool AnimalIsDead();


    }
}
