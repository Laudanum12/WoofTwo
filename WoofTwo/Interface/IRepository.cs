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

        void RestoreInfo();

        bool CanAddUser(string name);
        User UserInStorage(string name, string password);

        Animal AddIncompleteAnimal(string name);
        void AddAnAnimal(Animal animal);
        void AddUSer(string _city, DateTime _dateOfRegistration, string _email, string _password, string _name);

        City FindCity(string city);
        Species FindSpecies(string name);
        Animal FindAnimal(User us);
        int FindFoodPoints(Species species);
        int FindSleepPoints(Species species);
        int FindPoopPoints(Species species);

        Task<DateTime> GetConvertedDateTimeBasedOnAddress(string cityName);

        string GetAPath(string species);
        string GetImageHelper(Animal an);

        void DecreaseNeeds();
        void IncreaseFoodValue(int points);
        void NeedsDecrease(object sender, EventArgs e);
        void Poop_Normalize(object sender, EventArgs e);
        void Sleep_Increase(object sender, EventArgs e);
        bool IsAnimalDead();
        void AnimalIsDead();


    }
}
