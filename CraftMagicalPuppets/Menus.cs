using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftMagicalPuppets
{
    public class Menus
    {
        public static int CraftPuppetMenu(List<Recipe> recipes)
        {
            string text = "What puppet would you like to craft?";
            List<string> mainMenuOptions = new List<string>();
            foreach (Recipe r in recipes)
            {
                mainMenuOptions.Add(r.Name);
            }
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            return mainMenuSelectedIndex;
        }
    }
}
