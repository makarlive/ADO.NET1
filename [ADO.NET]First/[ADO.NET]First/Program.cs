using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace _ADO.NET_First
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sql = new SqlConnection(@"Data Source = CR5-13\SQLEXPRESS; Initial Catalog = Publishers; Integrated Security = sspi");
            sql.Open();
            SqlCommand sqlcommand = new SqlCommand(@"select * from Authors",sql);
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]+" "+reader[1]+" "+reader[2]);
            }
            
        }
    }
}
