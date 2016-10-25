﻿using System;
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
        public List<Card> handCards { set; get; }
        public int total { set; get; }

        public Hand()
        {
            handCards = new List<Card>();
            total = 0;
        }
        public void AddCard(Deck deck)
        {
            if (deck.cards.Count <= 1) //Om det bara finns 1 eller mindre kort kvar -> skapa nytt deck.
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
        public void RemoveCard()
        {
            handCards.RemoveAt(handCards.Count-1);
            total = CheckHand();
        }
        public void clearHand()
        {
            handCards.Clear();
            total = 0;
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
                        if (handCards[j].value == 11)
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
        public Hand CreateSplit(Hand h)
        {
            try
            {
                if (h.handCards[0].value == h.handCards[1].value && h.handCards.Count == 2) //Måste vara 2 kort med samma värde.
                {
                    Hand splitHand = new Hand();
                    var cardToMove = h.handCards[1];
                    splitHand.handCards.Add(cardToMove);
                    splitHand.total = cardToMove.value;
                    return splitHand;
                }
                else
                {
                    Console.WriteLine("Sorry, cant split.");
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
