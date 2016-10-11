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
        public static Deck CreateDeck() //static??
        {
            Deck d = DAL.DBAccess.CreateDeck();
            return d;
        }
    }
}
