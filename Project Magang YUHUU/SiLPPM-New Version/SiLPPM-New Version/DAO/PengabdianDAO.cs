using System;
using System.Collections.Generic;
using System.Linq;
using SiLPPM_New_Version.Models;
using Dapper;
using System.Data.SqlClient;
namespace SiLPPM_New_Version.DAO
{
    public class PengabdianDAO

    {
        public DBOutput GetListPengabdian()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT silppm.TBL_PENGABDIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENGABDIAN.JUDUL_KEGIATAN JUDUL, 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, siatmax.MST_UNIT.NAMA_UNIT AS 'FAK', MST_UNIT_1.NAMA_UNIT AS 'PRODI', 
                    siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK, DANA_EKSTERNAL+DANA_KERJASAMA+DANA_PRIBADI+DANA_UAJY DANA, DANA_SETUJU
                    FROM silppm.TBL_PENGABDIAN INNER JOIN
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENGABDIAN.ID_STATUS INNER JOIN
                    simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENGABDIAN.NPP INNER JOIN
                    siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                    siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENGABDIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK";

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
