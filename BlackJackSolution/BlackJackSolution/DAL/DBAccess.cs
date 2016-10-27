using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlackJackSolution.DAL
{
    public class DBAccess
    {
        public static SqlConnection Connect()
        {
            SqlConnection con = new SqlConnection("user id=test;" +
                "password=test; server=localhost;" +
                "Trusted_Connection=yes;" +
                "database=Blackjack;" +
                "connection timeout=5");
            try
            {
                con.Open();
                return con;
            }
            catch (SqlException e)
            {
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.ToString() + e.Message + " " + ex);
                return null;
            }
        }
        public List<string[]> CreateDeck()
        {
            try
            {
                List<string[]> newDeck = new List<string[]>();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC dbo.SHUFFLECARDS", connection);
                SqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        string[] card = new string[2];
                        card[0] = read.GetInt32(read.GetOrdinal("value")).ToString();
                        card[1] = read.GetString(read.GetOrdinal("cardId"));
                        newDeck.Add(card);
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong, no objects found.");
                }
                return newDeck;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string CreateAccount(string aname, string password)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[ADDUSER] @USERNAME = '" + aname + "', @PASSWORD = '" + password + "'", connection);
                SqlDataReader read = command.ExecuteReader();
                string a = "True";

                
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            a = read.GetInt32(0).ToString();
                        }
                    
                    return a;
                }
                else
                {
                    return a;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string DeleteAccount(string aname, string password)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[DELETEUSER] @USERNAME = '" + aname + "', @PASSWORD = '" + password + "'", connection);
                SqlDataReader read = command.ExecuteReader();
                string a = "True";

                
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            a = read.GetString(0);
                        }
                    
                    return a;
                }
                else
                {
                    return a;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string[] GetAccount(string aname, string password)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[GETUSER] @USERNAME = '" + aname + "', @PASSWORD = '" + password + "'", connection);
                SqlDataReader read = command.ExecuteReader();
                string[] result = new string[4];

                if (read.HasRows)
                {
                    if (read.FieldCount > 1)
                    {
                        while (read.Read())
                        {
                            result[0] = read.GetString(0);
                            result[1] = read.GetString(1);
                            result[2] = read.GetDouble(2).ToString();
                            result[3] = read.GetString(3);
                        }
                    }
                    else if (read.FieldCount == 1)
                    {
                        while (read.Read())
                        {
                            result[0] = read.GetString(0);
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string WithdrawFunds(string aname, double amount)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[WITHDRAWFUNDS] @USERNAME = '" + aname + "', @AMOUNT = " + amount, connection);
                SqlDataReader read = command.ExecuteReader();
                string a = "False";

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        a = read.GetString(0);
                }
                }
                else
                {
                    a = "True";
                    return a;
                }
                return a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public string DepositFunds(string aname, double amount)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[DEPOSITFUNDS] @USERNAME = '" + aname + "', @AMOUNT = " + amount, connection);
                SqlDataReader read = command.ExecuteReader();
                string a = "False";

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        a = read.GetString(0);
                    }
                }
                else
                {
                    a = "True";
                    return a;
                }
                return a;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public int CreateGameRound(int bet, int result, string aname, int sessionid) //KLAR ISH, kanske vill förfina koden
        {
            try
            {

                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[CREATEGAMEROUND] @BET = " + bet + ", @RESULT = " + result + ", @USERNAME = '" + aname + "', @SESSIONID = " + sessionid, connection);
                SqlDataReader read = command.ExecuteReader();
                int gameid = 0;
                //if(read.GetInt32(read.GetOrdinal("ERROR")) > 0)
                //{
                //    return gameid;
                //}
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        gameid = read.GetInt32(0);
                        return gameid;
                }
                }
                return gameid;
            }
            catch (Exception e)
            {
                //string ex = Logic.Utils.SqlExceptionUtility(e);
                //return ex;
                return 0;
            }
        }

        public List<string[]> GetBlackJackGames()
        {
            try
            {
                List<string[]> setOfGames = new List<string[]>();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC dbo.GETBLACKJACKGAME", connection);
                SqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        string[] game = new string[4];
                        game[0] = read.GetInt32(read.GetOrdinal("sessionId")).ToString();
                        game[1] = read.GetDouble(read.GetOrdinal("maxBet")).ToString();
                        game[2] = read.GetDouble(read.GetOrdinal("minBet")).ToString();
                        game[3] = read.GetString(read.GetOrdinal("gstatus"));
                        setOfGames.Add(game);
                    }
                }
                else
                {
                    Console.WriteLine("Something went wrong, no objects found.");
                }
                return setOfGames;
            }
            catch (SqlException e)
            {
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.Message + " " + ex);
                return null;
            }
        }

        public string GameTransaction(string aname, int gameid)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC dbo.GAMETRANSACTION @USERNAME = '" + aname + "', @GAMEID = " + gameid, connection);
                SqlDataReader read = command.ExecuteReader();
                string a = "Transaction completed";

                if (read.HasRows)
                {
                    while (read.Read())
                {
                        a = read.GetInt32(0).ToString();
                    }

                    return a;
                }
                else
                {
                    return a;
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