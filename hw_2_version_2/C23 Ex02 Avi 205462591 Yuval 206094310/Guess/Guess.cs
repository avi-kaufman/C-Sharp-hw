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

        public char[] GetGuessValue
        {
            get { return m_Guess; }

        }

        public char[] SetGuessValue
        {
            set { m_Guess = value; }
        }

        public static char[] GetFidbackOnGuess(SecretCode i_SecretCode)
        {
            char[] FidbackOnPlayerGuess = new char[this.GetGuessValue.Length];

            for (int i = 0; i < FidbackOnPlayerGuess.Length; i++)
            {
                if (i_SecretCode.GetCode.Contains(this.GetGuessValue[i]))
                {
                    if (i_SecretCode.GetCode[i] == this.GetGuessValue[i])
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