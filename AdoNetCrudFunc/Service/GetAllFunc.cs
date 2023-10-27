using System.Data.SqlClient;

namespace AdoNetCRUD;

public class GetAllFunc
{
    public static void GettAll(string tableName, string DatabaseName, string shart)
    {
        using (SqlConnection conn = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;Database={DatabaseName}; Trusted_Connection = true;"))
        {
            conn.Open();
            string query = $"select * from {tableName} where {shart};";

            SqlCommand cmd = new SqlCommand(query, conn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                int count = rdr.FieldCount;
                while (rdr.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"Col{i} {rdr[i]}");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
