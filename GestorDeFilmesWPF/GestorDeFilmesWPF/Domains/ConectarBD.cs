using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeFilmesWPF.Domains
{
    class ConectarBD
    {
        public static SqlConnection getConnection()
        {
            return new SqlConnection("Data Source=tcp: 193.136.175.33\\SQLSERVER2012,8293;Initial Catalog=p1g10;User ID=p1g10;Password=atuamae");
        }

    }
}

