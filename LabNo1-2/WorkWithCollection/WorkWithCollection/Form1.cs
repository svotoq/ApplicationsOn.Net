using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkWithCollection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> Collection;
        List<int> NewCollection;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        Comparator comp;

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            comp = Sort;
            comp("ascending");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button1.Enabled = true;
            int CollectionSize = 0;
            try
            {
                CollectionSize = int.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Введите размер коллекции");
            }
            try
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                Collection = new List<int>();
                Random rand = new Random();
                for (int i = 0; i < CollectionSize; i++)
                {
                    Collection.Add(rand.Next(1000));
                }
                foreach (int elem in Collection)
                {
                    listBox1.Items.Add("Диаметр трубы = " + elem.ToString() + "мм");
                }
                NewCollection = Collection;
            }
            catch (Exception) { }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            comp = Sort;
            comp("descending");

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button1.Enabled = false;
            try
            {
                listBox2.Items.Clear();
                int result = Collection.Max();
                listBox2.Items.Add("Диаметр трубы = " + result + "мм");
            }
            catch (Exception) { }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button1.Enabled = true;
            try
            {
                listBox2.Items.Clear();
                NewCollection = Collection.Where(d => d > 900).ToList();
                foreach (var item in NewCollection)
                {
                    listBox2.Items.Add("Диаметр трубы = " + item + "мм");
                }
            }
            catch (Exception) { }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button1.Enabled = false;
            try
            {
                listBox2.Items.Clear();
                int result = Collection.Min();
                listBox2.Items.Add("Диаметр трубы = " + result + "мм");
            }
            catch (Exception) { }
        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private delegate void Comparator(string SortType);
        private void Sort(string SortType)
        {
            try
            {
                listBox2.Items.Clear();
                if (SortType == "ascending")
                {
                    NewCollection = NewCollection.OrderBy(d=>d).ToList();
                }
                if (SortType == "descending")
                {
                    NewCollection = NewCollection.OrderByDescending(d => d).ToList();
                }
                foreach (var item in NewCollection)
                {
                    listBox2.Items.Add("Диаметр трубы = " + item + "мм");
                }
            }
            catch (Exception) { }
        }
    }
}
