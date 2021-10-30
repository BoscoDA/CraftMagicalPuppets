using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftMagicalPuppets
{
    class Utility
    {
        public delegate void PrintOption(string message);
        public static PrintOption Print;

        public static Item FindItem(List<Item> items, Item item)
        {
            Item output = null;
            foreach (Item i in items)
            {
                if($"{i.Name}{i.Description}" == $"{item.Name}{item.Description}")
                {
                    output = i;
                    break;
                }
            }
            return output;
        }
        public static Material FindRecipe(List<Material> recipes, string find)
        {
            Material output = null;
            foreach (Material i in recipes)
            {
                if (i.Name.ToLower() == find)
                {
                    output = i;
                    break;
                }
            }
            return output;
        }
        public static Random Probability = new Random();
        public static void PrintCommandLine(string message)
        {
            Console.WriteLine(message);
        }
        public static void WaitForKey()
        {
            Console.WriteLine("(Press any key to continue...)");
            Console.ReadKey();
        }
        public static void RemoveItem(Item item, List<Item> items)
        {
            if (item.Quantity == 0)
            {
                items.Remove(FindItem(items, item));
            }
        }
        public static List<Puppet> FindAllPuppets(List<Item> items)
        {
            List<Puppet> puppets = new List<Puppet>();
            foreach (Item i in items)
            {
                if (i is Puppet)
                {
                    Puppet p = (Puppet)i;
                    puppets.Add(p);
                }
            }
            return puppets;
        }
    }
}
