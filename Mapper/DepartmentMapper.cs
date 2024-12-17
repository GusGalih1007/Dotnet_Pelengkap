using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Departmentjoin;
using Pelengkap.Model;

namespace Pelengkap.Mapper
{
    public static class DepartmentMapper
    {
        public static DepartmentjoinDto ToDepartmentDto(this Department departmentModel)
        {
            return new DepartmentjoinDto
            {
                Id = departmentModel.Id,
                Name = departmentModel.Name,
                TeacherId = departmentModel.TeacherId
            };
        }

        public static Department CreateDepartmentDto(this CreateDeparmentDto departmentDto)
        {
            return new Department
            {
                Name = departmentDto.Name,
                TeacherId = departmentDto.TeacherId
            };
        }

        public static Department UpdateDepartmentDto(this UpdateDepartmentDto departmentDto)
        {
            return new Department
            {
                Name = departmentDto.Name,
                TeacherId = departmentDto.TeacherId
            };
        }
    }
}