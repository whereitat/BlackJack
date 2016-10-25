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
        private String cardId;
        private String suit;
        //public int value { set; get; }
        //public string cardId { set; get; }
        //public String suit { set; get; }

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
        public void setCardId(String id)
        {
            this.cardId = id;
        }
        public String getCardId()
        {
            return this.cardId;
        }
        public void SetSuit(String s)
        {
            this.suit = s;
        }
        public String getSuit()
        {
            return this.suit;
        }
    }
}
