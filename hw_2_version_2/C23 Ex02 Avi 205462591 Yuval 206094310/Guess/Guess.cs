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

        public char[] GetGuess
        {
            get { return m_Guess; }

        }

        public char[] SetGuess
        {
            set { m_Guess = value; }
        }

        public static char[] GetFidbackOnGuess(SecretCode i_SecretCode)
        {
            char[] FidbackOnPlayerGuess = new char[this.GetGuess.Length];

            for (int i = 0; i < FidbackOnPlayerGuess.Length; i++)
            {
                if (i_SecretCode.GetCode.Contains(this.GetGuess[i]))
                {
                    if (i_SecretCode.GetCode[i] == this.GetGuess[i])
                    {
                        FidbackOnPlayerGuess.Append('V');
                    }
                    else
                    {
                        FidbackOnPlayerGuess.Append('X');
                    }
                }
            }

            Array.Sort(FidbackOnPlayerGuess);

            return FidbackOnPlayerGuess;

        }
    }
}