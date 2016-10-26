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
        public static List<string[]> CreateDeck()
        {
            try {
                List<string[]> newDeck = new List<string[]>();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC dbo.SHUFFLECARDS", connection);
                command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {                
                        while (read.Read())
                        {
                            string[] card = new string[3];
                            card[0] = read.GetInt32(read.GetOrdinal("value")).ToString();
                            card[1] = read.GetString(read.GetOrdinal("cardId"));
                            card[2] = read.GetString(read.GetOrdinal("cardId"));
                        newDeck.Add(card);
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

        public string[] GetAccount(string aname)
        {
            try
            {
                string[] result = new string[4];
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC [dbo].[GETUSER] @USERNAME = '" + aname + "'", connection);
                command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();

                if (read != null)
                {
                    result[0] = read.GetString(read.GetOrdinal("aname"));
                    result[1] = read.GetString(read.GetOrdinal("astatus"));
                    result[2] = read.GetDouble(read.GetOrdinal("balance")).ToString();
                    result[3] = read.GetString(read.GetOrdinal("password"));
                    return result;
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
