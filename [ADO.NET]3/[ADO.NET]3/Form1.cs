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

namespace _ADO.NET_3
{
    public partial class Form1 : Form
    {
        SqlConnection sql;
        public Form1()
        {
            InitializeComponent();
            sql = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand cmd = new SqlCommand("select * from information_schema.tables", sql);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if(reader[3].ToString() == "BASE TABLE")
                    cb_table.Items.Add(reader[2]);
            }
            sql.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand cmd = new SqlCommand($"select * from {cb_table.SelectedItem.ToString()}", sql);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                string result="";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i].ToString() + " ";
                }

                listBox1.Items.Add(result);
            }
            sql.Close();
        }
    }
}
