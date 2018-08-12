using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Converters
{
    public class ArticleConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static Services.Article Convert(Business.Models.Article origin)
        {
            Services.Article destiny = new Services.Article
            {
                Id = origin.Id,
                Title = origin.Title,
                Description = origin.Description,
                Created = origin.Created,
                Content = origin.Content,
                Author = origin.Author
            };
            return destiny;
        } // Convert models-entities ends 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static Business.Models.Article Convert(Services.Article origin)
        {
            Business.Models.Article destiny = new Business.Models.Article
            {
                Id = origin.Id,
                Title = origin.Title,
                Description = origin.Description,
                Created = origin.Created,
                Content = origin.Content,
                Author = origin.Author
            };
            return destiny;
        } // convert ends
    }
}
