using Microsoft.AspNetCore.Mvc;

namespace dbContext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Efcontext _dbcontext;

        public EmployeeController(Efcontext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _dbcontext.Employee.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Getbyid(int id)
        {
            var emp = await _dbcontext.Employee.FindAsync(id);
            if (emp == null)
                return BadRequest("Employee not found");
            return Ok(emp);
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> Add(Employee emp)
        {
            _dbcontext.Employee.Add(emp);
            _dbcontext.SaveChanges();

            return Ok(_dbcontext.Employee.ToList());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> Update(Employee employeeD)
        {
            var dbEmployee = _dbcontext.Employee.Find(employeeD.Id);
            if (dbEmployee == null)
                return BadRequest("Employee not found");

            dbEmployee.Name = employeeD.Name;

            dbEmployee.Id = employeeD.Id;

            dbEmployee.Age = employeeD.Age;

            dbEmployee.Location = employeeD.Location;

            dbEmployee.CompID = employeeD.CompID;

            _dbcontext.SaveChanges();

            return Ok(_dbcontext.Employee.ToList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            var dbemp = _dbcontext.Employee.Find(id);
            if (dbemp == null)
                return BadRequest("Employee not found");

            _dbcontext.Employee.Remove(dbemp);
            _dbcontext.SaveChanges();

            return Ok(_dbcontext.Employee.ToList());
        }
    }
}
