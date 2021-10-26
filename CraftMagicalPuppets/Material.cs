using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftMagicalPuppets
{
    public class Material : Item
    {

        public Material(string name, int quantity, string description, decimal value)
        {
            Quantity = quantity;
            Description = description;
            Name = name;
            Value = value;
        }


        public string DisplayMaterial()
        {
            return $"{Name} {Description} x{Quantity}";
        }
        
    }
}