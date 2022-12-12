using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Payloc.Application.Services;
using Payloc.Domain.Employees;

namespace Payloc.API.Employee.V1;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class EmployeesController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEmployeeService _service;

    public EmployeesController(IEmployeeService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet("{employeeId}")]
    public async Task<EmployeeModel> GetById(string employeeId, CancellationToken ct)
    {
        return _mapper.Map<EmployeeModel>(await _service.GetEmployee(employeeId, ct));
    }

    [HttpGet("{employeeId}/benefits")]
    public async Task<IEnumerable<BenefitModel>> ListBenefits(string employeeId, CancellationToken ct)
    {
        return _mapper.Map<List<BenefitModel>>((await _service.GetEmployee(employeeId, ct))?.Benefits.Describe());
    }

    [HttpPost("{employeeId}/benefits/{benefitName}")]
    public Task AddBenefit(string employeeId, string benefitName, CancellationToken ct)
    {
        return _service.AddBenefit(employeeId, benefitName, ct);
    }

    [HttpDelete("{employeeId}/benefits/{benefitName}")]
    public Task RemoveBenefit(string employeeId, string benefitName, CancellationToken ct)
    {
        return _service.RemoveBenefit(employeeId, benefitName, ct);
    }

    [HttpGet("{employeeId}/dependents")]
    public async Task<IEnumerable<DependentModel>> ListDependents(string employeeId, CancellationToken ct)
    {
        return _mapper.Map<List<DependentModel>>((await _service.GetEmployee(employeeId, ct))?.Dependents);
    }

    [HttpPost("{employeeId}/dependents/{dependent}")]
    public Task AddDependent(string employeeId, DependentModel dependent, CancellationToken ct)
    {
        return _service.AddDependent(employeeId, _mapper.Map<DependentPerson>(dependent), ct);
    }

    [HttpDelete("{employeeId}/dependents/{dependentId}")]
    public Task RemoveDependent(string employeeId, string dependentId, CancellationToken ct)
    {
        return _service.RemoveDependent(employeeId, dependentId, ct);
    }
}