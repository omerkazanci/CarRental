using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        // Burada Müşteri ekleyeceğiz. Fakat müşteriler Kullanıcılar arasında olmalı. Çünkü Kullanıcılar sistemde kaydı olan, Müşteriler ise
        // araç kiralamış olan kişilerdir. Bu bağlamda önce Kullanıcı kontrolünü sonrasında ise Müşteri kontrolünü yaparak ekleme yapacağız.
        public IResult Add(Customer entity)
        {
            var result = _customerDal.GetAll(c => c.UserId == entity.UserId);
            if (result.Count == 0)
            {
                _customerDal.Add(entity);
                Console.WriteLine("Kayıt işlemi başarılı");
                return new SuccessResult();
            }
            Console.WriteLine("Müşteri zaten kayıtlı");
            return new ErrorResult();
        }

        public IResult Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Customer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
