using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_11_.Model
{
    public class Subject : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _name;
        private int _numberOfHours;
        private string _lectorName;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public int NumberOfHours
        {
            get => _numberOfHours;
            set
            {
                _numberOfHours = value;
                OnPropertyChanged("NumberOfHours");
            }
        }
        public string LectorName
        {
            get => _lectorName;
            set
            {
                _lectorName = value;
                OnPropertyChanged("LectorName");
            }
        }
        public ObservableCollection<Student> Students { get; set; }
        public Subject()
        {
            Students = new ObservableCollection<Student>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
