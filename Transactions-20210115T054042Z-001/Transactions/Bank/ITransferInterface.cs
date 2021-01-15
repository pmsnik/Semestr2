using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface ITransferInterface
    {
        double RequestTransferAmount();//Сумма перевода
        void InformInsufficientFunds();//Сообщить что денег мало
    }
}
