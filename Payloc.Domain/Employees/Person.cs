namespace Payloc.Domain.Employees;

public abstract class Person
{
    public string Id { get; set; } = null!;

    public string FullName { get; set; } = string.Empty;
}