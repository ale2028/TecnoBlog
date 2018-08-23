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
    public class TagService : IModelService<Business.Models.Tag, string>
    {
        private TecnoBlogDataContext database;

        public TagService()
        {
            this.database = DataContextFactory.GetContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Business.Models.Tag IModelService<Business.Models.Tag, string>.Create(Business.Models.Tag model)
        {
            try
            {
                Tag tag = new Tag();
                // Insertamos datos en la base de datos
                this.database.Tag.InsertOnSubmit(TagConverter.Convert(model));
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
        bool IModelService<Business.Models.Tag, string>.Delete(string modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from tag in this.database.Tag
                            where tag.Name == modelId
                            select tag;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    this.database.Tag.DeleteOnSubmit(result);
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
        Business.Models.Tag IModelService<Business.Models.Tag, string>.Get(string modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el tag en la base de datos
                var query = from tag in this.database.Tag
                            where tag.Name == modelId
                            select tag;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    return TagConverter.Convert(result);
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
        IEnumerable<Business.Models.Tag> IModelService<Business.Models.Tag, string>.Get()
        {
            // La lista de articulos
            List<Business.Models.Tag> results = new List<Business.Models.Tag>();
            try
            {
                // Usamos una consulta LINQ para buscar el tag en la base de datos
                var query = from tag in this.database.Tag
                            select tag;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    results.Add(TagConverter.Convert(result));
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
        bool IModelService<Business.Models.Tag, string>.Update(string modelId, Business.Models.Tag newState)
        {
             try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from tag in this.database.Tag
                            where tag.Name == modelId
                            select tag;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    result.Name = newState.Name;

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
