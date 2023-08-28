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
        private char[][] m_FidbackOnGuesses;

        public Board(char[] i_CharArrayToGenerateSecretCodeFrom, int i_SizeOfSecretCode, int i_MaxNumberOfGuesses)
        {
            m_SecretCode = new SecretCode(i_CharArrayToGenerateSecretCodeFrom, i_SizeOfSecretCode);
            m_PlayerGuesses = new Guess[i_MaxNumberOfGuesses];
            m_FidbackOnGuesses = new char[i_MaxNumberOfGuesses, i_SizeOfSecretCode];
        }

        public static SecretCode GetCode
        {
            get { return m_SecretCode.GetCode; }
        }

        public static char[] GetPlayerGuesses
        {
            get { return m_PlayerGuesses}
        }
        
        public static Guess[] AppendGuess
        {
            set { m_PlayerGuesses.Append(value);
                  m_FidbackOnGuesses.Append(value.GetFidbackOnGuess(m_SecretCode)); }
        }

        public static char[][] GetFidbackOnGuesses
        {
            get { return m_FidbackOnGuesses; }
        }
    }
}
