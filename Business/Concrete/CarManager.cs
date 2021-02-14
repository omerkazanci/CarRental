using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                // magic string
                return new ErrorResult(Messages.CarNameInvalid);  // buraya string yazmak sakıncalırdır. Nerde ne yazdığını aklında tutman 
                // lazımdır veya heryerde aynı şeyi yazsan bile bir değişiklik yapmak istediğinde sıkıntı doğurur.
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);  // Burada Result nasıl dönebiliyorum ? Çünkü IResult, Result'ın referansını tutabiliyor.
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);  
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }

        // Bu metod bir liste dönüyor. Başka birşey nasıl döndürecek beraberinde ? Aynı anda birden fazla şey döndürmek istersek eğer
        // Encapsulation kullanacağız. Generic yapıları kullanarak.
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }
                      

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
