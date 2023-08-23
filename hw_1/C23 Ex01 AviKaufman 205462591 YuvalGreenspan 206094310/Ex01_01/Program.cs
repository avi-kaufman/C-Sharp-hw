using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    internal class Program
    {
        public static void Main()
        {
            int firstBinaryNumber = GetValidBinaryNumber();
            int secondBinaryNumber = GetValidBinaryNumber();
            int thirdBinaryNumber = GetValidBinaryNumber();

            Console.WriteLine("The Decimal Numbers are: " + BinaryToDecimal(firstBinaryNumber) + ", " + BinaryToDecimal(secondBinaryNumber) + ", " + BinaryToDecimal(thirdBinaryNumber));

            double averageNumberOfZeros = (CountZeros(firstBinaryNumber) + CountZeros(secondBinaryNumber) + CountZeros(thirdBinaryNumber)) / 3.0;
            double averageNumberOfOnes = (CountOnes(firstBinaryNumber) + CountOnes(secondBinaryNumber) + CountOnes(thirdBinaryNumber)) / 3.0;
            Console.WriteLine("Average Number of zeros is " + averageNumberOfZeros + " and the average number of ones is " + averageNumberOfOnes);

            int amountOfPowersOfTwoNumbers = CountPowerOfTwo(firstBinaryNumber) + CountPowerOfTwo(secondBinaryNumber) + CountPowerOfTwo(thirdBinaryNumber);
            Console.WriteLine("" + amountOfPowersOfTwoNumbers + " Of them are powers of two");

            int amountOfRisingSeriesNumbers = CountRisingSeries(BinaryToDecimal(firstBinaryNumber)) + CountRisingSeries(BinaryToDecimal(secondBinaryNumber)) + CountRisingSeries(BinaryToDecimal(thirdBinaryNumber));
            Console.WriteLine("" + amountOfRisingSeriesNumbers + " Of them are rising series numbers");

            Console.WriteLine("The biggest number is " + FindMaxNumber(firstBinaryNumber, secondBinaryNumber, thirdBinaryNumber) + " and the smallest number is " + FindMinNumber(firstBinaryNumber, secondBinaryNumber, thirdBinaryNumber));
            Console.WriteLine("Please press enter to close the console...");
            Console.ReadLine();
        }

        public static bool IsValidBinaryNumber(string i_BinaryNumber)
        {
            if (i_BinaryNumber.Length != 7)
            {
                return false;
            }

            for (int i = 0; i < 7; i++)
            {
                if (i_BinaryNumber[i] != '0' && i_BinaryNumber[i] != '1')
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetValidBinaryNumber()
        {
            Console.WriteLine("Enter a binary number with 7 digits.");
            bool isValid = false;
            string binaryNumber = "";

            while (!isValid)
            {
                binaryNumber = Console.ReadLine();
                if (!IsValidBinaryNumber(binaryNumber))
                {
                    Console.WriteLine("Number is invalid. Please enter a new number");
                }
                else
                {
                    isValid = true;
                }
            }

            return int.Parse(binaryNumber);
        }

        public static int BinaryToDecimal(int i_BinaryNumber)
        {
            int decimalNumber = 0;
            for (int i = 0; i < 7; i++)
            {
                decimalNumber += (int)Math.Pow(2, i) * (i_BinaryNumber % 10);
                i_BinaryNumber /= 10;
            }

            return decimalNumber;
        }

        public static int CountZeros(int i_BinaryNumber)
        {
            int zeroCount = 7;
            for (int i = 0; i < 7; i++)
            {
                zeroCount -= i_BinaryNumber % 10;
                i_BinaryNumber /= 10;
            }

            return zeroCount;
        }

        public static int CountOnes(int i_BinaryNumber)
        {
            return 7 - CountZeros(i_BinaryNumber);
        }

        public static int CountPowerOfTwo(int i_BinaryNumber)
        {
            return ConvertBooleanToInt(CountOnes(i_BinaryNumber) == 1);
        }

        public static int CountRisingSeries(int i_DecimalNumber)
        {
            int currentDigit;
            while (i_DecimalNumber > 0)
            {
                currentDigit = i_DecimalNumber % 10;
                i_DecimalNumber /= 10;
                if (currentDigit < i_DecimalNumber % 10)
                {
                    return 0;
                }
            }

            return 1;
        }

        public static int FindMaxNumber(int i_FirstNumber, int i_SecondNumber, int i_ThirdNumber)
        {
            return Math.Max(Math.Max(BinaryToDecimal(i_FirstNumber), BinaryToDecimal(i_SecondNumber)), BinaryToDecimal(i_ThirdNumber));
        }

        public static int FindMinNumber(int i_FirstNumber, int i_SecondNumber, int i_ThirdNumber)
        {
            return Math.Min(Math.Min(BinaryToDecimal(i_FirstNumber), BinaryToDecimal(i_SecondNumber)), BinaryToDecimal(i_ThirdNumber));
        }

        public static int ConvertBooleanToInt(bool i_BooleanValue)
        {
            if (i_BooleanValue)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
