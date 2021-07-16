using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafePOCO
{
    public class CafeMenu
    {
            public CafeMenu() { }
            public int ItemNumber { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Ingredients { get; set; }

            public CafeMenu(int itemNumber, string name, string description, string ingredients)
            {
                ItemNumber = itemNumber;
                Name = name;
                Description = description;
                Ingredients = ingredients;
            }
    }
}
