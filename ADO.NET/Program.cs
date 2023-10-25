using System.Data.SqlClient;

using (SqlConnection connect = new SqlConnection())
{
    connect.ConnectionString = "Server = (localdb)\\MSSQLLocalDB;;Database=Lms; Trusted_Connection = true;";

    connect.Open();

    string query = $"Insert into Course(id,name,TeacherId,SubjectId) values(1,'Sarvar',3,5)";

    SqlCommand sqlCommand = new SqlCommand(query, connect);

    using(SqlDataReader reader = sqlCommand.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader[0]}");

            Console.WriteLine($"Name: {reader["Name"]}");
        }
    
    }
}