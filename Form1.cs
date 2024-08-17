using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backpacks
{
    public partial class Form1 : Form
    {
        private List<Item> items;
        public Form1()
        {
            InitializeComponent();

            addItems();
            showItems(items);
        }
        private void addItems()
        {
            items = new List<Item>();

            items.Add(new Item("Book", 6, 5));
            items.Add(new Item("Binoculars", 4, 3));
            items.Add(new Item("First aid kit", 3, 1));
            items.Add(new Item("Laptop", 2, 3));
            items.Add(new Item("Lamp", 5, 6));
        }
        private void showItems(List<Item> items)
        {
            listView1.Items.Clear();
            foreach(var item in items)
            {
                listView1.Items.Add(new ListViewItem(new string[] { item.Name, item.Weigth.ToString(),
            item.Price.ToString() }));
            }
        }

        private void ShowInitialData_Click(object sender, EventArgs e)
        {
            showItems(items);
        }
        private void solveButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            { 
                Backpack bp = new Backpack(Convert.ToDouble(textBox1.Text));
                bp.makeAllSets(items);

                List<Item> solve = bp.getBestSet();

                if (solve == null)
                {
                    MessageBox.Show("There is no solutions!");
                }
                else
                {
                    listView1.Items.Clear();

                    showItems(solve);
                    label2.Text = $"Max price: {bp.getBestPrice()}";
                    MessageBox.Show("Solution is in the table");
                }
            }

            else
                MessageBox.Show("Input max weigth for the backpack!");
        }
    }
}
