using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Teacherjoin;
using Pelengkap.Model;

namespace Pelengkap.Interface
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> CreateAsync(Teacher teacherModel);
        Task<Teacher?> UpdateAsync(int id, UpdateTeacherDto updateTeacher);
        Task<Teacher?> DeleteAsync(int id);
        Task<bool> TeacherExists(int id);
    }
}