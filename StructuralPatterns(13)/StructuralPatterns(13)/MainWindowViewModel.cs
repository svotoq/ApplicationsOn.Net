using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
        #region factory
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
                    if (addFigureWindow.IsActive)
                    {
                        addFigureWindow.Close();
                    }
                    if (addCustomizableFigureWindow.IsActive)
                    {
                        addCustomizableFigureWindow.Close();
                    }

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
        #region builder
        private AddCustomizableCircle addCustomizableFigureWindow;
        public int Height { get; set; }
        public int Width { get; set; }
        public Brush SelectedFigureColor { get; set; }
        public Brush SelectedBorderColor { get; set; }
        public ObservableCollection<MyColor> MyColors { get; set; }
        public int BorderThickness { get; set; }
        private RelayCommand _addCustomizableFigureCommand;
        public RelayCommand AddCustomizableFigureCommand
        {
            get
            {
                return _addCustomizableFigureCommand ?? (_addCustomizableFigureCommand = new RelayCommand(obj =>
                {
                    addCustomizableFigureWindow = new AddCustomizableCircle { DataContext = (MainWindowViewModel)obj };
                    SelectedFigureColor = Brushes.Blue;
                    SelectedBorderColor = Brushes.Red;
                    BorderThickness = 0;
                    Width = 0;
                    Height = 0;
                    addCustomizableFigureWindow.ShowDialog();
                }));
            }
        }
        private RelayCommand _acceptCustomizedFigureCommand;
        public RelayCommand AcceptCustomizedFigureCommand
        {
            get
            {
                return _acceptCustomizedFigureCommand ?? (_acceptCustomizedFigureCommand = new RelayCommand(obj =>
                {
                    CustomizableFigure figure = new CustomizableFigure();
                    addCustomizableFigureWindow.Close();
                    Shape circle = figure.GetCircle(new DefaultCircleBuilder
                    {
                        FillColor = SelectedFigureColor,
                        BorderColor = SelectedBorderColor,
                        Thickness = BorderThickness,
                        Height = Height,
                        Width = Width
                    });
                    FigureGrid.Children.Clear();
                    FigureGrid.Children.Add(circle);
                    Grid.SetRow(circle, 0);
                    Grid.SetColumn(circle, 0);
                    Grid.SetRowSpan(circle, 3);
                    Grid.SetColumnSpan(circle, 3);
                }
                ));
            }
        }
        #endregion
        public MainWindowViewModel(Grid grid)
        {
            FigureGrid = grid;
            Figures = SingletonFigures.GetSingletonFigures().Figures;
            shapes = new Shape[11, 11];
            MyColors = new ObservableCollection<MyColor>
            {
                new MyColor{Name = "Yellow", Color = Brushes.Yellow},
                new MyColor{Name = "Black", Color = Brushes.Black},
                new MyColor{Name = "Blue", Color = Brushes.Blue},
                new MyColor{Name = "Red", Color = Brushes.Red},
                new MyColor{Name = "White", Color = Brushes.White},
                new MyColor{Name = "HotPink", Color = Brushes.HotPink}
            };

        }
    }
}
