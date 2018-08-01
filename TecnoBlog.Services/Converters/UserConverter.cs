using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Converters
{
    class UserConverter
    {
        public static Services.AspNetUsers Convert(Business.Models.User origin)
        {
            Services.AspNetUsers destiny = new Services.AspNetUsers
            {
                Email = origin.Email,
                Id = origin.Id,
                UserName = origin.UserName
            };
            return destiny;
        }

        public static Business.Models.User Convert(Services.AspNetUsers origin)
        {
            Business.Models.User destiny = new Business.Models.User
            {
                UserName = origin.UserName,
                Id = origin.Id,
                Email = origin.Email
            };
            return destiny;
        }
    }
}
