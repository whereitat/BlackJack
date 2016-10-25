using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
                    Console.WriteLine("Caught : invalid database");
                    ex = "The database is unavailable at the moment";
                    return ex;
                case 18456:
                    Console.WriteLine("Caught : login failed");
                    ex = "Failed to log on to database";
                    return ex;
                case 547:
                    Console.WriteLine("Caught : foreignKey violation");
                    ex = "It seems the information you entered was incorrect";
                    return ex;
                case 2627:
                    Console.WriteLine("Caught : primarykey/constraint/uniqueKey violation");
                    ex = "Account already exists";
                    return ex;
                default:
                    Console.WriteLine("Caught : SqlException ");
                    ex = "Something went wrong, please try again later";
                    return ex;
            }
        }

        public static string ExceptionEUtility(Exception e)
        {
            Console.WriteLine("Caught : " + e.Message);
            string exc = e.Message;
            return exc;
        }

        /** Hash to byte[] and convert by base64 to 88 char string
        public string GetCrypt(string input)
        {
            SHA512 alg = SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.Unicode.GetBytes(input));
            return Convert.ToBase64String(result);
        }
        **/
    }
}
