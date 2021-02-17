using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //DtoTest();


            AddUser();

            AddCustomer();

            RentACar();
            // Şuan için işlemler tam doğru ilerlemiyor. Çünkü kiralama kısmında CustomerId manüel veriyoruz ve olmayan bir CustomerId versek bile 
            // sistem çalışır. Fakar Manager dosyalarında temel birkaç kontrolü gerçekleştirdim ve ilerleyen dönemde Angular ile bir web arayüz
            // oluşturduğumuzda işlemlerimiz daha kolay olacak çünkü başta arayüzde kısıtlamalar getirip bahsettiğim hataların önüne geçeceğiz.
            // Şuan için hala sistemi simüle ediyoruz ve eksikleri çok.
        }

        private static void RentACar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental { CarId = 5, CustomerId = 1, RentalDate = new DateTime(2021 / 02 / 18), ReturnDate = new DateTime(2021 / 03 / 01) });
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Apple" });
            customerManager.Add(new Customer { UserId = 3, CompanyName = "Samsung" });
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "Ömer", LastName = "Kazancı", EMail = "omer@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Engin", LastName = "Demiroğ", EMail = "engin@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Kerem", LastName = "Varış", EMail = "kerem@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Murat", LastName = "Kurtboğan", EMail = "murat@gmail.com", Password = "123456" });
            userManager.Add(new User { FirstName = "Esra", LastName = "Sancak", EMail = "esra@gmail.com", Password = "123456" });
        }

        private static void DtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            foreach (var carDetail in result.Data)  // artık Data'mız var onu düzenledik.
            {
                Console.WriteLine(
                    "CarName : {0} -- BrandName : {1} -- ColorName : {2} -- DailyPrice : {3}",
                    carDetail.CarName, carDetail.BrandName, carDetail.ColorName, carDetail.DailyPrice
                    );
            }
        }
    }
}
