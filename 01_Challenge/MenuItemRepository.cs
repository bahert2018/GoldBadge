using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuItemRepository
    {
        List<MenuItem> _Items = new List<MenuItem>();

        public void AddMenuItemToList(MenuItem item)
        {
            _Items.Add(item);
        }

        public List<MenuItem> GetMenuItems()
        {
            return _Items;
        }

        public void RemoveMenuItem(MenuItem item)
        {
            _Items.Remove(item);
        }

        public void RemoveItemBySpecifications(int number)
        {
            foreach (MenuItem item in _Items)
            {
                if(item.Number == number)
                {
                    RemoveMenuItem(item);
                    break;
                }
            }
        }

        public bool RemoveItemBySpecifications(string name, int number)
        {
            bool successful = false;
            foreach(MenuItem item in _Items)
            {
                if(item.Name == name && item.Number == number)
                {
                    RemoveMenuItem(item);
                    successful = true;
                    break;
                }
            }
            return successful;
        }
    }
}
