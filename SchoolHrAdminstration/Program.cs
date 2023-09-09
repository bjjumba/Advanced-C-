using System.Collections.Generic;
using System.Linq;
namespace School;

public class Program
{
    static void Main()
    {
        decimal totalSalaries = 0;
        List<IEmployee> employees = new List<IEmployee>();
        
        seedData(employees);
      
        Console.WriteLine($"Total {employees.Sum(e=>e.Salary)}");
    }
    /*Seed Data*/
    public static void seedData(List<IEmployee> employees)
    {
        /*Sample*/
        IEmployee t = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,  1,"Jimmy","k", 2000);
        employees.Add(t);
        
        IEmployee h = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,  1,"Lubwama","Stuart", 9000);
        employees.Add(h);
        
        IEmployee r = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher,  1,"Loor","J", 20000);
        employees.Add(r);
    }
}

public class Teacher : EmployeeBase
{
    /* Override Salary*/
    public override decimal Salary
    {
        get => base.Salary + (base.Salary * 0.02m);
    }
}

public class HeadOfDepartment : EmployeeBase
{
    public override decimal Salary
    {
        get => base.Salary + (base.Salary * 0.03m);
    }
}

public class DeputyHeadTeacher : EmployeeBase
{
    public override decimal Salary
    {
        get => base.Salary + (base.Salary * 0.04m);
    }
}
/* Employee Fcatory*/
public static class EmployeeFactory
{
    public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
    {
        IEmployee employee = null;
        switch (employeeType)
        {
            case EmployeeType.Teacher:
                employee = new Teacher { Id=id, FirstName = firstName, LastName = lastName, Salary = salary};
                break;
            case EmployeeType.HeadOfDepartment:
                employee = new HeadOfDepartment { Id=id, FirstName = firstName, LastName = lastName, Salary = salary};
                break;
            case EmployeeType.DeputyHeadTeacher:
                employee = new DeputyHeadTeacher { Id=id, FirstName = firstName, LastName = lastName, Salary = salary};
                break;
            default:
                break;
        }

        return employee;
    }
}