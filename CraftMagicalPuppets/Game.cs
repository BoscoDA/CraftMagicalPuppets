using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace CraftMagicalPuppets
{
    public class Game
    {
        public Player CurrentPlayer;
        public string GameTitle;
        public bool ContinuePlay = true;

        public Game()
        {
            GameTitle = "Puppet Crafter";

        }
        public void StartGame()
        {
            Write("Please enter your name: ");
            string nameResponse = ReadLine();
            CurrentPlayer = new Player(nameResponse);

            WriteLine($"Welcome to {GameTitle}, {CurrentPlayer.DisplayName()}\n");

            while (ContinuePlay)
            {
                WriteLine("Would you like to.... (Enter Number That Corrisponds To The Option You Want)");
                WriteLine("1) View Inventory");
                WriteLine("2) View Recipies\n");
                string playerResponse = ReadLine();
                int playResponse = Convert.ToInt32(playerResponse);
                switch (playResponse)
                {
                    case 1:
                        CurrentPlayer.ViewInventory();
                        break;

                    case 2:
                        CurrentPlayer.ViewRecipes();
                        break;
                    default:
                        WriteLine("Please enter a valid option.");
                        ReadKey();
                        break;
                        
                }

            }


        }
    }
}