using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface IWithdrawalInterface
    {
        double RequestWithdrawalAmount();//Сумма вывода
        void InformInsufficientFunds();//Сообщить что денег мало
        void GiveOutCash(double amount);//Выдать кэш
    }
}
