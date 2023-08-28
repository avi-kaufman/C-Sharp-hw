using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex02
{
    public class Program
    {
        public static void Main()
        {
            Game game = new Game();
            do
            {
                game.PlayGame();
            } while (game.m_ContinuePlayFlag);
        }
    }
}
