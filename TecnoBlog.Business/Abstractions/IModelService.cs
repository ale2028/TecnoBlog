using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoBlog.Business.Abstractions
{
    public interface IModelService<T> where T:class
    {
        /// <summary>
        ///     Obtiene una única instancia de T que se encuentra persistida en la base de datos
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        T Get(Guid modelId);

        /// <summary>
        ///     Recupera todos los elementos en la base de datos de un tipo determinado
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Get();

        /// <summary>
        ///     Persite una instancia de T
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        T Create(T model);

        /// <summary>
        ///  Actualiza el estado de un model que ha sido persistido previamente en la base de datos
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="newState"></param>
        /// <returns></returns>
        bool Update(Guid modelId, T newState);

        /// <summary>
        ///     Elimina modelos que han sido previamente persistidos en la base de datos. 
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        bool Delete(Guid modelId);
    }
}
