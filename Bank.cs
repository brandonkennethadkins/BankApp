using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BankApp
{
    class Bank
    {
       public String name;
       public int bankID;
       public List<Account> accounts;

        public Bank(string name, int bankID)
        {
            this.name = name;
            this.bankID = bankID;
            this.accounts = new List<Account>();

        }

        public void Deposit(decimal amount, int accountID)
        {
            if (amount > 0)
            {
                GetAccountById(accountID).Deposit(amount);
            }
        }

        public void Withdrawal(decimal amount, int accountID,bool isTransfer=false)
        {
            if (amount > 0)
            {
                GetAccountById(accountID).Withdrawal(amount);
            }
        }


        public void Transfer(decimal amount, int transferFromID, int transferToID)
        {
            if (amount > 0)
            {
                Account toWithdraw = GetAccountById(transferFromID);
                Account ToDeposit = GetAccountById(transferToID);
                if (toWithdraw.Owner.Equals(ToDeposit.Owner))
                {
                    toWithdraw.Withdrawal(amount, true);

                    ToDeposit.Deposit(amount);
                }
                else
                {
                    //throw new Exception("Owner Id's do not match");
                }
            }
        }

        public void AddAccount(string owner, int ownerID, decimal balance, string type)
        {
            accounts.Add(new Account(owner, ownerID, balance, type));
        }



        public String Name
        {
            get { return name; }
        }

        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public Account GetAccountById(int id)
        {
            Account temp = accounts.FirstOrDefault(account => account.ID == id);
            return temp;
        }

        public void AddAccount(Account newAccount)
        {
            accounts.Add(newAccount);
        }
    }
}
