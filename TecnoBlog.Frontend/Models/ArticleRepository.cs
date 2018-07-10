using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TecnoBlog.Frontend.Models
{
    public class ArticleRepository
    {
        /// <summary>
        ///  Consultar un articulo por id
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <returns></returns>
        public Article GetArticle(Guid theArticleId) {
            return null;
        }

        /// <summary>
        /// Consultar toda la lista de articulos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Article> GetArticles() {
            return null;
        }

        /// <summary>
        /// Crear un articulo nuevo
        /// </summary>
        /// <param name="theArticle"></param>
        /// <returns></returns>
        public Article CreateArticle(Article theArticle) {
            return null;
        }

        /// <summary>
        /// Actualizar un articulo
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <param name="theArticleData"></param>
        /// <returns></returns>
        public bool UpdateArticle(Guid theArticleId, Article theArticleData) {
            return false;
        }

        /// <summary>
        /// Borrar un articulo por id
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <returns></returns>
        public bool DeleteArticle(string theArticleId) {
            return false;
        }

    }
}