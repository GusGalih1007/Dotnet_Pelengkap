using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Model
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int TeacherId { get; set; }
        public Teacher? Teachers { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}