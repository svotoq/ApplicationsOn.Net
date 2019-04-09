using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItLab
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public List<Computer> comps = new List<Computer>();
        public DataGridView datagrid1;
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        Criteries FCrit = Criteries.None;
        Criteries SCrit = Criteries.None;
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FirstCrit.SelectedIndex == 0)
                FCrit = Criteries.ProcManufacturer;
            if(FirstCrit.SelectedIndex == 1)
                FCrit = Criteries.ProcModel;
            if (FirstCrit.SelectedIndex == 2)
                FCrit = Criteries.VideoManufacturer;
            if (FirstCrit.SelectedIndex == 3)
                FCrit = Criteries.VideoModel;
            if (FirstCrit.SelectedIndex == 4)
                FCrit = Criteries.RamSize;
            if (FirstCrit.SelectedIndex == 5)
                FCrit = Criteries.HDDSize;
        }

        private void FirstSearchString_TextChanged(object sender, EventArgs e)
        {

        }
        enum Criteries
        {
            ProcManufacturer,
            ProcModel,
            VideoManufacturer,
            VideoModel,
            RamSize,
            HDDSize,
            None
        }
        private void Button1_Click(object sender, EventArgs e) //search
        {
            try
            {
                string FirstPattern = FirstSearchString.Text;
                string SecondPattern = SecondSearchString.Text;
                Regex newReg1 = new Regex(FirstPattern, RegexOptions.IgnoreCase);
                Regex newReg2 = new Regex(SecondPattern, RegexOptions.IgnoreCase);
                OutPut(Search2(Search(newReg1), newReg2));
            }
            catch (Exception)
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }
        public void OutPut(List<Computer> comp)
        {
            try
            {
                datagrid1.DataSource = null;
                datagrid1.DataSource = comp;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка вывода добавленных данных");
            }
        }
        private List<Computer> Search(Regex newReg1)
        {
            List<Computer> SearchResult = new List<Computer>();
            if (FCrit == Criteries.ProcManufacturer)
                SearchResult = comps.Where(o => newReg1.Match(o.processor.Manufacturer.ToString()).Success).ToList();
            if (FCrit == Criteries.ProcModel)
                SearchResult = comps.Where(o => newReg1.Match(o.processor.Model).Success).ToList();
            if (FCrit == Criteries.VideoManufacturer)
                SearchResult = comps.Where(o => newReg1.Match(o.videoAdapter.Friequency.ToString()).Success).ToList();
            if (FCrit == Criteries.VideoModel)
                SearchResult = comps.Where(o => newReg1.Match(o.videoAdapter.Model).Success).ToList();
            if (FCrit == Criteries.RamSize)
                SearchResult = comps.Where(o => newReg1.Match(o.RamSize.ToString()).Success).ToList();
            if (FCrit == Criteries.HDDSize)
                SearchResult = comps.Where(o => newReg1.Match(o.HDDSize.ToString()).Success).ToList();
            return SearchResult;
        }
        private List<Computer> Search2(List<Computer> computers, Regex newReg2)
        {
            List<Computer> SearchResult = new List<Computer>();
            if (SCrit == Criteries.ProcManufacturer)
                SearchResult = computers.Where(o => newReg2.Match(o.processor.Manufacturer.ToString()).Success).ToList();
            if (SCrit == Criteries.ProcModel)
                SearchResult = computers.Where(o => newReg2.Match(o.processor.Model).Success).ToList();
            if (SCrit == Criteries.VideoManufacturer)
                SearchResult = computers.Where(o => newReg2.Match(o.videoAdapter.Friequency.ToString()).Success).ToList();
            if (SCrit == Criteries.VideoModel)
                SearchResult = computers.Where(o => newReg2.Match(o.videoAdapter.Model).Success).ToList();
            if (SCrit == Criteries.RamSize)
                SearchResult = computers.Where(o => newReg2.Match(o.RamSize.ToString()).Success).ToList();
            if (SCrit == Criteries.HDDSize)
                SearchResult = computers.Where(o => newReg2.Match(o.HDDSize.ToString()).Success).ToList();
            return SearchResult;
        }
        private void SecondCrit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SecondCrit.SelectedIndex == 0)
                SCrit = Criteries.ProcManufacturer;
            if (SecondCrit.SelectedIndex == 1)
                SCrit = Criteries.ProcModel;
            if (SecondCrit.SelectedIndex == 2)
                SCrit = Criteries.VideoManufacturer;
            if (SecondCrit.SelectedIndex == 3)
                SCrit = Criteries.VideoModel;
            if (SecondCrit.SelectedIndex == 4)
                SCrit = Criteries.RamSize;
            if (SecondCrit.SelectedIndex == 5)
                SCrit = Criteries.HDDSize;
        }
    }
}
