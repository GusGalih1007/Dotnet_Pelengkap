using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Studentjoin;
using Pelengkap.Model;

namespace Pelengkap.Interface
{
    public interface IStudentJoinRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student> CreateAsync(Student studentModel);
        Task<Student?> UpdateAsync(int id, UpdateStudentDto updateStudent);
        Task<Student?> DeleteAsync(int id);
    }
}