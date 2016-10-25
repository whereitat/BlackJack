using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Account
    {

        public string aname { set; get; }
        public string astatus { set; get; }
        public double balance { set; get; }
        public string password { set; get; }

        public Account ()
        {

        }

        public Account(string aname, string astatus, double balance, string password)
        {
            this.aname = aname;
            this.astatus = astatus;
            this.balance = balance;
            this.password = password;
        }
    }
}
