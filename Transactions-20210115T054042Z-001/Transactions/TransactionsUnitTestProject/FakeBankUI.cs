using System;
using Bank;
using Transactions;

namespace TransactionsUnitTestProject
{
    class FakeBankUI : IDepositInterface, IWithdrawalInterface, ITransferInterface, IPaymentInterface
    {
        public string CashGivenOut = "";
        public bool IsInsuffisientFunds = false;
        public double DepositAmount = 0;
        public double TransferAmount = 0;
        public double WithdrawalAmount = 0;
        public double PaymentAmount = 0;
        public Service Service;
        public void GiveOutCash(double amount)
        {
            CashGivenOut = $"Give out ${amount:F2}".Replace(',', '.');
        }

        public void InformInsufficientFunds()
        {
            IsInsuffisientFunds = true;
        }

        public double RequestDepositAmount()
        {
            return DepositAmount;
        }

        public double RequestTransferAmount()
        {
            return TransferAmount;
        }

        public double RequestWithdrawalAmount()
        {
            return WithdrawalAmount;
        }

        public double RequestPaymentAmount()
        {
            return PaymentAmount;
        }

        public Service RequestService()
        {
            return Service;
        }
    }
}
