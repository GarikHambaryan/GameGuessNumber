using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Guess Number";
            GameController gameController = new GameController();
            gameController.Start();

            Console.ReadKey();
        }
    }
}
