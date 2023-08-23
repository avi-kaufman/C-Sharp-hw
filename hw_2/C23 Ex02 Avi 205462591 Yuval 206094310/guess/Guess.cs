namespace Guess
{
    public class Guess
    {
        private char[] m_PlayerGuess = new char[4];

        public Guess(string i_PlayerGuess)
        {
            if(i_PlayerGuess.Length == 4)
            {
                m_PlayerGuess[0] = i_PlayerGuess[0];
                m_PlayerGuess[1] = i_PlayerGuess[1];
                m_PlayerGuess[2] = i_PlayerGuess[2];
                m_PlayerGuess[3] = i_PlayerGuess[3];
            }
        }

        public char[] Get()
        {
            return m_PlayerGuess;
        }
    }
}