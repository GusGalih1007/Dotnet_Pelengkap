using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Model;

namespace Pelengkap.Dto
{
    public class FileUploadDto
    {
        public required IFormFile FormDetails { get; set; }
    }
}