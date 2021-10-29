using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CraftMagicalPuppets.Utility;

namespace CraftMagicalPuppets
{
    class Person
    {
        private string name = "Anonymous Player";
        private decimal money = 0.00M;
        private List<Item> inventory = new List<Item>();

        protected string Name { get => name; set => name = value; }
        public decimal Money { get => money; set => money = value; }
        public List<Item> Inventory { get => inventory; set => inventory = value; }

        public string DisplayName()
        {
            return Name;
        }
        public string ViewInventory()
        {
            WriteLine("Viewing Inventory...\n");
            string output = "";
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i] is Material)
                {
                    Material m = (Material)Inventory[i];
                    output += $"{m.DisplayMaterial()}\n";
                }
                if (Inventory[i] is Puppet)
                {
                    Puppet p = (Puppet)Inventory[i];
                    output += $"{p.Display()}\n";
                }
            }
            return output;
        }
    }
}
