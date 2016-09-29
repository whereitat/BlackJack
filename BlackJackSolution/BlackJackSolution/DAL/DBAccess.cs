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

            try
            {
                SqlConnection con = new SqlConnection("user id=test;" +
                "password=test; server=localhost;" +
                "Trusted_Connection=yes;" +
                "database=BlackJackProject;" +
                "connection timeout=5");

                con.Open();
                Console.WriteLine("Connection established");
                return con;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString() + e.Message);
                return null;
            }
        }
        public static Deck CreateDeck()
        {
            try {
                Deck newDeck = new Deck();
                SqlConnection connection = Connect();
                SqlCommand command = new SqlCommand("EXEC dbo.ShuffleCards", connection);
                command.ExecuteNonQuery();
                SqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                        while (read.Read())
                        {
                            Card card = new Card();
                            card.value = read.GetInt32(read.GetOrdinal("value"));
                            newDeck.cards.Add(card);
                        }
                }
                else
                {
                    Console.WriteLine("Something went wrong, no objects found.");
                }
                return newDeck;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
    }
}
