using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)  // Buradaki base işlemini neden yaptık ? Çünkü miras alınan sınıfın (Result)
                                                // constructor'ı parametre istiyor ve biz burada ve aşağıda her iki durum için de parametre yolladık.
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
