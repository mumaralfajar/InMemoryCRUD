using InMemoryCRUD.Models;

namespace InMemoryCRUD.Repositories;
public static class EmployeeRepository
{
    public static List<Employee> Employees { get; } =
    [
        new() { EmployeeID = 1001, FullName = "Adit", BirthDate = new DateTime(1954, 8, 17) },
        new() { EmployeeID = 1002, FullName = "Anton", BirthDate = new DateTime(1954, 8, 18) },
        new() { EmployeeID = 1003, FullName = "Amir", BirthDate = new DateTime(1954, 8, 19) },
        new() { EmployeeID = 1004, FullName = "Budi", BirthDate = new DateTime(1954, 8, 20) },
        new() { EmployeeID = 1005, FullName = "Bambang", BirthDate = new DateTime(1954, 8, 21) },
        new() { EmployeeID = 1006, FullName = "Cindy", BirthDate = new DateTime(1954, 8, 22) },
        new() { EmployeeID = 1007, FullName = "Citra", BirthDate = new DateTime(1954, 8, 23) },
        new() { EmployeeID = 1008, FullName = "Dewi", BirthDate = new DateTime(1954, 8, 24) },
        new() { EmployeeID = 1009, FullName = "Dian", BirthDate = new DateTime(1954, 8, 25) },
        new() { EmployeeID = 1010, FullName = "Eko", BirthDate = new DateTime(1954, 8, 26) }
    ];
}
