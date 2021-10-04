using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftMagicalPuppets
{
    public class Recipe
    {
        public List<string> recipe;
        public string Name;
        public Recipe(string name, List<string> items)
        {
            recipe  = items;
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine(Name);
            foreach (string i in recipe)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

    }
}
