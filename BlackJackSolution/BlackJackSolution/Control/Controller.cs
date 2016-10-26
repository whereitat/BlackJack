using BlackJackSolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackSolution.DAL;
using System.Security.Cryptography;


namespace BlackJackSolution.Control
{
    public class Controller
    {
        private static Deck deck = new Deck();
        private static Hand myHand = new Hand();
        private static Hand dealerHand = new Hand();
        private static DBAccess db = new DBAccess();
        public int CheckMyHand()
        {
            int value = myHand.getTotal();
            return value;
        }
        public int CheckDealerHand()
        {
            int value = dealerHand.getTotal();
            return value;
        }
        public void ClearHands()
        {
            myHand.clearHand();
            dealerHand.clearHand();
        }
        public void CreateDeck()
        {
            deck = db.CreateDeck();
        }
        public bool CreateAccount(string aname, string password)
        {
            return db.CreateAccount(aname, Crypt(password));
        }
        public string Crypt(string input)
        {
            SHA512 alg = SHA512.Create();
            return Convert.ToBase64String(alg.ComputeHash(Encoding.Unicode.GetBytes(input)));
        }
        public void DealButtonPush()
        {
            try
            {
                if(deck.cards.Count < 1)
                {
                    CreateDeck();
                }
                myHand.AddCard(deck);
                myHand.AddCard(deck);
                dealerHand.AddCard(deck);

            }
            catch (Exception e)
            {

            }
        }
        //Behöver commit på nya procedures för test
        public bool Login(string accname, string pwd)
        {
            
            string[] dbData = db.GetAccount(accname);
            
            
            if (dbData == null)
            {
                return false;
            } else
            {
                Account a = new Account();
                a.setAname(dbData[0]);
                a.setAstatus(dbData[1]);
                a.setBalance(double.Parse(dbData[2]));
                a.setPassword(dbData[3]);

                if (a.getAname().Equals(accname) && a.getPassword().Equals(Crypt(pwd)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
            
        }
        //Behöver commit på nya procedures för test
    }
}
