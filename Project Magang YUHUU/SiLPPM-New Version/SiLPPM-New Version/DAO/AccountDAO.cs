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
        public List<dynamic> getAllMenu(Array id_role)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"
                        SELECT      DISTINCT ID_SI_MENU, ID_SISTEM_INFORMASI, DESKRIPSI, ISACTIVE, LINK, NO_URUT
                        FROM        siatmax.TBL_SI_MENU
                        WHERE       ID_SISTEM_INFORMASI = 8 AND ISACTIVE = 1 ";

                    var data = conn.Query<dynamic>(query).ToList();

                    return data;
                }
                catch (Exception ex)
                {
                    return new List<dynamic>();
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
        public List<dynamic> getAllSubMenu(Array id_role)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    int arrayIndex = 0;

                    string query = @"
                        SELECT      DISTINCT siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU, siatmax.TBL_ROLE_SUBMENU.ID_ROLE, siatmax.TBL_SI_SUBMENU.ID_SI_MENU, siatmax.TBL_SI_SUBMENU.DESKRIPSI, siatmax.TBL_SI_SUBMENU.ISACTIVE, siatmax.TBL_SI_SUBMENU.LINK
                        FROM        siatmax.TBL_ROLE_SUBMENU 
                        INNER JOIN  siatmax.TBL_SI_SUBMENU ON siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU
                        INNER JOIN  siatmax.TBL_SI_MENU ON siatmax.TBL_SI_SUBMENU.ID_SI_MENU = siatmax.TBL_SI_MENU.ID_SI_MENU
                        WHERE       siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI = 8 AND siatmax.TBL_SI_SUBMENU.ISACTIVE = 1";

                    if (Array.IndexOf(id_role, "1") != -1)
                    {
                        query += @"AND siatmax.TBL_ROLE_SUBMENU.ID_ROLE = 1";
                    }
                    //else
                    //{
                    //    if (id_role.Length > 1)
                    //    {
                    //        foreach (var id in id_role)
                    //        {
                    //            arrayIndex++;
                    //            if (arrayIndex > 1)
                    //            {
                    //                query += @" OR ";
                    //            }
                    //            else
                    //            {
                    //                query += @" AND (";
                    //            }

                    //            query += @" siatmax.TBL_ROLE_SUBMENU.ID_ROLE = " + String.Join("", id);
                    //        }
                    //        query += @")";
                    //    }
                    //    else
                    //    {
                    //        foreach (var id in id_role)
                    //        {
                    //            query += @" AND siatmax.TBL_ROLE_SUBMENU.ID_ROLE = " + String.Join("", id);
                    //        }
                    //    }
                    //}

                    var data = conn.Query<dynamic>(query).ToList();

                    return data;
                }
                catch (Exception ex)
                {
                    return new List<dynamic>();
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
        public dynamic GetUser(string Username)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = null;
                    query = @"SELECT simka.MST_KARYAWAN.username as username, simka.MST_KARYAWAN.password as password,siatmax.REF_ROLE.ID_ROLE, 
                            siatmax.TBL_USER_ROLE.NPP, siatmax.REF_ROLE.deskripsi as role, simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR as nama_lengkap,
                            simka.MST_KARYAWAN.ID_UNIT
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
