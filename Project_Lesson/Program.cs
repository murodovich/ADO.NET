using Project_Lesson.Dtos;
using Project_Lesson.Repository;

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

        //employeeRepository.DeleteEmployee(2);
        EmployeeDto employeeDto = new EmployeeDto();
        employeeDto.Name = "Test";
        employeeDto.Surname = "Test";
        employeeDto.Login = "test";
        employeeDto.Email = "test";
        employeeDto.Password = "test";
        employeeDto.Role = Project_Lesson.Models.Role.Admin;

        employeeRepository.CreateEmployee(employeeDto);
    }
}