using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Abstractions;
using TecnoBlog.Business.Models;
using TecnoBlog.Services.Converters;

namespace TecnoBlog.Services.Impl
{
    public class CommentService : IModelService<Business.Models.Comment, Guid>
    {
        private TecnoBlogDataContext database;

        public CommentService()
        {
            this.database = DataContextFactory.GetContext();
        } // ------------------------------------------------------------------ // 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Business.Models.Comment IModelService<Business.Models.Comment, Guid>.Create(Business.Models.Comment model)
        {
            try
            {
                // Le generamos un id único al nuevo comentario
                model.Id = Guid.NewGuid();
                // Insertamos datos en la base de datos
                this.database.Comment.InsertOnSubmit(CommentConverter.Convert(model));
                // Guardamos los cambios
                this.database.SubmitChanges();
                return model;
            } // TRY ENDS
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // CREATE ENDS ------------------------------------------------------ //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        bool IModelService<Business.Models.Comment, Guid>.Delete(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from comment in this.database.Comment
                            where comment.Id == modelId
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
        } // DELETE ENDS ------------------------------------------------------ //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        Business.Models.Comment IModelService<Business.Models.Comment, Guid>.Get(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from comment in this.database.Comment
                            where comment.Id == modelId
                            select comment;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    return CommentConverter.Convert(result);
                } // FOREACH ENDS

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // GET ENDS --------------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Business.Models.Comment> IModelService<Business.Models.Comment, Guid>.Get()
        {
            // La lista de comentarios 
            List<Business.Models.Comment> results = new List<Business.Models.Comment>();
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from comment in this.database.Comment
                            select comment;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    results.Add(CommentConverter.Convert(result));
                } // FOREACH ENDS

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return results;
        } // GET ENDS --------------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        bool IModelService<Business.Models.Comment, Guid>.Update(Guid modelId, Business.Models.Comment newState)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el comentario en la base de datos
                var query = from Comment in this.database.Comment
                            where Comment.Id == modelId
                            select Comment;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    result.Content = newState.Content;
                    result.Created = newState.Created;
                    result.Id = newState.Id;
                    result.ArticleId = newState.ArticleId;
                    result.UserName = newState.UserName;

                } // FOREACH ENDS

                this.database.SubmitChanges();
                return true;

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return false;
        } // UPDATE ENDS ------------------------------------------------------ //
    }
}
