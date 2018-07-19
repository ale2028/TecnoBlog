using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecnoBlog.Entities;

namespace TecnoBlog.Repositories
{
    public class UserRepository
    {
        // Referencia a la conexión con la base de datos.
        private TecnoBlogEntitiesDataContext database = new TecnoBlogEntitiesDataContext();

        /// <summary>
        ///  Consultar un usuario por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Models.User GetUser(Guid Id)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el usuario en la base de datos
                var query = from AspNetUsers in this.database.AspNetUsers
                            where AspNetUsers.Id == Id.ToString()
                            select AspNetUsers;

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
        } // METHOD GET USER ENDS --------------------------------------------------------------

        /// <summary>
        /// Consultar toda la lista de usuarios
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.User> GetArticles()
        {

            // La lista de usuarios
            List<Models.User> results = new List<Models.User>();
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from AspNetUsers in this.database.AspNetUsers
                            select AspNetUsers;

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
        } // METHOD GET USERS ------------------------------------------------------------------


        private Entities.AspNetUsers Convert(Models.User origin)
        {
            Entities.AspNetUsers destiny = new Entities.AspNetUsers();
            destiny.Email = origin.Email;
            destiny.Id = origin.Id;
            destiny.UserName = origin.UserName;
            return destiny; 
        }

        private Models.User Convert(Entities.AspNetUsers origin) {
            Models.User destiny = new Models.User();
            destiny.UserName = origin.UserName;
            destiny.Id = origin.Id;
            destiny.Email = origin.Email;
            return destiny; 
        }
    }
}