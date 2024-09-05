using InMemoryCRUD.DTOs.request.employee;
using InMemoryCRUD.DTOs.Response;
using InMemoryCRUD.DTOs.Response.employee;

namespace InMemoryCRUD.Services.Interfaces;

public interface IEmployeeService
{
    PagedResponse<EmployeeResponse> GetAllEmployees(int page, int size);
    EmployeeResponse GetEmployeeById(long id);
    EmployeeResponse AddEmployee(EmployeeRequest employee);
    EmployeeResponse UpdateEmployee(long id, EmployeeRequest employee);
    EmployeeResponse DeleteEmployee(long id);
}