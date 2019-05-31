using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserContolsWPF_7_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class WindowCommands
    {
        static WindowCommands()
        {
            Exit = new RoutedUICommand("Exit", "Exit", typeof(MainWindow));
        }
        public static RoutedUICommand Exit { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Checkbut_Click(object sender, RoutedEventArgs e)
        {
            Check check = (Check)this.Resources["Bulichka"];
            MessageBox.Show(check.Price.ToString());
        }
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Sender: " + sender.ToString() + "\n" +
                "Source: " + e.Source.ToString());
        }
    }
    public class Check : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty PriceProperty;

        static Check()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Check));
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            PriceProperty = DependencyProperty.Register("Price", typeof(int), typeof(Check), metadata, new ValidateValueCallback(ValidateValue));
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0)
                return true;
            return false;
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 600)
                MessageBox.Show("Цена должна быть ниже 600");
            if (currentValue < 400)
                MessageBox.Show("Цена должна быть выше 400");
            return currentValue;
        }
    }

}
