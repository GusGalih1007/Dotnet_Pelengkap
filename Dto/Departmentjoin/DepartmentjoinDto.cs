using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Dto.Departmentjoin
{
    public class DepartmentjoinDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int TeacherId { get; set; }
    }
}