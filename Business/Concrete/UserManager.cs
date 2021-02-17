﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        // Kullanıcı ekliyoruz fakat daha önce kayıt var mı ? Şuan sadece isim yönünden kontrol gerçekleştirdim. Normalde EMail unique(eşsiz)
        // olması gerekir ve onun üzerinden kontrol yapılır. Ve diğer tanımlanan kontroller üzerinden.
        public IResult Add(User entity)
        {
            var result = _userDal.GetAll(u => u.FirstName == entity.FirstName);
            if (result.Count == 0)
            {
                _userDal.Add(entity);
                Console.WriteLine("Kayıt işlemi başarılı");
                return new SuccessResult();
            }
            Console.WriteLine("Kullanıcı zaten kayıtlı");
            return new ErrorResult();
        }

        public IResult Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}