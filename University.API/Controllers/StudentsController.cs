using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.BLL.Dtos;
using University.DAL.DataContext;
using University.DAL.Entities;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        public StudentsController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _dbContext.Students.ToListAsync();
            var studentsDtos = _mapper.Map<List<StudentDto>>(students);

            return Ok(studentsDtos);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
                return NotFound("Bele telebe movcud deyil");

            var studentDto = _mapper.Map<StudentDto>(student);       

            return Ok(studentDto);
        }
    }
}
