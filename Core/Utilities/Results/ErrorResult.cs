using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)  // Buradaki base işlemini neden yaptık ? Çünkü miras alınan sınıfın (Result)
                                                                    // constructor'ı parametre istiyor ve biz burada ve aşağıda her iki durum için de parametre yolladık.
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}