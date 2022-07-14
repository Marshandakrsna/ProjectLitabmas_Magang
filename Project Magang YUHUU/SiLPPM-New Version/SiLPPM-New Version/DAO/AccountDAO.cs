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
        public List<dynamic> getAllMenu(string username)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"
                       SELECT DISTINCT d.DESKRIPSI, d.DESKRIPSI, d.LINK, d.ID_SI_MENU, d.NO_URUT
                                FROM siatmax.TBL_USER_ROLE a
                                JOIN siatmax.TBL_ROLE_SUBMENU b ON a.ID_ROLE = b.ID_ROLE
                                JOIN siatmax.TBL_SI_SUBMENU c ON b.ID_SI_SUBMENU = c.ID_SI_SUBMENU
                                JOIN siatmax.TBL_SI_MENU d ON c.ID_SI_MENU = d.ID_SI_MENU
                                WHERE a.NPP = @username AND a.ID_SISTEM_INFORMASI = 8 AND c.ISACTIVE = 1 AND d.ISACTIVE = 1 AND d.ID_SISTEM_INFORMASI = 8 ORDER BY d.NO_URUT ASC ";

                    var param = new { username = username };
                    var data = conn.Query<dynamic>(query, param).ToList();

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
        public List<dynamic> getAllSubMenu(string username)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    int arrayIndex = 0;

                    string query = @"
                      SELECT DISTINCT c.DESKRIPSI, c.DESKRIPSI, c.LINK, c.ID_SI_MENU,c.ID_SI_SUBMENU
                                FROM siatmax.TBL_USER_ROLE a
                                JOIN siatmax.TBL_ROLE_SUBMENU b ON a.ID_ROLE = b.ID_ROLE
                                JOIN siatmax.TBL_SI_SUBMENU c ON b.ID_SI_SUBMENU = c.ID_SI_SUBMENU
                                JOIN siatmax.TBL_SI_MENU d ON c.ID_SI_MENU = d.ID_SI_MENU
                                WHERE a.NPP = @username AND d.ID_SISTEM_INFORMASI = 8 AND c.ISACTIVE = 1 AND d.ISACTIVE = 1
                                ORDER BY c.ID_SI_SUBMENU ASC";

                    //if (Array.IndexOf(id_role, "1") != -1)
                    //{
                    //    query += @"AND siatmax.TBL_ROLE_SUBMENU.ID_ROLE = 1";
                    //}
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

                    //            query += @" siatmax.TBL_ROLE_SUBMENU.ID_ROLE = 1" ;
                    //        }
                    //        query += @")";
                    //    }
                    //    else
                    //    {
                    //        foreach (var id in id_role)
                    //        {
                    //            query += @" AND siatmax.TBL_ROLE_SUBMENU.ID_ROLE = 1" ;
                    //        }
                    //    }
                    //}

                    var param = new { username = username };
                    var data = conn.Query<dynamic>(query, param).ToList();

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
