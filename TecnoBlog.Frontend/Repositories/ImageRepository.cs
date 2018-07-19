using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecnoBlog.Entities;

namespace TecnoBlog.Repositories
{
    public class ImageRepository
    {
        // Referencia a la conexión con la base de datos.
        private TecnoBlogEntitiesDataContext database = new TecnoBlogEntitiesDataContext();

        public Models.Image CreateImage(Models.Image image)
        {
            try
            {
                // Le generamos un id único al nuevo comentario
                image.Id = Guid.NewGuid();
                // Insertamos datos en la base de datos
                this.database.Image.InsertOnSubmit(Convert(image));
                // Guardamos los cambios
                this.database.SubmitChanges();
                return image;
            } // TRY ENDS
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            } // CATCH ENDS
            return null;
        } // METHOD CREATE ENDS -------------------------------------------------------------------

        public Models.Image GetImage(Guid Id)
        {
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from image in this.database.Image
                            where image.Id == Id
                            select image;

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
        } // GET IMAGE ENDS --------------------------------------------------------------------
        public IEnumerable<Models.Image> GetImages()
        {
            // La lista de imagenes
            List<Models.Image> results = new List<Models.Image>();
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from Image in this.database.Image
                            select Image;

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
        } // METHOD GET IMAGES ------------------------------------------------------------------

        /// <summary>
        /// Actualizar una imagan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="imageData"></param>
        /// <returns></returns>
        public bool UpdateImage(Guid Id, Models.Image imageData)
        {
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from image in this.database.Image
                            where image.Id == Id
                            select image;

                // Si hay resultados, entonces buscamos la primera y la devolvemos
                foreach (var result in query)
                {
                    result.Format = imageData.Format;
                    result.Path = imageData.Path;
                    result.Id = imageData.Id;
                    result.ArticleId = imageData.ArticleId;
                } // FOREACH ENDS

                this.database.SubmitChanges();
                return true;

            } // TRY ENDS
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } // CATCH ENDS
            return false;
        }// UPDATE IMAGE ENDS ------------------------------------------------

        /// <summary>
        /// Borrar una imagen por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteImage(Guid Id)
        {
            try
            {
                // Usamos una consulta LINQ para buscar la imagen en la base de datos
                var query = from image in this.database.Image
                            where image.Id == Id
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
        } // METHOD DELETE IMAGE ENDS -----------------------------------------------------------

        private Entities.Image Convert(Models.Image origin) {
            Entities.Image destiny = new Entities.Image();
            destiny.Format = origin.Format;
            destiny.Id = origin.Id;
            destiny.Path = origin.Path;
            destiny.ArticleId = origin.ArticleId;
            return destiny; 
        }

        private Models.Image Convert(Entities.Image origin) {
            Models.Image destiny = new Models.Image();
            destiny.Format = origin.Format;
            destiny.Id = origin.Id;
            destiny.Path = origin.Path;
            destiny.ArticleId = origin.ArticleId;
            return destiny;
        }
    }
}