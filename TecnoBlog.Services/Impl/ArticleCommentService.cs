using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Services.Converters;

namespace TecnoBlog.Services.Impl
{
    public class ArticleCommentService
    {
        private TecnoBlogDataContext database;
        public ArticleCommentService()
        {
            this.database = DataContextFactory.GetContext(); 

        } // CONSTRUCTOR ENDS ------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public List<Business.Models.Comment> GetCommentsForArticle(Guid articleId)
        {
            List<Business.Models.Comment> comments = new List<Business.Models.Comment>();
            try
            {
                var query = from x in this.database.Comment
                            where x.ArticleId == articleId
                            select x;
                foreach (var comment in query)
                {
                    comments.Add(CommentConverter.Convert(comment));
                } // FOR ENDS
            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS 
            return comments;
        } // METHOD GET COMMENTS FOR ARTICLE ENDS ----------------------------- //

    }
}
