using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.IO;


namespace CraftMagicalPuppets
{
    public class Player
    
    {
        private string Name;
        public string RecipePath = "Recipes.txt";
        public string MaterialList = "Materials.txt";
        public string InventoryPath = "Inventory.txt";
        public List<Item> inventory = new List<Item>();
        List<Recipe> recipes = new List<Recipe>();

        public Player(string name)
        {
            Name = name;
            string[] inventoryLines = File.ReadAllLines(MaterialList);
            for (int i = 0; i < inventoryLines.Length; i += 2)
            {
                string itemName = inventoryLines[i];
                Material material = new Material(itemName);
                inventory.Add(material);
            }
            string[] recipeLines = File.ReadAllLines(RecipePath);
            for (int i = 0; i < recipeLines.Length; i += 3)
            {
                string recipeName = recipeLines[i];
                string itemInfo = recipeLines[i + 1];
                string[] recipeParts = itemInfo.Split(',');
                List<string> final = recipeParts.ToList();
                Recipe recipe = new Recipe(recipeName, final);
                recipes.Add(recipe);

            }
            Clear();
        }
        public string DisplayName()
        {
            return Name;
        }
        public void ViewRecipes()
        {
            Clear();
            WriteLine("Viewing Recipes...");

            foreach (Recipe recipe in recipes)
            {
                recipe.Display();
            }
            Clear();

            WriteLine("What puppet would you like to craft?");
            int response = Convert.ToInt32(ReadLine().Trim());
            CraftPuppet(recipes[response]);

        }

        public void ViewInventory()
        {
            Clear();
            WriteLine("Viewing Inventory...");
            foreach (Item item in inventory)
            {
                WriteLine(item.Name);
            }
            ReadKey();
            Clear();
        }


        public void CraftPuppet(Recipe recipe)
        {
            bool inInventory = false;
            foreach (string item in recipe.recipe)
            {
                inInventory = inventory.Exists(x => x.Name == item);
                if(inInventory == false)
                {
                    break;
                }
            }
            if (inInventory == true)
            {
                foreach (string item in recipe.recipe)
                {
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (item.ToString().ToLower().Trim() == inventory[i].Name.ToString().ToLower().Trim())
                        {
                            inventory.RemoveAt(i);
                            break;
                        }
                    }
                }
                Write("Name Puppet: ");
                string namePup = ReadLine().Trim();
                Puppet puppet = new Puppet(namePup, recipe.Name);
                inventory.Add(puppet);
            }
            else
            {
                WriteLine("You do not have the materials to build that puppet!");
            }
            ReadKey();
        }
    }
}
