namespace Project_Lesson.Models;

public class Employee : Base
{
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public Status status { get; set; }
    public Role Role { get; set; }
}
