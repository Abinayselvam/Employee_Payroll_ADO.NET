// See https://aka.ms/new-console-template for more information
using Employee_payroll_Application_ADO.NET;

Console.WriteLine("Hello, World!");

EmployeePayrollDBService service = new EmployeePayrollDBService();
service.GetConnection();
