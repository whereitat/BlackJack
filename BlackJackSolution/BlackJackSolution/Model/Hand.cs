using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackSolution.Model;
using BlackJackSolution.DAL;

namespace BlackJackSolution.Model
{
    public class Hand
    {
        //private Deck deck; //alltid null......
        public List<Card> handCards { set; get; }
        public int total { set; get; }

        public Hand()
        {
            handCards = new List<Card>();
            total = 0;
        }
        public void AddCard(Deck deck)
        {
            if(deck.cards.Count <= 1) //Om det bara finns 1 eller mindre kort kvar -> skapa nytt deck.
            {
                DBAccess.CreateDeck();
            }

            if (total < 21) //Om totalen är mindre än 21 lägg till nytt kort och kolla efter ess.
            {               //Om total är 21 ska det inte kunna gå att lägga till kort
                var cardToAdd = deck.cards[0];
                handCards.Add(cardToAdd);
                deck.cards.RemoveAt(0);
                total = CheckHand();
            }
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
