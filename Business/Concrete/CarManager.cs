using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        // Bu kısımda kafası karışan çok oluyor kendimden biliyorum. Neden bu şekilde injection yapıyoruz ? 
        // Aslında cevap çok basit. Interface'lerin referans tutucu özelliğinin olması. Şöyle ki;
        // Aşağıda yaptığımız işlemleri kendi belleğimizde oluşturduğumuz (InMemoryCarDal) içindeki List üzerinden yapıyoruz.
        // Ve biz ICarDal içinde metodlar tanımladık (Add, Delete, GetAll, GetById, Update) ve bu metodlar ICarDal interface'sini implemente eden
        // sınıflarda olmak zorunda. Şu an için InMemoryCarDal implemente ediyor ve içinde implemente ettiğim metodların hepsinin işlemlerini yaptım.
        // Fakat yarın Excel dosyasından verileri okumam gerekebilir ve bir IExcelCarDal sınıfı oluşturup ICarDal sınıfından implemente edebilirim.
        // Bu değişiklik için bütün kodlar değişecek mi şimdi ? Hayır. Aşağıdaki gibi bir kullanım bizi bu dertten kurtarır. CarManager'dan bir
        // instance(örnek) oluşturduğumda benden ICarDal türünde bir parametre isteyecek. ICarDal interface'si kendisinden implementasyon yapan
        // sınıfların referansını tutabildiğinden parametre olarak IExcelCarDal türünde gönderirsem ona göre işlem yapar, InMemoryCarDal
        // türünde gönderirsem ona göre. Yada başka başka veri okuma sınıflarım olabilir önemli değil. Yüzlerce olsa da mantığımız işlemeye devam eder.
        // Bu özgürlüğe sahip olmamız ve sürdürülebilir yazılım geliştirme üretebilmemiz için bu kullanım çok önemlidir.

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int Id)
        {
            return _carDal.GetById(Id);
        }

        public void Update(Car carOld, Car carNew)
        {
            _carDal.Update(carOld, carNew);
        }
    }
}
