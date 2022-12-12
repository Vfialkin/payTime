using Payloc.Application.Infrastructure;
using Payloc.Domain.Payroll;

namespace Payloc.Application.Services;

internal class PayrollService : IPayrollService
{
    private readonly IEmployeeRepository _repo;
    readonly Payroll _payroll;

    public PayrollService(IEmployeeRepository repo, Payroll payroll)
    {
        _repo = repo;
        _payroll = payroll;
    }

    public async Task<PayCheck?> CalculatePayroll(string employeeId, CancellationToken ct)
    {
        var employee = await _repo.GetEmployee(employeeId, ct);
        return employee == null ? null : _payroll.CreatePaycheck(employee);
    }
}