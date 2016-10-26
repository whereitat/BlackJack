using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackSolution.Model;

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
                Console.WriteLine("Connection established");
                return con;
            }
            catch (SqlException e)
            {
                String ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.ToString() + e.Message + " " + ex);
                return null;
            }
            /** Kanske ska användas??
            finally
            {
                con.Close();
            }
            **/
        }
        public Deck CreateDeck()
        {
            try {
                Deck newDeck = new Deck();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC dbo.SHUFFLECARDS", connection);
                command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                        while (read.Read())
                        {
                            Card card = new Card();
                            card.setValue(read.GetInt32(read.GetOrdinal("value")));
                            card.setCardId(read.GetString(read.GetOrdinal("cardId")));
                            string suite = read.GetString(read.GetOrdinal("cardId"));
                                if (suite.Substring(0, 1).Equals("H"))
                                {
                                    card.SetSuit("hearts");
                                }
                                else if (suite.Substring(0, 1).Equals("S"))
                                {
                                    card.SetSuit("spades");
                                }
                                else if (suite.Substring(0, 1).Equals("C"))
                                {
                                    card.SetSuit("clubs");
                                }
                                else if (suite.Substring(0, 1).Equals("D"))
                                {
                                    card.SetSuit("diamonds");
                                }
                            newDeck.cards.Add(card);
                        }
                }
                else
                {
                    Console.WriteLine("Something went wrong, no objects found.");
                }
                return newDeck;
            }
            catch(SqlException e)
            {
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.Message + " " + ex);
                return null;
            }
        }

        public bool CreateAccount(string aname, string password)
        {
            try
            {
                Account account = new Account();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[ADDUSER] @USERNAME = '" + aname + "', @PASSWORD = '" + password + "'", connection);
                command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();
                return true;         
            }
            catch(SqlException e)
            {               
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.Message + " " + ex);
                return false;
            }
        }

        public bool DeleteAccount(string aname, string password)
        {
            try
            {
                Account account = new Account();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[DELETEUSER] @USERNAME = '" + aname + "', @PASSWORD = '" + password + "'", connection);
                int result = command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();

                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException e)
            {
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.Message + " " + ex);
                return false;
            }
        }

        public Account GetAccount(string aname)
        {
            try
            {
                Account account = new Account();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[GETUSER] @USERNAME = '" + aname + "'", connection);
                command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();

                if (read != null)
                {
                    account.setAname(read.GetString(read.GetOrdinal("aname")));
                    account.setAstatus(read.GetString(read.GetOrdinal("astatus")));
                    account.setBalance(read.GetDouble(read.GetOrdinal("balance")));
                    account.setPassword(read.GetString(read.GetOrdinal("password")));
                    return account;
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException e)
            {
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.Message + " " + ex);
                return null;
            }
        }

        public string WithdrawFunds(string aname, double amount)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[WITHDRAWFUNDS] @USERNAME = '" + aname + "', @AMOUNT = " + amount, connection);
                int s = command.ExecuteNonQuery();

                if (s != 0)
                {
                    string result = amount + " withdrawn";
                    return result;
                }
                else
                {
                    return "else";
                }
                
            }
            catch (SqlException e)
            {
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.Message + " " + ex);
                return "catch";
            }
        }
        public string DepositFunds(string aname, double amount)
        {
            try
            {
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[DEPOSITFUNDS] @USERNAME = '" + aname + "', @AMOUNT = " + amount, connection);
                int s = command.ExecuteNonQuery();
                if (s != 0)
                {
                    string result = amount + " inserted!";
                    return result;
                }
                else
                {
                    return "else"; //what
                }

            }
            catch (SqlException e)
            {
                string ex = Logic.Utils.SqlExceptionUtility(e);
                Console.WriteLine(e.Message + " " + ex);
                return "catch";
            }
        }
    }
}
