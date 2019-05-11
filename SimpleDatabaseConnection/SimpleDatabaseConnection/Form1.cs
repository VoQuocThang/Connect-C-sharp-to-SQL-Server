using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleDatabaseConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectButt(object sender, EventArgs e)
        {
            string URL;
            SqlConnection cnn;

            URL = @"Data Source=DESKTOP-3L1UM7T;Initial Catalog=QLTV;Integrated Security=False;User ID=sa;Password=lethiloi1999";
            cnn = new SqlConnection(URL);
            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();
            cnn.Open();
            MessageBox.Show("Connected");

            string query = "Insert into TuaSach(ma_tuasach,Tuasach,tacgia,tomtat) " +
                           "values(303,N'Nhắm mắt 3',N'VQT',NULL)";
            // Insert(query,cnn);

            query = "Update TuaSach SET Tuasach =N'Mủa hè xanh' where ma_tuasach = 300";
            // Update(cnn, query);

            query = "Delete from TuaSach where ma_tuasach =300";
           // Delete(query,cnn);


            
            query = "select * from Tuasach where ma_tuaSach = 301";
            // View(query,cnn);
            Fetch(query, cnn);

            cnn.Close();
        }
        public void Fetch(string query,SqlConnection cnn)
        {
            SqlCommand command;
            SqlDataReader cursor;

            string output = " ";

            command = new SqlCommand(query, cnn);

            cursor = command.ExecuteReader();
             while (cursor.Read())
             {
                 output = output + "\n" + cursor.GetValue(1);
             }
            MessageBox.Show(output);

            cursor.Close();
            command.Dispose();
        }



        public void View(string query,SqlConnection cnn)
        {
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
         
            dataGridView1.DataSource = new BindingSource(table,null);
            command.Dispose();
        }

        public void Insert(string query, SqlConnection cnn)
        {
          
             SqlDataAdapter adapter=new SqlDataAdapter();

             adapter.InsertCommand = new SqlCommand(query, cnn);
             adapter.InsertCommand.ExecuteNonQuery();

        }

        public void Update(string query, SqlConnection cnn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.UpdateCommand = new SqlCommand(query, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
        }

        public void Delete(string query, SqlConnection cnn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.DeleteCommand = new SqlCommand(query, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();
        }
    }
}
