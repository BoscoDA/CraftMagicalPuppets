using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftMagicalPuppets
{
    class Menus
    {
        public static Recipe CraftPuppetMenu(List<Recipe> recipes)
        {
            string text = "What puppet would you like to craft?";
            List<string> mainMenuOptions = new List<string>();
            foreach (Recipe r in recipes)
            {
                mainMenuOptions.Add(r.Name);
            }
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            return recipes[mainMenuSelectedIndex];
        }
        public static int StoreMenu()
        {
            string text = "Would you like to.... ";
            List<string> mainMenuOptions = new List<string> { "Sell Puppet", "Buy Materials", "Exit Store" };
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            return mainMenuSelectedIndex;
        }
        public static Puppet SellPuppetMenu(Player player)
        {
            List<Puppet> puppets = Utility.FindAllPuppets(player.Inventory);
            List<string> mainMenuOptions = new List<string>();
            foreach (Puppet p in puppets)
            {
                mainMenuOptions.Add($"{p.Name} Value: {p.SellValue()}");
            }
            string text = ("What puppet do you want to sell?");
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            Puppet puppet = (Puppet)Utility.FindItem(player.Inventory, puppets[mainMenuSelectedIndex]);
            return puppet;
        }
        public static Material BuyMaterialMenu(Player player, StoreKeeper storeKeeper)
        {
            string text = $"Player's Wallet: {player.Money.ToString("c")}\n\nWhat would you like to buy?";
            List<string> mainMenuOptions = new List<string>();
            foreach (Item i in storeKeeper.Inventory)
            {
                mainMenuOptions.Add($"{i.Name}{i.Description} Price: {i.Value} Quantity: {i.Quantity}");
            }
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            Material m = (Material)storeKeeper.Inventory[mainMenuSelectedIndex];
            return m;
        }
    }
}
