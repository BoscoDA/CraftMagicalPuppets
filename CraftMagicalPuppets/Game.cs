using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static CraftMagicalPuppets.Utility;

namespace CraftMagicalPuppets
{
    public class Game
    {
        public Player CurrentPlayer;
        private Store store = new Store();
        public string GameTitle;
        public bool ContinuePlay = true;
        

        public Game()
        {
            GameTitle = "Puppet Crafter";
            Title = GameTitle;
            Print = PrintCommandLine;
        }
        public void StartGame()
        {
            Write("Please enter your name: ");
            string nameResponse = ReadLine();
            CurrentPlayer = new Player(nameResponse);
            Print($"Welcome to {GameTitle}, {CurrentPlayer.DisplayName()}\n");
            ReadKey();
            while (ContinuePlay)
            {

                string text = "Would you like to....";
                List<string> mainMenuOptions = new List<string>{ "View Inventroy", "View Recipies", "Craft Puppet", "Shop", "Exitgame" };
                Menu mainMenu = new Menu(text, mainMenuOptions);
                int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
                switch (mainMenuSelectedIndex)
                {
                    case 0:
                        CurrentPlayer.ViewInventory();
                        Clear();
                        break;
                    case 1:
                        CurrentPlayer.ViewRecipes();
                        Clear();
                        break;
                    case 2:
                        CurrentPlayer.CraftPuppet();
                        Clear();
                        break;
                    case 3:
                        store.Start(CurrentPlayer);
                        Clear();
                        break;
                    case 4:
                        ContinuePlay = false;
                        Clear();
                        Print("See you next time!");
                        ReadKey();
                        break;
                    default:
                        Print("Please enter a valid option.");
                        ReadKey();
                        Clear();
                        break;

                }
            }
        }
    }
}