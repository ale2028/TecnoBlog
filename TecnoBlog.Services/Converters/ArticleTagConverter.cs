using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Converters
{
    public class ArticleTagConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static Services.Article_Tag Convert(Business.Models.ArticleTag origin)
        {
            Services.Article_Tag destiny = new Services.Article_Tag
            {
                ArticleId = origin.ArticleId,
                Tag = origin.Tag
     
            };
            return destiny;
        } // Convert models-entities ends 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static Business.Models.ArticleTag Convert(Services.Article_Tag origin)
        {
            Business.Models.ArticleTag destiny = new Business.Models.ArticleTag
            {
                ArticleId = origin.ArticleId,
                Tag = origin.Tag
            };
            return destiny;
        } // convert ends
    }
}

