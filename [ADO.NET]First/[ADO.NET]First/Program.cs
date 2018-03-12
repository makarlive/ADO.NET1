using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;

namespace _ADO.NET_First
{
    class Program
    {
        static void Main(string[] args)
        {
            
                SqlConnection sql = new SqlConnection(@"Data Source = CR5-13\SQLEXPRESS; Initial Catalog = Publishers; Integrated Security = sspi");
                sql.Open();
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.Connection = sql;
                string text;
                SqlDataReader reader;
                while (true)
                {
                try
                {
                    text = Console.ReadLine();
                    sqlcommand.CommandText = text;
                    reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                    reader.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
                sql.Close();
            
        }
    }
}
