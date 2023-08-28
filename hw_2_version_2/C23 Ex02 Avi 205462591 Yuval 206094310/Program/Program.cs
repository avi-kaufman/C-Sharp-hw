using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Game game = new Game();
                game.PlayGame();
            } while (game.continuePlayFlag);
        }
    }
}
