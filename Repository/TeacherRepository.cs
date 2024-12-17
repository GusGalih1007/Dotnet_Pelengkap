using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pelengkap.DataBase;
using Pelengkap.Dto.Teacherjoin;
using Pelengkap.Interface;
using Pelengkap.Model;

namespace Pelengkap.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDBContext _context;
        public TeacherRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Teacher> CreateAsync(Teacher teacherModel)
        {
            await _context.TeachersJoin.AddAsync(teacherModel);
            await _context.SaveChangesAsync();
            return teacherModel;
        }

        public async Task<Teacher?> DeleteAsync(int id)
        {
            var delTeacher = await _context.TeachersJoin.FirstOrDefaultAsync(t => t.Id == id);

            if (delTeacher == null)
            {
                return null;
            }

            _context.TeachersJoin.Remove(delTeacher);
            await _context.SaveChangesAsync();

            return delTeacher;
        }

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.TeachersJoin.ToListAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            var teacherId = await _context.TeachersJoin.FirstOrDefaultAsync(t => t.Id == id );

            if (teacherId == null)
            {
                return null;
            }

            return teacherId;
        }

        public Task<bool> TeacherExists(int id)
        {
            return _context.TeachersJoin.AnyAsync(t => t.Id == id);
        }

        public async Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto updateTeacher)
        {
            var editTeach = await _context.TeachersJoin.FirstOrDefaultAsync(t => t.Id == id);

            if (editTeach == null)
            {
                return null;
            }

            editTeach.First = updateTeacher.First;
            editTeach.Last = updateTeacher.Last;
            editTeach.City = updateTeacher.City;

            await _context.SaveChangesAsync();

            return editTeach;
        }
    }
}