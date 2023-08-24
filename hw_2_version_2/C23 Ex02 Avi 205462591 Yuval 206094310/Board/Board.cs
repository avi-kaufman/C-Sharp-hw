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
        private char[,] m_FidbackOnPlayerGuesses;

        public Board(char[] i_CharArrayToGenerateSecretCodeFrom, int i_SizeOfSecretCode, int i_MaxNumberOfGuesses)
        {
            m_SecretCode = new SecretCode(i_CharArrayToGenerateSecretCodeFrom, i_SizeOfSecretCode);
            m_PlayerGuesses = new Guess[i_MaxNumberOfGuesses];
            m_FidbackOnPlayerGuesses = new char[i_MaxNumberOfGuesses, i_SizeOfSecretCode];
        }



        public char[] GetFidbackOnGuess(Guess i_PlayerGuess)
        {
            char[] FidbackOnPlayerGuess = new char[i_PlayerGuess.GuessValue.Length];

            for(int i = 0; i < FidbackOnPlayerGuess.Length; i++)
            {
                if (this.m_SecretCode.GetCode.Contains(i_PlayerGuess.GuessValue[i]))
                {
                    if (this.m_SecretCode.GetCode[i] == i_PlayerGuess.GuessValue[i])
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
