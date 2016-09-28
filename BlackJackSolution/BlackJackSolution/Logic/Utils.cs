using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Logic
{
    public class Utils
    {
        public static string SqlExceptionUtility(SqlException e)
        {
            string ex;
            switch (e.Number)
            {
                case 4060:
                    Console.WriteLine("Fångade : invalid database");
                    ex = "The database is unavailable at the moment";
                    return ex;
                case 18456:
                    Console.WriteLine("Fångade : login failed");
                    ex = "Failed to log on to database";
                    return ex;
                case 547:
                    Console.WriteLine("Fångade : foreignKey violation");
                    ex = "It seems the information you entered was incorrect";
                    return ex;
                case 2627:
                    Console.WriteLine("Fångade : primarykey/constraint/uniqueKey violation");
                    ex = "Account already exists";
                    return ex;
                default:
                    Console.WriteLine("Fångade : SqlException ");
                    ex = "Something went wrong, please try again later";
                    return ex;
            }
        }
        public static string ExceptionEUtility(Exception e)
        {
            Console.WriteLine("Fångade Exception : " + e.Message);
            string exc = e.Message;
            return exc;
        }
    }
}
