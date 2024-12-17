using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pelengkap.DataBase;
using Pelengkap.Dto.Departmentjoin;
using Pelengkap.Dto.Group;
using Pelengkap.Dto.Studentjoin;
using Pelengkap.Dto.Teacherjoin;
using Pelengkap.Interface;
using Pelengkap.Mapper;
using Pelengkap.Model;

namespace Pelengkap.Service
{
    public class LinqService : ILinqservice
    {
        private readonly ApplicationDBContext _context;
        public LinqService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeachDepartStudGroupDto>> GetAllGroupAsync()
        {
            var teachers = await _context.TeachersJoin.ToListAsync();
            var departments = await _context.DepartmentsJoin.ToListAsync();
            var students = await _context.StudentsJoin.ToListAsync();

#pragma warning disable CS8601 // Possible null reference assignment.
            var group = teachers.GroupJoin(departments,
            teacher => teacher.Id,
            department => department.Id,
            (teacher, departmentGroup) => new
            {
                Teacher = teacher,
                Departments = departmentGroup.ToList()
            })
            .SelectMany(teacherDeptGroup => teacherDeptGroup.Departments
            .GroupJoin(students,
            department => department.Id,
            student => student.DepartmentId,
            (department, studentGroup) => new
            {
                Teacher = teacherDeptGroup.Teacher,
                Department = department,
                Student = studentGroup.ToList()
            }))
            .Select(group => new TeachDepartStudGroupDto
            {
                TeacherName = new TeacherjoinDto
                {
                    Id = group.Teacher.Id,
                    First = group.Teacher.First,
                    Last = group.Teacher.Last,
                    City = group.Teacher.City
                },

                DepartmentName = new DepartmentjoinDto
                {
                    Id = group.Department.Id,
                    Name = group.Department.Name,
                    TeacherId = group.Department.TeacherId
                },

                StudentName = group.Student.Select(s => new StudentjoinDto
                {
                    Id = s.Id,
                    Firstname = s.Firstname,
                    Lastname = s.Lastname,
                    DepartmentId = s.DepartmentId
                }).FirstOrDefault()
            }).ToList();
#pragma warning restore CS8601 // Possible null reference assignment.

            return group;
        }

        public async Task<IEnumerable<DepartmentGroupDto>> GetDepartmentGroupsAsync()
        {
            var departments = await _context.DepartmentsJoin.ToListAsync();
            var teachers = await _context.TeachersJoin.ToListAsync();

            var departGroup = teachers.GroupJoin(departments,
            t => t.Id,
            d => d.TeacherId,
            (t, d) => new DepartmentGroupDto
            {
                TeacherName = $"{t.First} {t.Last}",
                DepartmentName = d.Select(dn => dn.ToDepartmentDto()).ToList()
            });

            return departGroup;
        }

        public async Task<IEnumerable<StudentGroupDepartDto>> GetStudentGroupsAsync()
        {
            var students = await _context.StudentsJoin.ToListAsync();
            var departments = await _context.DepartmentsJoin.ToListAsync();

            var studentGroup = departments.GroupJoin(students,
            department => department.Id,
            student => student.DepartmentId,
            (department, studentGroup) => new StudentGroupDepartDto
            {
                DepartmentName = department.Name,
                StudentName = studentGroup.Select(s => s.ToStudentDto()).ToList()
            });

            return studentGroup;
        }

    }
}