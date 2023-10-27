using Project_Lesson.Models;
using System.Data.SqlClient;

namespace Project_Lesson;
public class Database 
{
    public static void CreateTable(string tableName, string DatabaseName, List<Employee> columns)
    {
        using (SqlConnection connect = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB; Database ={DatabaseName}; Trusted_Connection = true; "))
        {
            connect.Open();

            string query = $"Create Table {tableName}";
            

        }


    }

}
