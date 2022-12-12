using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payloc.Application.Infrastructure;
using Payloc.Application.Services;
using Payloc.Domain.Payroll;

namespace Payloc.Application;

public static class Registrations
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IPayrollService, PayrollService>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        
        services.AddTransient<Payroll>();

        services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();

        return services;
    }
}