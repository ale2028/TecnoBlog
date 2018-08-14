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
    public class ArticleTagService : IModelService<Business.Models.ArticleTag, Guid> 
    {
        private TecnoBlogDataContext database;

        public ArticleTagService()
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
        Business.Models.ArticleTag IModelService<Business.Models.ArticleTag , Guid>.Create(Business.Models.ArticleTag model)
        {
            try
            {
                this.database.Article_Tag.InsertOnSubmit(ArticleTagConverter.Convert(model));
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
        bool IModelService<Business.Models.ArticleTag, Guid>.Delete(Guid modelId)
        {
            return false;
        } // DELETE ENDS ------------------------------------------------------ //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        Business.Models.ArticleTag IModelService<Business.Models.ArticleTag, Guid>.Get(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from articleTag in this.database.Article_Tag
                            where articleTag.ArticleId == modelId
                            select articleTag;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    return ArticleTagConverter.Convert(result);
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
       IEnumerable<Business.Models.ArticleTag> IModelService<Business.Models.ArticleTag, Guid>.Get()
        {
            return null;
        } // GET ENDS --------------------------------------------------------- //
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        bool IModelService<Business.Models.ArticleTag, Guid>.Update(Guid modelId, Business.Models.ArticleTag newState)
        {
            return false;
        } // UPDATE ENDS ------------------------------------------------------ //
    }



}

