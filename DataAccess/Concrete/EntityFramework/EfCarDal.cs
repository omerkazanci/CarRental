using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             select new CarDetailDto
                             {
                                 CarName = "Otomobil",
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList(); // Niye ToList ? Dönen sonuç IQueryable dediğimiz bir döngü türü. Onu listeye çevirdik.
            }
        }
    }
}
