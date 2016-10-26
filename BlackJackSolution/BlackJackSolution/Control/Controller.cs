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
        private static Table currentTable = new Table();
        
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
        public string CreateAccount(string aname, string password)
        {
            return db.CreateAccount(aname, Crypt(password));
        }
        public void Transaction(int bet, int result)
        {
            int gameId = db.CreateGameRound(bet, result, user.getAname(), currentTable.SessionId);
            if(gameId > 0)
            {
                db.GameTransaction(user.getAname(), gameId);
            }
            else
            {
                Console.WriteLine("Fel");
            }
        }
        public string Crypt(string input)
        {
            SHA512 alg = SHA512.Create();
            string cryptedInChar = Convert.ToBase64String(alg.ComputeHash(Encoding.UTF8.GetBytes(input)));
            alg.Dispose();
            return cryptedInChar;
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
        public List<Table> GetAllBlackJackGames()
        {
            List<string[]> dbData = db.GetBlackJackGames();
            List<Table> returnList = new List<Table>();
            foreach (string[] datarow in dbData)
            {
                Table t = new Table(Int32.Parse(datarow[0]), Int32.Parse(datarow[1]), Int32.Parse(datarow[2]), datarow[3]);
                returnList.Add(t);
            }
            return returnList;
        }
        public Table GetBlackJackGameById(int sessionId)
        {
            foreach (Table t in GetAllBlackJackGames())
            {
                if(t.SessionId == sessionId)
                {
                    return t;
                }
            }
            return null;
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
        public int GetMaxBet()
        {
            return currentTable.MaxBet;
        }
        public int GetMinBet()
        {
            return currentTable.MinBet;
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
            string[] dbData = db.GetAccount(uname, pw);
            if (Crypt(pw ).Equals(dbData[3]))
            {
                
            }
        }
        public void HitBtnPush()
        {
            myHand.AddCard(deck);
        }
        public void InitiateTable(int nr)
        {
            int i = new int();
            switch (nr)
            {
                case 0: i = 200;
                    break;
                case 1: i = 201;
                    break;
                case 2: i = 202;
                    break;
            }
            currentTable = GetBlackJackGameById(i);
        }
        public bool Login(string accname, string pwd)
        {
            string[] dbData = db.GetAccount(accname, Crypt(pwd));
            if (dbData == null)
            {
                return false;
            }
            else
            {
                if (dbData[3] == null)
                {
                    return false;
                }
                else if (dbData[3] == Crypt(pwd))
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
        public void LogOut()
        {
            user = new Account();
        }
        public void StandBtnPush()
        {
            while(dealerHand.getTotal() < 17)
            {
                dealerHand.AddCard(deck);
            }
        }
        
    } 
}
