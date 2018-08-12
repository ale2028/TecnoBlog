using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Converters
{
    public class CommentConverter
    {
        public static Services.Comment Convert(Business.Models.Comment origin)
        {
            Services.Comment destiny = new Services.Comment
            {
                ArticleId = origin.ArticleId,
                UserName = origin.UserName,
                Id = origin.Id,
                Created = origin.Created,
                Content = origin.Content
            };
            return destiny;
        }

        public static Business.Models.Comment Convert(Services.Comment origin)
        {
            Business.Models.Comment destiny = new Business.Models.Comment
            {
                ArticleId = origin.ArticleId,
                UserName = origin.UserName,
                Id = origin.Id,
                Created = origin.Created,
                Content = origin.Content
            };
            return destiny;
        }
    }
}
