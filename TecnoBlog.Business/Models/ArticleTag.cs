using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoBlog.Business.Models
{
    public class ArticleTag
    {
        public Guid ArticleId { get; set; }
        public string Tag { get; set; }
    }
}
