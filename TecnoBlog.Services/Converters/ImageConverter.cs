using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoBlog.Business.Models;

namespace TecnoBlog.Services.Converters
{
    public class ImageConverter
    {
        public static Services.Image Convert(Business.Models.Image origin)
        {
            Services.Image destiny = new Services.Image
            {
                Format = origin.Format,
                Id = origin.Id,
                Path = origin.Path,
                ArticleId = origin.ArticleId
            };
            return destiny;
        }

        public static Business.Models.Image Convert(Services.Image origin)
        {
            Business.Models.Image destiny = new Business.Models.Image
            {
                Format = origin.Format,
                Id = origin.Id,
                Path = origin.Path,
                ArticleId = origin.ArticleId
            };
            return destiny;
        }
    }
}
