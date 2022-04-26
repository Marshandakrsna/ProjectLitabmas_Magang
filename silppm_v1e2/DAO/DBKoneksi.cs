﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Softlib.Data;
using System.Data.SqlClient;

namespace silppm_v1e2
{
    public class DBKoneksi
    {
        const DataProvider _dp = DataProvider.SqlServer;

        const string _connStr = @"Data Source=192.168.15.156;Initial Catalog=portal_dosen;User ID=portal; Password=portal123!";
      
        public static DataProvider DB_PROVIDER
        {
            get { return _dp; }
        }

        public static string CONN_STRING
        {
            get { return _connStr; }
        }
        public SqlConnection getConnection()
        {
            SqlConnection koneksi = new SqlConnection(_connStr);
            return koneksi;
        }
        public static string FilterORCombiner(string filter1, string filter2)
        {
            if ((filter1 != "") & (filter2 != ""))
            {
                return " (" + filter1 + " OR " + filter2 + " ) ";
            }
            else if ((filter1 != "") & (filter2 == ""))
            {
                return " (" + filter1 + ") ";
            }
            else if ((filter1 == "") & (filter2 != ""))
            {
                return " (" + filter2 + ") ";
            }
            else
            {
                return "";
            }

        }
        public static string FilterANDCombiner(string filter1, string filter2)
        {
            if ((filter1 != "") & (filter2 != ""))
            {
                return " (" + filter1 + " AND " + filter2 + " ) ";
            }
            else if ((filter1 != "") & (filter2 == ""))
            {
                return " (" + filter1 + ") ";
            }
            else if ((filter1 == "") & (filter2 != ""))
            {
                return " (" + filter2 + ") ";
            }
            else
            {
                return "";
            }

        }

    }
}