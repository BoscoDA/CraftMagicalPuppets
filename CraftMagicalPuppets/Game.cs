using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using static CraftMagicalPuppets.Utility;

namespace CraftMagicalPuppets
{
    class Game
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
                MainMenu();
            }
        }
        private void MainMenu()
        {
            string text = "Would you like to....";
            List<string> mainMenuOptions = new List<string> { "View Inventroy", "View Recipies", "Craft Puppet", "Shop", "View Puppets", "Exitgame" };
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            switch (mainMenuSelectedIndex)
            {
                case 0:
                    Clear();
                    Print(CurrentPlayer.ViewInventory());
                    WaitForKey();
                    break;
                case 1:
                    Clear();
                    Print(CurrentPlayer.ViewRecipes());
                    WaitForKey();
                    break;
                case 2:
                    Clear();
                    Print(CurrentPlayer.CraftPuppet());
                    WaitForKey();
                    break;
                case 3:
                    Clear();
                    store.Start(CurrentPlayer);
                    break;
                case 4:
                    Clear();
                    CurrentPlayer.ViewPuppets();
                    break;
                case 5:
                    ContinuePlay = false;
                    Clear();
                    Print("See you next time!");
                    WaitForKey();
                    break;
                default:
                    Print("Please enter a valid option.");
                    WaitForKey();
                    break;
            }
        }
    }
}