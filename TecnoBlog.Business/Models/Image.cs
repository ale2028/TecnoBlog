using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TecnoBlog.Business.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }

        [Required]
        [Display(Name = "Path")]
        [DataType(DataType.Text)]
        public string Path { get; set; }

        [Required]
        [Display(Name = "Format")]
        [DataType(DataType.Text)]
        public string Format { get; set; }
    }
}