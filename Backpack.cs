using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backpacks
{
    internal class Backpack
    {
        private List<Item> best_items = null;
        private double max_weigth;
        private double best_price;
        public Backpack(double max_weight)
        {
            this.max_weigth = max_weight;
        }
        private double calcTotalWeigth(List<Item> items)
        {
            double total_weigth = 0;
            foreach(var item in items)
            {
                total_weigth += item.Weigth;
            }
            return total_weigth;
        }
        private double calcTotalPrice(List<Item> items)
        {
            double total_price = 0;
            foreach(var item in items)
            {
                total_price += item.Price;
            }
            return total_price;
        }
        private void checkSet(List<Item> items)
        {
            if(best_items == null)
            {
                if(calcTotalWeigth(items) <= max_weigth)
                {
                    best_items = items;
                    best_price = calcTotalPrice(items);
                }
            }
            else
            {
                if (calcTotalWeigth(items) <= max_weigth && calcTotalPrice(items) > best_price)
                {
                    best_items = items;
                    best_price = calcTotalPrice(best_items);
                }
            }
        }
        public void makeAllSets(List<Item> items)
        {
            if(items.Count > 0)
                checkSet(items);
            for (int i = 0; i < items.Count; i++)
            {
                List<Item> new_set = new List<Item>(items);
                new_set.RemoveAt(i);
                makeAllSets(new_set);
            }
        }
        public List<Item> getBestSet()
        {
            return best_items;
        }
        public double getBestPrice()
        {
            return calcTotalPrice(best_items);
        }
    }
}
