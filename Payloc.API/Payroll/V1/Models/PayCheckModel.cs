public record PayCheckModel()
{
    public DateTime PayDate { get; init; }

    public decimal BasePayRate { get; init; }

    public decimal BenefitDeductions { get; init; }

    public decimal Total { get; init; }
}