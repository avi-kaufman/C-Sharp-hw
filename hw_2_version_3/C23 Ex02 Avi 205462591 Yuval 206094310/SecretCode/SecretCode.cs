using System;
using System.Linq;

namespace Ex02
{
    public class SecretCode
    {
        private readonly Char[] m_CodeToGuess;

        public SecretCode(char[] i_CharArrayToGenerateSecretCodeFrom, int i_SizeOfSecretCode)
        {
            m_CodeToGuess = new char[i_SizeOfSecretCode];

            int NumberOfCharactersGenerated = 0;
            Random Random = new Random();
            int RandomIndex;

            while (NumberOfCharactersGenerated < i_SizeOfSecretCode)
            {
                RandomIndex = Random.Next(i_CharArrayToGenerateSecretCodeFrom.Length);

                if (!m_CodeToGuess.Contains(i_CharArrayToGenerateSecretCodeFrom[RandomIndex]))
                {
                    m_CodeToGuess.Append(i_CharArrayToGenerateSecretCodeFrom[RandomIndex]);
                    NumberOfCharactersGenerated++;
                }
            }
        }

        public Char[] GetCode
        {
            get { return m_CodeToGuess; }
        }

    }
}