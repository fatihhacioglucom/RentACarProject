using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            //BrandId = 1 (Fiat), 2 (Peugeout), 3 (Audi), 4 (Renault)
            //ColorId = 1 (Beyaz),2 (Gri), 3 (Siyah)
            _cars = new List<Car> {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear="2010", DailyPrice=5250, CarName="Fiat Fiorino" },
                new Car{CarId=2, BrandId=2, ColorId=2, ModelYear="2010", DailyPrice=5750, CarName="Peugeout 301" },
                new Car{CarId=3, BrandId=2, ColorId=1, ModelYear="2011", DailyPrice=9500, CarName="Peugeout Boxer" },
                new Car{CarId=4, BrandId=3, ColorId=1, ModelYear="2018", DailyPrice=8250, CarName="Audi A3" },
                new Car{CarId=5, BrandId=4, ColorId=3, ModelYear="2019", DailyPrice=7500, CarName="Renault Megane" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByID(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.CarName = car.CarName;
        }
    }
}
