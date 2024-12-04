using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Pelengkap.DataBase;
using Pelengkap.Interface;
using Pelengkap.Model;

namespace Pelengkap.Service
{
    public class ExcelService : IExcelService
    {
        private readonly ApplicationDBContext _context;
        public ExcelService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task ImportExcelAsync(IFormFile import)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var importPath = $"{Directory.GetCurrentDirectory()}\\ImportedExcel";

            if (!Directory.Exists(importPath))
            {
                Directory.CreateDirectory(importPath);
            }

            var filePath = Path.Combine(importPath, import.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                import.CopyTo(stream);
            }

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                            ExcelImport s = new ExcelImport();

                            s.Name = reader.GetValue(1)?.ToString();

                            var marksValue = reader.GetValue(2)?.ToString();

                            if (int.TryParse(marksValue, out int marks))
                            {
                                s.Marks = marks;
                            }
                            else
                            {
                                s.Marks = 0;
                            }

                            await _context.AddAsync(s);
                            await _context.SaveChangesAsync();
                        }
                    } while (reader.NextResult());

                    /*// 2. Use the AsDataSet extension method
                    var result = reader.AsDataSet();

                    // The result of each spreadsheet is in result.Tables
                    */
                }
            }
        }
    }
}