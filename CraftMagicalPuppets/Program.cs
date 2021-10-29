using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CraftMagicalPuppets
{
    class Program
    {
        static void Main(string[] args)
        {
            CursorVisible = false;
            int Height = 50;
            int Width = 100;

            try
            {
                SetWindowSize(Width, Height);
            }
            catch
            {
                WriteLine("Cannot create a big enough console window.");
                WriteLine("Try adjusting your font/console settings and restarting.");
                WriteLine("You can continue playing, just be aware that some art might not render properly!");
                Utility.WaitForKey();
            }
            Game game = new Game();
            game.StartGame();
        }
    }
}
