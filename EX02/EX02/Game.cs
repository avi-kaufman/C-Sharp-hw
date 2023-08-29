using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02
{
    public class Game
    {
        private char[] m_CharArrayToGenerateSecretCodeFrom;
        private int m_SizeOfSecretCode;
        private int m_MaxNumberOfGuesses;
        private int m_MinNumberOfGuesses;
        private int m_NumOfDesiredGuesses;
        private int m_CurrentGuess;
        private bool m_StartGame;
        private bool m_ContinuePlayFlag;
        private bool m_VictoryFlag;
        private Board m_Board;

        public Game()
        {
            m_CharArrayToGenerateSecretCodeFrom = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            m_SizeOfSecretCode = 4;
            m_MaxNumberOfGuesses = 10;
            m_MinNumberOfGuesses = 4;
            m_NumOfDesiredGuesses = 0;
            m_CurrentGuess = 0;
            m_StartGame = false;
            m_ContinuePlayFlag = true;
            m_VictoryFlag = false;
        }

        public bool ContinuePlay
        {
            get { return m_ContinuePlayFlag; }
        }

        public void PlayGame()
        {
            this.m_CurrentGuess = 0;
            this.m_StartGame = false;
            this.m_ContinuePlayFlag = true;
            this.m_VictoryFlag = false;
            this.m_Board = new Board(m_CharArrayToGenerateSecretCodeFrom, m_SizeOfSecretCode);

            SetDesiredMaxNumOfGuesses();

            string UserInputString;
            string OutputString;

            while (this.m_CurrentGuess < this.m_NumOfDesiredGuesses && this.m_ContinuePlayFlag && !this.m_VictoryFlag)
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

                if (IsGuessValid(UserInputString))
                {
                    List<char> InputStringToListOfChars = new List<char>();
                    InputStringToListOfChars.AddRange(UserInputString);
                    Guess UserNewGuess = new Guess(InputStringToListOfChars);
                    this.m_Board.AddGuess(UserNewGuess);
                    m_CurrentGuess++;

                    ClearBoard();
                    this.PrintBoard();

                    if (IsPlayerVictory())
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

            if (this.m_CurrentGuess == this.m_NumOfDesiredGuesses && m_ContinuePlayFlag)
            {
                ClearBoard();
                this.PrintBoard();

                OutputString = "No more guesses allowed. You Lost.\nWould you like to start a new game <Y/N>?";
                Console.WriteLine(OutputString);
                if (!CheckForNewGame())
                {
                    m_ContinuePlayFlag = false;
                }
            }
        }

        private void SetDesiredMaxNumOfGuesses()
        {
            string UserInputString = "";
            string OutputString = "";

            while (!this.m_StartGame)
            {
                OutputString = String.Format("Please type the maximum number of guesses between {0} to {1} for the game.", m_MinNumberOfGuesses, m_MaxNumberOfGuesses);
                Console.WriteLine(OutputString);
                UserInputString = Console.ReadLine();

                if (IsQuit(UserInputString))
                {
                    m_ContinuePlayFlag = false;
                    break;
                }

                if (int.TryParse(UserInputString, out m_NumOfDesiredGuesses))
                {
                    if (this.m_NumOfDesiredGuesses >= this.m_MinNumberOfGuesses && this.m_NumOfDesiredGuesses <= this.m_MaxNumberOfGuesses)
                    {
                        m_StartGame = true;
                        ClearBoard();
                        this.PrintBoard();
                    }
                    else
                    {
                        OutputString = string.Format("Its seems like the number you have enterd isnt between {0} to {1}. Please try again!", m_MinNumberOfGuesses, m_MaxNumberOfGuesses);
                        Console.WriteLine(OutputString);
                    }
                }
                else
                {
                    OutputString = string.Format("{0} is invalid input. Please type the maximum number of guesses between {1} to {2} for the game.", UserInputString, m_MinNumberOfGuesses, m_MaxNumberOfGuesses);
                    Console.WriteLine(OutputString);
                }
            }
        }

        private bool IsGuessValid(string i_InputGuess)
        {
            if (i_InputGuess.Length != m_SizeOfSecretCode || i_InputGuess.Distinct().Count() != m_SizeOfSecretCode)
            {
                return false;
            }
            foreach (char c in i_InputGuess)
            {
                if (!m_CharArrayToGenerateSecretCodeFrom.Contains(c))
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

        private static bool CheckForNewGame()
        {
            bool ReturnValidAnswer = false;
            while (!ReturnValidAnswer)
            {
                string PlayerInput = Console.ReadLine();

                if (string.Equals(PlayerInput, "Y"))
                {
                    return true;
                }
                if (string.Equals(PlayerInput, "N") || IsQuit(PlayerInput))
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

        private bool IsPlayerVictory()

        {
            List<char> VictoryList = Enumerable.Repeat('V', m_SizeOfSecretCode).ToList();

            if (this.m_Board.FeedbackOnGuesses.Last().SequenceEqual(VictoryList))
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
            if (m_CurrentGuess == m_NumOfDesiredGuesses)
            {
                string SecretCode = string.Join(" ", this.m_Board.SecretCode.GetCode);
                Console.WriteLine(String.Format("| {0} |       |", SecretCode));
                Console.WriteLine("|=========|=======|");

            }
            else
            {
                string HiddenSecretCode = string.Join(" ", Enumerable.Repeat("#", m_SizeOfSecretCode));
                string OutputHiddenSecretCode = string.Format("| {0} |       |", HiddenSecretCode);
                Console.WriteLine(OutputHiddenSecretCode);
                Console.WriteLine("|=========|=======|");

            }
            for (int i = 0; i < m_CurrentGuess; i++)
            {

                string PlayerGuess = string.Join(" ", this.m_Board.PlayerGuesses[i].ToString().ToCharArray());
                string GuessFeedback = string.Join(" ", this.m_Board.FeedbackOnGuesses[i]);
                string SpacesForFeedback = "";
                int spacesToAdd = m_SizeOfSecretCode - this.m_Board.FeedbackOnGuesses[i].Count;
                if (spacesToAdd > 0)
                {
                    SpacesForFeedback = string.Join(" ", Enumerable.Repeat(" ", spacesToAdd));
                    Console.WriteLine(String.Format("| {0} |{1} {2}|", PlayerGuess, GuessFeedback, SpacesForFeedback));
                }
                else
                {
                    Console.WriteLine(String.Format("| {0} |{1}|", PlayerGuess, GuessFeedback));

                }
                Console.WriteLine("|=========|=======|");
            }
            for (int i = 0; i < this.m_NumOfDesiredGuesses - this.m_CurrentGuess; i++)
            {
                Console.WriteLine("|         |       |");
                Console.WriteLine("|=========|=======|");

            }
        }
    }
}
