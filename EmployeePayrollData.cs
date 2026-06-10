using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_payroll_Application_ADO.NET
{
    public class EmployeePayrollData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
    }
}
