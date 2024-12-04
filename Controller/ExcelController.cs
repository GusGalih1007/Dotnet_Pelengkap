using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pelengkap.Dto;
using Pelengkap.Interface;

namespace Pelengkap.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelService _excelService;
        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost("importexcel")]
        public async Task<IActionResult> ImportExcel([FromForm] ImportExcelDto excelFile)
        {
            if (excelFile == null)
            {
                return BadRequest("No file uploaded");
            }

            await _excelService.ImportExcelAsync(excelFile.ExcelImport);

            return Ok("Excel data imported successfully");
        }
    }
}