using Payloc.Application.Infrastructure;
using Payloc.Domain.Benefits;
using Payloc.Domain.Employees;

namespace Payloc.Application.Services;

internal class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo = repo;
    }

    public Task<Employee?> GetEmployee(string employeeId, CancellationToken ct)
    {
        return _repo.GetEmployee(employeeId, ct);
    }

    public async Task AddDependent(string employeeId, DependentPerson dependentPerson, CancellationToken ct)
    {
        var employee = await _repo.GetEmployee(employeeId, ct);
        if (employee == null) { return; }
        
        employee.Dependents.Add(dependentPerson);
        await _repo.UpdateEmployee(employee, ct);
    }

    public async Task RemoveDependent(string employeeId, string dependentId, CancellationToken ct)
    {
        var employee = await _repo.GetEmployee(employeeId, ct);
        if (employee == null) { return; }

        var toRemove = employee.Dependents.FirstOrDefault(x => x.Id == dependentId);
        if (toRemove != null)
        {
            employee.Dependents.Remove(toRemove);
            await _repo.UpdateEmployee(employee, ct);
        }
    }

    public async Task AddBenefit(string employeeId, string benefitName, CancellationToken ct)
    {
        var employee = await _repo.GetEmployee(employeeId, ct);
        if (employee == null) return;
        
        var benefit = new DefaultBenefit(); //shortcut, would need some factory here to create by name
        employee.Benefits.Add(benefit);
        await _repo.UpdateEmployee(employee, ct);
    }

    public async Task RemoveBenefit(string employeeId, string benefitName, CancellationToken ct)
    {
        var employee = await _repo.GetEmployee(employeeId, ct);
        if (employee == null) { return; }

        var toRemove = employee.Benefits.FirstOrDefault(x => x.Id == benefitName);
        if (toRemove != null)
        {
            employee.Benefits.Remove(toRemove);
            await _repo.UpdateEmployee(employee, ct);
        }
    }

    public async Task<decimal?> BenefitsAnnualCost(string employeeId, CancellationToken ct)
    {
        var employee = await _repo.GetEmployee(employeeId, ct);
        return employee?.Benefits.GetTotalAnnualCost();
    }
}