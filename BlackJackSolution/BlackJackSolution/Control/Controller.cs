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
        private static Account user = new Account();
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
            Deck newDeck = new Deck();
            List<string[]> dbData = new List<string[]>();
            dbData = db.CreateDeck();

            foreach (string[] dataRow in dbData)
            {
                Card card = new Card();

                card.setValue(Int32.Parse(dataRow[0]));
                card.setCardId(dataRow[1]);

                if (dataRow[1].Substring(0, 1).Equals("H")){
                    card.SetSuit("hearts");
                } else if (dataRow[1].Substring(0, 1).Equals("S")) {
                    card.SetSuit("spades");
                } else if (dataRow[1].Substring(0, 1).Equals("C")) {
                    card.SetSuit("clubs");
                } else if (dataRow[1].Substring(0, 1).Equals("D")) {
                    card.SetSuit("diamonds");
                }
                newDeck.cards.Add(card);
            }
            deck = newDeck;
        }
        public bool CreateAccount(string aname, string password)
        {
            return db.CreateAccount(aname, Crypt(password));
        }
        public string Crypt(string input)
        {
            SHA512 alg = SHA512.Create();
            return Convert.ToBase64String(alg.ComputeHash(Encoding.UTF8.GetBytes(input)));
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
        public List<String> GetDealerPictureStrings()
        {
            List<String> picList = new List<string>();
            String picture;
            for (int i = 0; i < dealerHand.handCards.Count; i++)
            {
                if (dealerHand.handCards[i].getValue() < 10)
                {
                    picture = "_0" + dealerHand.handCards[i].getValue() + "_" + dealerHand.handCards[i].getSuit();
                    picList.Add(picture);
                }
                else if (dealerHand.handCards[i].getValue() == 10)
                {
                    picture = "_" + dealerHand.handCards[i].getValue() + "_" + dealerHand.handCards[i].getSuit();
                    picList.Add(picture);
                }
                else if (dealerHand.handCards[i].getValue() == 11)
                {
                    picture = "_" + dealerHand.handCards[i].getValue() + "_" + dealerHand.handCards[i].getSuit();
                    picList.Add(picture);
                }
                else if (dealerHand.handCards[i].getValue() == 12)
                {
                    picture = "_" + dealerHand.handCards[i].getValue() + "_" + dealerHand.handCards[i].getSuit();
                    picList.Add(picture);
                }
                else if (dealerHand.handCards[i].getValue() == 13)
                {
                    picture = "_" + dealerHand.handCards[i].getValue() + "_" + dealerHand.handCards[i].getSuit();
                    picList.Add(picture);
                }
            }
            return picList;
        }
        public List<String> GetMyPictureStrings()
        {
            List<String> picList = new List<string>();
            String picture;
                for(int i = 0; i < myHand.handCards.Count; i++)
                {
                    if (myHand.handCards[i].getValue() < 10)
                    {
                        picture = "_0" + myHand.handCards[i].getValue() + "_" + myHand.handCards[i].getSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].getValue() == 10)
                    {
                        picture = "_" + myHand.handCards[i].getValue() + "_" + myHand.handCards[i].getSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].getValue() == 11) 
                    {
                        picture = "_" + myHand.handCards[i].getValue() + "_" + myHand.handCards[i].getSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].getValue() == 12)
                    {
                        picture = "_" + myHand.handCards[i].getValue() + "_" + myHand.handCards[i].getSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].getValue() == 13)
                    {
                        picture = "_" + myHand.handCards[i].getValue() + "_" + myHand.handCards[i].getSuit();
                        picList.Add(picture);
                    }  
                }
            return picList;
        }
        public void GetUser(string uname, string pw)
        {
            string[] dbData = db.GetAccount(uname);
            if (Crypt(pw ).Equals(dbData[3]))
            {
                
            }
        }
        public void HitBtnPush()
        {
            myHand.AddCard(deck);
        }
        //Behöver commit på nya procedures för test
        public bool Login(string accname, string pwd)
        {   
            string[] dbData = db.GetAccount(accname);
            if (dbData == null)
            {
                return false;
            }
            else
            {
                if (dbData[3].Equals(Crypt(pwd)))
                {
                    user.setAname(dbData[0]);
                    user.setAstatus(dbData[1]);
                    user.setBalance(double.Parse(dbData[2]));
                    user.setPassword(dbData[3]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void StandBtnPush()
        {
            while(dealerHand.getTotal() < 17)
            {
                dealerHand.AddCard(deck);
            }
        }
        //Behöver commit på nya procedures för test
    }
}
