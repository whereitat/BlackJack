using BlackJackSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Control
{
    public class Controller
    {
        public Deck CreateDeck() //static??
        {
            Deck d = DAL.DBAccess.CreateDeck();
            return d;
        }

            public bool Login(string aname, string pwd)
        {
            return true;
        }
        public void AddCard(Deck d, Hand h)
        {
            h.AddCard(d);
        }
    }
}
