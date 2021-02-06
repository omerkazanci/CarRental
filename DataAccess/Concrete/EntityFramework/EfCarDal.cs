using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            // Rerefans tiplerin bellekte(heap) bir referans ile tutulduğunu biliyoruz. Bu heap'teki referansın bellekte(stack) bir değer karşılığı
            // kalmayınca yani referansı tutan bir değer kalmadığında bir süre sonra .Net'in Garbage Collector dediğimiz çöp toplayıcı
            // yapısı gelir ve bellekten bu referansı siler. Ancak bu silme işlemi belirli periyotlarda olur. 
            // Burada kullanacağımız Context nesnesi bellekte fazla yer işgal eder ve kullanıp hemen silmek birçok açıdan yaralıdır. Aşağıda
            // kullandığımız using yapısı içerisine yazılan nesneleri using bitince hemen çöp toplayıcısını çağırıp nesneleri bellekten atmaya yarar.
            // Yani kısaca belleği hızlıca temizleme.
            // IDisposable patter implementation of c#
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity);  // entity'i veri kaynağından bir nesne ile eşleştir demek. Ama burada bir nesne
                //  ile eşleşmez. Çünkü aşağıda ekleme yapacağız. Eşleşme olmayacak ekleme yapacağız.
                // Ayrıca burada new'lenip gelen nesnenin referansını yakalamaya çalışıyoruz.
                //// Özetle yapılan şu. entity nesnemin referansını yakalıyorum ve veri kaynağı ile nesnemi ilişkilendiriyorum.                 
                //// Sonrasında EntityState ile ne yapmak istediğime karar vereceğim.

                addedEntity.State = EntityState.Added;
                context.SaveChanges();  // Değişiklikleri kaydet.
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList() 
                    : context.Set<Car>().Where(filter).ToList();
                // arka planda SELECT * FROM CARS döndürür. Ve sonrasında onu listeye çavirdik.
                // SELECT * FROM CARS WHERE FILTER(burada gönderdiğim filtre ne ise)
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Car>().First(filter);

                // context.Set<Car>()  : Bu aslında ürünler tablom. Burası tabloyu liste olarak dönüyor ve IEnumerable nesnesi oluyor. InMemory'de
                // çalışırken List oluşturup orada Linq kullanarak işlemler yapmıştım. Burada da yine Lİnq kullandım çünkü tablo liste olarak geldi.
            }
        }

    }
}
