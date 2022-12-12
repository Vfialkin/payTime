namespace Payloc.Domain.Employees;

public class DependentPerson : Person
{
    public DependentTypes RelationToEmployee { get; set; }
}