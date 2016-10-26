using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Account
    {
        private String aname;
        private String astatus;
        private Double balance;
        private String password;
        //public string aname { set; get; }
        //public string astatus { set; get; }
        //public double balance { set; get; }
        //public string password { set; get; }

        public Account ()
        {

        }
        public void setAname(String name)
        {
            this.aname = name;
        }
        public String getAname()
        {
            return this.aname;
        }
        public void setAstatus(String status)
        {
            this.astatus = status;
        }
        public String getAstatus()
        {
            return this.astatus;
        }
        public void setBalance(Double amount)
        {
            this.balance = amount;
        }
        public Double getBalance()
        {
            return this.balance;
        }
        public void setPassword(String pw)
        {
            this.password = pw;
        }
        public String getPassword()
        {
            return this.password;
        }
    }
}
