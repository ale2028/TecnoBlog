using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecnoBlog.Entities;
using TecnoBlog.Models;

namespace TecnoBlog.Reposirories
{
    public class ArticleRepository
    {
        // Referencia a la conexión con la base de datos.
        private TecnoBlogEntitiesDataContext database = new TecnoBlogEntitiesDataContext();

        /// <summary>
        ///     Permite crear nuevos artículos en la base datos. 
        /// </summary>
        /// <param name="theArticle">
        ///     Instancia del nuevo artículo que se va a insertar en la base de datos
        /// </param>
        /// <returns></returns>
        public Models.Article CreateArticle(Models.Article theArticle) {
            try
            {
                // Le generamos un id único al nuevo articulo
                theArticle.Id = Guid.NewGuid();
                // Insertamos datos en la base de datos
                this.database.Article.InsertOnSubmit(Convert(theArticle));
                // Guardamos los cambios
                this.database.SubmitChanges();
                return theArticle;
            } // TRY ENDS
            catch (Exception e) {
                Console.Out.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // METHOD CREATE ENDS -------------------------------------------------------------------

        /// <summary>
        ///  Consultar un articulo por id
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <returns></returns>
        public Models.Article GetArticle(Guid theArticleId) {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                where article.Id == theArticleId
                select article;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query) {
                    return Convert(result);
                } // FOREACH ENDS

            } // TRY ENDS
            catch (Exception e) {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // METHOD GET ARTICLE ENDS --------------------------------------------------------------

        /// <summary>
        /// Consultar toda la lista de articulos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Article> GetArticles() {

            // La lista de articulos
            List<Models.Article> results = new List<Models.Article>();
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
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

        /// <summary>
        /// REciben un id user y retornan una lista de artiulos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Article> GetArticlesByAuthor(string userId)
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
        } // METHOD GET ARTICLES ------------------------------------------------------------------


        /// <summary>
        /// Actualizar un articulo
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <param name="theArticleData"></param>
        /// <returns></returns>
        public bool UpdateArticle(Guid theArticleId, Models.Article theArticleData) {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                            where article.Id == theArticleId
                            select article;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    result.Author = theArticleData.Author;
                    result.Content = theArticleData.Content;
                    result.Created = theArticleData.Created;
                    result.Description = theArticleData.Description;
                    result.Title = theArticleData.Title;

                } // FOREACH ENDS

                this.database.SubmitChanges();
                return true;

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return false;
        }

        /// <summary>
        /// Borrar un articulo por id
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <returns></returns>
        public bool DeleteArticle(Guid theArticleId) {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                            where article.Id == theArticleId
                            select article;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    this.database.Article.DeleteOnSubmit(result);
                } // FOREACH ENDS

                this.database.SubmitChanges();
                return true;

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return false;
        } // METHOD DELETE ARTICLE ENDS -----------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        private Entities.Article Convert(Models.Article origin) {
            Entities.Article destiny = new Entities.Article();
            destiny.Id = origin.Id;
            destiny.Title = origin.Title;
            destiny.Description = origin.Description;
            destiny.Created = origin.Created;
            destiny.Content = origin.Content;
            destiny.Author = origin.Author;
            return destiny; 
        } // Convert models-entities ends 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        private Models.Article Convert(Entities.Article origin) {
            Models.Article destiny = new Models.Article();
            destiny.Id = origin.Id;
            destiny.Title = origin.Title;
            destiny.Description = origin.Description;
            destiny.Created = origin.Created;
            destiny.Content = origin.Content;
            destiny.Author = origin.Author;
            return destiny;
        } // convert ends

    }
}