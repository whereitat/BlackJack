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
        public void SetAname(string name)
        {
            this.aname = name;
        }
        public string GetAname()
        {
            return this.aname;
        }
        public void SetAstatus(string status)
        {
            this.astatus = status;
        }
        public string GetAstatus()
        {
            return this.astatus;
        }
        public void SetBalance(double amount)
        {
            this.balance = amount;
        }
        public double GetBalance()
        {
            return this.balance;
        }
        public void SetPassword(string pw)
        {
            this.password = pw;
        }
        public string GetPassword()
        {
            return this.password;
        }
    }
}
