using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoBlog.Reposirories
{
    public class ArticleRepository
    {

        /// <summary>
        /// REciben un id user y retornan una lista de artiulos
        /// </summary>
        /// <returns></returns>
        /*public IEnumerable<Models.Article> GetArticlesByAuthor(string userId)
        {
            // La lista de articulos
            List<Models.Article> results = new List<Models.Article>();
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                            where article.Author == userId
                            select article;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    results.Add(Convert(result));
                } // FOREACH ENDS

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return results;
        } // METHOD GET ARTICLES ------------------------------------------------------------------


        /// Reciben un nombre de tag y devuelve una lista de articulos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Article> GetArticlesByTag(string tagName)
        {
            // La lista de articulos
            List<Models.Article> results = new List<Models.Article>();
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from articleTag in this.database.Article_Tag
                            where articleTag.Tag == tagName
                            select articleTag;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    var query2 = from article in this.database.Article
                                 where article.Id == result.ArticleId
                                 select article;
                    foreach (var article in query2) {
                        results.Add(Convert(article));
                    }
                } // FOREACH ENDS

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return results;
        } // METHOD GET ARTICLES ------------------------------------------------------------------*/

    }
}