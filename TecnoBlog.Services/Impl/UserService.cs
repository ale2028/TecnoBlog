using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Abstractions;
using TecnoBlog.Business.Models;
using TecnoBlog.Services.Converters;

namespace TecnoBlog.Services.Impl
{
    class UserService : IModelService<Business.Models.User>
    {
        private TecnoBlogDataContext database = new TecnoBlogDataContext();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        User IModelService<User>.Create(User model)
        {
            return null;    
        } //  CREATE ENDS ----------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        bool IModelService<User>.Delete(Guid modelId)
        {
            return false; 
        } // DELETE ----------------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        User IModelService<User>.Get(Guid modelId)
        {
            try
            {
                // Usamos una consulta LINQ para buscar el usuario en la base de datos
                var query = from AspNetUsers in this.database.AspNetUsers
                            where AspNetUsers.Id == modelId.ToString()
                            select AspNetUsers;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    return UserConverter.Convert(result);
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
        IEnumerable<User> IModelService<User>.Get()
        {
            // La lista de usuarios
            List<Business.Models.User> results = new List<Business.Models.User>();
            try
            {
                // Usamos una consulta LINQ para buscar el artículo en la base de datos
                var query = from AspNetUsers in this.database.AspNetUsers
                            select AspNetUsers;

                // Si hay resultados, entonces buscamos el primero y lo devolvemos
                foreach (var result in query)
                {
                    results.Add(UserConverter.Convert(result));
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
        bool IModelService<User>.Update(Guid modelId, User newState)
        {
            return false; 
        } // UPDATE ----------------------------------------------------------- //
    }
}
