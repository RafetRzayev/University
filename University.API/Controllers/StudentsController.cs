using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using University.BLL.Dtos;
using University.BLL.Services.Contracts;
using University.DAL.Entities;
using University.DAL.Repositories.Contracts;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Student> _studentRepository;
        private readonly IStudentService _studentService;
        public StudentsController(IMapper mapper, IRepository<Student> studentRepository, IStudentService studentService)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentsDtos = _mapper.Map<List<StudentDto>>(students);

            return Ok(studentsDtos);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _studentRepository.GetAsync(id);

            if (student == null)
                return NotFound("Bele telebe movcud deyil");

            var studentDto = _mapper.Map<StudentDto>(student);       

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDto studentCreateDto)
        {
            var createdStudent = _mapper.Map<Student>(studentCreateDto);

            await _studentRepository.AddAsync(createdStudent);

            return Created(HttpContext.Request.Path, createdStudent.Id);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put([FromRoute]int? id, [FromBody] StudentDto studentDto)
        {
            if (id == null) return NotFound();

            var existStudent = await _studentRepository.GetAsync(id);

            if (existStudent == null) return NotFound();

            if (studentDto.Id != id) return BadRequest();

            var student = _mapper.Map<Student>(studentDto);

            await _studentRepository.UpdateAsync(student);

            return Ok();
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromRoute]int? id)
        {
            await _studentRepository.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok(await _studentService.Test());
        }
    }
}
