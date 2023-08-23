using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            string userInput = GetUserInput();
            StringBuilder dynamicStringBuilder = new StringBuilder(userInput, userInput.Length);
            Boolean isPalindrome = CheckPalindromeRecursively(dynamicStringBuilder);

            if (isPalindrome)
            {
                Console.WriteLine("The input is a palindrome.");
            }
            else
            {
                Console.WriteLine("The input is not a palindrome.");
            }
            if (IsDigit(userInput))
            {
                if (DivBy4(userInput))
                {
                    Console.WriteLine("The number is divisible by 4.");
                }
                else
                {
                    Console.WriteLine("The number is not divisible by 4.");
                }
            }
            if (IsLetter(userInput))
            {
                Console.WriteLine("The amount of upper case letters in the input is " + AmountOfUpperCase(userInput));
            }
            Console.Read();
        }
        public static Boolean CheckPalindromeRecursively(StringBuilder i_DynamicStringBuilder)
        {
            if (i_DynamicStringBuilder.Length == 0)
            {
                return true;
            }
            else if (i_DynamicStringBuilder[0] != i_DynamicStringBuilder[i_DynamicStringBuilder.Length - 1])
            {
                return false;
            }
            i_DynamicStringBuilder.Remove(0, 1);
            i_DynamicStringBuilder.Remove(i_DynamicStringBuilder.Length - 1, 1);

            return CheckPalindromeRecursively(i_DynamicStringBuilder);
        }
        public static string GetUserInput()
        {
            string outputString = "";
            Boolean validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Please enter a valid word with 8 characters");
                outputString = Console.ReadLine();
                if (outputString.Length != 8)
                {
                    Console.WriteLine("Invalid input, the length is not 8 characters");
                }
                else if (IsDigit(outputString) || IsLetter(outputString))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }

            return outputString;
        }
        public static Boolean IsDigit(string i_InputString)
        {
            for (int i = 0; i < i_InputString.Length; i++)
            {
                if (!(i_InputString[i] <= '9' && i_InputString[i] >= '0'))
                {
                    return false;
                }
            }

            return true;
        }
        public static Boolean IsLetter(string i_InputString)
        {
            for (int i = 0; i < i_InputString.Length; i++)
            {
                if (!((i_InputString[i] >= 'a' && i_InputString[i] <= 'z') || (i_InputString[i] >= 'A' && i_InputString[i] <= 'Z')))
                {
                    return false;
                }
            }

            return true;
        }
        public static Boolean DivBy4(string i_strInput)
        {
            if ((Int32.Parse(i_strInput) % 4) == 0)
            {
                return true;
            }

            return false;
        }
        public static int AmountOfUpperCase(string i_strInput)
        {
            int amount = 0;
            for (int i = 0; i < i_strInput.Length; i++)
            {
                if (i_strInput[i] >= 'A' && i_strInput[i] <= 'Z')
                {
                    amount += 1;
                }
            }

            return amount;
        }
    }
}
