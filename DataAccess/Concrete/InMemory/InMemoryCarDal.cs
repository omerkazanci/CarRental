using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDal()
        {
            _brands = new List<Brand>
            {
                new Brand{Id = 1, Name = "Citroen"},
                new Brand{Id = 2, Name = "Renault"},
                new Brand{Id = 3, Name = "Peugeot"},
                new Brand{Id = 4, Name = "Hyundai"},
                new Brand{Id = 5, Name = "Fiat"},
                new Brand{Id = 6, Name = "Mitsubishi"},
                new Brand{Id = 7, Name = "BMW"},
                new Brand{Id = 8, Name = "Mercedes Benz"},
                new Brand{Id = 9, Name = "Scoda"},
                new Brand{Id = 10, Name = "Alfa Romeo"}
            };

            _colors = new List<Color>
            {
                new Color{Id = 1, Name = "White"},
                new Color{Id = 2, Name = "Black"},
                new Color{Id = 3, Name = "Red"},
                new Color{Id = 4, Name = "Purple"},
                new Color{Id = 5, Name = "Orange"},
                new Color{Id = 6, Name = "Brown"},
                new Color{Id = 7, Name = "Green"}
            };

            _cars = new List<Car>()
            {
                new Car {Id = 1, BrandId = 4, ColorId = 3, ModelYear = 2015, DailyPrice = 290, Description = "Az yakar çok kaçar"},
                new Car {Id = 2, BrandId = 8, ColorId = 7, ModelYear = 2019, DailyPrice = 350, Description = "Az yakar çok kaçar"},
                new Car {Id = 3, BrandId = 1, ColorId = 5, ModelYear = 2021, DailyPrice = 420, Description = "Az yakar çok kaçar"},
                new Car {Id = 4, BrandId = 3, ColorId = 4, ModelYear = 2017, DailyPrice = 300, Description = "Az yakar çok kaçar"},
                new Car {Id = 5, BrandId = 7, ColorId = 4, ModelYear = 2015, DailyPrice = 250, Description = "Az yakar çok kaçar"},
                new Car {Id = 6, BrandId = 7, ColorId = 7, ModelYear = 2020, DailyPrice = 400, Description = "Az yakar çok kaçar"},
                new Car {Id = 7, BrandId = 5, ColorId = 2, ModelYear = 2018, DailyPrice = 330, Description = "Az yakar çok kaçar"},
                new Car {Id = 8, BrandId = 9, ColorId = 6, ModelYear = 2019, DailyPrice = 370, Description = "Az yakar çok kaçar"},
                new Car {Id = 9, BrandId = 10, ColorId = 1, ModelYear = 2016, DailyPrice = 280, Description = "Az yakar çok kaçar"},
                new Car {Id = 10, BrandId = 2, ColorId = 3, ModelYear = 2018, DailyPrice = 340, Description = "Az yakar çok kaçar"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Yeni araba eklendi : {0}", car.Description);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.First(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("Araba silme işlemi tamamlandı : {0}", carToDelete.Description);
        }

        public void Update(Car carOld, Car carNew) // carOld : güncellenmesini istediğim nesne.    carNew : carOld nesnesinin güncellemek istediğim bilgileri
        {
            Car carOldFind = _cars.First(c => c.Id == carOld.Id);
            carOldFind.BrandId = carNew.BrandId;
            carOldFind.ColorId = carNew.ColorId;
            carOldFind.ModelYear = carNew.ModelYear;
            carOldFind.DailyPrice = carNew.DailyPrice;
            carOldFind.Description = carNew.Description;
            Console.WriteLine("Araba bilgileri güncellendi : {0}", carOldFind.Description);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int Id)
        {
            Car carFilterById = _cars.First(c => c.Id == Id);
            return carFilterById;
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
