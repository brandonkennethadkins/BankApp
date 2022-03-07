using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BankApp
{
   public class Account
    {
        private string owner;
        private int id;
        private decimal balance;
        private string type;


        public Account(string owner, int id,decimal balance, string type)
        {
            this.owner= owner;
            this.id = id;
            this.balance= balance;
            //could have created inherited classes for each account type, but this was a faster method. 
            this.type= type;
            
        }

        public void Deposit(decimal amount)
        {
           this.balance += amount;
     
        }

        public virtual void Withdrawal(decimal amount, bool isTransferII=false)
        {
            if (type == "Investment-Individual" && amount >500.0m &&isTransferII==false)
            {
                //do nothing
            }
            else
            {
                balance -= amount;
            }
        }

        public decimal Balance
        {
            get { return balance; }
        }

        public int ID
        {
            get { return id; }
        }


        public string Type
        {
            get { return type; }
        }

        public String Owner
        {
            get { return owner; }
        }
    }



}
