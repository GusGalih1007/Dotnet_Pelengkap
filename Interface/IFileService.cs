using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pelengkap.Dto;
using Pelengkap.Model;

namespace Pelengkap.Interface
{
    public interface IFileService
    {
        public Task<FileDetails> UploadSingleFIleAsync(IFormFile fileData);
        public Task<FileDetails> UploadMultiFileAsync(List<FileUploadDto> uploadDtos);
        public Task<FileDetails?> DownloadFileByIdAsync(int id);
    }
}