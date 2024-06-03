
using Microsoft.Data.SqlClient;

namespace WebApiProject.Data
{
    public class EmployeeService:IEmployeeService
    {
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=NewEmployee;Trusted_Connection=True;";

        public void DeleteEmployee(int empNo)
        {

            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmpNo = @EmpNo", cn))
                {
                    cmd.Parameters.AddWithValue("@EmpNo", empNo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmps = new List<Employee>();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lstEmps.Add(new Employee
                            {
                                EmpNo = dr.GetInt32(0),
                                Name = dr.GetString(1),
                                Basic = dr.GetDecimal(2),
                                DeptNo = dr.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return lstEmps;
        }
    

        public Employee GetSingleEmployee(int empNo)
        {
            Employee obj = new Employee();
            using (SqlConnection cn = new SqlConnection(_connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE EmpNo = @EmpNo", cn))
                {
                    cmd.Parameters.AddWithValue("@EmpNo", empNo);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj.EmpNo = dr.GetInt32(0);
                            obj.Name = dr.GetString(1);
                            obj.Basic = dr.GetDecimal(2);
                            obj.DeptNo = dr.GetInt32(3);
                        }
                    }
                }
            }
            return obj;
        }
    

        public void InsertEmployee(Employee employee)
        {
        using (SqlConnection cn = new SqlConnection(_connectionString))
        {
            cn.Open();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Employees VALUES ( @Name, @Basic, @DeptNo)", cn))
            {
                cmd.Parameters.AddWithValue("@EmpNo", employee.EmpNo);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Basic", employee.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", employee.DeptNo);
                cmd.ExecuteNonQuery();
            }
        }
    }

        public void UpdateEmployee(Employee employee)
        {
            using(SqlConnection cn = new SqlConnection(_connectionString))
        {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Employees SET Name = @Name, Basic = @Basic, DeptNo = @DeptNo WHERE EmpNo = @EmpNo", cn))
                {
                    cmd.Parameters.AddWithValue("@EmpNo", employee.EmpNo);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@Basic", employee.Basic);
                    cmd.Parameters.AddWithValue("@DeptNo", employee.DeptNo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
