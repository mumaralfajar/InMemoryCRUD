using Swashbuckle.AspNetCore.Filters;

namespace InMemoryCRUD.DTOs.request.employee;

public class EmployeeRequestExample : IExamplesProvider<EmployeeRequest>
{
    public EmployeeRequest GetExamples()
    {
        return new EmployeeRequest
        {
            FullName = "John Doe",
            BirthDate = new DateTime(1990, 9, 15)
        };
    }
}