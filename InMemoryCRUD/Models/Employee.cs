namespace InMemoryCRUD.Models;

public class Employee
{
    public required long EmployeeID { get; set; }
    public required string FullName { get; set; }
    public required DateTime BirthDate { get; set; }
}