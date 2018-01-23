using System;

namespace GameGuessNumber
{
    class GameController
    {
        private Random rand;
        private Player player;
        private int compScore;
        private int compNumber;
        private int numberOfAttemps;

        public GameController()
        {
            rand = new Random();
            numberOfAttemps = Settings.AttempsCount;
            player = new Player();
            compScore = 0;
        }

        private bool IsEndOfRound()
        {
            if (numberOfAttemps == 0 || player.Number == compNumber)
            {
                return true;
            }
            return false;
        }

        private bool IsEndOfGame()
        {
            if (player.Score == Settings.ScoresCountToWin || compScore == Settings.ScoresCountToWin)
            {
                return true;
            }
            return false;
        }

        private bool IsPlayerWonRound()
        {
            if (player.Number == compNumber)
            {
                return true;
            }
            return false;
        }

        private bool IsPlayerWonGame()
        {
            if (player.Score == Settings.ScoresCountToWin)
            {
                return true;
            }
            return false;
        }

        private void AddScoreToRound()
        {
            if (IsPlayerWonRound())
            {
                player.Score += Settings.DeltaScore;
                Console.Write("You win round.\nNew Round.");
            }
            else
            {
                compScore += Settings.DeltaScore;
                Console.Write("Comp win round.\nNew Round.");
            }
        }

        private int GetValidNumberFromConsole()
        {
            while (true)
            {
                string number = Console.ReadLine();
                if (Int32.TryParse(number, out int validNumber))
                {
                    if (validNumber < Settings.MinValue || validNumber >= Settings.MaxValue)
                    {
                        Console.Write($"Enter valid number[{Settings.MinValue},{Settings.MaxValue - 1}]: ");
                        continue;
                    }
                    return validNumber;
                }
                else
                {
                    Console.Write($"Enter valid number[{Settings.MinValue},{Settings.MaxValue - 1}]: ");
                }
            }
        }

        private void DisplayUpdatedScore()
        {
            int cursorLeft = Console.CursorLeft;
            int cursorTop = Console.CursorTop;
            Console.SetCursorPosition(Console.CursorLeft + 30, Console.CursorTop);
            Console.Write($"Your score: {player.Score}   Comp score: {compScore}");
            Console.SetCursorPosition(0, cursorTop + 1);
        }

        public void Start()
        {
            while (!IsEndOfGame())
            {
                compNumber = rand.Next(Settings.MinValue, Settings.MaxValue);
                while (!IsEndOfRound())
                {
                    Console.Write($"Enter your number[{Settings.MinValue},{Settings.MaxValue - 1}]: ");
                    player.Number = GetValidNumberFromConsole();

                    if (!IsPlayerWonRound())
                    {
                        numberOfAttemps--;
                        Console.WriteLine($"Wrong!!! {numberOfAttemps} chances left.");
                    }
                }
                AddScoreToRound();
                DisplayUpdatedScore();
                numberOfAttemps = Settings.AttempsCount;
                player.Number = -1;
            }

            if (IsPlayerWonGame())
            {
                Console.WriteLine("You won!!! Congratulations on your victory.");
            }
            else
            {
                Console.WriteLine("You loser ;).");
            }
        }
    }
}
