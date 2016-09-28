using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSolution.Model
{
    public class Hand
    {
        public List<Card> handCards { set; get; }
        public int score { set; get; }
        public int numberOfCards { set; get; }

        public Hand()
        {

        }
    }
}
