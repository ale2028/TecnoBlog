using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoBlog.Business.Models
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public string Path { get; set; }
        public string Format { get; set; }
    }
}