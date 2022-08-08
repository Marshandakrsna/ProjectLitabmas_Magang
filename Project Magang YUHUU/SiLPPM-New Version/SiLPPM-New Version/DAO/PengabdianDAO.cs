using System;
using System.Collections.Generic;
using System.Linq;
using SiLPPM_New_Version.Models;
using Dapper;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.IO;

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
                    string query = @"SELECT silppm.TBL_PENGABDIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, simka.MST_KARYAWAN.NPP, silppm.TBL_PENGABDIAN.JUDUL_KEGIATAN JUDUL, 
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
        public DBOutput GetCountPengabdian(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT count(silppm.TBL_PENELITIAN.ID_PROPOSAL) as JUMLAH FROM siatmax.MST_UNIT INNER JOIN
                      simka.MST_KARYAWAN ON siatmax.MST_UNIT.ID_UNIT = simka.MST_KARYAWAN.ID_UNIT INNER JOIN
                      siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                      silppm.TBL_PENELITIAN INNER JOIN silppm.TBL_PERSONIL_PENELITIAN ON silppm.TBL_PENELITIAN.ID_PROPOSAL = silppm.TBL_PERSONIL_PENELITIAN.ID_PROPOSAL INNER JOIN
                      silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                      siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK ON 
                      simka.MST_KARYAWAN.NPP = silppm.TBL_PERSONIL_PENELITIAN.NPP where  simka.MST_KARYAWAN.USERNAME = @username";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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
        public DBOutput GetRAB(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT    ID_RAB_PENGABDIAN, silppm.TBL_RAB_PENGABDIAN.ID_PROPOSAL, 
                    silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB, silppm.REF_PENGELUARAN_RAB.DESKRIPSI, silppm.TBL_RAB_PENGABDIAN.JUMLAH_DANA, 
                    silppm.TBL_RAB_PENGABDIAN.PERSENTASE,[MIN_PCT],[MAX_PCT]
                    FROM silppm.REF_PENGELUARAN_RAB INNER JOIN
                    silppm.TBL_RAB_PENGABDIAN ON silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB = silppm.TBL_RAB_PENGABDIAN.ID_PENGELUARAN_RAB
                    WHERE (ID_PROPOSAL = @id_proposal)";

                    var data = conn.Query<dynamic>(query, new { id_proposal = id_proposal }).ToList();

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

        public DBOutput GetDokumenFile(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select dokumen from silppm.TBL_PENGABDIAN where ID_PROPOSAL = @ID_PROPOSAL";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_proposal = id_proposal });

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
        public DBOutput UbahPengabdian(int ID_TAHUN_ANGGARAN, string REVIEWER1, string REVIEWER2, string JUDUL_KEGIATAN, string LANDASAN_PENELITIAN, string JENIS_PENGABDIAN, string ANGGOTA1,
             string ANGGOTA2, string MITRA, string MITRA_KEAHLIAN, string LOKASI, int JARAK_PT_LOKASI, string OUTPUT, string OUTCOME, int ID_ROAD_MAP, string AWAL, string AKHIR, string SASARAN,
             int SKS_KETUA, int SKS_ANGGOTA, string NPP, float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY,
             string INSERT_DATE,  string USER_ID, int ID_SKIM, int ID_TEMA_UNIVERSITAS, int NO_SEMESTER, string ID_PROPOSAL)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"UPDATE [silppm].[TBL_PENGABDIAN] SET
                    [ID_TAHUN_ANGGARAN] = @ID_TAHUN_ANGGARAN, [JUDUL_KEGIATAN] = @JUDUL_KEGIATAN, [LANDASAN_PENELITIAN] = @LANDASAN_PENELITIAN, [JENIS_PENGABDIAN] = @JENIS_PENGABDIAN,
                    [ANGGOTA1] = @ANGGOTA1, [ANGGOTA2] = @ANGGOTA2, [MITRA] = @MITRA, [MITRA_KEAHLIAN] = @MITRA_KEAHLIAN, [LOKASI] = @LOKASI, [JARAK_PT_LOKASI] = @JARAK_PT_LOKASI, [OUTPUT] = @OUTPUT, [OUTCOME] = @OUTCOME, [ID_ROAD_MAP] = @ID_ROAD_MAP, 
                    [AWAL] = @AWAL, [AKHIR] = @AKHIR, [SASARAN] = @SASARAN, [SKS_KETUA] = @SKS_KETUA, [SKS_ANGGOTA] = @SKS_ANGGOTA, [NPP] = @NPP, [DANA_PRIBADI] = @DANA_PRIBADI, 
                    [DANA_EKSTERNAL] = @DANA_EKSTERNAL, [DANA_KERJASAMA] = @DANA_KERJASAMA, [DANA_UAJY] = @DANA_UAJY, [INSERT_DATE] = @INSERT_DATE
                    ,[USER_ID] = @USER_ID,[ID_SKIM] = @ID_SKIM, [ID_TEMA_UNIVERSITAS] = @ID_TEMA_UNIVERSITAS, [NO_SEMESTER] = @NO_SEMESTER  where ID_PROPOSAL = @ID_PROPOSAL";
                  

                    var param = new { ID_TAHUN_ANGGARAN = ID_TAHUN_ANGGARAN, JUDUL_KEGIATAN = JUDUL_KEGIATAN, LANDASAN_PENELITIAN = LANDASAN_PENELITIAN, JENIS_PENGABDIAN=JENIS_PENGABDIAN, ANGGOTA1= ANGGOTA1,ANGGOTA2= ANGGOTA2, MITRA= MITRA, 
                        MITRA_KEAHLIAN = MITRA_KEAHLIAN, LOKASI = LOKASI, JARAK_PT_LOKASI = JARAK_PT_LOKASI,OUTPUT = OUTPUT, OUTCOME = OUTCOME,ID_ROAD_MAP = ID_ROAD_MAP, AWAL = AWAL, AKHIR = AKHIR, SASARAN = SASARAN, SKS_KETUA = SKS_KETUA, SKS_ANGGOTA= SKS_ANGGOTA, NPP = NPP,
                        DANA_PRIBADI = DANA_PRIBADI, DANA_EKSTERNAL = DANA_EKSTERNAL, DANA_KERJASAMA=DANA_KERJASAMA, DANA_UAJY=DANA_UAJY, INSERT_DATE = DateTime.Now
                        , USER_ID = USER_ID, ID_SKIM = ID_SKIM, ID_TEMA_UNIVERSITAS = ID_TEMA_UNIVERSITAS, NO_SEMESTER = NO_SEMESTER, ID_PROPOSAL = ID_PROPOSAL};


                    conn.Execute(query, param);

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

        public DBOutput UpdateDisetujuiDekan(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"update silppm.TBL_PENGABDIAN set IS_SETUJU_DEKAN=1,ID_STATUS=6  where id_proposal = @id_proposal";

                  
                    var param = new { id_proposal = id_proposal };



                    var data = conn.QueryFirstOrDefault<dynamic>(query, param);

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

        public DBOutput UpdateDitolakDekan(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"update silppm.TBL_PENGABDIAN set IS_SETUJU_DEKAN=1,ID_STATUS=9  where id_proposal = @id_proposal";


                    var param = new { id_proposal = id_proposal };



                    var data = conn.QueryFirstOrDefault<dynamic>(query, param);

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

        public DBOutput GetApprovalPengabdian(string id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select * from silppm.TBL_PENGABDIAN where ID_PROPOSAL = @id_proposal";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_proposal = id_proposal });

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

        public DBOutput GetNamaDosenByIDProposalPengabdian(string id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select d.NAMA from silppm.TBL_PENGABDIAN p join simka.Mst_karyawan d on d.NPP=p.NPP where ID_PROPOSAL = @id_proposal";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_proposal = id_proposal });

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
        public DBOutput GetTopikByIDProposalPengabdian(string id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select d.DESKRIPSI, p.ID_PROPOSAL from silppm.TBL_Pengabdian p join silppm.REF_ROAD_MAP_PENGABDIAN d on d.ID_ROAD_MAP_PENGABDIAN=p.ID_ROAD_MAP where ID_PROPOSAL = @id_proposal";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_proposal = id_proposal });

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

        public DBOutput GetListPengesahanPengabdian()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select p.id_proposal, p.IS_SETUJU_DEKAN, p.IS_SETUJU_PRODI, p.IS_DROPPED, d.ID_UNIT,p.Judul_kegiatan,d.nama,  CASE WHEN p.IS_SETUJU_DEKAN is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENGABDIAN p join simka.Mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_DEKAN =1 AND IS_SETUJU_PRODI=1 AND IS_DROPPED=0 ";

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

        public byte[] _getByteArrayFromDokumenPengabdian(IFormFile dokumenPengabdian)
        {
            using (var target = new MemoryStream())
            {
                dokumenPengabdian.CopyTo(target);
                var cek = target.ToArray();
                return cek;
            }
        }
        //public byte[] _getByteArrayFromPengesahan(IFormFile dokumenPengesahan)
        //{
        //    using (var target = new MemoryStream())
        //    {
        //        dokumenPengesahan.CopyTo(target);
        //        var cek = target.ToArray();
        //        return cek;
        //    }
        //}
        public byte[] GetDokumenFilePengabdian(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT [DOKUMEN] FROM [PORTAL_DOSEN].[silppm].[TBL_PENGABDIAN]  where ID_PROPOSAL = @ID_PROPOSAL";

                    var data = conn.QueryFirstOrDefault<byte[]>(query, new { id_proposal = id_proposal });

                    output.data = data;

                    return data;
                }
                catch (Exception ex)
                {
                    output.status = false;
                    output.pesan = ex.Message;
                    output.data = new List<string>();
                    return null;
                }
                finally
                {
                    conn.Dispose();
                }
            }
        }
        public DBOutput AddFeedback(int ID_PROPOSAL,string NPP, string FEEDBACK, string TANGGAL, string STATUS)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"insert into silppm.TBL_FEEDBACK_PENGABDIAN  ([ID_PROPOSAL]
           ,[NPP]
           ,[FEEDBACK]
           ,[TANGGAL]
           ,[STATUS]) values (@ID_PROPOSAL, @NPP, @FEEDBACK, @TANGGAL, @STATUS);";


                    var param = new { ID_PROPOSAL = ID_PROPOSAL , NPP = NPP, FEEDBACK=FEEDBACK, TANGGAL = DateTime.Now, STATUS=STATUS };



                    conn.Execute(query, param);

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
        public DBOutput AddPengabdian(int ID_TAHUN_ANGGARAN,  string REVIEWER1, string REVIEWER2, string JUDUL_KEGIATAN, string LANDASAN_PENELITIAN, string JENIS_PENGABDIAN, string ANGGOTA1, 
             string ANGGOTA2, string MITRA, string MITRA_KEAHLIAN, string LOKASI, int JARAK_PT_LOKASI, string OUTPUT, string OUTCOME, int ID_ROAD_MAP, string AWAL, string AKHIR,  string SASARAN, 
             int SKS_KETUA, int SKS_ANGGOTA, string NPP,  float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY,
            byte[] DOKUMEN,string INSERT_DATE, string IP_ADDRESS, string USER_ID,int ID_SKIM, int ID_TEMA_UNIVERSITAS, int NO_SEMESTER)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"insert into silppm.TBL_PENGABDIAN ([ID_TAHUN_ANGGARAN],
                    [ID_SUMBER],[REVIEWER1],[REVIEWER2],[JUDUL_KEGIATAN],[LANDASAN_PENELITIAN],
                    [JENIS_PENGABDIAN],[ANGGOTA1],[ANGGOTA2],[MITRA]
                    ,[MITRA_KEAHLIAN],[LOKASI],
                    [JARAK_PT_LOKASI],[OUTPUT],[OUTCOME],
                    [ID_ROAD_MAP],[AWAL],[AKHIR],
                    [SASARAN],[SKS_KETUA],[SKS_ANGGOTA],[NPP],[DANA_EKSTERNAL]
                    ,[DANA_KERJASAMA],[DANA_UAJY],[DANA_PRIBADI]
                    ,[DOKUMEN],[IS_CHECKED], [IS_DROPPED], [ID_STATUS], [IS_SETUJU_PRODI]
                    ,[IS_SETUJU_DEKAN],[IS_SETUJU_LPPM], [NPP_REVIEWER],[DANA_SETUJU]
                    ,[INSERT_DATE],[IP_ADDRESS],[USER_ID],[ID_SKIM],[ID_TEMA_UNIVERSITAS], NO_SEMESTER)   OUTPUT  INSERTED.ID_PROPOSAL values 
                    (@ID_TAHUN_ANGGARAN, 0,NULL,NULL,@JUDUL_KEGIATAN,@LANDASAN_PENELITIAN,@JENIS_PENGABDIAN,@ANGGOTA1,@ANGGOTA2,@MITRA,@MITRA_KEAHLIAN,@LOKASI,
                    @JARAK_PT_LOKASI,@OUTPUT,@OUTCOME,@ID_ROAD_MAP,@AWAL,@AKHIR,@SASARAN,@SKS_KETUA,@SKS_ANGGOTA,@NPP, @DANA_EKSTERNAL, @DANA_KERJASAMA, 
                    @DANA_UAJY,@DANA_PRIBADI
                    ,@DOKUMEN,0,0,1,1,1,NULL,NULL,0
                    ,@INSERT_DATE,@IP_ADDRESS,@USER_ID,@ID_SKIM, @ID_TEMA_UNIVERSITAS,@NO_SEMESTER)";
                    //reviewer 1 not declare must modify in sql , in design sql --> allow null
                    var param = new
                    { ID_TAHUN_ANGGARAN = ID_TAHUN_ANGGARAN, JUDUL_KEGIATAN = JUDUL_KEGIATAN, LANDASAN_PENELITIAN = LANDASAN_PENELITIAN, JENIS_PENGABDIAN=JENIS_PENGABDIAN, ANGGOTA1= ANGGOTA1,ANGGOTA2= ANGGOTA2, MITRA= MITRA, 
                        MITRA_KEAHLIAN = MITRA_KEAHLIAN, LOKASI = LOKASI, JARAK_PT_LOKASI = JARAK_PT_LOKASI,OUTPUT = OUTPUT, OUTCOME = OUTCOME,ID_ROAD_MAP = ID_ROAD_MAP, AWAL = AWAL, AKHIR = AKHIR, SASARAN = SASARAN, SKS_KETUA = SKS_KETUA, SKS_ANGGOTA= SKS_ANGGOTA, NPP = NPP,
                         DANA_EKSTERNAL = DANA_EKSTERNAL, DANA_KERJASAMA=DANA_KERJASAMA, DANA_UAJY=DANA_UAJY, DANA_PRIBADI=DANA_PRIBADI, DOKUMEN=DOKUMEN
                        ,INSERT_DATE = DateTime.Now, IP_ADDRESS=IP_ADDRESS,  USER_ID = USER_ID, ID_SKIM = ID_SKIM, ID_TEMA_UNIVERSITAS = ID_TEMA_UNIVERSITAS, NO_SEMESTER = NO_SEMESTER};


                    conn.Execute(query, param);

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
