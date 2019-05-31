using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFandEOF.Context;
using WPFandEOF.Model;

namespace WPFandEOF
{
    public class Methods
    {
        public List<string> Types { get; set; }
        public ItLaboratoryContext db { get; }
        private RelayCommand _addRow;
        private Add add { get; set; }
        public RelayCommand AddRow
        {
            get
            {
                return _addRow ?? (_addRow = new RelayCommand(obj =>
                {
                    add = new Add { DataContext = (Methods)obj };
                    add.ShowDialog();
                }));
            }
        }
        public Processor SelectedProcessor { get; set; }
        public string SelectedType { get; set; }
        public int RamSize { get; set; }
        private RelayCommand _acceptCommand;
        public RelayCommand AcceptCommand
        {
            get
            {
                return _acceptCommand ?? (_acceptCommand = new RelayCommand(obj =>
                    AddRowMethod()));
            }
        }
        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand(obj =>
                {
                    add.Close();
                }));
            }
        }
        public Methods(ItLaboratoryContext _db)
        {
            db = _db;
            db.Processors.Load();
            db.Computers.Include(t => t.Processor).Load();
            Types = new List<string>();
            Types.Add("Сервер");
            Types.Add("Домашний Пк");
            Types.Add("Ноутбук");
        }

        private async void AddRowMethod()
        {
            Computer computer = new Computer
            {
                Processor = SelectedProcessor,
                ProcessorId = SelectedProcessor.Id,
                Type = SelectedType,
                RamSize = RamSize
            };
            db.Computers.Add(computer);
            add.Close();
            await db.SaveChangesAsync();
        }

    }
}
