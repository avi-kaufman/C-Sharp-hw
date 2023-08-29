using System.Collections.Generic;

namespace Ex02
{
    public class Guess
    {
        private List<char> m_Guess;

        public Guess(List<char> i_GuessInput)
        {
            m_Guess = i_GuessInput;
        }


        public List<char> GuessValue
        {
            get { return m_Guess; }
            ///set { m_Guess = value; } need to think if we need it
        }

        public List<char> GetFeedbackOnGuess(SecretCode i_SecretCode)
        {
            List<char> FidbackOnGuess = new List<char>();

            foreach (char c in this.m_Guess)
            {
                if (i_SecretCode.GetCode.Contains(c))
                {
                    if (i_SecretCode.GetCode.IndexOf(c) == this.m_Guess.IndexOf(c))
                    {
                        FidbackOnGuess.Add('V');
                    }
                    else
                    {
                        FidbackOnGuess.Add('X');
                    }
                }
                
            }
            FidbackOnGuess.Sort();

            return FidbackOnGuess;
        }
    }
}

