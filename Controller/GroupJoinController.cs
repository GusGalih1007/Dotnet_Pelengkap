using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelengkap.Interface;

namespace Pelengkap.Controller
{
    [Route("groupjoin")]
    [ApiController]
    public class GroupJoinController : ControllerBase
    {
        private readonly ILinqservice _linqservice;
        public GroupJoinController(ILinqservice linqservice)
        {
            _linqservice = linqservice;
        }

        /// <summary>
        /// Student group by department
        /// </summary>
        /// <returns></returns>
        [HttpGet("student-group")]
        public async Task<IActionResult> GetStudentDepartment()
        {
            var studentGroup = await _linqservice.GetStudentGroupsAsync();
            return Ok(studentGroup);
        }

        /// <summary>
        /// Department group by teacher
        /// </summary>
        /// <returns></returns>
        [HttpGet("department-group")]
        public async Task<IActionResult> GetDepartmentTeacher()
        {
            var departmentGroup = await _linqservice.GetDepartmentGroupsAsync();
            return Ok(departmentGroup);
        }

        [HttpGet("all-group")]
        public async Task<IActionResult> GetAllGroup()
        {
            var allGroup = await _linqservice.GetAllGroupAsync();
            return Ok(allGroup);
        }
    }
}