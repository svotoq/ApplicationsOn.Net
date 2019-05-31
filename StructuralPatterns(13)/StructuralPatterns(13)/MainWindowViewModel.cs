using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace StructuralPatterns_13_
{
    public class MainWindowViewModel
    {
        #region fields
        public Grid FigureGrid;
        private AddFigure addFigureWindow;
        public Figure Figure { get; set; }
        public int Count { get; set; }
        public ObservableCollection<Figure> Figures { get; set; }
        private Shape[,] shapes;
        #endregion
        #region Commands
        private RelayCommand _addFigureCommand;
        public RelayCommand AddFigureCommand
        {
            get
            {
                return _addFigureCommand ?? (_addFigureCommand = new RelayCommand(obj =>
                {
                    addFigureWindow = new AddFigure { DataContext = (MainWindowViewModel)obj };
                    Figure = null;
                    Count = 0;
                    addFigureWindow.ShowDialog();
                }));
            }
        }
        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(obj =>
                {
                    addFigureWindow.Close();
                }));
            }
        }
        private RelayCommand _acceptCommand;
        public RelayCommand AcceptCommand
        {
            get
            {
                return _acceptCommand ?? (_acceptCommand = new RelayCommand(obj =>
                {
                    if (Figure == null || Count == 0)
                    {
                        MessageBox.Show("Выберите фигуру и количество!", "Ошибка");
                        return;
                    }
                    shapes = new Shape[11, 11];
                    FigureGrid.Children.Clear();
                    addFigureWindow.Close();
                    Random random = new Random();
                    int row = 0;
                    int column = 0;
                    for (int i = 0; i < Count; i++)
                    {
                        while (shapes[row, column] != null)
                        {
                            row = random.Next(0, 11);
                            column = random.Next(0, 11);
                        }
                        Shape shape = Figure.GetShape();
                        Grid.SetRow(shape, row);
                        Grid.SetColumn(shape, column);
                        FigureGrid.Children.Add(shape);
                        shapes[row, column] = shape;
                    }
                }));
            }
        }
        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand(obj =>
                {
                    shapes = new Shape[11, 11];
                    FigureGrid.Children.Clear();
                }));
            }
        }
        #endregion
        public MainWindowViewModel(Grid grid)
        {
            FigureGrid = grid;
            Figures = SingletonFigures.GetSingletonFigures().Figures;
            shapes = new Shape[11, 11];
        }
    }
}
