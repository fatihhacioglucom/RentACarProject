using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Console.WriteLine("Id'ye Göre Getirme------------------");
            //foreach (var car in carManager.GetById())
            //{
            //    Console.WriteLine(car.Description);
            //}

            Console.WriteLine("Listeleme------------------");
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }

            Console.WriteLine("Ekleme------------------");
            carManager.Add(new Car { CarId = 5, BrandId = 1, ColorId = 1, ModelYear = "2021", DailyPrice = 7250, Description = "Fiat Doblo" });

            Console.WriteLine("Güncelleme------------------");
            carManager.Update(new Car { CarId = 2, BrandId = 2, ColorId = 2, ModelYear = "2010", DailyPrice = 5750, Description = "Peugeout 301" });

            Console.WriteLine("Silme------------------");
            carManager.Delete(new Car { CarId = 4, BrandId = 3, ColorId = 1, ModelYear = "2018", DailyPrice = 8250, Description = "Audi A3" });
        }
    }
}
