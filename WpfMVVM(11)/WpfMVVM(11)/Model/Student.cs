using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfMVVM_11_.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Subject> Subj { get; set; }
        public Student()
        {
            Subj = new ObservableCollection<Subject>();
        }
    }
}