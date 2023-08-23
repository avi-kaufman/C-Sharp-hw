using System;

namespace Ex01_03
{
    internal class Program
    {
        public static void Main()
        {
            AdvancedHourglassPattern();
            Console.Read();
        }

        public static void AdvancedHourglassPattern()
        {
            int requestedHeight;
            bool validInputReceived = false;

            while (!validInputReceived)
            {
                Console.WriteLine("Please enter a valid height for the hourglass.");
                string inputHeight = Console.ReadLine();

                if (int.TryParse(inputHeight, out requestedHeight))
                {
                    Ex01_02.Program.HourGlassPattern(requestedHeight);
                    validInputReceived = true;
                }
            }
        }
    }
}
