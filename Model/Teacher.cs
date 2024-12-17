using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public required string First { get; set; }
        public required string Last { get; set; }
        public required string City { get; set; }
        public ICollection<Department>? Departments { get; set; }
    }
}