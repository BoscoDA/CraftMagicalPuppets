using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CraftMagicalPuppets.Utility;

namespace CraftMagicalPuppets
{
    class Store
    {
        StoreKeeper storeKeeper = new StoreKeeper();
        public Store()
        {
            Print = PrintCommandLine;
        }
        public void Start(Player player)
        {
            string text = "Would you like to.... ";
            List<string> mainMenuOptions = new List<string> { "Sell Puppet", "Buy Materials", "Exit Store" };
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            switch (mainMenuSelectedIndex)
            {
                case 0:
                    SellPuppet(player);
                    break;

                case 1:
                    Buymaterial(player);
                    break;
                case 2:
                    break;
            }
        }
        private void SellPuppet(Player player)
        {
            List<Puppet> puppets = new List<Puppet>();
            foreach (Item i in player.Inventory)
            {
                if (i is Puppet)
                {
                    Puppet p = (Puppet)i;
                    puppets.Add(p);
                }
            }
            if (puppets.Count > 0)
            {
                List<string> mainMenuOptions = new List<string>();
                foreach (Puppet p in puppets)
                {
                    mainMenuOptions.Add($"{p.Name} Value: {p.SellValue()}");
                }
                string text = ("What puppet do you want to sell?");
                Menu mainMenu = new Menu(text, mainMenuOptions);
                int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
                if(storeKeeper.Money >= puppets[mainMenuSelectedIndex].Value)
                {
                    foreach (Item i in player.Inventory)
                    {
                        if (puppets[mainMenuSelectedIndex].Name.ToLower() == i.Name.ToLower()) 
                        {
                            player.Money += puppets[mainMenuSelectedIndex].SellValue();
                            storeKeeper.Money -= puppets[mainMenuSelectedIndex].SellValue();
                            player.Inventory.Remove(i); 
                            break; 
                        };
                    }
                }
                else
                {
                    WriteLine("Store keeper does not have enough money to buy this.");
                }
                
            }
            else
            {
                WriteLine("You have no puppets to sell right now. Come back when you have crafted one.");
                ReadKey();
            }

        }
        private void Buymaterial(Player player)
        {
            string text = "Would you like to buy.... ";
            List<string> mainMenuOptions = new List<string>();
            foreach (Item i in storeKeeper.Inventory)
            {
                mainMenuOptions.Add($"{i.Name}{i.Description} Price: {i.Value} Quantity: {i.Quantity}");
            }
            if(mainMenuOptions.Count == 0)
            {
                Print("Sold Out!");
            }
            else
            {
                Menu mainMenu = new Menu(text, mainMenuOptions);
                int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
                Print($"How many {storeKeeper.Inventory[mainMenuSelectedIndex].Name} would you like to buy?");
                int quantity = Convert.ToInt32(ReadLine().Trim().ToLower());
                if (quantity <= storeKeeper.Inventory[mainMenuSelectedIndex].Quantity & player.Money >= storeKeeper.Inventory[mainMenuSelectedIndex].Value)
                {
                    Print("Item Pruchased!");
                    storeKeeper.Money += storeKeeper.Inventory[mainMenuSelectedIndex].Value;
                    player.Money -= storeKeeper.Inventory[mainMenuSelectedIndex].Value;
                    if (FindItem(player.Inventory, storeKeeper.Inventory[mainMenuSelectedIndex]) == null)
                    {
                        player.Inventory.Add(storeKeeper.Inventory[mainMenuSelectedIndex]);
                    }
                    else
                    {
                        FindItem(player.Inventory, storeKeeper.Inventory[mainMenuSelectedIndex]).Quantity += quantity;
                    }
                    FindItem(storeKeeper.Inventory, storeKeeper.Inventory[mainMenuSelectedIndex]).Quantity -= quantity;
                    if (FindItem(storeKeeper.Inventory, storeKeeper.Inventory[mainMenuSelectedIndex]).Quantity == 0)
                    {
                        storeKeeper.Inventory.Remove(FindItem(storeKeeper.Inventory, storeKeeper.Inventory[mainMenuSelectedIndex]));
                    }
                    
                }
                else
                {
                    if(player.Money < storeKeeper.Inventory[mainMenuSelectedIndex].Value)
                    {
                        Print("You do not have the money to buy that!");
                    }
                    else
                    {
                        Print($"{storeKeeper.DisplayName()} doesn't have that many {storeKeeper.Inventory[mainMenuSelectedIndex].Name}.");
                    }
                }
            }
            ReadKey();
        }
    }
}
