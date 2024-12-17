using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pelengkap.DataBase;
using Pelengkap.Dto.Departmentjoin;
using Pelengkap.Interface;
using Pelengkap.Model;

namespace Pelengkap.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDBContext _context;
        public DepartmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Department> CreateAsync(Department DepartmentModel)
        {
            await _context.DepartmentsJoin.AddAsync(DepartmentModel);
            await _context.SaveChangesAsync();

            return DepartmentModel;
        }

        public async Task<Department?> DeleteAsync(int id)
        {
            var delDepart = await _context.DepartmentsJoin.FirstOrDefaultAsync(d => d.Id == id);

            if(delDepart == null)
            {
                return null;
            }

            _context.DepartmentsJoin.Remove(delDepart);
            await _context.SaveChangesAsync();

            return delDepart;
        }

        public Task<bool> DepartmentExists(int? id)
        {
            return _context.DepartmentsJoin.AnyAsync(d => d.Id == id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.DepartmentsJoin.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            var departId = await _context.DepartmentsJoin.FirstOrDefaultAsync(d => d.Id == id);

            if(departId == null)
            {
                return null;
            }

            return departId;
        }

        public async Task<Department?> UpdateAsync(int id, UpdateDepartmentDto updateDepartment)
        {
            var editDepart = await _context.DepartmentsJoin.FirstOrDefaultAsync(d => d.Id == id);
            
            if(editDepart == null)
            {
                return null;
            }

            editDepart.Name = updateDepartment.Name;
            editDepart.TeacherId = updateDepartment.TeacherId;

            await _context.SaveChangesAsync();

            return editDepart;
        }
    }
}