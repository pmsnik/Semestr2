using System;
using Bank;

namespace Transactions
{
    public class WithdrawalTransaction : Transaction
    {
        IWithdrawalInterface ui;
        Account account;

        public WithdrawalTransaction(IWithdrawalInterface ui, Account account)
        {
            this.ui = ui;
            this.account = account;
        }
        
        public override void Execute()
        {
            var amount = ui.RequestWithdrawalAmount();
            
            if (amount > account.Funds)
                ui.InformInsufficientFunds();
            else
            {
                account.Funds -= amount;
                ui.GiveOutCash(amount);
            }
        }
    }
}
