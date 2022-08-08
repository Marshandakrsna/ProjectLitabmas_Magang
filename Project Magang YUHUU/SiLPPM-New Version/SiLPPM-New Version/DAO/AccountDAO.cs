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
        public List<dynamic> getAllMenu(string IDRole)
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
                                WHERE b.ID_ROLE = @IDRole AND d.ISACTIVE = 1 AND d.ID_SISTEM_INFORMASI = 8 ORDER BY d.NO_URUT ASC ";

                    var param = new { IDRole = IDRole };
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
    
        public List<dynamic> getAllSubMenu(string IDRole)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    int arrayIndex = 0;

                    string query = @"
                         SELECT  distinct TBL_SI_SUBMENU.ID_SI_SUBMENU, NO_URUT, TBL_SI_SUBMENU.DESKRIPSI ,TBL_SI_SUBMENU.LINK
                    ,TBL_SI_SUBMENU.ID_SI_MENU  FROM         siatmax.TBL_SI_MENU INNER JOIN
                      siatmax.TBL_SI_SUBMENU ON siatmax.TBL_SI_MENU.ID_SI_MENU = siatmax.TBL_SI_SUBMENU.ID_SI_MENU INNER JOIN
                      siatmax.TBL_ROLE_SUBMENU ON siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU INNER JOIN
                      siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE AND 
                      siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI = siatmax.TBL_USER_ROLE.ID_SISTEM_INFORMASI
                    WHERE siatmax.TBL_ROLE_SUBMENU.ID_ROLE = @IDRole and siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI =8
and TBL_USER_ROLE.IS_ACTIVE=1 and TBL_SI_SUBMENU.IsActive=1  ";

               
                    var param = new { IDRole = IDRole };
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
                            simka.MST_KARYAWAN.ID_UNIT, siatmax.MST_UNIT.NAMA_UNIT
                            FROM simka.MST_KARYAWAN 
                            JOIN siatmax.TBL_USER_ROLE
                            ON simka.MST_KARYAWAN.username = siatmax.TBL_USER_ROLE.NPP
                            JOIN siatmax.REF_ROLE
                            ON siatmax.REF_ROLE.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE  
							LEFT JOIN   siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT = siatmax.MST_UNIT.ID_UNIT
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

        public List<dynamic> getUserRole(string npp)
        {
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"
                        SELECT DISTINCT siatmax.REF_ROLE.ID_ROLE, siatmax.REF_ROLE.DESKRIPSI FROM siatmax.TBL_USER_ROLE
                        INNER JOIN siatmax.REF_ROLE ON siatmax.TBL_USER_ROLE.ID_ROLE = siatmax.REF_ROLE.ID_ROLE
                        WHERE siatmax.TBL_USER_ROLE.ID_SISTEM_INFORMASI = 8 AND siatmax.REF_ROLE.ID_ROLE IN (1,3,12)
                        AND siatmax.TBL_USER_ROLE.NPP = @npp ORDER BY siatmax.REF_ROLE.ID_ROLE DESC
                    ";

                    var data = conn.Query<dynamic>(query, new { npp = npp }).ToList();

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
      

    }

}
