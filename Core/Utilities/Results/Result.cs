using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success) // this bu sınıfı gösterir. Yani bu kullanım şunu ifade eder. 
                                                      // Result'ın contructor'una (tek parametreli olan) success'i yolla. 
                                                      // Buraya iki parametre gönderdiğimizde otomatikman aşağıdaki ctor da çalışır.
        {
            Message = message;
        }
         
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }  // getter'lar readonly'dir. Ve readonly'ler constructor'da set edilebilir.

        public string Message { get; }  // getter'lar set edilemez denilir fakat constructor içinde set edilebilirler.
    }
}
