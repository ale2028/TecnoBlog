using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoBlog.Repositories
{
    public class CommentRepository
    {
        /*
        /// <summary>
        /// Devolver una lista de comentarios buscando un articulo 
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <returns></returns>
        public IEnumerable<Models.Comment> GetCommentsByArticle(Guid theArticleId)
        {

            // La lista de comentarios 
            List<Models.Comment> results = new List<Models.Comment>();
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from comment in this.database.Comment
                            where comment.ArticleId == theArticleId
                            select comment;

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
        } // METHOD GET COMMENTS ------------------------------------------------------------------
     */
    }
} 