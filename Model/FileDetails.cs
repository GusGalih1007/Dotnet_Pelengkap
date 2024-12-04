using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pelengkap.Model
{
    [Table("FileDetails")]
    public class FileDetails
    {
        [Key]
        public int FileId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public byte[] FileData { get; set; }
    }
}