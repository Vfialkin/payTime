using System.Collections;
using Payloc.Domain.Benefits;

namespace Payloc.Domain.Employees;

public class EmployeeBenefits : IEnumerable<Benefit>
{
    private readonly Employee _employee;

    private List<Benefit> Benefits { get; } = new();

    public EmployeeBenefits(Employee employee)
    {
        _employee = employee;
    }

    public void Add(Benefit benefit)
    {
        Benefits.Add(benefit);
    }

    public bool Remove(Benefit benefit)
    {
       return Benefits.Remove(benefit);
    }

    /// <summary>
    /// Lists all benefits with cost
    /// (I used tuple for simplicity to avoid adding another model)
    /// </summary>
    /// <returns>Name and Cost of each benefit</returns>
    public IEnumerable<(string Name, decimal Cost)> Describe()
    {
        return Benefits.Select(x => (Name: x.Id, x.CalculateAnnualCost(_employee)));
    }

    public decimal GetTotalAnnualCost()
    {
        return Benefits.Sum(x => x.CalculateAnnualCost(_employee));
    }

    public IEnumerator<Benefit> GetEnumerator()
    {
        return Benefits.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}