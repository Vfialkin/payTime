using Payloc.Domain.Employees;

namespace Payloc.Domain.Benefits;

public abstract class Benefit
{
    public abstract string Id { get; }

    public abstract decimal CalculateAnnualCost(Employee employee);
}