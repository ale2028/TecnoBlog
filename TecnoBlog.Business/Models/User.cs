using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TecnoBlog.Business.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "The email is mandatory*")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The username is mandatory*")]
        [Display(Name = "UserName")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
 
    }
}