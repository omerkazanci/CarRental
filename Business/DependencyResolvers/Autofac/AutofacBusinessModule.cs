using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)  // Uygulama hayata geçtiğinde, ayağa kalktığında kısaca çalıştığında burası çalışacak.
        {
            // ICarService istenirse ona CarManager örneği ver. SingleInstance ile de tek bir instance üretir ve herkese onu verir.
            //  Yüz bin kullanıcılı bir istemde her kullanıcı için ayrı instance üretmez bir tane üretir ve herkesle paylaşır.
            //  Bellekteki aynı referans numarasını herkese verir. İçinde data tutmaz sadece operasyon çağırır. 
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            
            builder.RegisterType<BrandManager>().As<BrandManager>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

        }
    }
}
