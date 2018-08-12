using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecnoBlog.Business.Models
{
    public class Article
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Content")]
        [DataType(DataType.Html)]
        public string Content { get; set; }
    }
}