﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }

        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(c => c.Id == id);
        }

    }
}