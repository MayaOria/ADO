using System;
using System.Data.SqlClient;

namespace Exo02
{
    class Program
    {
        static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Theatre-DB;Integrated Security=True";

        static void Main(string[] args)
        {
            using (SqlConnection cnx = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = cnx.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [spectacle]";
                    cnx.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"Id : {reader[0]}, Nom : {reader[1]}, Description : {reader[2]}");
                        }
                    }
                }
            }
            
            
        }
    }
}
