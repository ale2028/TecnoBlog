using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TecnoBlog.Business.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }

        [Required]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }


}