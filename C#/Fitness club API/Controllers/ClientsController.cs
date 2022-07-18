using Fitness_club_API.Models;
using Fitness_club_API.Utilities;
using Library;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fitness_club_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientsController : ControllerBase
    {
        private DataBase data = new DataBase();
        private Clients client = new Clients();
        private List<Clients> clients;

        private readonly Employees? employee;

        // GET: api/<ClientsController>
        [HttpGet("{id}")]
        public Clients Get(int id)
        {
            (client, clients) = data.ClientsReader(id);
            return client;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<Clients> Get()
        {
            

            (client, clients) = data.ClientsReader();
            return clients;
        }


        // POST api/<ClientsController>
        [HttpPost]
        public void Post([FromBody] Clients client)
        {
            data.Writer(client,employee);
        }

        

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            data.Eraser(id,"Clients");
        }


        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
