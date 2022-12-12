using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payloc.Application.Services;

namespace Payloc.API.Payroll.V1;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class PayrollController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPayrollService _service;

    public PayrollController(IPayrollService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{employeeId}")]
    public async Task<PayCheckModel?> GetById(string employeeId, CancellationToken ct)
    {
        return _mapper.Map<PayCheckModel>(await _service.CalculatePayroll(employeeId, ct));
    }
}