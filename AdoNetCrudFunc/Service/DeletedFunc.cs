using System.Data.SqlClient;

namespace AdoNetCRUD;

public class DeletedFunc
{
    public static void Delete(string DatabaseName, string TableName, string Condition)
    {
        using (SqlConnection connection = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;Database={DatabaseName}; Trusted_Connection = true;"))
        {
            connection.Open();

            string query = $"Delete from {TableName} Where {Condition}";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Deleted");



        }
    }
}
