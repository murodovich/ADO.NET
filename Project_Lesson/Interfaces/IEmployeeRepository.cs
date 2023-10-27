using Project_Lesson.Dtos;
using Project_Lesson.Models;

namespace Project_Lesson.Interfaces;

public interface IEmployeeRepository 
{
    void CreateEmployee(EmployeeDto employee);
    void UpdateEmployee(int EmployeeId, EmployeeDto employee);
    void DeleteEmployee(int EmployeeId);
    void EmployeeDeepDelete(int EmployeeId);
    void GetAllEmployees();
    void GetEmployeeById(int EmployeeId);

}
