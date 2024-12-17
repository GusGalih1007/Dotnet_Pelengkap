using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Departmentjoin;
using Pelengkap.Dto.Studentjoin;
using Pelengkap.Dto.Teacherjoin;

namespace Pelengkap.Dto.Group
{
    public class TeachDepartStudGroupDto
    {
        public required TeacherjoinDto TeacherName { get; set; }
        public required DepartmentjoinDto DepartmentName { get; set; }
        public required StudentjoinDto StudentName { get; set; }
    }
}