using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Table
    {
        private int sessionId;
        private int maxBet;
        private int minBet;
        private string gstatus;

        public Table(int sessionId, int maxBet, int minBet, string gstatus)
        {
            this.sessionId = sessionId;
            this.maxBet = maxBet;
            this.minBet = minBet;
            this.gstatus = gstatus;
        }

        public int SessionId
        {
            get
            {
                return sessionId;
            }

            set
            {
                sessionId = value;
            }
        }

        public int MaxBet
        {
            get
            {
                return maxBet;
            }

            set
            {
                maxBet = value;
            }
        }

        public int MinBet
        {
            get
            {
                return minBet;
            }

            set
            {
                minBet = value;
            }
        }

        public string Gstatus
        {
            get
            {
                return gstatus;
            }

            set
            {
                gstatus = value;
            }
        }
    }
}
