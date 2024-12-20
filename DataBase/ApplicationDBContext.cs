using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pelengkap.Model;

namespace Pelengkap.DataBase
{
    public class ApplicationDBContext(DbContextOptions db) : DbContext(db)
    {
        public required DbSet<FileDetails> FileDetails { get; set; }
        public required DbSet<ExcelImport> Students { get; set; }
        public required DbSet<Teacher> TeachersJoin { get; set; }
        public required DbSet<Department> DepartmentsJoin { get; set; }
        public required DbSet<Student> StudentsJoin { get; set; }
    }
}