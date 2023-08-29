using System;
using System.Collections.Generic;

namespace Ex02
{
    public class SecretCode
    {
        private List<char> m_CodeToGuess;

        public SecretCode(char[] i_CharArrayToGenerateSecretCodeFrom, int i_SizeOfSecretCode)
        {
            m_CodeToGuess = new List<char>();

            Random Random = new Random();
            int RandomIndex;

            while (m_CodeToGuess.Count < i_SizeOfSecretCode)
            {
                RandomIndex = Random.Next(i_CharArrayToGenerateSecretCodeFrom.Length);

                if (!m_CodeToGuess.Contains(i_CharArrayToGenerateSecretCodeFrom[RandomIndex]))
                {
                    m_CodeToGuess.Add(i_CharArrayToGenerateSecretCodeFrom[RandomIndex]);
                }
            }
        }

        public List<char> GetCode
        {
            get { return m_CodeToGuess; }
        }

    }
}