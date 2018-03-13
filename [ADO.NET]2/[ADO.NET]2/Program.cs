using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace _ADO.NET_2
{

    class Program
    {
        static void CreateTable(SqlConnection con,ref SqlCommand cmd, string NameTable, int countParam)
        {
            string query = $"create table [{NameTable}]( id int primary key identity, ";
            for (int i = 0; i < countParam; i++)
            {
                Console.Write("Write param name: ");
                query += Console.ReadLine() + " ";
                Console.Write("Write param type: ");
                query += Console.ReadLine() + " not null, ";
            }
            query += ");";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

        }
        static void Main(string[] args)
        {
            using (SqlConnection sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MCS"].ConnectionString))
            {
                //Create Command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlcon;
                Console.Write("Write Table Name: ");
                string tableName = Console.ReadLine();
                Console.Write("Write quantity param: ");
                int countParam = Convert.ToInt32(Console.ReadLine());
                CreateTable(sqlcon, ref cmd, tableName, countParam);
                

            }
        }
    }
}
