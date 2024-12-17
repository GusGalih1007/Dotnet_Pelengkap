using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Departmentjoin;

namespace Pelengkap.Dto.Group
{
    public class DepartmentGroupDto
    {
        public required string TeacherName { get; set; }
        public List<DepartmentjoinDto>? DepartmentName { get; set; }
    }
}