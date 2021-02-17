using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context : Db tabloları ile proje class'larını bağlamak
    // Aşağıda RentACarContext yazmak onu bir context yapmaz. Bunun için EntityFramework içindeki DbContext sınıfından miras alırız.
    public class RentACarContext : DbContext
    {
        // Öncelikle veribanımızın nerede olduğunu söylememiz gerekir.
        // Aşağıdaki metod projemin hangi veritabanı ile ilişkili olduğunu belirteceğiz. Önce override yaptık. Çünkü virtual metod'dur.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);  // override eriyoruz ama base class'ı da kullanabilirim istersem.

            // @ : tıknak içindeki bütün ifadeler string ifadesidir. Özel anlamı olan karakterler burada işe yaramaz.
            // Trusted_Connection = true : Kullanıcı adı ve şifre olmadan kullanabiliyorum. Gerçek sistemlerde eğer güçlü bir domain
            // yönetimi varsa bu şekilde kullanırız fakat zayıf olduğu yerlerde kullanıcı adı ve şifre ile kullanıldığını görürüz. Ama
            // gerçek sistemlerde genellikle bir kullanıcı adı ve şifre ile bu durum ilerler.
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = RentACar; Trusted_Connection = true");
        }
        public DbSet<Car> Cars { get; set; }  // Bendeki Car nesnesini veritabanındaki Cars ile bağla.
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        // İlk konfigürasyon yukarıdaki gibi. Daha sonra profesyonelleştireceğiz.
    }
}
