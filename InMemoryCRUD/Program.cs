using InMemoryCRUD.DTOs.request.employee;
using InMemoryCRUD.Services;
using InMemoryCRUD.Services.Interfaces;
using InMemoryCRUD.Utils;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverterUsingDateFormat());
    });

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "In-Memory CRUD",
        Version = "v1",
        Description = "This API provides basic CRUD operations for managing employee data in an in-memory store."
    });
    c.EnableAnnotations();
    c.ExampleFilters();
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<EmployeeRequestExample>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();