namespace Payloc.Domain.Payroll;

public record PayCheck(DateTime PayDate, decimal BasePayRate, decimal BenefitDeductions)
{
    public decimal Total => BasePayRate - BenefitDeductions; //feels wrong not to include taxes :)
}