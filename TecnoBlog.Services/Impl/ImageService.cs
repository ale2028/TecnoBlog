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
    public class ImageService : IModelService<Business.Models.Image, Guid>
    {
        private TecnoBlogDataContext database;

        public ImageService()
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
        ///  L
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Business.Models.Image IModelService<Business.Models.Image, Guid>.Create(Business.Models.Image model)
        {
            try
            {
                // Le generamos un id único al nuevo comentario
                model.Id = Guid.NewGuid();
                // Insertamos datos en la base de datos
                this.database.Image.InsertOnSubmit(ImageConverter.Convert(model));
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
        bool IModelService<Business.Models.Image, Guid>.Delete(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from image in this.database.Image
                            where image.Id == modelId
                            select image;

                // Si hay resultados, entonces buscamos la primera y la devolvemos
                foreach (var result in query)
                {
                    this.database.Image.DeleteOnSubmit(result);
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
        Business.Models.Image IModelService<Business.Models.Image, Guid>.Get(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from image in this.database.Image
                            where image.Id == modelId
                            select image;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    return ImageConverter.Convert(result);
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
        IEnumerable<Business.Models.Image> IModelService<Business.Models.Image, Guid>.Get()
        {
            // La lista de imagenes
            List<Business.Models.Image> results = new List<Business.Models.Image>();
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from Image in this.database.Image
                            select Image;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    results.Add(ImageConverter.Convert(result));
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
        bool IModelService<Business.Models.Image, Guid>.Update(Guid modelId, Business.Models.Image newState)
        {
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from image in this.database.Image
                            where image.Id == modelId
                            select image;

                // Si hay resultados, entonces buscamos la primera y la devolvemos
                foreach (var result in query)
                {
                    result.Format = newState.Format;
                    result.Path = newState.Path;
                    result.Id = newState.Id;
                    result.ArticleId = newState.ArticleId;
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
