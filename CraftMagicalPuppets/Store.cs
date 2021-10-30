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
        public string ConsoleStart(Player player)
        {
            switch (Menus.StoreMenu())
            {
                case 0:
                    if (FindAllPuppets(player.Inventory).Count == 0)
                    {
                        return "You have no puppets to sell right now. Come back when you have crafted one.";
                    }
                    else { return SellPuppet(player, Menus.SellPuppetMenu(player)); }
                case 1:
                    if (storeKeeper.Inventory.Count == 0)
                    {
                        return "Sold Out!";
                    }
                    else
                    {
                        return Buymaterial(player, Menus.BuyMaterialMenu(player,storeKeeper));
                    }
                case 2:
                    return $"See you next time {player.DisplayName()}";
            }
            return "That was not supposed to happen...";
        }
        private string SellPuppet(Player player, Puppet puppet)
        {
            if (storeKeeper.Money >= puppet.Value)
            {
                foreach (Item i in player.Inventory)
                {
                    if (player.Inventory.Exists(x => x.Name == puppet.Name))
                    {
                        player.Money += puppet.SellValue();
                        storeKeeper.Money -= puppet.SellValue();
                        player.Inventory.Remove(i);
                        break;
                    };
                }
                return $"{puppet.Name} has been sold!";
            }
            else { return "Store keeper does not have enough money to buy this."; }
        }
        private string Buymaterial(Player player, Material material)
        {
            int quantity = BuyInputConsole(material);
            if (quantity <= material.Quantity & player.Money >= material.Value * quantity)
            {
                storeKeeper.Money += material.Value * quantity;
                player.Money -= material.Value * quantity;
                if (FindItem(player.Inventory, material) == null)
                {
                    player.Inventory.Add(new Material(material.Name, quantity, material.Description, material.Value));
                }
                else
                {
                    FindItem(player.Inventory, material).Quantity += quantity;
                }
                FindItem(storeKeeper.Inventory, material).Quantity -= quantity;
                if (FindItem(storeKeeper.Inventory, material).Quantity == 0)
                {
                    storeKeeper.Inventory.Remove(FindItem(storeKeeper.Inventory, material));
                }
                return "Item purchased!";
            }
            else
            {
                if (player.Money < material.Value)
                {
                    return "You do not have the money to buy that!";
                }
                else
                {
                    return $"{storeKeeper.DisplayName()} doesn't have that many {material.Name}.";
                }
            }
        }
        private int BuyInputConsole(Material material)
        {
            Print($"How many {material.Name} would you like to buy?");
            int quantity = Convert.ToInt32(ReadLine().Trim().ToLower());
            return quantity;
        }
        private int BuyInputWPF()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
