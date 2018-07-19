using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecnoBlog.Entities;

namespace TecnoBlog.Repositories
{
    public class CommentRepository
    {
        // Referencia a la conexión con la base de datos.
        private TecnoBlogEntitiesDataContext database = new TecnoBlogEntitiesDataContext();

        public Models.Comment CreateComment(Models.Comment comment) {
            try {
                // Le generamos un id único al nuevo comentario
                comment.Id = Guid.NewGuid();
                // Insertamos datos en la base de datos
                this.database.Comment.InsertOnSubmit(Convert(comment));
                // Guardamos los cambios
                this.database.SubmitChanges();
                return comment;
            } // TRY ENDS
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // METHOD CREATE ENDS -------------------------------------------------------------------


        public Models.Comment GetComment(Guid Id) {
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from comment in this.database.Comment
                            where comment.Id == Id
                            select comment;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    return Convert(result);
                } // FOREACH ENDS

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // GET COMMENT ENDS --------------------------------------------------------------------
    
        /// <summary>
        /// Consultar toda la lista de comentarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Comment> GetComments()
        {

            // La lista de comentarios 
            List<Models.Comment> results = new List<Models.Comment>();
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from comment in this.database.Comment
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

        /// <summary>
        /// Actualizar un comentario
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="commentData"></param>
        /// <returns></returns>
        public bool UpdateComment(Guid Id, Models.Comment commentData)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from Comment in this.database.Comment
                            where Comment.Id == Id
                            select Comment;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    result.Content = commentData.Content;
                    result.Created = commentData.Created;
                    result.Id = commentData.Id;
                    result.ArticleId = commentData.ArticleId;
                    result.UserName = commentData.UserName; 

                } // FOREACH ENDS

                this.database.SubmitChanges();
                return true;

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return false;
        } // UPDATECOMMENT ENDS ------------------------------------------------------------------------------

        /// <summary>
        /// Borrar un comentario por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteComment(Guid Id)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from comment in this.database.Comment
                            where comment.Id == Id
                            select comment;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    this.database.Comment.DeleteOnSubmit(result);
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

        private Entities.Comment Convert(Models.Comment origin)
        {
            Entities.Comment destiny = new Entities.Comment();
            destiny.ArticleId = origin.ArticleId;
            destiny.UserName = origin.UserName;
            destiny.Id = origin.Id;
            destiny.Created = origin.Created;
            destiny.Content = origin.Content;
            return destiny;
        }

        private Models.Comment Convert(Entities.Comment origin)
        {
            Models.Comment destiny = new Models.Comment();
            destiny.ArticleId = origin.ArticleId;
            destiny.UserName = origin.UserName;
            destiny.Id = origin.Id;
            destiny.Created = origin.Created;
            destiny.Content = origin.Content;
            return destiny;
        }
    }
} 