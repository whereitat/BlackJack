using BlackJackSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackSolution.DAL;
using System.Security.Cryptography;


namespace BlackJackSolution.Control
{
    public class Controller
    {
        DBAccess db = new DBAccess();
        public Deck CreateDeck() //static??
        {
            Deck d = DAL.DBAccess.CreateDeck();
            return d;            
        }
        public void AddCard(Deck d, Hand h)
        {
            h.AddCard(d);
        }

        //Behöver commit på nya procedures för test
        public bool Login(string accname, string pwd)
        {
            Account a = db.GetAccount(accname);
            if (a == null)
            {
                return false;
            }
            if (a.getAname().Equals(accname) && a.getPassword().Equals(pwd))
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }
        //Behöver commit på nya procedures för test
        public bool CreateAccount(string aname, string password)
        {
            return db.CreateAccount(aname, Crypt(password));
        }
        public string Crypt(string input)
        {
            SHA512 alg = SHA512.Create();
            return Convert.ToBase64String(alg.ComputeHash(Encoding.Unicode.GetBytes(input)));
        }
    }
}
