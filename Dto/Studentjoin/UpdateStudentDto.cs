using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Dto.Studentjoin
{
    public class UpdateStudentDto
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required int DepartmentId { get; set; }
    }
}