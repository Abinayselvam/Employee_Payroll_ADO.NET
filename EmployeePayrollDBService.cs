using Microsoft.Data.SqlClient;

namespace Employee_payroll_Application_ADO.NET
{
    public class EmployeePayrollDBService
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=payroll_service;Trusted_Connection=True;TrustServerCertificate=True";

        public List<EmployeePayrollData> GetEmployeePayrollDatas()
        {
            List<EmployeePayrollData> emplist= new List<EmployeePayrollData>();

            //step 1 create connection
            using SqlConnection connection=new SqlConnection(connectionString);
            //step2 open connection
            connection.Open();
            //step3 query for that operations
            string query = "SELECT * FROM employee_payroll";
            //step4 command query to get the data from db
            SqlCommand command = new SqlCommand(query,connection);
            //step5 datareader store the data in this temporary table
            SqlDataReader reader = command.ExecuteReader();
            //step6 iterate the data from the datareader
            while (reader.Read())
            {
                EmployeePayrollData empdata = new EmployeePayrollData
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Salary=Convert.ToDouble(reader.GetDecimal(2)),
                    StartDate = reader.GetDateTime(3),
                };
                emplist.Add(empdata);
            }
            return emplist;
        }
        

    }
}
