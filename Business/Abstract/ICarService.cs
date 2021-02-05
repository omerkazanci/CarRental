using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(int Id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car carOld, Car carNew);
        void Delete(Car car);
    }
}
