using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            HourGlassPattern(5);
            Console.Read();
        }

        public static void HourGlassPattern(int i_NumStars, int i_NumSpaces = 0, bool i_IsFirstHalf = true)
        {
            string spaceString = new string(' ', i_NumSpaces);
            string starString = new string('*', i_NumStars);

            if (starString != "")
            {
                Console.WriteLine(spaceString + starString + spaceString);
            }

            if (i_NumStars > 1 && i_IsFirstHalf)
            {
                HourGlassPattern(i_NumStars - 2, i_NumSpaces + 1, true);
            }
            else if (i_NumSpaces > 0)
            {
                HourGlassPattern(i_NumStars + 2, i_NumSpaces - 1, false);
            }
        }
    }
}
