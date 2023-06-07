using EntityFrameCoreInMemory.Entities;
using EntityFrameCoreInMemory.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFramworkInMemory.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeRepo _employeeRepository;
        public EmployeeController(IEmployeeRepo employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee? Get(int id)
        {
            return _employeeRepository.GetById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post()
        {
            var empList = new List<Employee>
            {
                new Employee{ Id = 1, FirstName = "Hoang", LastName = "Nguyen Le"},
                new Employee{ Id = 2, FirstName = "Thu", LastName = "Trang"},
                new Employee{ Id = 3, FirstName = "Viet", LastName = "Nguyen"},
            };

            foreach (var item in empList)
            {
                _employeeRepository.Add(item);
            }
            _employeeRepository.Save();
            return;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
