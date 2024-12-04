using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pelengkap.DataBase;
using Pelengkap.Dto;
using Pelengkap.Interface;
using Pelengkap.Model;

namespace Pelengkap.Service
{
    public class FIleService : IFileService
    {
        private readonly ApplicationDBContext _context;
        public FIleService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<FileDetails?> DownloadFileByIdAsync(int id)
        {
            var downFile = await _context.FileDetails.FirstOrDefaultAsync(f => f.FileId == id);
            if(downFile == null)
            {
                return null;
            }

            var file = new System.IO.MemoryStream(downFile.FileData);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DownloadedFile", downFile.FileName);

            await CopyStream(file, path);

            return downFile;
        }

        public async Task<FileDetails?> UploadMultiFileAsync(List<FileUploadDto> uploadDtos)
        {
            try
            {
                if(uploadDtos == null )
                {
                    return null;
                }

                FileDetails? files = null;

                foreach (FileUploadDto fileUpload in uploadDtos)
                {
                    var multiFile = new FileDetails
                    {
                        FileId = 0,
                        FileName = fileUpload.FormDetails.FileName,
                    };

                    using (var stream = new MemoryStream())
                    {
                        fileUpload.FormDetails.CopyTo(stream);
                        multiFile.FileData = stream.ToArray();
                    }

                    var save = new System.IO.MemoryStream(multiFile.FileData);

                    if(!Directory.Exists("UploadedFile"))
                    {
                        Directory.CreateDirectory("UploadedFile");
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFile", multiFile.FileName);

                    await CopyStream(save, path);

                    await _context.FileDetails.AddAsync(multiFile);

                    files = multiFile;
                }
                await _context.SaveChangesAsync();
                return files;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FileDetails?> UploadSingleFIleAsync(IFormFile fileData)
        {
            try
            {
                if (fileData == null || fileData.Length == 0)
                {
                    return null;
                }
                var uploadedfile = new FileDetails
                {
                    FileId = 0,
                    FileName = fileData.FileName,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    uploadedfile.FileData = stream.ToArray();
                }

                var content = new System.IO.MemoryStream(uploadedfile.FileData);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFile", uploadedfile.FileName);

                await CopyStream(content, path);

                var result = await _context.FileDetails.AddAsync(uploadedfile);

                await _context.SaveChangesAsync();

                return uploadedfile;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
