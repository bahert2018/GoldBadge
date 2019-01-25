using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge
{
    public class MenuItem
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
        public string Info { get; set; }

        public MenuItem(string name, int number, decimal price, string info, string ingredients)
        {   
            Name = name;
            Number = number;
            Price = price;
            Info = info;
            Ingredients = ingredients;
        }
        public MenuItem()
        {

        }
    }
}
