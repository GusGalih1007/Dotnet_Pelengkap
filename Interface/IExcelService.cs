using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Model;

namespace Pelengkap.Interface
{
    public interface IExcelService
    {
        public Task ImportExcelAsync(IFormFile import);
    }
}