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

            Random rnd = new Random();
            int randomIndex = 0;

            while(m_CodeToGuess.Length <= i_SizeOfSecretCode)
            {
                randomIndex = rnd.Next(i_CharArrayToGenerateSecretCodeFrom.Length);

                if (!m_CodeToGuess.Contains(i_CharArrayToGenerateSecretCodeFrom[randomIndex])){
                    m_CodeToGuess.Append(i_CharArrayToGenerateSecretCodeFrom[randomIndex]);
                }
            }
        }

        public Char[] GetCode
        {
            get { return m_CodeToGuess; }
        }
        
    }
}
