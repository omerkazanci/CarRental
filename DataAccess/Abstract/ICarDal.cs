using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        Car GetById(int Id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car carOld, Car carNew);  // carOld : güncellenmesini istediğim nesne.    carNew : carOld nesnesinin güncellemek istediğim bilgileri
        void Delete(Car car);
    }
}
