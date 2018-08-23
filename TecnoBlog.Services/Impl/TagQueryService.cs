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
    public class TagQueryService
    {
        private TecnoBlogDataContext database;

        public TagQueryService()
        {
            this.database = DataContextFactory.GetContext();
        }

        public IEnumerable<Business.Models.Article> GetArticlesByTag(string tag)
        {
            List<Business.Models.Article> results = new List<Business.Models.Article>();
            try
            {
                var query = from articleTag in this.database.Article_Tag
                            where articleTag.Tag == tag
                            select articleTag;

                foreach (var result in query)
                {
                    results.Add(ArticleConverter.Convert(result.Article));
                }
            } // TRY ENDS
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            } // CATCH ENDS
            return results;
        }

        public IEnumerable<string> GetTagsForArticle(Guid articleId)
        {
            List<string> results = new List<string>();
            try
            {
                var query = from articleTag in this.database.Article_Tag
                            where articleTag.ArticleId == articleId
                            select articleTag;

                foreach (var result in query)
                {
                    results.Add(result.Tag);
                }
            } // TRY ENDS
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            } // CATCH ENDS 
            return results; 
        }

        public IEnumerable<Business.Models.Article> GetArticlesByAuthor(string userName)
        {
            // La lista de articulos
            List<Business.Models.Article> results = new List<Business.Models.Article>();
            try
            {
                var query = from article in this.database.Article
                            where article.Author == userName
                            select article;

                foreach (var result in query)
                {
                    results.Add(ArticleConverter.Convert(result));
                } // FOREACH ENDS

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return results;
        } 

    }
}
