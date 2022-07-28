using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
//    public class InMemoryCarDal : ICarDal
//    {
//       List<Car> _cars;

//        public InMemoryCarDal()
//        {
//            _cars = new List<Car>()
//            {
//                new Car {CarID=1,BrandID=1,ColorID=1,DailyPrice=450,ModelYear=2017,Description="Honda Civic"},
//                new Car { CarID = 2, BrandID = 2, ColorID = 2, DailyPrice = 850, ModelYear = 2010, Description = "Porsche" },
//                new Car { CarID = 3, BrandID = 3, ColorID = 3, DailyPrice = 350, ModelYear = 2016, Description = "Passat" },
//                new Car {CarID=4,BrandID=4,ColorID=4,DailyPrice=220,ModelYear=2011,Description="Hyundai"},
//                new Car { CarID = 5, BrandID = 5, ColorID = 5, DailyPrice = 1000, ModelYear = 2021, Description = "BMW" },
//            };
//        }

//        public void Add(Car car)
//        {
//            _cars.Add(car);
//        }

//        public void Delete(Car car)
//        {
//            Car CarToDelete = _cars.SingleOrDefault(p => p.CarID == car.CarID);
//            _cars.Remove(CarToDelete);
//        }

//        public List<Car> GetAll()
//        {
//            return _cars;
//        }

//        public List<Car> GetById(int CarID)
//        {
//            return _cars.Where(p => p.CarID == CarID).ToList();
//        }

//        public void Update(Car car)
//        {
//            Car CarToUpdate = _cars.SingleOrDefault(p => p.CarID == car.CarID);
//            CarToUpdate.CarID = car.CarID;
//            CarToUpdate.DailyPrice = car.DailyPrice;
//            CarToUpdate.BrandID = car.BrandID;
//            CarToUpdate.ColorID = car.ColorID;
//            CarToUpdate.Description = car.Description;
//        }
//    }
}
