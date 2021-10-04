using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CraftMagicalPuppets
{
    public class Puppet : Item
    {
        public string Type;
        public Puppet(string name, string type)
            : base(name)
        {
            Type = type;
        }

        public void Talk()
        {
            throw new System.NotImplementedException();
        }
    }
}