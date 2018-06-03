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
        List<Person> People { get;  }
        List<Animal> Animals { get;  }
        List<Species> Species { get;  }
    }
}
