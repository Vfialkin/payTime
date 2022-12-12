using Payloc.Domain.Employees;

namespace Payloc.Application.Services;

public interface IEmployeeService
{
    Task<Employee?> GetEmployee(string employeeId, CancellationToken ct);
    Task AddDependent(string employeeId, DependentPerson dependentPerson, CancellationToken ct);
    Task RemoveDependent(string employeeId, string dependentId, CancellationToken ct);
    Task AddBenefit(string employeeId, string benefitName, CancellationToken ct);
    Task RemoveBenefit(string employeeId, string benefitName, CancellationToken ct);
    Task<decimal?> BenefitsAnnualCost(string employeeId, CancellationToken ct);
}