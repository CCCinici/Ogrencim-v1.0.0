using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FacadeLayer
{
    public class SQLBaglanti
    {
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=.;Initial Catalog=KatmanDB;Integrated Security=True");
    }
}
