using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuessNumber
{
    class Player
    {
        public int Score { get; set; }
        public int Number { get; set; }

        public Player()
        {
            Score = 0;
        }
    }
}
