using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Account
    {
        private string aname;
        private string astatus;
        private double balance;
        private string password;

        public Account ()
        {

        }
        public void setAname(string name)
        {
            this.aname = name;
        }
        public string getAname()
        {
            return this.aname;
        }
        public void setAstatus(string status)
        {
            this.astatus = status;
        }
        public string getAstatus()
        {
            return this.astatus;
        }
        public void setBalance(double amount)
        {
            this.balance = amount;
        }
        public double getBalance()
        {
            return this.balance;
        }
        public void setPassword(string pw)
        {
            this.password = pw;
        }
        public string getPassword()
        {
            return this.password;
        }
    }
}
