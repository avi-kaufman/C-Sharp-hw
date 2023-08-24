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

        
    }
}