
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Data;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            
            this.employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult<List<Employee> >GetEmployees()
        {
            return employeeService.GetAllEmployees();
        }
        [HttpGet("{id}")]

        public ActionResult<Employee> GetEmployee(int id)
        {
            return Employee.GetSingleEmployee(id);
        }
        [HttpPost]
        public void Post(Employee employee)
        {
            employeeService.InsertEmployee(employee);

        }
        [HttpPut]
        public void Put(Employee employee)
        {
            employeeService.UpdateEmployee(employee);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            employeeService.DeleteEmployee(id);
        }

    }
}

