using Microsoft.AspNetCore.Mvc;

namespace dbContext.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly Efcontext _dbcontext;

        public CompanyController(Efcontext context)
        {
            _dbcontext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return Ok(await _dbcontext.Company.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Getbyid(int id)
        {
            var company = await _dbcontext.Company.FindAsync(id);
            if (company == null)
                return BadRequest("Company not found");
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<List<Company>>> Add(Company company)
        {
            _dbcontext.Company.Add(company);
            _dbcontext.SaveChanges();

            return Ok(await _dbcontext.Company.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Company>>> Update(Company request)
        {
            var dbCompany = _dbcontext.Company.Find(request.Id);
            if (dbCompany == null)
                return BadRequest("Company not found");

            dbCompany.Id = request.Id;
            dbCompany.Name = request.Name;
            dbCompany.Location = request.Location;

            _dbcontext.SaveChanges();

            return Ok(_dbcontext.Company.ToList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Company>>> Delete(int id)
        {
            var dbcomp = _dbcontext.Company.Find(id);
            if (dbcomp == null)
                return BadRequest("Company not found");

            _dbcontext.Company.Remove(dbcomp);
            _dbcontext.SaveChanges();

            return Ok(_dbcontext.Company.ToList());
        }

    }
}
