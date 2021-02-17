using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
    // Yukarıda ReturnDate'i ? ile nullable olarak tanimladık. Bunun nedeni veritabanında ReturnDate'i default olarak null 
    // tanımladığımızdan c# bunu algılayamaz ve hata fırlatır. Çünkü c#'ta ön tanimli olarak DateTime veri tipi null deger alamaz.
    // ? ile beraber yukarıda null değer alabileceği iznini vermiş olduk.   
}
