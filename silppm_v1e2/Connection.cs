﻿using System;
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
              //koneksi = new SqlConnection("Data Source=PUMPZ\\SILPPMV2;Initial Catalog=SILPPMv1.1;Integrated Security=True");

            koneksi = new SqlConnection("Data Source=192.168.15.20;Initial Catalog=SIATMAX;User ID=usersispras;Password='sisprasu4jy!'");
        }

        public SqlConnection getConnection()
        {
            return koneksi;
        }
    }
}