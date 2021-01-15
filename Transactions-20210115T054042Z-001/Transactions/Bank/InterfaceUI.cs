using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public interface InterfaceUI
    {
        double RequestDepositAmount(); //Сумма пополнения
        double RequestWithdrawalAmount();//Сумма вывода
        double RequestTransferAmount();//Сумма перевода
        void InformInsufficientFunds();//Сообщить что денег мало
        void GiveOutCash(double amount);//Выдать кэш
    }
}
