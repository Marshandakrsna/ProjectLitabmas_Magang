using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SiLPPM_New_Version.DAO;
using SiLPPM_New_Version.Models;
using SiLPPM_New_Version.Controllers;
using System.Data.SqlClient;

namespace SiLPPM_New_Version.DAO
{
    public class ProfileDAO
    {
        public DBOutput GetDataUser(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"SELECT simka.MST_KARYAWAN.NPP, simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR, simka.MST_KARYAWAN.EMAIL_INSTITUSI, 
simka.MST_KARYAWAN.NO_TELPON_HP, simka.MST_KARYAWAN.NIDN, simka.MST_KARYAWAN.ALAMAT, simka.MST_KARYAWAN.USERNAME
FROM   simka.MST_KARYAWAN  WHERE simka.MST_KARYAWAN.USERNAME= @USERNAME;";
                    //    SELECT NAMA_LENGKAP_GELAR
                    //    FROM   simka.MST_KARYAWAN
                    //    WHERE (simka.MST_KARYAWAN.NPP = @username )
                    //";
                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username= username });

                    output.data = data;

                    return output;
                }
                catch (Exception ex)
                {
                    output.status = false;
                    output.pesan = ex.Message;
                    output.data = new { };
                    return output;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
    }
}
