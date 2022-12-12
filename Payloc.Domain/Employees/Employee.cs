namespace Payloc.Domain.Employees;

public class Employee : Person
{
    public Employee()
    {
        Benefits = new EmployeeBenefits(this);
    }

    public Employee(EmployeeBenefits benefits)
    {
        Benefits = benefits;
    }

    public virtual decimal AnnualSalary => 2000 * 26;//$ hardcoded 

    public List<DependentPerson> Dependents { get; set; } = new();

    public EmployeeBenefits Benefits { get; init; }

}