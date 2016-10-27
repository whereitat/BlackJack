using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Card
    {
        private int value;
        private string cardId;
        private string suit;

        public Card()
        {

        }
        public void setValue(int v)
        {
            this.value = v;
        }
        public int getValue()
        {
            return this.value;
        }
        public void setCardId(string id)
        {
            this.cardId = id;
        }
        public string getCardId()
        {
            return this.cardId;
        }
        public void SetSuit(string s)
        {
            this.suit = s;
        }
        public string getSuit()
        {
            return this.suit;
        }
    }
}
