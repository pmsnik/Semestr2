using System;
using Bank;

namespace Transactions
{
    public class DepositTransaction : Transaction
    {
        IDepositInterface ui;
        Account account;

        public DepositTransaction(IDepositInterface ui, Account account)
        {
            this.ui = ui;
            this.account = account;
        }
        public override void Execute()
        {
            account.Funds += ui.RequestDepositAmount();
        }
    }
}
