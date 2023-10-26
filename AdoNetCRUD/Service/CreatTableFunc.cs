using System.Data.SqlClient;

namespace AdoNetCRUD;

public class CreatTableFunc
{
    public static void CreateTable(string tableName, string DatabaseName, List<CreateModel> columns)
    {
        using (SqlConnection connect = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB; Database ={DatabaseName}; Trusted_Connection = true; "))
        {
            connect.Open();

            string query = $"Create Table {tableName}";

            string query1 = columns.Aggregate(query, (x1, x2) => x1 += x2.ColumnName + "" +
            " " + x2.ColumnType + ",", (x) => x.Substring(0, x.Length - 1) + ");");
            SqlCommand cmd = new SqlCommand(query1, connect);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Created");
        }


    }
}
