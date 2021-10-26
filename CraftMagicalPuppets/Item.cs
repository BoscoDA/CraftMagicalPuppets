using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftMagicalPuppets
{
    public class Item
    {
        protected string name;
        protected int quantity;
        protected decimal value;
        private string description;
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal Value { get => value; set => this.value = value; }
        public string Description { get => description; set => description = value; }
    }
}