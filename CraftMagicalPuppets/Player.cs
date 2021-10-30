using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.IO;
using static CraftMagicalPuppets.Utility;


namespace CraftMagicalPuppets
{
    class Player : Person

    {
        private string RecipePath = "../../Data/recipes.xml";

        private List<Recipe> recipes = new List<Recipe>();
        public List<Recipe> Recipes { get => recipes; set => recipes = value; }

        public Player(string name)
        {
            if (name != "")
            {
                Name = name;
            }
            Inventory = DataLoader.LoadMaterialsXML(RecipePath);
            Recipes = DataLoader.LoadRecipesXML(RecipePath);
            Clear();
        }
        public string ViewRecipes()
        {
            string output = "";
            output += $"Viewing Recipes...\n";
            foreach (Recipe recipe in Recipes)
            {
                output += recipe.DisplayFullRecipe();
            }
            return output;
        }
        public string CraftPuppet(Recipe recipe)
        {
            string output = "";
            bool inInventory = false;
            foreach (Material item in recipe.recipe)
            {
                inInventory = Inventory.Exists(x => $"{x.Name}{x.Description}" == $"{item.Name}{item.Description}");
                if (inInventory == false)
                {
                    break;
                }
            }
            if (inInventory == true)
            {
                Puppet puppet = new Puppet(recipe.Name, recipe.Name);
                Inventory.Add(puppet);
                output += "Puppet crafted!";
                foreach (Material item in recipe.recipe)
                {
                    if (Inventory.Exists(x => $"{x.Name}{x.Description}" == $"{item.Name}{item.Description}"))
                    {
                        Material m = (Material)FindItem(Inventory, item);
                        puppet.Value += m.Value * item.Quantity;
                        m.Quantity = m.Quantity - item.Quantity;
                        RemoveItem(m, Inventory);
                    }
                }
            }
            else
            {
                output += "You do not have the materials to build that puppet!";
            }
            return output;
        }
        public string ViewPuppets()
        {
            string output = "";
            List<Puppet> puppets = new List<Puppet>();
            foreach (Item i in Inventory)
            {
                if (i is Puppet)
                {
                    Puppet p = (Puppet)i;
                    puppets.Add(p);
                }
            }
            if(puppets.Count > 0)
            {
                List<string> mainMenuOptions = new List<string>();
                foreach (Puppet p in puppets)
                {
                    mainMenuOptions.Add(p.Display());
                }
                string text = ("What puppet do you want to interact with?");
                Menu mainMenu = new Menu(text, mainMenuOptions);
                int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
                output += $"{puppets[mainMenuSelectedIndex].Talk()}";
            }
            else { output = "You do not have any puppets at this time."; };
            return output;
        }
    }
}
