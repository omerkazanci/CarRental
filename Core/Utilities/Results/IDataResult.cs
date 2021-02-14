using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult  // işlem sonucu ve mesaj IResult implementasyonundan gelecek.
    {
        T Data { get; }  // Ayrıca T türünde birde data listem olacak.
    }
}
