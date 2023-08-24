using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    public class SecretCode
    {
        private Char[] m_CodeToGuess;

        public SecretCode(char[] i_CharArrayToGenerateSecretCodeFrom, int i_SizeOfSecretCode)
        {

            Random Random = new Random();
            int RandomIndex;

            while (m_CodeToGuess.Length <= i_SizeOfSecretCode)
            {
                RandomIndex = Random.Next(i_CharArrayToGenerateSecretCodeFrom.Length);

                if (!m_CodeToGuess.Contains(i_CharArrayToGenerateSecretCodeFrom[RandomIndex]))
                {
                    m_CodeToGuess.Append(i_CharArrayToGenerateSecretCodeFrom[RandomIndex]);
                }
            }
        }

        public Char[] GetCode
        {
            get { return m_CodeToGuess; }
        }

    }
}
