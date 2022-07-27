using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreatingAPIFromNorthWind.Models;

namespace CreatingAPIFromNorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public NorthwindContext northwindcontext = new NorthwindContext();

        [HttpGet("GetAllEmployees")]
        public List<Employee> GetAll()
        {
            return northwindcontext.Employees.ToList();
        }
        [HttpGet("GetEmployeeInfoById")]
        public Employee GetById(int Id)
        {
            return northwindcontext.Employees.FirstOrDefault(x => x.EmployeeId == Id);
        }
        [HttpPost("AddEmployee")]
        public Employee AddEmployee(string LastName, string FirstName, string Title, string TitleOfCourtesy)
        {
            Employee employee = new Employee()
            {
                LastName = LastName,
                FirstName = FirstName,
                Title = Title,
                TitleOfCourtesy = TitleOfCourtesy
            };
            northwindcontext.Add(employee);
            northwindcontext.SaveChanges();
            return employee;
        }





    }
}
