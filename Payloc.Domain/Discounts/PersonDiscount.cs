using Payloc.Domain.Employees;

namespace Payloc.Domain.Discounts;

/// <summary>
/// Applies discounts based on Person context
/// </summary>
public abstract class PersonDiscount
{
    public abstract decimal ApplyDiscount(Person person, decimal originalCost);
}