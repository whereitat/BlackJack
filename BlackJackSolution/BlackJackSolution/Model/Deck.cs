using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Deck
    {
        public List<Card> cards { set; get; }
        public Deck()
        {
            cards = new List<Card>();
        }
    }
}
