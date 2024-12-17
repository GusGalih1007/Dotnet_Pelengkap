using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelengkap.Dto.Teacherjoin;
using Pelengkap.Interface;
using Pelengkap.Mapper;

namespace Pelengkap.Controller
{
    [Route("/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// read all data using repositary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherRepository.GetAllAsync();

            var teacherDto = teachers.Select(t => t.ToTeacherDto());

            return Ok(teacherDto);
        }

        /// <summary>
        /// Read data By Id using repositary
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var teacherId = await _teacherRepository.GetByIdAsync(id);

            if (teacherId == null)
            {
                return NotFound("Teacher does not exist");
            }

            return Ok(teacherId.ToTeacherDto());
        }

        /// <summary>
        /// Create teacher data using repositary
        /// </summary>
        /// <param name="teacherFDto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateTeacherFDto teacherFDto)
        {
            var teacherData = teacherFDto.CreateTeacherDto();

            await _teacherRepository.CreateAsync(teacherData);

            return CreatedAtAction(nameof(GetById), new { id = teacherData.Id }, teacherData.ToTeacherDto());
        }

        /// <summary>
        /// Update data by selecting id using repostory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherDto"></param>
        /// <returns></returns>
        [HttpPut("edit/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromForm] UpdateTeacherDto teacherDto)
        {
            var editTeacher = await _teacherRepository.UpdateAsync(id, teacherDto);

            if (editTeacher == null)
            {
                return NotFound("Teacher does not Exist");
            }

            return Ok(new {message = "Data edited", data = editTeacher.ToTeacherDto()});
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var delTeacher = await _teacherRepository.DeleteAsync(id);

            if(delTeacher == null)
            {
                return NotFound("Teacher does not exist");
            }

            return Ok("Data deleted successfully");
        }
    }
}