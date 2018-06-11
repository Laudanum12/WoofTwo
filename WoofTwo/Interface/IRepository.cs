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
        void AddUser(string name, string email, string password, string city, DateTime dateTime, int level);
        User UserInStorage(string name, string password);
        void RestoreInfo();
        string FindImages();
        Species FindSpecies(string name);
        void AddAnAnimal(Animal animal);



    }
}
