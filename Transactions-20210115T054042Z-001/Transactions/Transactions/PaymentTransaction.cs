using System;
using Bank;

namespace Transactions
{
    public class PaymentTransaction : Transaction
    {
        IPaymentInterface ui;
        Account user;

        public PaymentTransaction(IPaymentInterface ui, Account user)
        {
            this.ui = ui;
            this.user = user;
        }

        public override void Execute()
        {
            var amount = ui.RequestPaymentAmount();
            var service = ui.RequestService();

            if (amount > user.Funds)
                ui.InformInsufficientFunds();
            else
            {
                user.Funds -= amount;
                service.Funds += amount;
            }
        }
    }
}
