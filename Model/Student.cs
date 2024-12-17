using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Model
{
    public class Student
    {
        public int Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}