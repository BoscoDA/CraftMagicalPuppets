using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.IO;
using static CraftMagicalPuppets.Utility;


namespace CraftMagicalPuppets
{
    public class Player : Person
    
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
        public void ViewRecipes()
        {
            Clear();
            WriteLine("Viewing Recipes...");

            foreach (Recipe recipe in Recipes)
            {
                recipe.DisplayFullRecipe();
            }
            WaitForKey();
        }
        public void CraftPuppet()
        {
            string text = "What puppet would you like to craft?";
            List<string> mainMenuOptions = new List<string>();
            foreach (Recipe r in Recipes)
            {
                mainMenuOptions.Add(r.Name);
            }
            Menu mainMenu = new Menu(text, mainMenuOptions);
            int mainMenuSelectedIndex = mainMenu.Run(ConsoleColor.Red);
            bool inInventory = false;
            foreach (Material item in Recipes[mainMenuSelectedIndex].recipe)
            {
                foreach (Item i in Inventory)
                {
                    if ($"{i.Name.ToLower()}{i.Description.ToLower()}" == $"{item.Name.ToLower()}{item.Description.ToLower()}" & i.Quantity >= item.Quantity)
                    {
                        inInventory = true;
                        break;
                    }
                }
                if (inInventory == false)
                {
                    break;
                }
            }
            if (inInventory == true)
            {
                Puppet puppet = new Puppet(Recipes[mainMenuSelectedIndex].Name, Recipes[mainMenuSelectedIndex].Name);
                Inventory.Add(puppet);
                WriteLine("Puppet crafted!");
                foreach (Material item in Recipes[mainMenuSelectedIndex].recipe)
                {
                    for (int i = 0; i < Inventory.Count; i++)
                    {
                        if ($"{Inventory[i].Name.ToLower()}{Inventory[i].Description.ToLower()}" == $"{item.Name.ToLower()}{item.Description.ToLower()}")
                        {
                            Material m = (Material)Inventory[i];
                            puppet.Value += m.Value;
                            m.Quantity = m.Quantity - item.Quantity;
                            if (m.Quantity == 0)
                            {
                                Inventory.Remove(Inventory[i]);
                            }
                            break;
                        }
                    }
                } 
            }
            else
            {
                WriteLine("You do not have the materials to build that puppet!");
            }
            WaitForKey();
        }
    }
}
