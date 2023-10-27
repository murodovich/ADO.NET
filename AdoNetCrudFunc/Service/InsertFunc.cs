using System.Data.SqlClient;

namespace AdoNetCRUD;

public class InsertFunc
{
    public static void Insert(string databaseName, string tableName, string values)
    {
        string connectionString = $"Server=(localdb)\\MSSQLLocalDB;Database={databaseName};Trusted_Connection=True;";

        using (SqlConnection connection = new SqlConnection())
        {
            connection.ConnectionString = connectionString;

            connection.Open();

            string Columns = $"select * from {tableName};";

            SqlCommand ColumnCommond = new SqlCommand(Columns, connection);

            dynamic result;

            using (SqlDataReader reader = ColumnCommond.ExecuteReader())
            {
                result = reader.GetColumnSchema();
            }

            string stringResult = string.Empty;

            foreach (var i in result)
            {
                stringResult += i.ColumnName + ",";
            }

            stringResult = stringResult.Substring(0, stringResult.Length - 1);

            string query = $"insert into {tableName} ({stringResult}) values {values}";

            SqlCommand command = new SqlCommand(query, connection);

            using (SqlDataReader reader2 = command.ExecuteReader())
            {

            }
        }
    }
}
