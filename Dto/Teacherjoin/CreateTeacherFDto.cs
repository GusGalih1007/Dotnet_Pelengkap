using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Dto.Teacherjoin
{
    public class CreateTeacherFDto
    {
        public required string First { get; set; }
        public required string Last { get; set; }
        public required string City { get; set; }
    }
}