﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TecnoBlog.Business.Models
{
    public class Tag
    {

        [Required(ErrorMessage = "The email is mandatory*")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string Name { set; get; }
    }
}