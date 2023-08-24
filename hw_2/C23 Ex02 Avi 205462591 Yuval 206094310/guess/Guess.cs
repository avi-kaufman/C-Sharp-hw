using System;


namespace Ex02
{
    public class Guess
    {
        private char[] m_Guess;
        
        public Guess(string i_GuessInput)
        {
            m_Guess = i_GuessInput.ToCharArray();
        }

        public char[] GetGuessValue
        { 
            get { return m_Guess; }
                 
        }

        public void SetGuessValue
        {
            set { return m_Guess = value; }
        }
    }
}