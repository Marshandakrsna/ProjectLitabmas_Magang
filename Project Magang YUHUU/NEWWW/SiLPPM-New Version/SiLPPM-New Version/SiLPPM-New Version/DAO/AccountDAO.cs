using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace SiLPPM_New_Version.DAO
{
    public class AccountDAO
    {

        public dynamic GetUser(string Username)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = null;
                    query = @"SELECT simka.MST_KARYAWAN.username as username, simka.MST_KARYAWAN.password as password, siatmax.REF_ROLE.deskripsi as role, simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR as nama_lengkap
                            FROM simka.MST_KARYAWAN 
                            JOIN siatmax.TBL_USER_ROLE
                            ON simka.MST_KARYAWAN.username = siatmax.TBL_USER_ROLE.NPP
                            JOIN siatmax.REF_ROLE
                            ON siatmax.REF_ROLE.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE
                            WHERE simka.MST_KARYAWAN.username like @username";
                    var param = new { username = Username };
                    var data = conn.Query<dynamic>(query, param).ToList();

                    return data[0];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return null;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        //public dynamic GetDataUser(string username)
        //{
        //    using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
        //    {
        //        try
        //        {
        //            string query = @"
        //                SELECT NAMA
        //                FROM   simka.MST_KARYAWAN_1
        //                WHERE (simka.MST_KARYAWAN_1.NPP = @username)
        //            ";


        //            //query = @"select [DESKRIPSI] from [siatmax].[REF_ROLE] r join [siatmax].[TBL_USER_ROLE] s on r.id_role=s.id_role where s.npp = '" + uname + "'and s.ID_SISTEM_INFORMASI=8 ";
        //            var param = new { username = username };
        //            var data = conn.Query<dynamic>(query, param).ToList();

        //            return data;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex);
        //            return null;
        //        }
        //        finally
        //        {
        //            conn.Dispose();
        //        }
        //    }
        //}

    }

}
