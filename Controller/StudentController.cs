using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelengkap.Dto.Studentjoin;
using Pelengkap.Interface;
using Pelengkap.Mapper;

namespace Pelengkap.Controller
{
    [Route("student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentJoinRepository _studentrepository;
        private readonly IDepartmentRepository _departmentRepository;
        public StudentController(IStudentJoinRepository studentJoin, IDepartmentRepository departmentRepository)
        {
            _studentrepository = studentJoin;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// Read all using repository and dipendency injection
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentrepository.GetAllAsync();

            var studentDto = students.Select(s => s.ToStudentDto());

            return Ok(studentDto);
        }

        /// <summary>
        /// Read by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var studentId = await _studentrepository.GetByIdAsync(id);

            if(studentId == null)
            {
                return NotFound("Student does not exist");
            }

            return Ok(studentId.ToStudentDto());
        }

        /// <summary>
        /// Create data by using repository pattern and DI
        /// </summary>
        /// <param name="createStudents"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateStudentsJoin createStudents)
        {
            var createSt = createStudents.CreateStudentDto();

            var departId = createSt.DepartmentId;

            if(! await _departmentRepository.DepartmentExists(departId))
            {
                return NotFound("Department can't be found/does not exist");
            }

            await _studentrepository.CreateAsync(createSt);

            return CreatedAtAction(nameof(GetById), new { id = createSt.Id }, createSt.ToStudentDto());
        }

        /// <summary>
        /// Update by using repository pattern and DI
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateStudent"></param>
        /// <returns></returns>
        [HttpPut("edit/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateStudentDto updateStudent)
        {
            var departId = updateStudent.DepartmentId;

            if(! await _departmentRepository.DepartmentExists(departId))
            {
                return NotFound("Department does not exist");
            }
            
            var editStudent = await _studentrepository.UpdateAsync(id, updateStudent);

            if (editStudent == null)
            {
                return NotFound("Student does not exist");
            }

            return Ok("Data edited successfully");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var del = await _studentrepository.DeleteAsync(id);

            if (del == null)
            {
                return NotFound("Student does not exist");
            }

            return Ok("Data deleted successfully");
        }
    }
}