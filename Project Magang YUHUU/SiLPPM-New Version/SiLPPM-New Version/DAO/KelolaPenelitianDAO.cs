using System;
using System.Collections.Generic;
using System.Linq;
using SiLPPM_New_Version.Models;

using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SiLPPM_New_Version.DAO
{
    public class KelolaPenelitianDAO
    {
        public DBOutput GetPenelitianSetReviewer()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT TBL_PENELITIAN.NPP, silppm.TBL_PENELITIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, siatmax.MST_UNIT.NAMA_UNIT AS 'FAK', MST_UNIT_1.NAMA_UNIT AS 'PRODI', 
                    siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK,DANA_SETUJU
                    FROM silppm.TBL_PENELITIAN INNER JOIN
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                    simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENELITIAN.NPP INNER JOIN
                    siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                    siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK
                    where REVIEWER1 is null and REVIEWER2 is null";

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
        public DBOutput GetPenelitianReviewer()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT TBL_PENELITIAN.NPP, silppm.TBL_PENELITIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, siatmax.MST_UNIT.NAMA_UNIT AS 'FAK', MST_UNIT_1.NAMA_UNIT AS 'PRODI', 
                    siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK,DANA_SETUJU,REVIEWER1,REVIEWER2
                    FROM silppm.TBL_PENELITIAN INNER JOIN
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                    simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENELITIAN.NPP INNER JOIN
                    siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                    siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK
                    where REVIEWER1 is not null and REVIEWER2 is not null";

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
    }
}
