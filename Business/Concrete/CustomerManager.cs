using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        // Bütün metodlarda kontroller olmak zorunda fakat şuan için sadece Add metodunda kullandım

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            var result = _customerDal.GetAll(c => c.UserId == entity.UserId);
            if (result.Count == 0)
            {
                _customerDal.Add(entity);
                return new SuccessResult(Messages.Valid);
            }
            return new ErrorResult(Messages.InValid);
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {            
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetById(c => c.Id == id));
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
