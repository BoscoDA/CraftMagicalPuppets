using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace CraftMagicalPuppets
{
    class DataLoader
    {
        public static List<Recipe> LoadRecipesXML(string fileName)
        {
            List<Recipe> Recipes = new List<Recipe>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode root = doc.DocumentElement;
            XmlNodeList recipeList = root.SelectNodes("/recipes/recipe");
            XmlNodeList ingredientsList;

            foreach (XmlElement recipe in recipeList)
            {
                List<Material> materialToAdd = new List<Material>();
                Recipe recipeToAdd = new Recipe(recipe.GetAttribute("Name"), materialToAdd);
                ingredientsList = recipe.ChildNodes;

                foreach (XmlElement i in ingredientsList)
                {
                    string materialName = i.GetAttribute("Name");
                    string materialDescription = i.GetAttribute("Description");
                    string materialAmountString = i.GetAttribute("Quantity");
                    int materialAmount = 0;
                    if (int.TryParse(materialAmountString, out int e))
                    { materialAmount = e; }
                    string materialValueString = i.GetAttribute("Value");
                    decimal materialValue = 0;
                    if (decimal.TryParse(materialValueString, out decimal ingValue))
                    { materialValue = ingValue; }

                    materialToAdd.Add(new Material(materialName, materialAmount, materialDescription, materialValue));
                }
                Recipes.Add(recipeToAdd);
            }
            return Recipes;
        }
        public static List<Item> LoadMaterialsXML(string fileName)
        {
            List<Item> Inventory = new List<Item>();
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode root = doc.DocumentElement;
            XmlNodeList recipeList = root.SelectNodes("/recipes/recipe");
            XmlNodeList ingredientsList;

            foreach (XmlElement recipe in recipeList)
            {
                ingredientsList = recipe.ChildNodes; //for ingredients

                foreach (XmlElement i in ingredientsList)
                {
                    string materialName = i.GetAttribute("Name");
                    string materialDescription = i.GetAttribute("Description");
                    string materialAmountString = i.GetAttribute("Quantity");
                    int materialAmount = 0;
                    if (int.TryParse(materialAmountString, out int e))
                    { materialAmount = e; }
                    string materialValueString = i.GetAttribute("Value");
                    decimal materialValue = 0;
                    if (decimal.TryParse(materialValueString, out decimal ingValue))
                    { materialValue = ingValue; }
                    Material temp = new Material(materialName, materialAmount, materialDescription, materialValue);
                    if (Inventory.Contains(Utility.FindItem(Inventory, temp)) == true )
                    {
                        Utility.FindItem(Inventory, temp).Quantity += temp.Quantity;
                    }
                    else
                    {
                        Inventory.Add(temp);
                    }
                }
            }
            return Inventory;
        }
    }
}
