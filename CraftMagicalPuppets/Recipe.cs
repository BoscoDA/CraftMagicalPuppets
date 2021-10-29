using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static CraftMagicalPuppets.Utility;

namespace CraftMagicalPuppets
{
    public class Recipe
    {
        public List<Material> recipe;
        public string Name;
        public Recipe(string name, List<Material> items)
        {
            recipe = items;
            Name = name;
            Print = PrintCommandLine;
        }
        public string DisplayFullRecipe()
        {
            string output = "";
            output += $"\n{Name}\n";
            foreach (Material i in recipe)
            {
                output += $">{i.DisplayMaterial()}\n";
            }
            return output;
        }
        public string DisplayRecipeName()
        {
            return Name;
        }
    }
}
