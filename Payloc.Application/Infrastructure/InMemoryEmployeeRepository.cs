using Payloc.Domain.Employees;

namespace Payloc.Application.Infrastructure;

/// <summary>
/// In memory repository for manual testing 
/// </summary>
internal class InMemoryEmployeeRepository : IEmployeeRepository
{
    private static readonly Dictionary<string, Employee> Employees = new ();

    public Task<Employee?> GetEmployee(string employeeId, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        if (!Employees.ContainsKey(employeeId))
        {
            //for test simplicity I add fake one on get to always have a person in db
            var employee = new Employee()
            {
                Id = employeeId,
            };
            Employees.Add(employeeId, employee);
        }

        Employees.TryGetValue(employeeId, out var result);
        return Task.FromResult(result);
    }

    public Task UpdateEmployee(Employee employee, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        if (Employees.ContainsKey(employee.Id))
        {
            Employees[employee.Id] = employee;
        }
        else
        {
            Employees.Add(employee.Id, employee);
        }

        return Task.CompletedTask;
    }
}