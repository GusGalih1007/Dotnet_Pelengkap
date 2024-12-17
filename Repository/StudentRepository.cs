using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pelengkap.DataBase;
using Pelengkap.Dto.Studentjoin;
using Pelengkap.Interface;
using Pelengkap.Model;

namespace Pelengkap.Repository
{
    public class StudentRepository : IStudentJoinRepository
    {
        private readonly ApplicationDBContext _context;
        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Student> CreateAsync(Student studentModel)
        {
            await _context.StudentsJoin.AddAsync(studentModel);
            await _context.SaveChangesAsync();
            
            return studentModel;
        }

        public async Task<Student?> DeleteAsync(int id)
        {
            var delStudent = await _context.StudentsJoin.FirstOrDefaultAsync(s => s.Id == id);

            if(delStudent == null)
            {
                return null;
            }

            _context.StudentsJoin.Remove(delStudent);
            await _context.SaveChangesAsync();

            return delStudent;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.StudentsJoin.ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var studentId = await _context.StudentsJoin.FirstOrDefaultAsync(s => s.Id == id);

            if(studentId == null)
            {
                return null;
            }

            return studentId;
        }

        public async Task<Student?> UpdateAsync(int id, UpdateStudentDto updateStudent)
        {
            var editStudent = await _context.StudentsJoin.FirstOrDefaultAsync(s => s.Id == id);

            if (editStudent == null)
            {
                return null;
            }

            editStudent.Firstname = updateStudent.Firstname;
            editStudent.Lastname = updateStudent.Lastname;
            editStudent.DepartmentId = updateStudent.DepartmentId;

            await _context.SaveChangesAsync();

            return editStudent;
        }
    }
}