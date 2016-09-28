using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Hand
    {
        public List<Card> handCards { set; get; }
        public int total { set; get; }

        public Hand()
        {

        }
        public int CheckHand()
        {
            int handTotal = 0;
                for (int i = 0; i < handCards.Count; i++)
                {

                    handTotal += handCards[i].value;

                    if (handTotal > 21)
                    {
                        for (int j = 0; j < handCards.Count; j++)
                        {
                            if(handCards[j].value == 11)
                            {
                                handCards[j].value = 1;
                                handTotal += handCards[j].value - 11;
                                break;
                            }
                        }
                    }
                }
            this.total = handTotal;
            return total;
        }
        public int getNumberOfCards()
        {
            return handCards.Count;
        }
    }
}
