using Microsoft.Data.SqlClient;

namespace Employee_payroll_Application_ADO.NET
{
    public class EmployeePayrollDBService
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=payroll_service;Trusted_Connection=True;TrustServerCertificate=True";

        public void GetConnection()
        {
            using SqlConnection connection= new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Successfully connected database");
           
            Console.WriteLine(
           "Database Name : " +
           connection.Database
                  );

            Console.WriteLine(
                "Server Name : " +
                connection.DataSource
            );
        }

    }
}
