﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoBlog.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }
    }


}