using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ItLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.xml)|*.xml|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.xml)|*.xml|All files(*.*)|*.*";
        }
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        List<Computer> computers = new List<Computer>();
        private int processorArchitecture = 0;
        List<string> IntelProcessorSeries = new List<string>
        {
            "i3",
            "i5",
            "i7"
        };
        List<string> AmdProcessorSeries = new List<string>
        {
            "FX",
            "A",
            "Ryzen"
        };
        List<string> AmdVideoSeries = new List<string>
        {
            "R",
            "RX",
            "HD"
        };
        List<string> NvidiaVideoSeries = new List<string>
        {
            "GT",
            "GTX",
            "RTX"
        };
        List<string> IntelVideoSeries = new List<string>
        {
            "HD 2000",
            "HD 3000",
            "HD 4000",
            "HD 5000"
        };
        private bool Saved = false;
        private string SavedFileName = null;
        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void SeriesLabel_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseDateMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void CompTypeLable_Click(object sender, EventArgs e)
        {

        }

        private void CompTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddComputer_Click(object sender, EventArgs e)
        {

            Processor processor = null;
            VideoAdapter videoAdapter = null;
            Computer computer = null;
            try
            {
                processor = new Processor(ProcessorManufactorComboBox.Text, ProcessorSeriesComboBox.Text, ProcessorModelTextBox.Text,
                      int.Parse(ProcessorCoresNumericUpDown.Value.ToString()), int.Parse(ProcessorToFriequencyTextBox.Text), processorArchitecture,
                      int.Parse(ProcessorCacheL1TextBox.Text), int.Parse(ProcessorCacheL2TextBox.Text), int.Parse(ProcessorCacheL3TextBox.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните всю информацию о процессоре");
            }
            try
            {
                videoAdapter = new VideoAdapter(VideoAdapterManufacturerComboBox.Text, VideoAdapterSeriesComboBox.Text,
                    VideoAdapterModelTextBox.Text, int.Parse(VideoAdapterMaxFriequencyTextBox.Text),
                    VideoAdapterDirectX11CheckBox.Checked, VideoMemorySizeTrackBar.Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните всю информацию о Видеокарте");
            }
            try
            {
                computer = new Computer(CompTypeComboBox.Text, processor, videoAdapter, int.Parse(RamSizeComboBox.Text), RamTypeComboBox.Text,
                        int.Parse(HDDSizeComboBox.Text), HDDTypeComboBox.Text, PurchaseDateMonthCalendar.SelectionStart);
                computers.Add(computer);
                Saved = false;
                SavedStatus();
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните всю информацию о компьютере");
            }
       
        }

        private void X64Architecture_CheckedChanged(object sender, EventArgs e)
        {
            if (x64Architecture.Checked)
                processorArchitecture = 64;
        }

        private void X86Architecture_CheckedChanged(object sender, EventArgs e)
        {
            if (x86Architecture.Checked)
                processorArchitecture = 86;
        }

        private void ProcessorSeriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void ProcessorManufactorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProcessorManufactorComboBox.Text == "Intel")
            {
                ProcessorSeriesComboBox.DataSource = IntelProcessorSeries;
            }
            if (ProcessorManufactorComboBox.Text == "Amd")
            {
                ProcessorSeriesComboBox.DataSource = AmdProcessorSeries;
            }
        }

        private void VideoAdapterManufacturerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VideoAdapterManufacturerComboBox.Text == "Nvidia")
            {
                VideoAdapterSeriesComboBox.DataSource = NvidiaVideoSeries;
            }
            if (VideoAdapterManufacturerComboBox.Text == "Amd")
            {
                VideoAdapterSeriesComboBox.DataSource = AmdVideoSeries;
            }
            if (VideoAdapterManufacturerComboBox.Text == "Intel")
            {
                VideoAdapterSeriesComboBox.DataSource = IntelVideoSeries;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {

        }

        private void ProcessorModelTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void VideoMemorySizeLabel_Click(object sender, EventArgs e)
        {

        }

        private void VideoMemorySizeTrackBar_Scroll(object sender, EventArgs e)
        {
            VideoMemorySizeLabel.Text = VideoMemorySizeTrackBar.Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = computers;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка вывода добавленных данных");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Computer>));
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, computers);
                }
                MessageBox.Show("Файл сохранен");
                Saved = true;
                SavedFileName = Path.GetFileNameWithoutExtension(filename);
                SavedStatus();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения!");
            }
        }
        private void Button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Computer>));
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = openFileDialog1.FileName;
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    computers = (List<Computer>)formatter.Deserialize(fs);
                }
                MessageBox.Show("Объект десериализован");
                Saved = true;
                SavedFileName = Path.GetFileNameWithoutExtension(filename);
                SavedStatus();

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка десериализации");
            }
        }

        private void DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void SavedStatus()
        {
            if (Saved)
            {
                SavedLabel.ForeColor = Color.Green;
                SavedLabel.Text = "Лаборатория " + SavedFileName;
            }
            else
            {
                SavedLabel.ForeColor = Color.Red;
                SavedLabel.Text = "Лаборатория не сохранена!";
            }
            PriceLabel.Text = "Стоймость: " + CalculatePrice().ToString("0.00") +"$";
        }

        private void ProcessorToFriequencyTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private double CalculatePrice()
        {
            double ProcessorPrice = 0;
            double VideoAdapterPrice = 0;
            double RamPrice = 0;
            double HDDPrice = 0;
            foreach(var comp in computers)
            {
                ProcessorPrice += comp.processor.Friequency * 0.4 + comp.processor.Cores * 0.35 + comp.processor.CacheL1 * 0.15 
                    * comp.processor.CacheL2 * 0.05* comp.processor.CacheL3 * 0.05;
                VideoAdapterPrice += comp.videoAdapter.Friequency * 0.6 + comp.videoAdapter.MemorySize * 0.4;
                RamPrice += comp.RamSize;
                HDDPrice += comp.HDDSize;
            }
            return (ProcessorPrice + VideoAdapterPrice + RamPrice + HDDPrice)/10;
        }

        private void SavedLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
