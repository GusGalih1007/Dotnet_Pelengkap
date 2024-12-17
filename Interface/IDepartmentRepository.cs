using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Departmentjoin;
using Pelengkap.Dto.Teacherjoin;
using Pelengkap.Model;

namespace Pelengkap.Interface
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<Department> CreateAsync(Department DepartmentModel);
        Task<Department?> UpdateAsync(int id, UpdateDepartmentDto updateDepartment);
        Task<Department?> DeleteAsync(int id);
        Task<bool> DepartmentExists(int? id);
    }
}