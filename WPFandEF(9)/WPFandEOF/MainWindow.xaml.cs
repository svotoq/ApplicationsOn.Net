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
using System.Data.Entity;
using WPFandEOF.Context;
using WPFandEOF.Model;

namespace WPFandEOF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ItLaboratoryContext db { get; }
        public MainWindow()
        {
            InitializeComponent();
            db = new ItLaboratoryContext();
            DataContext = new Methods(db);
        }
        private void ShowFromDb(object sender, RoutedEventArgs e)
        {
            ListView.ItemsSource = db.Computers.Local;
        }
        private async void Delete(object sender, RoutedEventArgs e)
        {
            if (ListView.SelectedItems.Count > 0)
            {
                Computer comp = (Computer)ListView.SelectedItem;
                if(db.Computers.Any(t=>t.Id ==comp.Id))
                {
                    db.Computers.Remove(comp);
                }
                await db.SaveChangesAsync();

                MessageBox.Show("Объект удален");
            }
        }
    }
}
