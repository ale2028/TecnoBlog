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

        [Required(ErrorMessage = "The title is mandatory*")]
        [Display(Name = "Title")]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The description is mandatory*")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The content is mandatory*")]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}