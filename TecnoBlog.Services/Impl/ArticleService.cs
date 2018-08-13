using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Abstractions;
using TecnoBlog.Services.Converters;

namespace TecnoBlog.Services.Impl
{
    public class ArticleService : IModelService<Business.Models.Article, Guid>
    {

        private TecnoBlogDataContext database;


        public ArticleService()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["TECNOBLOGConnectionString"];
            SqlConnectionStringBuilder builder;

            if (null != settings)
            {
                string connection = settings.ConnectionString;
                builder = new SqlConnectionStringBuilder(connection);
                database = new TecnoBlogDataContext(builder.ConnectionString);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Business.Models.Article IModelService<Business.Models.Article, Guid>.Create(Business.Models.Article model)
        {

            try
            {
                // admin@example.com
                // Le generamos un id único al nuevo articulo
                model.Id = Guid.NewGuid();
                // Insertamos datos en la base de datos
                this.database.Article.InsertOnSubmit(ArticleConverter.Convert(model));
                // Guardamos los cambios
                this.database.SubmitChanges();
                return model;
            } // TRY ENDS
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                Console.Out.WriteLine(e.StackTrace);
            } // CATCH ENDS
            return null;
        } // CREATE ENDS ------------------------------------------------------ //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        bool IModelService<Business.Models.Article, Guid>.Delete(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                            where article.Id == modelId
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
        } // DELETE ENDS ------------------------------------------------------ //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        Business.Models.Article IModelService<Business.Models.Article, Guid>.Get(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                            where article.Id == modelId
                            select article;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    return ArticleConverter.Convert(result);
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
        IEnumerable<Business.Models.Article> IModelService<Business.Models.Article, Guid>.Get()
        {
            // La lista de articulos
            List<Business.Models.Article> results = new List<Business.Models.Article>();
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                            select article;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
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
        } // GET ENDS --------------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        bool IModelService<Business.Models.Article, Guid>.Update(Guid modelId, Business.Models.Article newState)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from article in this.database.Article
                            where article.Id == modelId
                            select article;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    result.Author = newState.Author;
                    result.Content = newState.Content;
                    result.Created = newState.Created;
                    result.Description = newState.Description;
                    result.Title = newState.Title;

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
