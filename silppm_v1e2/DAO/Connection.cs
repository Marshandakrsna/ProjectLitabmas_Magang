using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace silppm_v1e2
{

    public class Connection
    {
        private SqlConnection koneksi;

        public Connection()
        {
            

            koneksi = new SqlConnection("Data Source=192.168.15.156;Initial Catalog=portal_dosen;User ID=portal; Password=portal123!");
        }

        public SqlConnection getConnection()
        {
            return koneksi;
        }
    }
}