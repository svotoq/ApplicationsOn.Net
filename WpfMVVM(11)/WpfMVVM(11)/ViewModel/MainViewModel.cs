using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM_11_.Context;
using WpfMVVM_11_.Model;

namespace WpfMVVM_11_.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Subject _selectedSubject;
        private Student _selectedStudent;
        public ObservableCollection<Subject> Subjects { get; set; }
        public ObservableCollection<Student> Students { get; set; }
        public Subject SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                OnPropertyChanged("SelectedSubject");
            }
        }
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        private ControlCommand _addCommand;
        public ControlCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new ControlCommand(obj => AddStuentToSubject()));
            }
        }
        private ControlCommand _deleteCommand;
        public ControlCommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new ControlCommand(obj => DeleteStuentFromSubject()));
            }
        }
        private ControlCommand _initialDb;
        public ControlCommand InitialDB
        {
            get
            {
                return _initialDb ?? (_initialDb = new ControlCommand(obj => Load()));
            }
        }
        public MainViewModel()
        {
            Students = new ObservableCollection<Student>();
            Subjects = new ObservableCollection<Subject>();
        }
        private void Load()
        {
            using (CoursesContext db = new CoursesContext())
            {
                foreach(var i in db.Students)
                {
                    Students.Add(i);
                }
                foreach (var i in db.Subjects.Include(s=>s.Students))
                {
                    Subjects.Add(i);
                }
           
            }
            MessageBox.Show("Loaded");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private async void AddStuentToSubject()
        {
            if(SelectedSubject == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }
            if(SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента");
                return;
            }
            if (SelectedSubject.Students.Contains(SelectedStudent))
            {
                MessageBox.Show("Данный студент уже ходит на эти курсы");
                return;
            }
            SelectedSubject.Students.Add(SelectedStudent);
            using (CoursesContext db = new CoursesContext())
            {
                Subject subject = await db.Subjects.Where(f=>f.Id == SelectedSubject.Id).FirstOrDefaultAsync();
                subject.Students.Add(_selectedStudent);
                await db.SaveChangesAsync();
            }
        }
        private async void DeleteStuentFromSubject()
        {
            if (SelectedSubject == null)
            {
                MessageBox.Show("Выберите предмет");
                return;
            }
            if (SelectedStudent == null)
            {
                MessageBox.Show("Выберите студента");
                return;
            }
            if (!SelectedSubject.Students.Contains(SelectedStudent))
            {
                MessageBox.Show("Данный студент не ходит на эти курсы");
                return;
            }
            SelectedSubject.Students.Remove(SelectedStudent);
            using (CoursesContext db = new CoursesContext())
            {
                Subject subject = await db.Subjects.Where(f => f.Id == SelectedSubject.Id).FirstOrDefaultAsync();
                subject.Students.Remove(_selectedStudent);
                await db.SaveChangesAsync();
            }
        }

    }
}
