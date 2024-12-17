using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelengkap.Dto.Departmentjoin;
using Pelengkap.Interface;
using Pelengkap.Mapper;

namespace Pelengkap.Controller
{
    [Route("/Department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ITeacherRepository _teacherRepository;
        public DepartmentController(IDepartmentRepository departmentRepository, ITeacherRepository teacherRepository)
        {
            _departmentRepository = departmentRepository;
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// get all department data using repository pattern and DI + Dto
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentRepository.GetAllAsync();

            var departmentDto = departments.Select(d => d.ToDepartmentDto());

            return Ok(departmentDto);
        }

        /// <summary>
        /// Get department data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var departmentId = await _departmentRepository.GetByIdAsync(id);

            if (departmentId == null)
            {
                return NotFound("Department does not exist!");
            }

            return Ok(departmentId.ToDepartmentDto());
        }

        /// <summary>
        /// create department data
        /// </summary>
        /// <param name="createDeparment"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateDeparmentDto createDeparment)
        {
            var dataDepart = createDeparment.CreateDepartmentDto();

            var teacherId = dataDepart.TeacherId;

            if (!await _teacherRepository.TeacherExists(teacherId))
            {
                return NotFound("Teacher does not exist!");
            }

            await _departmentRepository.CreateAsync(dataDepart);

            return CreatedAtAction(nameof(GetById), new { id = dataDepart.Id }, dataDepart.ToDepartmentDto());
        }

        /// <summary>
        /// update department data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDepartment"></param>
        /// <returns></returns>
        [HttpPut("edit/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] UpdateDepartmentDto updateDepartment)
        {
            var teacherId = updateDepartment.TeacherId;

            if(! await _teacherRepository.TeacherExists(teacherId))
            {
                return NotFound("Teacher does not exist");
            }
            
            var editDepart = await _departmentRepository.UpdateAsync(id, updateDepartment);

            if (editDepart == null)
            {
                return NotFound("Department does not exist");
            }

            return Ok(new
            {
                message = "Data edited successfully",
                data = editDepart.ToDepartmentDto()
            });
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var delDepart = await _departmentRepository.DeleteAsync(id);

            if(delDepart == null)
            {
                return NotFound("Department does not exist");
            }

            return Ok("Data deleted successfully");
        }
    }
}