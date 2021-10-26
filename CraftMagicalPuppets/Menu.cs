using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CraftMagicalPuppets
{
    class Menu
    {
        private int SelectedIndex;
        private List<string> Options;
        private string Prompt;

        public Menu(string prompt, List<string> options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
            CursorVisible = false;
        }

        private void DisplayOptions(ConsoleColor color = ConsoleColor.White)
        {
            ForegroundColor = color;
            WriteLine(Prompt);

            for (int i = 0; i < Options.Count; i++)
            {
                string currentOption = Options[i];
                string prefix;

                if (i == SelectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;

                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine($"{prefix} << {currentOption} >>");
            }
            ResetColor();
        }

        public int Run(ConsoleColor color = ConsoleColor.White)
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions(color);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // Update SelectedIndex based on arrow keys.
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Count - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Count)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }
    }
}
