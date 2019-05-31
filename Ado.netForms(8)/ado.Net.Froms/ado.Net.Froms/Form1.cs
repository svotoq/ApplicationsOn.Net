using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ado.Net.Froms
{
    public partial class Form1 : Form
    {
        string ConnectionString;
        DataSet dataSet;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        TableName tableName;
        string SQLExpression;
        int pageSize;
        int pageNumber; 
        public Form1()
        {
            InitializeComponent();
            DataGridViewElement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridViewElement.AllowUserToAddRows = false;
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            tableName = TableName.Computer;
            pageSize = 2;
            pageNumber = 0;
            PrevPage.Enabled = false;
            NextPage.Enabled = false;
        }
        private enum TableName
        {
            Computer,
            Ram
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow elem in DataGridViewElement.SelectedRows)
                {
                    DataGridViewElement.Rows.Remove(elem);
                }
            }
            catch
            {
                Console.WriteLine("Error! Row/rows cannot be deleted");
            }
        }
        private void ShowComputerDB_Click(object sender, EventArgs e)
        {
            tableName = TableName.Computer;
            CheckUpdateDBParametrs();
        }
        private void ShowRamDB_Click(object sender, EventArgs e)
        {
            tableName = TableName.Ram;
            CheckUpdateDBParametrs();
        }
        private void CheckUpdateDBParametrs()
        {
            if (tableName == TableName.Computer)
            {
                UpdateDB();
                DataGridViewElement.Columns["ID"].ReadOnly = true;
            }
            if (tableName == TableName.Ram)
            {
                UpdateDB();
            }
        }
        private void UpdateDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    adapter = new SqlDataAdapter(GetSQL(), connection);
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    DataGridViewElement.DataSource = dataSet.Tables[0];
                }
                PrevPage.Enabled = true;
                NextPage.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (tableName == TableName.Computer)
            {
                SaveComputerDB();
            }
            if (tableName == TableName.Ram)
            {
                SaveRamDB();
            }
        }
        private void SaveComputerDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    adapter = new SqlDataAdapter(GetSQL(), connection);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = new SqlCommand("SP_INSERT_Computer", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50, "Type");
                    adapter.InsertCommand.Parameters.Add("@Processor", SqlDbType.VarChar, 50, "Processor");
                    adapter.InsertCommand.Parameters.Add("@VideoAdapter", SqlDbType.VarChar, 50, "VideoAdapter");
                    adapter.InsertCommand.Parameters.Add("@RamType", SqlDbType.VarChar, 10, "RamType");
                    adapter.InsertCommand.Parameters.Add("@RamSize", SqlDbType.Int, 0, "RamSize");
                    adapter.InsertCommand.Parameters.Add("@HDD", SqlDbType.VarChar, 50, "HDD");
                    adapter.InsertCommand.Parameters.Add("@PurchaseDate", SqlDbType.Date, 0, "PurchaseDate");
                    SqlParameter ID = adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                    ID.Direction = ParameterDirection.Output;
                    adapter.Update(dataSet);
                }
                CheckUpdateDBParametrs();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void SaveRamDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    adapter = new SqlDataAdapter(GetSQL(), connection);
                    commandBuilder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = new SqlCommand("SP_INSERT_RAM", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add("@Type", SqlDbType.VarChar, 50, "Type");
                    adapter.InsertCommand.Parameters.Add("@Size", SqlDbType.Int, 0, "Size");
                    adapter.Update(dataSet);
                }
                CheckUpdateDBParametrs();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newRow = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(newRow);
            }
            catch
            {
                Console.WriteLine("Error! Row cannot be added!");
            }
        }
        private void IdAsc_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewElement.Sort(DataGridViewElement.Columns["Id"], ListSortDirection.Ascending);
            }
            catch { }
        }
        private void IdDesc_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewElement.Sort(DataGridViewElement.Columns["Id"], ListSortDirection.Descending);
            }
            catch { }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewElement.Sort(DataGridViewElement.Columns["Type"], ListSortDirection.Ascending);
            }
            catch { }
        }
        private void TypeDesc_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewElement.Sort(DataGridViewElement.Columns["Type"], ListSortDirection.Descending);
            }
            catch { }
        }
        private void NextPage_Click(object sender, EventArgs e)
        {
            if (dataSet.Tables[0].Rows.Count < pageSize)
            {
                return;
            }
            pageNumber++;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                adapter = new SqlDataAdapter(GetSQL(), connection);

                dataSet.Tables[0].Rows.Clear();

                adapter.Fill(dataSet);
            }
        }
        private void PrevPage_Click(object sender, EventArgs e)
        {
            if (pageNumber == 0)
            {
                return;
            }
            pageNumber--;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                adapter = new SqlDataAdapter(GetSQL(), connection);
                dataSet.Tables[0].Rows.Clear();
                adapter.Fill(dataSet);
            }
        }
        private string GetSQL()
        {
            if (tableName == TableName.Computer)
            {
                return "SELECT * FROM COMPUTER ORDER BY Id OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
                   "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
            }
            if (tableName == TableName.Ram)
            {
                return "SELECT * FROM RAM ORDER BY TYPE OFFSET ((" + pageNumber + ") * " + pageSize + ") " +
                      "ROWS FETCH NEXT " + pageSize + "ROWS ONLY";
            }
            return "";
        }
    }
}
