using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Dto
{
    public class ImportExcelDto
    {
        public required IFormFile ExcelImport { get; set; }
    }
}