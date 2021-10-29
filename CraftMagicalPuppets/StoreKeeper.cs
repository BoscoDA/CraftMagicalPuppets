using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftMagicalPuppets
{
    class StoreKeeper : Person
    {
        
        private string MaterialList = "../../Data/recipes.xml";
        public StoreKeeper()
        {
            Name = "Dave";
            Money = 50.00M;
            Inventory = DataLoader.LoadMaterialsXML(MaterialList);
        }

    }
}
