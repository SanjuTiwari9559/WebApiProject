namespace WebApiProject.Data
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetSingleEmployee(int empNo);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int empNo);
    }
}
