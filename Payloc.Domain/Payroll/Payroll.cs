using Payloc.Domain.Employees;

namespace Payloc.Domain.Payroll;

public class Payroll
{
    private const int PaychecksAYear = 26;

    //not implemented but would be good to round up numbers for paycheck
    //private readonly RoundingStrategy; 

    public PayCheck CreatePaycheck(Employee employee)
    {
        return CreatePaycheck(employee, DateTime.Now);
    }

    public PayCheck CreatePaycheck(Employee employee, DateTime payDate)
    {
        return new PayCheck(
            PayDate: payDate, 
            BasePayRate: employee.AnnualSalary / PaychecksAYear, 
            BenefitDeductions: employee.Benefits.GetTotalAnnualCost() / PaychecksAYear);
    }
}
