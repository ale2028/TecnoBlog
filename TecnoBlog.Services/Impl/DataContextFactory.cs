using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnoBlog.Services.Impl
{
    public class DataContextFactory
    {
        public static TecnoBlogDataContext GetContext()
        {
            TecnoBlogDataContext database = null; 

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["TECNOBLOGConnectionString"];
            SqlConnectionStringBuilder builder;

            if (null != settings)
            {
                string connection = settings.ConnectionString;
                builder = new SqlConnectionStringBuilder(connection);
                database = new TecnoBlogDataContext(builder.ConnectionString);
            } // IF ENDS

            return database; 
        } // GET CONTEXT ENDS 

    }
}
