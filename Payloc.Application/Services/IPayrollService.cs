using Payloc.Domain.Payroll;

namespace Payloc.Application.Services;

public interface IPayrollService
{
    Task<PayCheck?> CalculatePayroll(string employeeId, CancellationToken ct);
}