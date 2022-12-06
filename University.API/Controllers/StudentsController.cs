using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.DAL.DataContext;
using University.DAL.Entities;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public StudentsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var student = await _dbContext.Students.ToListAsync();
            
            return Ok(student);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
                return NotFound("Bele telebe movcud deyil");

            return Ok(student);
        }
    }
}
