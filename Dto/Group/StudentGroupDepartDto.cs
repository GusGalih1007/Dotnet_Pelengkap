using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Studentjoin;

namespace Pelengkap.Dto.Group
{
    public class StudentGroupDepartDto
    {
        public required string DepartmentName { get; set; }
        public List<StudentjoinDto>? StudentName { get; set; }
    }
}