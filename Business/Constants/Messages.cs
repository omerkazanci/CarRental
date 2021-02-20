using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages  // static verdiğimizde new'lemeyiz. direk çağırır kullanırız.
    {
        public static string CarAdded = "Araba eklendi"; // metodları kullanabilmek için static olmalı.
        public static string CarDeleted = "Araba silindi";  // bu bir değişkendir fakat PascalCase yazdım. Nedeni public olması
        public static string CarUpdated = "Araba güncellendi";  // eğer private bir değişken olsa camelCase yazardım.
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarListed = "Arabalar listelendi";

        public static string InValid = "İşlem yapılamadı";
        public static string Valid = "İşlem tamamlandı";
    }
}
