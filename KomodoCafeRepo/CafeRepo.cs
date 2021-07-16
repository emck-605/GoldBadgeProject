using KomodoCafePOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepo
{
    public class CafeRepo
    {
        private List<CafeMenu> _items = new List<CafeMenu>();
        public List<CafeMenu> ListItems()
        {
            return _items;
        }
        public void AddItem(CafeMenu item)
        {
            _items.Add(item);
        }
        public CafeMenu FindItemByID(int itemID)
        {
            foreach (CafeMenu menuItem in _items)
            {
                if (menuItem.ItemNumber == itemID)
                {
                    return menuItem;
                }
            }
            return null;
        }
        public bool RemoveItem(CafeMenu item)
        {
            int initialCount = _items.Count;

            _items.Remove(item);

            if(initialCount > _items.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
