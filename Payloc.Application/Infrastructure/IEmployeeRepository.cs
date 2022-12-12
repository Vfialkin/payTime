using Payloc.Domain.Employees;

namespace Payloc.Application.Infrastructure;

internal interface IEmployeeRepository
{
    Task<Employee?> GetEmployee(string employeeId, CancellationToken ct);

    Task UpdateEmployee(Employee employee, CancellationToken ct);
}