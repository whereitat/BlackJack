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
        public void SetValue(int v)
        {
            this.value = v;
        }
        public int GetValue()
        {
            return this.value;
        }
        public void SetCardId(string id)
        {
            this.cardId = id;
        }
        public string GetCardId()
        {
            return this.cardId;
        }
        public void SetSuit(string s)
        {
            this.suit = s;
        }
        public string GetSuit()
        {
            return this.suit;
        }
    }
}
