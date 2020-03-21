using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Proxy
{
    class CarInfo : IGetCarInfo
    {
        public List<string> CarsInfo(IAccess person)
        {
            if (person.Access.Equals("inspector", StringComparison.CurrentCultureIgnoreCase))
                return _cars.GetAll().Select(x => x.ToString()).ToList();
            else if (person.Access.Equals("owner", StringComparison.CurrentCultureIgnoreCase))
                return _cars.GetAll().Where(x => x.Owner.Name == person.Name).Select(x => x.ToString()).ToList();
            else return null;
        }
        private Repository<Car> _cars;

        public CarInfo(Repository<Car> cars) => _cars = cars;

    }
    class CarInfoProxy : IGetCarInfo
    {
        readonly CarInfo Info;

        public CarInfoProxy(Repository<Car> cars)
        {
            Info = new CarInfo(cars);
        }

        public List<string> CarsInfo(IAccess person)
        {
            return Info.CarsInfo(person);
        }
    }
}
