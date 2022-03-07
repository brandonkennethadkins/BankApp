using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankApp
{
    [TestClass]
    public class BankTestSetup
    {
        private string bankName = "Test Bank";
        private int bankId = 1;

        private int accountId1 = 1;
        private decimal accountId1Balance = 1000.0m;
        private string accoutId1Owner = "Test Account1";
        private string accountId1Type = "Checking";

        private int accountId2 = 2;
        private decimal accountId2Balance = 1500.0m;
        private string accoutId2Owner = "Test Account2";
        private string accountId2Type = "Investment-Individual";

        private int accountId3 = 3;
        private decimal accountId3Balance = 2000.0m;
        private string accoutId3Owner = "Test Account3";
        private string accountId3Type = "Investment-Corporate";

        private int accountId4 = 4;
        private decimal accountId4Balance = 2000.0m;
        private string accountId4Type = "Investment-Corporate";
        BankApp.Bank TestBank;
        [TestInitialize]

        public void Test_Initialize()
        {
            TestBank = new BankApp.Bank(bankName, bankId);
            BankApp.Account Account1 = new BankApp.Account(accoutId1Owner, accountId1, accountId1Balance, accountId1Type);
            BankApp.Account Account2 = new BankApp.Account(accoutId2Owner, accountId2, accountId2Balance, accountId2Type);
            BankApp.Account Account3 = new BankApp.Account(accoutId3Owner, accountId3, accountId3Balance, accountId3Type);
            BankApp.Account Account4 = new BankApp.Account(accoutId2Owner, accountId4, accountId4Balance, accountId4Type);

            TestBank.AddAccount(Account1);
            TestBank.AddAccount(Account2);
            TestBank.AddAccount(Account3);
            TestBank.AddAccount(Account4);

        }
    



        [TestMethod]

        public void Test_Deposit()
        {
            TestBank.Deposit(400.0m, 1);
            Assert.AreEqual(400.0m + 1000.0m, TestBank.GetAccountById(1).Balance);
            TestBank.Deposit(400.0m, 2);
            Assert.AreNotEqual(400.0m + 1000.0m, TestBank.GetAccountById(2).Balance);
        }
        [TestMethod]
        public void Test_Withdrawal()

        {
            TestBank.Withdrawal(400.0m, 1);
            Assert.AreEqual(1000.0m-400.0m , TestBank.GetAccountById(1).Balance);
            TestBank.Withdrawal(500.1m, 2);
            Assert.AreEqual(1500.0m, TestBank.GetAccountById(2).Balance);
            TestBank.Withdrawal(400.0m, 3);
            Assert.AreNotEqual(1000.0m-400.0m, TestBank.GetAccountById(3).Balance);
        }
        [TestMethod]
        public void Test_Transfer()
        {
            TestBank.Transfer(400.0m, 2,4);
            Assert.AreEqual(1500.0m - 400.0m, TestBank.GetAccountById(2).Balance);
            Assert.AreEqual(2000.0m + 400.0m, TestBank.GetAccountById(4).Balance);

            TestBank.Transfer(100.0m, 1, 3);
            Assert.AreNotEqual(1000.0m - 100.0m, TestBank.GetAccountById(1).Balance);
            Assert.AreNotEqual(2000.0m + 400.0m, TestBank.GetAccountById(3).Balance);
        }
    }
}
