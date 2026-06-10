
namespace Employee_payroll_Application_ADO.NET
{
    public class EmployeePayrollData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public override string ToString()
        {
            return $"Id:{Id} Name:{Name} Salary:{Salary} StartDate:{StartDate:yyyy-MM-dd}";
        }

    }
}
