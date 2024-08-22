using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastahaneSistemi
{
    internal class Sql
    {
       public SqlConnection connection()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-33VDDOP\\SQLEXPRESS17;Initial Catalog=HastahaneProje;Integrated Security=True;Encrypt=False");
            connect.Open();
            return connect;
        }
    }
}
