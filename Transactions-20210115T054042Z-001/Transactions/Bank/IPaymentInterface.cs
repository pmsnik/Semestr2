using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface IPaymentInterface
    {
        void InformInsufficientFunds();//Сообщить что денег мало
        double RequestPaymentAmount();//Сумма перевода
        Service RequestService();//Сервис, на который переводим деньги
    }
}
