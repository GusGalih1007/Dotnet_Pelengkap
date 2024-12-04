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
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        //single file
        [HttpPost("postsinglefile")]
        public async Task<IActionResult> PostSingleFile([FromForm] FileUploadDto fileUpload)
        {
            if(fileUpload == null)
            {
                return BadRequest();
            }

            try
            {
                var postOne = await _fileService.UploadSingleFIleAsync(fileUpload.FormDetails);
                return Ok(new {message = "File uploaded successfully", File = postOne.FileName});
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }

        //multi file
        [HttpPost("postmultifile")]
        public async Task<IActionResult> PostMultiFile([FromForm] List<FileUploadDto> files)
        {
            if(files == null)
            {
                return BadRequest();
            }

            try
            {
                await _fileService.UploadMultiFileAsync(files);
                return Ok("Files uploaded successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Download File
        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            
            try
            {
                var fileId = await _fileService.DownloadFileByIdAsync(id);

                if (fileId == null)
                {
                    return NotFound("File does not exist!");
                }

                return Ok(fileId.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}