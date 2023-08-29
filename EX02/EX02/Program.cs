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
            } while (game.ContinuePlay);
        }
    }
}
