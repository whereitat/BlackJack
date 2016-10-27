using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlackJackSolution.Model;
using BlackJackSolution.DAL;

namespace BlackJackSolution
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //private static DBAccess db = new DBAccess();
       
            

       

        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());


            //------------------------------TEST------------------------------------ 
            /*
            Deck deckTest = DAL.DBAccess.CreateDeck();
            for(int i = 0; i < deckTest.cards.Count; i++)
            {
                Console.WriteLine(deckTest.cards[i].value);
            }

            //Console.WriteLine("test");
            //string s = db.WithdrawFunds("Gustav Hedin", 20000);
            //Console.WriteLine(s);

            //string a = db.DepositFunds("Mattias West", 5000); 
            //db.CreateAccount("1234567890123456789012345", "password");
            //db.DeleteAccount("Alex Eiring", "password");           

            Console.WriteLine(" Antal kort: " + deckTest.cards.Count);
            Hand dealerhand = new Hand();
            Hand accountHand = new Hand();
            dealerhand.AddCard(deckTest);
            dealerhand.AddCard(deckTest);
            accountHand.AddCard(deckTest);
            accountHand.AddCard(deckTest);

            Console.WriteLine(dealerhand.total);
            Console.WriteLine(accountHand.total);
            Console.WriteLine(dealerhand.handCards[0].value);
            Console.WriteLine(dealerhand.handCards[1].value);
            Console.WriteLine(accountHand.handCards[0].value);
            Console.WriteLine(accountHand.handCards[1].value);
            /**
            accountHand.RemoveCard();
            Console.WriteLine(accountHand.total);
            **/
        }

    }
}
