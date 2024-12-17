using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto.Group;

namespace Pelengkap.Interface
{
    public interface ILinqservice
    {
        Task<IEnumerable<StudentGroupDepartDto>> GetStudentGroupsAsync();
        Task<IEnumerable<DepartmentGroupDto>> GetDepartmentGroupsAsync();
        Task<IEnumerable<TeachDepartStudGroupDto>> GetAllGroupAsync();
    }
}