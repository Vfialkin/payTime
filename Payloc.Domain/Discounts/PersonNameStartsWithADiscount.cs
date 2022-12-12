using Payloc.Domain.Employees;

namespace Payloc.Domain.Discounts;

/// <summary>
/// Applies discount based on first letter of a name
/// </summary>
public class PersonNameStartsWithADiscount: PersonDiscount
{
    protected decimal LetterADiscountPercentage = 10;//%

    public override decimal ApplyDiscount(Person person, decimal originalCost)
    {
        if (person.FullName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase))
        {
            originalCost = CalculateDiscount(originalCost);
        }

        decimal CalculateDiscount(decimal cost)
        {
            return cost - cost * LetterADiscountPercentage / 100;
        }

        return originalCost;
    }
}