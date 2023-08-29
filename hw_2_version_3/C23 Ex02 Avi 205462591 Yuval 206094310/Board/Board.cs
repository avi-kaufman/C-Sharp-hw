using System.Collections.Generic;

namespace Ex02
{
    public class Board
    {
        private SecretCode m_SecretCode;
        private List<Guess> m_PlayerGuesses;
        private List<List<char>> m_FeedbackOnGuesses;
        
        public Board(char[] i_CharArrayToGenerateSecretCodeFrom, int i_SizeOfSecretCode)
        {
            m_SecretCode = new SecretCode(i_CharArrayToGenerateSecretCodeFrom, i_SizeOfSecretCode);
            m_PlayerGuesses = new List<Guess>();
            m_FeedbackOnGuesses = new List<List<char>>();
        }

        public SecretCode SecretCode
        {
            get { return this.m_SecretCode; }
        }

        public List<Guess> PlayerGuesses
        {
            get { return this.m_PlayerGuesses; }
        }

        public List<List<char>> FeedbackOnGuesses
        {
            get { return this.m_FeedbackOnGuesses; }
        }
        public void AddGuess(Guess i_Guess)
        {
            m_PlayerGuesses.Add(i_Guess);
            m_FeedbackOnGuesses.Add(i_Guess.GetFeedbackOnGuess(m_SecretCode));
        }
    }
}
