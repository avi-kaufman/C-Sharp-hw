using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Game
    {
        private char[] CharArrayToGenerateSecretCodeFrom;
        private int SizeOfSecretCode;
        private int MaxNumberOfGuesses;
        private int MinNumberOfGuesses;
        private int numOfGuesses;
        private int currentGuess;
        privat bool startGame;
        public bool continuePlayFlag;
        privat bool victoryFlag;
        private Board board;

        public void Game()
        {
            CharArrayToGenerateSecretCodeFrom = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H']
        SizeOfSecretCode = 4;
            MaxNumberOfGuesses = 10;
            MinNumberOfGuesses = 4;
            numOfGuesses = 0;
            currentGuess = 0;
            startGame = false;
            continuePlayFlag = true;
            victoryFlag = false;
            board = new Board(CharArrayToGenerateSecretCodeFrom, SizeOfSecretCode, MaxNumberOfGuesses);
        }

        public static PlayGame()
        {
            this.SetNumOfGuesses();

            string userInputString = "";
            string outputString = "";

            while (currentGuess <= numOfGuesses && continuePlayFlag && !victoryFlag)
            {
                string separateChars = string.Join(" ", CharArrayToGenerateSecretCodeFrom)
                outputString = String.Format("Please type your guess <{0}> or 'Q' to quit", separateChars)
                Console.WriteLine(outputString);
                string userInputString = Console.ReadLine();

                if (IsQuit(userInputString))
                {
                    continuePlayFlag = false;
                    break;
                }

                if (IsInputValid(userInputString))
                {
                    Guess userGuess = new Guess(userInputString.ToCharArray());
                    board.AppendGuess(userGuess);
                    currentGuess++;

                    //PRINT HERE THE BOARD//

                    if (IsVictory())
                    {
                        victoryFlag = true;
                        outputString = String.Format("You guessed after {0} steps!\nWould you like to start a new game? <Y/N>", currentGuess);
                        Console.WriteLine(outputString);
                        continuePlayFlag = CheckForNewGame();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid guess.");
                }
            }

            if (currentGuess == MaxNumberOfGuesses && continuePlayFlag)
            {
                //PRINT HERE THE BOARD//

                Console.WriteLine("No more guesses allowed. You Lost.\nWould you like to start a new game <Y/N>?");
                if (!CheckForNewGame())
                {
                    continuePlayFlag = false;
                }
            }
        }

        private static void SetNumOfGuesses()
        {
            string userInputString = "";
            string outputString = "";

            while (!startGame)
            {
                string outputString = String.Format("Please type the maximum number of guesses between {0} to {1} for the game.", MinNumberOfGuesses, MaxNumberOfGuesses)
                Console.WriteLine(outputString);
                string userInputString = Console.ReadLine();

                if (IsQuit(userInputString))
                {
                    continuePlayFlag = false;
                    break;
                }

                if (int.TryParse(userInputString, out numOfGuesses))
                {
                    if (numOfGuesses >= MinNumberOfGuesses && numOfGuesses <= MaxNumberOfGuesses)
                    {
                        startGame = true;
                        ClearBoard();
                        this.PrintBoard();
                    }
                    else
                    {
                        outputString = String.Format("Its seems like the number you have enterd isnt between {0} to {1}. Please try again!", MinNumberOfGuesses, MaxNumberOfGuesses);
                        Console.WriteLine(outputString);
                    }
                }
                else
                {
                    outputString = "Its seems like you have enterd an invalid input. Please try again!";
                    Console.WriteLine(outputString);
                }
            }
        }

        private bool IsInputValid(string i_input)
        {
            foreach (char c in i_input)
            {
                if (i_input.Distinct().Count(c) != 4)
                {
                    return false;
                }
                if (c < CharArrayToGenerateSecretCodeFrom[0] || c > CharArrayToGenerateSecretCodeFrom[CharArrayToGenerateSecretCodeFrom.Length - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsQuit(string i_input)
        {
            if (i_input.isEqaual("Q"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void CheckForNewGame()
        {
            bool quitGameFlag = false;
            while (!quitGameFlag)
            {
                string isNewGame = Console.ReadLine();

                if (isNewGame == 'Y')
                {
                    return true;
                }
                if (isNewGame == 'N' || IsQuit(isNewGame))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid answer. Please type <Y/N>")
                }
            }

        }

        private static bool IsVictory()

        {
            if (board.GetFidbackOnPlayerGuesses[currentGuess - 1].isEqaual(['V', 'V', 'V', 'V']))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    private static void ClearBoard()
    {
        Console.Clear();
    }

    private static void PrintBoard()
    {
        console.WriteLine("Current board status:");
        console.WriteLine("");
        console.WriteLine("|Pins:    |Result:|");
        console.WriteLine("|=========|=======|");
        if (currentGuess == MaxNumberOfGuesses)
        {
            string printSecretCode = string.Join(" ", bord.GetCode)
            console.WriteLine(String.Format("|{0}|       |", printSecretCode));
            console.WriteLine("|=========|=======|");

        }
        else
        {
            console.WriteLine("| # # # # |       |");
            console.WriteLine("|=========|=======|");

        }
        for (int i = 0; i < currentGuess; i++)
        {
            string plaerGuess = string.Join(" ", board.GetPlayerGuesses[i].GetGuess);
            string plaerFeedback = string.Join(" ", board.board.GetFidbackOnGuess[i]);
            console.WriteLine(String.Format(" |{0} |{1}|", plaerGuess, plaerFeedback));
            console.WriteLine("|=========|=======|");
        }
        for (int i = 0; i < numOfGuesses - currentguess; i++)
        {
            console.WriteLine("|         |       |");
            console.WriteLine("|=========|=======|");

        }
    }
}
