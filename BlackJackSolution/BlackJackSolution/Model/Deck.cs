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
        public void updateDeck(Deck d)
        {
            if(d.cards.Count < 1)
            {
                d = Control.Controller.CreateDeck();
            }
        }
    }
}
