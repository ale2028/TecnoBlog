using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecnoBlog.Entities;

namespace TecnoBlog.Repositories
{
    public class TagRepository
    {
        // Referencia a la conexión con la base de datos.
        private TecnoBlogEntitiesDataContext database = new TecnoBlogEntitiesDataContext();

        /// <summary>
        ///     Permite crear nuevas etiquetas en la base datos. 
        /// </summary>
        /// <param name="tag">
        ///     Instancia de la nueva etiqueta que se va a insertar en la base de datos
        /// </param>
        /// <returns></returns>
        public Models.Tag CreateTag(Models.Tag theTag)
        {
            try
            {
                Tag tag = new Tag(); 
                // Insertamos datos en la base de datos
                this.database.Tag.InsertOnSubmit(Convert(theTag));
                // Guardamos los cambios
                this.database.SubmitChanges();
                return theTag;
            } // TRY ENDS
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // METHOD CREATE ENDS -------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="theTag"></param>
        /// <returns></returns>
        public Models.Tag GetTag(string theTag)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el tag en la base de datos
                var query = from tag in this.database.Tag
                            where tag.Name == tag.Name
                            select tag;

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
        } // METHOD GET ARTICLE ENDS --------------------------------------------------------------

        /// <summary>
        /// Consultar toda la lista de articulos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Tag> GetTags()
        {
            // La lista de articulos
            List<Models.Tag> results = new List<Models.Tag>();
            try
            {
                // Usamos una consulta LINQ para buscar el tag en la base de datos
                var query = from tag in this.database.Tag
                            select tag;

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
        /// Actualizar un articulo
        /// </summary>
        /// <param name="theArticleId"></param>
        /// <param name="theArticleData"></param>
        /// <returns></returns>
        public bool UpdateTag(string name, Models.Tag tagData)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from tag in this.database.Tag
                            where tag.Name == tag.Name
                            select tag;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    result.Name = tagData.Name;

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
        public bool DeleteTag(string name)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from tag in this.database.Tag
                            where tag.Name == tag.Name
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
        } // METHOD DELETE ARTICLE ENDS -----------------------------------------------------------

        private Entities.Tag Convert(Models.Tag origin) {
            Entities.Tag destiny = new Entities.Tag();
            destiny.Name = origin.Name;
            return destiny; 
        }

        private Models.Tag Convert(Entities.Tag origin) {
            Models.Tag destiny = new Models.Tag();
            destiny.Name = origin.Name;
            return destiny; 
        }
    }
}