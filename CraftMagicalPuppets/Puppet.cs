using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftMagicalPuppets
{
    public class Puppet : Item, IMagical
    {
        private string type;
        public string Type { get => type; set => type = value; }
        public bool Magical { get; set; }

        enum Rarity
        {
            Common = 11,
            Uncommon = 22,
            Rare = 33
        }
        Rarity rarity;
        public Puppet(string name, string type)
        {
            Type = type;
            Name = name;
            rarity = SetRarity();
            Description = rarity.ToString();
        }


        public string Display() => $"{Name} ({Description})";
        private Rarity SetRarity()
        {
            Rarity output;
            int rarity = Utility.Probability.Next(0, 100);
            if (rarity > 0 & rarity <= 70)
            {
                output = Rarity.Common;
                Magical = false;
            }
            else if (rarity > 70 & rarity <= 90)
            {
                output = Rarity.Uncommon;
                Magical = false;
            }
            else
            {
                output = Rarity.Rare;
                Magical = true;
            }
            return output;
        }
        public decimal SellValue()
        {
            decimal price = Math.Round(Value + (Value * (int)rarity / 100), 2);
            return price;
        }

        public string Talk()
        {
            if (Magical == true){return $"The puppet seems to come alive and turns to you... BOO!";}
            else {return "You stare into the puppets cold beady eyes and nothing happens.";}
        }
    }
}