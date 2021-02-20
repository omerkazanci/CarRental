using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        // Ekleme yapacağız fakat şu an manuel versek de parametreleri normalde bir arayüzden seçilecek bilgilere göre parametreler atanır.
        // Örneğin kullanıcı girişi yaptığınız bir sistem UserId vermenize gerek yok çünkü bu bilgiyi sistem otomatik olarak çeker. 
        // Müşteri olmak için eklemeyi de manuel yapmayız. Biz bir araç kiraladığımızda o an Customer sınıfına eklenmiş oluruz.
        // Sonrasında aşağıda bazı kontroller yapmak gerekir.
        // 1.Araç kiralanmış mı ? -- 2.Böyle bir kullanıcı var mı ? -- 3.Böyle bir araç var mı ? -- 4.Kiralama tarihi teslim tarihinden önce mi ?
        // 5.Müşteri oluşturulmuş mu ?
        // Bu maddeleri kontrol edeceğiz. Fakat şuan sistemimiz daha çok simüle etmeye yönelik olduğundan sadece Aracın kiralanmış olup
        // olmadığına bakalım ilerleyen dönemlerde bir web arayüz oluşturduğumuzda bu kısımlar refactor edilecek ve tüm kontroller yapılabilecek..               
        // Bütün metodlarda kontroller olmak zorunda fakat şuan için sadece Add metodunda kullandım

        public IResult Add(Rental entity)
        {
            var result = _rentalDal.GetAll(r => r.CarId == entity.CarId);
            if (result.Count == 0)
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Valid);
            }
            return new ErrorResult(Messages.InValid);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r => r.Id == id));
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }
    }
}
