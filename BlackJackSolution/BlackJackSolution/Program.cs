using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJackSolution.Model;

namespace BlackJackSolution
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /**
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());
            **/

            //------------------------------TEST------------------------------------ 
            Deck deckTest = DAL.DBAccess.CreateDeck();
            for(int i = 0; i < deckTest.cards.Count; i++)
            {
                Console.WriteLine(deckTest.cards[i].value);
            }
            Console.WriteLine(" Antal kort: " + deckTest.cards.Count);
            Hand dealerhand = new Hand();
            Hand accountHand = new Hand();
            dealerhand.AddCard(deckTest);
            dealerhand.AddCard(deckTest);
            accountHand.AddCard(deckTest);
            accountHand.AddCard(deckTest);

            Console.WriteLine(dealerhand.total);
            Console.WriteLine(accountHand.total);
        }
    }
}
