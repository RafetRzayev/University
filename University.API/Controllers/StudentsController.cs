using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.DAL.Entities;
using University.DAL.Repository.Contracts;
using Unversity.BLL.Dtos;
using Unversity.BLL.Services.Contracts;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentsController(IRepository<Student> repository, IMapper mapper, IStudentService studentService)
        {
            _repository = repository;
            _mapper = mapper;
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _repository.GetAllAsync();
            var studentDtos = _mapper.Map<List<StudentDto>>(students);
            
            return Ok(studentDtos);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _repository.GetAsync(id);

            if (student == null)
                return NotFound("Bele telebe movcud deyil");

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreateDto studentCreateDto)
        {
            var student = _mapper.Map<Student>(studentCreateDto);

            await _repository.AddAsync(student);

            return Ok(student.Id);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] StudentDto studentDto)
        {
            var existStudent = await _repository.GetAsync(id);

            if (studentDto.Id != id)
                return BadRequest();

            var updatedStudent = _mapper.Map<Student>(studentDto);

            await _repository.UpdateAsync(updatedStudent);

            return Ok(updatedStudent.Id);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _repository.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            
            return Ok(_studentService.Test());
        }
    }
}
