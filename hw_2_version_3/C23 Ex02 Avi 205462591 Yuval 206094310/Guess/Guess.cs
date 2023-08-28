using System.Linq;
using System;

namespace Ex02
{
    public class Guess
    {
        private char[] m_Guess;

        public Guess(char[] i_GuessInput)
        {
            m_Guess = i_GuessInput;
        }

        public char[] GuessValue
        {
            get { return m_Guess; }
            set { m_Guess = value; }
        }

        public char[] GetFidbackOnGuess(SecretCode i_SecretCode)
        {
            char[] FidbackOnGuess = new char[this.m_Guess.Length];

            for (int i = 0; i < FidbackOnGuess.Length; i++)
            {
                if (i_SecretCode.GetCode.Contains(this.m_Guess[i]))
                {
                    if (i_SecretCode.GetCode[i] == this.m_Guess[i])
                    {
                        FidbackOnGuess.Append('V');
                    }
                    else
                    {
                        FidbackOnGuess.Append('X');
                    }
                }
            }

            Array.Sort(FidbackOnGuess);

            return FidbackOnGuess;

        }
    }
}

