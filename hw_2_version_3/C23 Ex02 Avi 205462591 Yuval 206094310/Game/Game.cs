using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Game
    {
        private char[] m_CharArrayToGenerateSecretCodeFrom;
        private int m_SizeOfSecretCode;
        private int m_MaxNumberOfGuesses;
        private int m_MinNumberOfGuesses;
        private int m_NumOfGuesses;
        private int m_CurrentGuess;
        private bool m_StartGame;
        public bool m_ContinuePlayFlag;
        private bool m_VictoryFlag;
        private Board m_Board;

        public Game()
        {
            m_CharArrayToGenerateSecretCodeFrom = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            m_SizeOfSecretCode = 4;
            m_MaxNumberOfGuesses = 10;
            m_MinNumberOfGuesses = 4;
            m_NumOfGuesses = 0;
            m_CurrentGuess = 0;
            m_StartGame = false;
            m_ContinuePlayFlag = true;
            m_VictoryFlag = false;
            m_Board = new Board(m_CharArrayToGenerateSecretCodeFrom, m_SizeOfSecretCode, m_MaxNumberOfGuesses);
        }

        public void PlayGame()
        {
            SetNumOfGuesses();

            string UserInputString;
            string OutputString;

            while (this.m_CurrentGuess <= this.m_NumOfGuesses && this.m_ContinuePlayFlag && !this.m_VictoryFlag)
            {
                string CharsToCooseFrom = string.Join(" ", m_CharArrayToGenerateSecretCodeFrom);
                OutputString = String.Format("Please type your guess <{0}> or 'Q' to quit", CharsToCooseFrom);
                Console.WriteLine(OutputString);
                UserInputString = Console.ReadLine();

                if (IsQuit(UserInputString))
                {
                    m_ContinuePlayFlag = false;
                    break;
                }

                if (IsInputValid(UserInputString))
                {
                    Guess userGuess = new Guess(UserInputString.ToCharArray());
                    this.m_Board.AppendGuess = userGuess;
                    m_CurrentGuess++;

                    //PRINT HERE THE BOARD//

                    if (IsVictory())
                    {
                        m_VictoryFlag = true;
                        OutputString = String.Format("You guessed after {0} steps!\nWould you like to start a new game? <Y/N>", m_CurrentGuess);
                        Console.WriteLine(OutputString);
                        m_ContinuePlayFlag = CheckForNewGame();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid guess.");
                }
            }

            if (m_CurrentGuess == m_MaxNumberOfGuesses && m_ContinuePlayFlag)
            {
                //PRINT HERE THE BOARD//

                Console.WriteLine("No more guesses allowed. You Lost.\nWould you like to start a new game <Y/N>?");
                if (!CheckForNewGame())
                {
                    m_ContinuePlayFlag = false;
                }
            }
        }

        private void SetNumOfGuesses()
        {
            string userInputString = "";
            string outputString = "";

            while (!this.m_StartGame)
            {
                outputString = String.Format("Please type the maximum number of guesses between {0} to {1} for the game.", m_MinNumberOfGuesses, m_MaxNumberOfGuesses);
                Console.WriteLine(outputString);
                userInputString = Console.ReadLine();

                if (IsQuit(userInputString))
                {
                    m_ContinuePlayFlag = false;
                    break;
                }

                if (int.TryParse(userInputString, out m_NumOfGuesses))
                {
                    if (this.m_NumOfGuesses >= this.m_MinNumberOfGuesses && this.m_NumOfGuesses <= this.m_MaxNumberOfGuesses)
                    {
                        m_StartGame = true;
                        ClearBoard();
                        this.PrintBoard();
                    }
                    else
                    {
                        outputString = String.Format("Its seems like the number you have enterd isnt between {0} to {1}. Please try again!", m_MinNumberOfGuesses, m_MaxNumberOfGuesses);
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
            if (i_input.Distinct().Count() != m_SizeOfSecretCode)
            {
                return false;
            }
            foreach (char c in i_input)
            {
                if (c < m_CharArrayToGenerateSecretCodeFrom[0] || c > m_CharArrayToGenerateSecretCodeFrom[m_CharArrayToGenerateSecretCodeFrom.Length - 1])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsQuit(string i_input)
        {
            if (string.Equals(i_input, "Q"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckForNewGame()
        {
            bool ReturnValidAnswer = false;
            while (!ReturnValidAnswer)
            {
                string PlayerInput = Console.ReadLine();

                if (string.Equals(PlayerInput,'Y'))
                {
                    return true;
                }
                if (string.Equals(PlayerInput, 'N') || IsQuit(PlayerInput))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid answer. Please type <Y/N>");
                }
            }
            return ReturnValidAnswer;
        }

        private bool IsVictory()

        {
            foreach(char c in this.m_Board.GetFidbackOnGuesses[this.m_CurrentGuess])
            if (this.m_Board.GetFidbackOnGuesses[this.m_CurrentGuess - 1][1] == ['V', 'V', 'V', 'V'])
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void ClearBoard()
        {
            Console.Clear();
        }

        private void PrintBoard()
        {
            Console.WriteLine("Current board status:");
            Console.WriteLine("");
            Console.WriteLine("|Pins:    |Result:|");
            Console.WriteLine("|=========|=======|");
            if (m_CurrentGuess == m_MaxNumberOfGuesses)
            {
                string printSecretCode = string.Join(" ", m_Board.GetCode);
                Console.WriteLine(String.Format("|{0}|       |", printSecretCode));
                Console.WriteLine("|=========|=======|");

            }
            else
            {
                Console.WriteLine("| # # # # |       |");
                Console.WriteLine("|=========|=======|");

            }
            for (int i = 0; i < m_CurrentGuess; i++)
            {
                string plaerGuess = string.Join(" ", this.m_Board.GetPlayerGuesses[i].GetGuess);
                string playerFeedback = string.Join(" ", this.m_Board.GetFidbackOnGuess[i,]);
                Console.WriteLine(String.Format(" |{0} |{1}|", plaerGuess, playerFeedback));
                Console.WriteLine("|=========|=======|");
            }
            for (int i = 0; i < this.m_NumOfGuesses - this.m_CurrentGuess; i++)
            {
                Console.WriteLine("|         |       |");
                Console.WriteLine("|=========|=======|");

            }
        }
    }
}
