using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class Board
    {
        private SecretCode m_SecretCode;
        private Guess[] m_PlayerGuesses;
        private char[,] m_FidbackOnGuesses;
        private int m_PlayerGuessesCount;

        public Board(char[] i_CharArrayToGenerateSecretCodeFrom, int i_SizeOfSecretCode, int i_MaxNumberOfGuesses)
        {
            m_SecretCode = new SecretCode(i_CharArrayToGenerateSecretCodeFrom, i_SizeOfSecretCode);
            m_PlayerGuesses = new Guess[i_MaxNumberOfGuesses];
            m_FidbackOnGuesses = new char[i_MaxNumberOfGuesses, i_SizeOfSecretCode];
            m_PlayerGuessesCount = 0;
        }

        public SecretCode GetCode
        {
            get { return this.m_SecretCode; }
        }

        public Guess[] GetPlayerGuesses
        {
            get { return this.m_PlayerGuesses; }
        }

        public Guess AppendGuess
        {
            set
            {
                m_PlayerGuesses[m_PlayerGuessesCount] = value;
                m_FidbackOnGuesses[m_PlayerGuessesCount] = value.GetFidbackOnGuess(m_SecretCode);
                m_PlayerGuessesCount++;
            }
        }

        public char[,] GetFidbackOnGuesses
        {
            get { return this.m_FidbackOnGuesses; }
        }
    }
}
