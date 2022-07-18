using Microsoft.AspNetCore.Mvc;
using Fitness_club_API.Utilities;
using Fitness_club_API.Models;
using Library;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fitness_club_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class EmployeesController : ControllerBase
    {

        private DataBase data = new DataBase();
        private Employees employee=new Employees();
        private List<Employees> employees;

        private readonly Clients? client;


        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employees Get(int Id)
        {
            (employee, employees) = data.EmployeesReader(Id);
            return employee;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employees> Get()
        {
            int number = CountOfViews.ReadFromCounter();
            CountOfViews.AddToCounter(number);

            (employee, employees) = data.EmployeesReader();
            return employees;

        }

        // POST api/<EmployeesController>
        [HttpPost]
        public void Post([FromBody] Employees employee)
        {
            data.Writer(client,employee);
        }


        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            data.Eraser(id, "Employees");
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
