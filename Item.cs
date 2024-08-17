using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpacks
{
    internal class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Weigth { get; set; }
        public Item(string name, double weigth, double price)
        {
            Name = name;
            Price = price;
            Weigth = weigth;
        }
    }
}
