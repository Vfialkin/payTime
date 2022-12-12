public record DependentModel
{
    public string Name { get; init; } = null!;

    public string RelationToEmployee { get; init; } = null!;
}