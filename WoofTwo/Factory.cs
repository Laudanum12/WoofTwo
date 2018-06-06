using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoofTwo
{
    public class Factory
    {
        static Factory _instance;
        public static Factory Instance => _instance ?? (_instance = new Factory());

        private Factory() { }

        IRepository _repository;

        public IRepository GetStorage()
        {
            return _repository ?? (_repository = new Repository());
        }
    }
}
