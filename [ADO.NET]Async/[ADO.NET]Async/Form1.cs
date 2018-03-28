using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _ADO.NET_Async
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=CR5-13\SQLEXPRESS;Initial Catalog=Publishers; Integrated Security=true;";
        SqlConnection sqlConnection = null;
        DataTable dataTable = null;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "select * from Books")
            {
                using (sqlConnection = new SqlConnection(connectionString))
                {
                    await sqlConnection.OpenAsync();
                    SqlCommand command = new SqlCommand(textBox1.Text);
                    command.Connection = sqlConnection;
                    dataTable = new DataTable();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        int line = 0;
                        while (reader.Read())
                        {
                            if (line++ == 0)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    dataTable.Columns.Add(reader.GetName(i));
                                }
                            }
                            DataRow dataRow = dataTable.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                dataRow[i] = reader.GetValue(i);
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dataTable;
                    }

                }
            }
        }
    }
}
