using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {
        }

        // aşağıdaki iki alternatif pek kullanılmaz.
        public ErrorDataResult(string message) : base(default, false, message)  // default data'ya karşılık gelir.
        {
        }

        public ErrorDataResult() : base(default, false)
        {
        }

    }
}
