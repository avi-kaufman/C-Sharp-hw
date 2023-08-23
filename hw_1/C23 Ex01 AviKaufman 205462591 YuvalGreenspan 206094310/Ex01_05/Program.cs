using System;
using Ex01_04;

namespace Ex01_05
{
    internal class Program
    {
        public static void Main()
        {
            string userInput = GetValidString();
            Console.WriteLine("The number of digits that are greater than the unit digit is " + CountDigitsGreaterThanUnit(userInput));
            Console.WriteLine("The smallest digit is " + FindSmallestDigit(userInput));
            Console.WriteLine("The count of digits that are divisible by 3 is " + CountDivisibleBy3(userInput));
            Console.WriteLine("The average of digits is " + CalculateAverageDigits(userInput));
            Console.Read();
        }

        public static string GetValidString()
        {
            bool validInput = false;
            string strInput = "";

            while (!validInput)
            {
                Console.WriteLine("Please enter a non negativ integer with 6 digits.");
                strInput = Console.ReadLine();
                if (strInput.Length != 6)
                {
                    Console.WriteLine("Input invalid, please try again.");
                }
                else if (Ex01_04.Program.IsDigit(strInput))
                {
                    if (Int32.Parse(strInput) < 0)
                    {
                        Console.WriteLine("Invalid input , please try again.");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input , please try again");
                }
            }

            return strInput;
        }

        public static int FindSmallestDigit(string i_InputString)
        {
            char smallestDigit = i_InputString[0];
            int smallestDigitAsInt = 0;
            for (int i = 1; i < i_InputString.Length; i++)
            {
                if (i_InputString[i] <= smallestDigit)
                {
                    smallestDigit = i_InputString[i];
                }
            }
            smallestDigitAsInt = smallestDigit - '0';

            return smallestDigitAsInt;
        }

        public static double CalculateAverageDigits(string i_InputString)
        {
            double sumOfDigits = 0;
            for (int i = 0; i < i_InputString.Length; i++)
            {
                sumOfDigits += (i_InputString[i] - '0');
            }

            return sumOfDigits / i_InputString.Length;
        }

        public static int CountDivisibleBy3(string i_InputString)
        {
            int divisibleByThreeDigits = 0;
            for (int i = 0; i < i_InputString.Length; i++)
            {
                if ((i_InputString[i] - '0') % 3 == 0)
                {
                    divisibleByThreeDigits++;
                }
            }

            return divisibleByThreeDigits;
        }

        public static int CountDigitsGreaterThanUnit(string i_InputString)
        {
            int unitDigit = i_InputString[i_InputString.Length - 1] - '0';
            int digitsGreaterThanUnit = 0;
            for (int i = 0; i < i_InputString.Length - 1; i++)
            {
                if ((i_InputString[i] - '0') > unitDigit)
                {
                    digitsGreaterThanUnit++;
                }
            }

            return digitsGreaterThanUnit;
        }
    }
}
