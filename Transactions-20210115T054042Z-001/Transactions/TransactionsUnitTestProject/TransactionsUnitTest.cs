using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using Transactions;

namespace TransactionsUnitTestProject
{
    [TestClass]
    public class TransactionsUnitTest
    {
        [TestMethod]
        public void DepositTransactionTest()
        {
            var ui = new FakeBankUI { DepositAmount = 40 };
            var account = new Account();
            var transaction = new DepositTransaction(ui, account);

            Assert.AreEqual(0, account.Funds, 1e-3);

            transaction.Execute();

            Assert.AreEqual(40, account.Funds, 1e-3);

            ui.DepositAmount = 50;
            transaction.Execute();

            Assert.AreEqual(90, account.Funds, 1e-3);
        }

        [TestMethod]
        public void WithdrawalTransactionTest()
        {
            var ui = new FakeBankUI { WithdrawalAmount = 50 };
            var account = new Account { Funds = 80 };
            var transaction = new WithdrawalTransaction(ui, account);

            Assert.AreEqual(80, account.Funds, 1e-3);
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.AreEqual(30, account.Funds, 1e-3);
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.AreEqual(30, account.Funds, 1e-3);
            Assert.IsTrue(ui.IsInsuffisientFunds);
        }

        [TestMethod]
        public void TransferTransactionTest()
        {
            var ui = new FakeBankUI { TransferAmount = 50 };
            var source = new Account { Funds = 80 };
            var target = new Account();
            var transaction = new TransferTransaction(ui, source, target);

            Assert.AreEqual(80, source.Funds, 1e-3);
            Assert.AreEqual(0, target.Funds, 1e-3);
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.AreEqual(30, source.Funds, 1e-3);
            Assert.AreEqual(50, target.Funds, 1e-3);
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.AreEqual(30, source.Funds, 1e-3);
            Assert.AreEqual(50, target.Funds, 1e-3);
            Assert.IsTrue(ui.IsInsuffisientFunds);
        }

        [TestMethod]
        public void PaymentTransactionTest()
        {
            var ui = new FakeBankUI { Service = new Service(1) { Funds = 500 }, PaymentAmount = 600 };
            var user = new Account { Funds = 1000 };
            var transaction = new PaymentTransaction(ui, user);

            Assert.AreEqual(1000, user.Funds, 1e-3);
            Assert.AreEqual(500, ui.Service.Funds, 1e-3);
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.AreEqual(400, user.Funds, 1e-3);
            Assert.AreEqual(1100, ui.Service.Funds, 1e-3);
            Assert.IsFalse(ui.IsInsuffisientFunds);

            transaction.Execute();

            Assert.AreEqual(400, user.Funds, 1e-3);
            Assert.AreEqual(1100, ui.Service.Funds, 1e-3);
            Assert.IsTrue(ui.IsInsuffisientFunds);
        }
    }
}
