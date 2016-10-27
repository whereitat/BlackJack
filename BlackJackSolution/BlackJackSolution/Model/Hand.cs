using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackSolution.Model;
using BlackJackSolution.DAL;
using BlackJackSolution.Control;

namespace BlackJackSolution.Model
{
    public class Hand
    {
        private int total;
        public List<Card> handCards { set; get; }

        public Hand()
        {
            handCards = new List<Card>();
            total = 0;
        }
        public void setTotal(int amount)
        {
            this.total = amount;
        }
        public int getTotal()
        {
            return this.total;
        }
        public void AddCard(Deck deck, Hand handen)
        {
            int handTot = 0;
            if (handen.getTotal() < 21) //Om totalen är mindre än 21 lägg till nytt kort och kolla efter ess.
            {               //Om total är 21 ska det inte kunna gå att lägga till kort
                Card cardToAdd = deck.cards[0];
                handen.handCards.Add(cardToAdd);
                deck.cards.RemoveAt(0);
                handen.setTotal(0);
                
                for (int i = 0; i < handen.handCards.Count; i++)
                {
                    if (handen.handCards[i].getValue() > 11)
                    {
                        handTot += 10;
                    }
                    else
                    {
                        handTot += handen.handCards[i].getValue();
                    }
                    if (handTot > 21)
                    {
                        for (int j = 0; j < handen.handCards.Count; j++)
                        {
                            if (handen.handCards[j].getValue() == 11)
                            {
                                handen.handCards[j].setValue(1);
                                handTot += handCards[j].getValue() - 11;
                                break;
                            }
                        }
                    }
                }
            }
            handen.setTotal(handTot);
        }
        public void clearHand()
        {
            this.handCards.Clear();
            this.total = 0;
        }
        public void CheckHand(Hand handen)
        {
            handen.setTotal(0);
            int handTot = 0;
            for(int i = 0; i < handen.handCards.Count; i++)
            {
                if(handen.handCards[i].getValue() > 11)
                {
                    handTot += 10;
                }
                else
                {
                    handTot += handen.handCards[i].getValue();
                }
                if (handen.getTotal() > 21)
                {
                    Console.WriteLine("Johan");
                    for (int j = 0; j < handen.handCards.Count; j++)
                    {
                        if (handen.handCards[j].getValue() == 11)
                        {
                            handen.handCards[j].setValue(1);
                            handTot += handCards[j].getValue() - 11;
                            break;
                        }
                    }
                }
                handen.setTotal(handTot);
            }
        }
        public int CheckHand2()
        {
            int handTotal = 0;
            for (int i = 0; i < handCards.Count; i++)
            {
                if (handCards[i].getValue() > 11)
                {
                    handTotal += 10;
                }
                else
                {
                    handTotal += handCards[i].getValue();
                }
                if (handTotal > 21)
                {
                    Console.WriteLine("Johan");
                    for (int j = 0; j < handCards.Count; j++)
                    {
                        if (handCards[j].getValue() == 11)
                        {
                            handCards[j].setValue(1);
                            handTotal += handCards[j].getValue() - 11;
                            break;
                        }
                    }
                }
            }
            this.total = handTotal;
            return total;
        }
    }
}
