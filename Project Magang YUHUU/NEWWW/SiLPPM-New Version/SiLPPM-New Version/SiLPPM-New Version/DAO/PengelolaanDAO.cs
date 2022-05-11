using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiLPPM_New_Version.Models;
using Dapper;
using System.Data.SqlClient;

namespace SiLPPM_New_Version.DAO
{
    public class PengelolaanDAO 
    
    {
        public DBOutput GetPengelolaanRole()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select distinct k.NPP,k.NAMA,r.DESKRIPSI from simka.MST_KARYAWAN k join siatmax.TBL_USER_ROLE u 
on u.NPP=k.NPP join siatmax.REF_ROLE r on r.ID_ROLE=u.ID_ROLE where ( r.DESKRIPSI= 'Dosen' and u.ID_SISTEM_INFORMASI=8  or r.DESKRIPSI='Assesor' 
and u.ID_SISTEM_INFORMASI=8 and u.IS_ACTIVE='1')  order by r.DESKRIPSI";

                    var data = conn.Query<dynamic>(query).ToList();

                    output.data = data;

                    return output;
                }
                catch (Exception ex)
                {
                    output.status = false;
                    output.pesan = ex.Message;
                    output.data = new List<string>();
                    return output;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        public DBOutput UbahRole(UbahRole myobj)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"";

                    output.data = conn.Execute(query, myobj);

                    return output;
                }
                catch (Exception ex)
                {
                    output.status = false;
                    output.pesan = ex.Message;
                    output.data = new List<string>();
                    return output;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }

        public DBOutput GetDetailPengelolaan(string npp)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select distinct k.NPP,k.NAMA,r.DESKRIPSI from simka.MST_KARYAWAN k join siatmax.TBL_USER_ROLE u 
on u.NPP=k.NPP join siatmax.REF_ROLE r on r.ID_ROLE=u.ID_ROLE where ( r.DESKRIPSI= 'Dosen' and u.ID_SISTEM_INFORMASI=8  or r.DESKRIPSI='Assesor' 
and u.ID_SISTEM_INFORMASI=8 and u.IS_ACTIVE='1')  and k.npp=@npp order by r.DESKRIPSI";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new {npp = npp });

                    output.data = data;

                    return output;
                }
                catch (Exception ex)
                {
                    output.status = false;
                    output.pesan = ex.Message;
                    output.data = new List<string>();
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
