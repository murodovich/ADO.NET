using Project_Lesson.Dtos;
using Project_Lesson.Interfaces;
using Project_Lesson.Models;
using System.Data.SqlClient;

namespace Project_Lesson.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    
    public void CreateEmployee(EmployeeDto employee)
    {
        using(SqlConnection connect = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;" +
            $" Database =Employee; Trusted_Connection = true; "))
        {
            connect.Open();
            string query = $"insert into Employee(Name,Surname,Email,Login,Password,Status,Role) values('{employee.Name}','{employee.Surname}','{employee.Email}','{employee.Login}','{employee.Password}','{Status.Created}','{Role.Admin}')";
            SqlCommand cmd = new SqlCommand(query, connect);
            using(SqlDataReader reader = cmd.ExecuteReader()) 
            {
                
            }
        }
    }

    public void DeleteEmployee(int EmployeeId)
    {
        using(SqlConnection con = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;" +
            $" Database =Employee; Trusted_Connection = true; "))
        {
            con.Open();

            string query = $"Update Employee set Status = '{Status.Deleted}',DeletedAt = '{DateTime.UtcNow}' where Id = { EmployeeId } and Status<> 'Deleted';";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            using(SqlDataReader rdr = sqlCommand.ExecuteReader())
            {

            }

        }
    }

    public void EmployeeDeepDelete(int EmployeeId)
    {
        using(SqlConnection con = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;" +
            $" Database =Employee; Trusted_Connection = true; "))
        {
            con.Open();
            string query = $"delete from Employee where Id = {EmployeeId};";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            using(SqlDataReader dr = sqlCommand.ExecuteReader())
            {

            }
        }
        


    }

    public void GetAllEmployees()
    {
        using (SqlConnection con = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;" +
            $" Database =Employee; Trusted_Connection = true;"))
        {
            con.Open();
            string query = $"select * from Employee where Status <> 'Deleted'";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                bool res = false;
                while (reader.Read())
                {
                    res = true;
                    Console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Surname"]} {reader["Email"]} {reader["Login"]} {reader["Password"]} {reader["Status"]} {reader["CreatedAt"]} {reader["UpdatedAt"]} {reader["DeletedAt"]}");
                }
                if (res == false)
                {
                    Console.WriteLine("Ma'lumot topilmadi");
                }

            }
}
    }

    public void GetEmployeeById(int EmployeeId)
    {
        using( SqlConnection con = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;" +
            $" Database =Employee; Trusted_Connection = true;"))
        {
            con.Open();
            string query = $"select * from Employee where Id = {EmployeeId} and Status <> 'Deleted'";
            SqlCommand sqlCommand = new SqlCommand( query, con);
            using( SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                bool res = false;
                while (reader.Read())
                {
                    res = true;
                    Console.WriteLine($"{reader["Id"]} {reader["Name"]} {reader["Surname"]} {reader["Email"]} {reader["Login"]} {reader["Password"]} {reader["Status"]} {reader["CreatedAt"]} {reader["UpdatedAt"]} {reader["DeletedAt"]}");
                }
                if (res == false)
                {
                    Console.WriteLine("Ma'lumot topilmadi");
                }
            }
        }
    }


    public void UpdateEmployee(int EmployeeId, EmployeeDto employee)
    {
        using(SqlConnection con = new SqlConnection($"Server = (localdb)\\MSSQLLocalDB;" +
            $" Database =Employee; Trusted_Connection = true;"))
        {
            con.Open();
            string query = $"Update Employe Set Name = '{employee.Name}','{employee.Surname}'" +
                $",'{employee.Email}','{employee.Login}',{employee.Password}',{Status.Updated}','{employee.Role}'";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            using(SqlDataReader reader = sqlCommand.ExecuteReader())
            {}
        }
    }
        
}

