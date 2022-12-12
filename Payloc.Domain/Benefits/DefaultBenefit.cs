using Payloc.Domain.Discounts;
using Payloc.Domain.Employees;

namespace Payloc.Domain.Benefits;

public class DefaultBenefit : Benefit
{
    protected int AnnualCost = 1000;//$
    protected int DependentAnnualCost = 500;//$

    private readonly PersonDiscount _personDiscount;

    public DefaultBenefit():this(new PersonNameStartsWithADiscount()) { }//shortcut 

    public DefaultBenefit(PersonDiscount personDiscount)
    {
        _personDiscount = personDiscount;
    }

    protected virtual DependentTypes[] ApplicableDependentTypes => new[] { DependentTypes.Child, DependentTypes.Spouse };

    public override string Id => nameof(DefaultBenefit);

    public override decimal CalculateAnnualCost(Employee employee)
    {
        var resultCost = _personDiscount.ApplyDiscount(employee, AnnualCost);
            
        foreach (var dependent in employee.Dependents)
        {
            if (ApplicableDependentTypes.Contains(dependent.RelationToEmployee))
                resultCost += _personDiscount.ApplyDiscount(dependent, DependentAnnualCost);
        }

        return resultCost;
    }
}