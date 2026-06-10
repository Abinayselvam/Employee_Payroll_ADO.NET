using Microsoft.Data.SqlClient;

namespace Employee_payroll_Application_ADO.NET
{
    public class EmployeePayrollDBService
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=payroll_service;Trusted_Connection=True;TrustServerCertificate=True";
        
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection Established Successfully");
            return connection;
        }
        public List<EmployeePayrollData> GetEmployeePayrollDatas()
        {
            List<EmployeePayrollData> emplist= new List<EmployeePayrollData>();

            //step 1 create connection
            using SqlConnection connection = GetConnection();
            //step2 query for that operations
            string query = "SELECT * FROM employee_payroll";
            //step3 command query to get the data from db
            SqlCommand command = new SqlCommand(query,connection);
            //step4 datareader store the data in this temporary table
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

        public bool UpdateEmployeeData(String name,double salary)
        {
            using SqlConnection connection = GetConnection();
            string query = "UPDATE employee_payroll SET salary=@salary where name=@name ";
            SqlCommand command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@salary", salary);
            command.Parameters.AddWithValue ("name", name);
            int rowAffected  = command.ExecuteNonQuery();
            Console.WriteLine($"Rows Affected = {rowAffected}");
            return rowAffected > 0;
        }
        public double GetEmployeeSalary(String name)
        {
            using SqlConnection connection = GetConnection();
            string query = "SELECT salary FROM employee_payroll WHERE name = @name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            object result = command.ExecuteScalar();    
            return Convert.ToDouble(result);
        }

        public int AddEmployee(EmployeePayrollData data)
        {
            using SqlConnection conn = GetConnection();
            string query = "INSERT INTO employee_payroll (name,salary,start) values (@name,@salary,@start)";
            SqlCommand command = new SqlCommand (query,conn);
            command.Parameters.AddWithValue("@name", data.Name);
            command.Parameters.AddWithValue("@salary", data.Salary);
            command.Parameters.AddWithValue("@start", data.StartDate);
            return command.ExecuteNonQuery ();

        }

        //salary analysis
        public void GetSalaryAnalysis()
        {
            using SqlConnection connection = GetConnection();

            string query =
                "SELECT gender, SUM(salary), AVG(salary), MIN(salary), MAX(salary), COUNT(*) " +
                "FROM employee_payroll GROUP BY gender";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(
                    $"Gender:{reader.GetString(0)} " +
                    $"SUM:{reader.GetDecimal(1)} " +
                    $"AVG:{reader.GetDecimal(2)} " +
                    $"MIN:{reader.GetDecimal(3)} " +
                    $"MAX:{reader.GetDecimal(4)} " +
                    $"COUNT:{reader.GetInt32(5)}"
                );
            }
        }


    }
}
