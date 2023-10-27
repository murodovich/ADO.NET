using Project_Lesson.Models;

namespace Project_Lesson.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
