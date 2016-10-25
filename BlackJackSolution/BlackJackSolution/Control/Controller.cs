using BlackJackSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackSolution.DAL;


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
        public bool Login(string accname, string pwd)
        {
            Account a = db.GetAccount(accname);
            if (a == null)
            {
                return false;
            }
            if (a.aname.Equals(accname) && a.password.Equals(pwd))
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }
        public bool CreateAccount(string accname, string )
    }
}
