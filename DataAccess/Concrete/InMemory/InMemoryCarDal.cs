using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal() 
        {
            _cars = new List<Car> {
                new Car { Id = 1,BrandId=1,ColorId=1,DailyPrice=900,Description="Mazda 323",ModelYear=1994},
                new Car { Id = 2,BrandId=2,ColorId=2,DailyPrice=200,Description="Nissan Qasqhai",ModelYear=2023},
                new Car { Id = 3,BrandId=3,ColorId=3,DailyPrice=300,Description="Citroen C3",ModelYear=2008},
                new Car { Id = 4,BrandId=4,ColorId=3,DailyPrice=1500,Description="Mercedes S400",ModelYear=2019},

            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete=_cars.SingleOrDefault(p=> p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(p=>p.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate=_cars.FirstOrDefault(p=>p.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            
        }
    }
}
