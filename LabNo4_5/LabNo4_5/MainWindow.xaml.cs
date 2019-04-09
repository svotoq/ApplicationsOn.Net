using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
namespace LabNo4_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsSaved { get; set; }
        bool IsFileOpened { get; set; }
        string FilePath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            rtbEditor.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(RtbEditor_DragOver), true);
            rtbEditor.AddHandler(RichTextBox.DropEvent, new DragEventHandler(RtbEditor_Drop), true);
            rtbEditor.Focus();
            IsSaved = false;
            IsFileOpened = false;
            FilePath = null;
            SetCursor();
        }
        #region Menu_File
        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string richText = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd).Text;
            if (!IsSaved)
            {
                MessageBoxResult result = IsFileNotSaved();
                if (result == MessageBoxResult.Yes)
                {
                    Save_Executed(sender, e);
                }
                if (result == MessageBoxResult.No)
                {
                    CreateNewFile();
                }
            }
            else
            {
                CreateNewFile();
            }
        }
        private MessageBoxResult IsFileNotSaved()
        {
            string FileName = null;
            if (FilePath == null)
            {
                FileName = "New_File";
            }
            else
            {
                FileName = System.IO.Path.GetFileNameWithoutExtension(FilePath);
            }
            string message = $"Вы хотите сохранить изменения в \"{FileName}\"?";
            MessageBoxResult result = MessageBox.Show(message, "Внимание!", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.Yes);
            return result;
        }
        private void CreateNewFile()
        {
            rtbEditor.Document.Blocks.Clear();
            IsSaved = false;
            FilePath = null;
            IsFileOpened = false;
        }
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    Open(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (IsFileOpened)
            {
                Save(FilePath);
            }
            else
            {
                SaveAs();
            }
        }
        private void SaveAs_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveAs();
        }
        private void Open(string path)
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Load(fileStream, DataFormats.Rtf);
                }
                IsSaved = true;
                IsFileOpened = true;
                FilePath = path;
                FilePathTextBlock.Text = path;
            }
            catch
            {
                MessageBox.Show("Ошибка открытия, неверный формат!");
            }
        }
        private void SaveAs()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
                if (dlg.ShowDialog() == true)
                {
                    Save(dlg.FileName);
                }
            }
            catch { }
        }
        private void Save(string path)
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Save(fileStream, DataFormats.Rtf);
                }
                IsSaved = true;
                IsFileOpened = true;
                FilePath = path;
                FilePathTextBlock.Text = path;
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения, неверный формат!");
            }
        }
        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (!IsSaved)
            {
                MessageBoxResult result = IsFileNotSaved();
                if (result == MessageBoxResult.No)
                {
                    this.Close();
                }
                if (result == MessageBoxResult.Yes)
                {
                    Save_Executed(sender, e);
                }
            }
            else
            {
                this.Close();
            }
        }
        #endregion
        private void RtbEditor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            IsSaved = false;
            CountOfSymbols();
        }
        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
                btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
                temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
                btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
                temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
                btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

                temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
                cmbFontFamily.SelectedItem = temp;
                temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
                cmbFontSize.Value = int.Parse(temp.ToString());
            }
            catch { }
        }
        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbFontFamily.SelectedItem != null)
                    rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
            catch
            {
            }

        }
        private void cmbFontSize_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Value);
                FontSizeLable.Content = cmbFontSize.Value;
            }
            catch
            {
            }
        }
        private void RtbEditor_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }
        private void RtbEditor_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);
                Open(docPath[0]);
            }
        }
        private void CountOfSymbols()
        {
            TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            StatusBar.Text = "Count of symbols - " + range.Text.Length;
        }
        private void SetCursor()
        {
            StreamResourceInfo sri = Application.GetResourceStream(
                new Uri("Img\\Arrow.cur", UriKind.Relative));
            Cursor customCursor = new Cursor(sri.Stream);
            this.Cursor = customCursor;
        }
        private void Color_Click(object sender, RoutedEventArgs e)
        {
            string color = (new SolidColorBrush(Colors.Black)).ToString();
            System.Windows.Forms.ColorDialog dialog = new System.Windows.Forms.ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtbEditor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                    dialog.Color.A, dialog.Color.R, dialog.Color.G, dialog.Color.B)));
                rtbEditor.Focus();
                ColorPicker.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(
                    dialog.Color.A, dialog.Color.R, dialog.Color.G, dialog.Color.B));
                if (ColorPicker.Background.ToString() == color) ColorPicker.Foreground = new SolidColorBrush(Colors.White);
                else ColorPicker.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void SetLanguageDictionary(string lang)
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch(lang)
            {
                case "EN-en":
                    dict.Source = new Uri("..\\LangEn-en.xaml", UriKind.Relative);
                    break;
                case "RU-ru":
                    dict.Source = new Uri("..\\LangRU-ru.xaml", UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("..\\LangRU-ru.xaml", UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);
        }

        private void Russian_Click(object sender, RoutedEventArgs e)
        {
            SetLanguageDictionary("RU-ru");
        }
        private void English_Click(object sender, RoutedEventArgs e)
        {
            SetLanguageDictionary("EN-en");
        }
    }
}