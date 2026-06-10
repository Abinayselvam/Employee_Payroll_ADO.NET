// See https://aka.ms/new-console-template for more information
using Employee_payroll_Application_ADO.NET;

Console.WriteLine("Hello, World!");

EmployeePayrollDBService service = new EmployeePayrollDBService();
//service.GetConnection();
List<EmployeePayrollData> empdata = service.GetEmployeePayrollDatas();

foreach(EmployeePayrollData emp in empdata)
{
    Console.WriteLine(emp);
}

bool updated =
        service.UpdateEmployeeData(
                "Terisa",
                3000000.00);


if (updated)
{
    Console.WriteLine(
            "Salary Updated Successfully");
}
else
{
    Console.WriteLine(
            "Employee Not Found");
}

double salary =
        service.GetEmployeeSalary(
                "Terisa");

Console.WriteLine(
        "Current Salary : " + salary);

// UC4
service.AddEmployee(new EmployeePayrollData
{
    Name = "John",
    Salary = 50000,
    StartDate = DateTime.Now
});