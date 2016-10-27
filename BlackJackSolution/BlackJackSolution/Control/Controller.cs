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

        public string AddFunds(double amount)
        {
            try
            {
                string check = db.DepositFunds(user.GetAname(), amount);
                if (GetBalance() >= 50000)
                {
                    user.SetAstatus("VIP");
                }
                return check;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " AddFunds(), Controller");
                return null;
            }
        }
        public int CheckMyHand()
        {
            try
            {
                int value = myHand.getTotal();
                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " CheckMyHand(), Controller");
                return 0;
            }
        }
        public int CheckDealerHand()
        {
            try
            {
                int value = dealerHand.getTotal();
                return value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " CheckDealerHand(), Controller");
                return 0;
            }
        }
        public void ClearHands()
        {
            try
            {
                myHand.clearHand();
                myHand.setTotal(0);
                dealerHand.clearHand();
                dealerHand.setTotal(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " ClearHands(), Controller");
            }
        }
        public void CreateDeck()
        {
            try
            {
                Deck newDeck = new Deck();
                List<string[]> dbData = new List<string[]>();
                dbData = db.CreateDeck();

                foreach (string[] dataRow in dbData)
                {
                    Card card = new Card();

                    card.SetValue(Int32.Parse(dataRow[0]));
                    card.SetCardId(dataRow[1]);

                    if (dataRow[1].Substring(0, 1).Equals("H")) {
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " CreateDeck(), Controller");
            }
        }
        public string CreateAccount(string aname, string password)
        {
            try
            {
                return db.CreateAccount(aname, Crypt(password));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " CreateAccount(), Controller");
                return null;
            }
        }
        public string DeleteAccount()
        {
            try
            {
                string check = db.DeleteAccount(user.GetAname(), user.GetPassword());
                if (check.Equals("True"))
                {
                    LogOut();
                }
                return check;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " DeleteAccount(), Controller");
                return null;
            }
        }
        public void Transaction(int bet, int result)
        {
            try
            {
                int gameId = db.CreateGameRound(bet, result, user.GetAname(), currentTable.SessionId);
                if (gameId > 0)
                {
                    db.GameTransaction(user.GetAname(), gameId);
                }
                else
                {
                    Console.WriteLine("Fel " + gameId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Transaction(), Controller");
            }
        }
        public string Crypt(string input)
        {
            try {
                SHA512 alg = SHA512.Create();
                string cryptedInChar = Convert.ToBase64String(alg.ComputeHash(Encoding.UTF8.GetBytes(input)));
                alg.Dispose();
                return cryptedInChar;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Crypt(), Controller");
                return null;
            }
        }
        public void DealButtonPush()
        {
            try
            {
                if (deck.cards.Count < 4)
                {
                    CreateDeck();
                }
                myHand.AddCard(deck, myHand);
                myHand.AddCard(deck, myHand);
                dealerHand.AddCard(deck, dealerHand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " DealButtonPush(), Controller");
            }
        }
        public List<Table> GetAllBlackJackGames()
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetAllBlackJackGames(), Controller");
                return null;
            }
        }
        public int GetBalance()
        {
            try
            {
                int retvalue = 0;
                string[] accB = db.GetAccount(user.GetAname(), user.GetPassword());
                if (accB[2] != null)
                {
                    retvalue = Int32.Parse(accB[2]);
                    if (retvalue >= 50000)
                    {
                        user.SetAstatus("VIP");
                    }
                    else
                    {
                        user.SetAstatus("STANDARD");
                    }
                    return retvalue;
                }
                else
                {
                    return retvalue;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetBalance(), Controller");
                return 0;
            }
        }
        public Table GetBlackJackGameById(int sessionId)
        {
            try
            {
                foreach (Table t in GetAllBlackJackGames())
                {
                    if (t.SessionId == sessionId)
                    {
                        return t;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetBlackJackGameById(), Controller");
                return null;
            }
        }
        public List<String> GetDealerPictureStrings()
        {
            try
            {
                List<String> picList = new List<string>();
                String picture;
                for (int i = 0; i < dealerHand.handCards.Count; i++)
                {
                    if (dealerHand.handCards[i].GetValue() < 10 && dealerHand.handCards[i].GetValue() > 1)
                    {
                        picture = "_0" + dealerHand.handCards[i].GetValue() + "_" + dealerHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (dealerHand.handCards[i].GetValue() == 1)
                    {
                        picture = "_11_" + dealerHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (dealerHand.handCards[i].GetValue() == 10)
                    {
                        picture = "_" + dealerHand.handCards[i].GetValue() + "_" + dealerHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (dealerHand.handCards[i].GetValue() == 11)
                    {
                        picture = "_" + dealerHand.handCards[i].GetValue() + "_" + dealerHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (dealerHand.handCards[i].GetValue() == 12)
                    {
                        picture = "_" + dealerHand.handCards[i].GetValue() + "_" + dealerHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (dealerHand.handCards[i].GetValue() == 13)
                    {
                        picture = "_" + dealerHand.handCards[i].GetValue() + "_" + dealerHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (dealerHand.handCards[i].GetValue() == 14)
                    {
                        picture = "_" + dealerHand.handCards[i].GetValue() + "_" + dealerHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                }
                return picList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetDealerPictureStrings(), Controller");
                return null;
            }
        }
        public int GetMaxBet()
        {
            try
            {
                return currentTable.MaxBet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetMaxBet(), Controller");
                return 0;
            }
        }
        public int GetMinBet()
        {
            try {
                return currentTable.MinBet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetMinBet(), Controller");
                return 0;
            }
        }
        public List<String> GetMyPictureStrings()
        {
            try
            {
                List<String> picList = new List<string>();
                String picture;
                for (int i = 0; i < myHand.handCards.Count; i++)
                {
                    if (myHand.handCards[i].GetValue() < 10 && myHand.handCards[i].GetValue() > 1)
                    {
                        picture = "_0" + myHand.handCards[i].GetValue() + "_" + myHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].GetValue() == 1)
                    {
                        picture = "_11_" + myHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].GetValue() == 10)
                    {
                        picture = "_" + myHand.handCards[i].GetValue() + "_" + myHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].GetValue() == 11)
                    {
                        picture = "_" + myHand.handCards[i].GetValue() + "_" + myHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].GetValue() == 12)
                    {
                        picture = "_" + myHand.handCards[i].GetValue() + "_" + myHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].GetValue() == 13)
                    {
                        picture = "_" + myHand.handCards[i].GetValue() + "_" + myHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                    else if (myHand.handCards[i].GetValue() == 14)
                    {
                        picture = "_" + myHand.handCards[i].GetValue() + "_" + myHand.handCards[i].GetSuit();
                        picList.Add(picture);
                    }
                }
                return picList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetMyPictureStrings()");
                return null;
            }
        }
        public string GetUserStatus()
        {
            try
            {
                string status = user.GetAstatus();
                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " GetUserStatus(), Controller");
                return null;
            }
        }
        public void HitBtnPush()
        {
            try
            {
                if (deck.cards.Count < 1)
                {
                    CreateDeck();
                }
                myHand.AddCard(deck, myHand);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " HitBtnPush(), Controller");
            }
        }
        public void InitiateTable(int nr)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " InitiateTable(), Controller");
            }
        }
        public bool Login(string accname, string pwd)
        {
            try
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
                        user.SetAname(dbData[0]);
                        user.SetAstatus(dbData[1]);
                        user.SetBalance(double.Parse(dbData[2]));
                        user.SetPassword(dbData[3]);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Login(), Controller");
                return false;
            }
        }
        public void LogOut()
        {
            try
            {
                user = new Account();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " LogOut(), Controller");
            }
        }
        public void StandBtnPush()
        {
            try
            {
                while (dealerHand.getTotal() < 17)
                {
                    if (deck.cards.Count < 1)
                    {
                        CreateDeck();
                    }
                    dealerHand.AddCard(deck, dealerHand);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " StandBtnPush(), Controller");
            }
        }
        public string WithdrawFunds(double amount)
        {
            try
            {
                string check = db.WithdrawFunds(user.GetAname(), amount);
                if (GetBalance() < 50000)
                {
                    user.SetAstatus("STANDARD");
                }
                return check;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " WithdrawFunds(), Controller");
                return null;
            }
        }
    }
}
