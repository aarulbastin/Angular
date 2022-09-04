using EmployeeViewAngular.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeViewAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
       // [Authorize]
        //[HttpGet]
        //public IEnumerable<Employee> Get()
        //{
        //    List<Employee> employees = new List<Employee>()
        //    {
        //        new Employee(){ID=1,Name="Ram",Salary=1000},
        //        new Employee(){ID=2,Name="Raj",Salary=2000},
        //        new Employee(){ID=3,Name="Rahul",Salary=3000}
        //    };
        //    return employees.ToArray();
        //}

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
