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

        public char[] Guess
        { 
            get { return m_Guess; }
            set { return m_Guess = value; }     /// We want to anable set option?? ///  
        }
    }
}