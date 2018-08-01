using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Converters
{
    class TagConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static Services.Tag Convert(Business.Models.Tag origin)
        {
            Services.Tag destiny = new Services.Tag
            {
                Name = origin.Name
            };
            return destiny;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static Business.Models.Tag Convert(Services.Tag origin)
        {
            Business.Models.Tag destiny = new Business.Models.Tag
            {
                Name = origin.Name
            };
            return destiny;
        }
    }
}
