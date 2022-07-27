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
             
                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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

        public DBOutput GetPangkatByUsername(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"select d.DESKRIPSI from SIMKA.REF_GOLONGAN d join SIMKA.MST_KARYAWAN p on p.ID_REF_GOLONGAN=d.ID_REF_GOLONGAN where p.USERNAME =@username";
               
                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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


        public DBOutput GetGolonganByUsername(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"select d.ID_REF_GOLONGAN from SIMKA.REF_GOLONGAN d 
                join SIMKA.MST_KARYAWAN p on p.ID_REF_GOLONGAN=d.ID_REF_GOLONGAN 
where p.USERNAME = @username";
                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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
        public DBOutput GetFakByUsername(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"select n.NAMA_UNIT from siatmax.MST_UNIT n join simka.MST_KARYAWAN p on p.ID_UNIT=n.ID_UNIT where p.USERNAME = @username";
             
                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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
        public DBOutput GetJurusanByUsername(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"select n.NAMA_UNIT from siatmax.MST_UNIT n join simka.MST_KARYAWAN p on p.ID_UNIT_AKADEMIK=n.ID_UNIT where p.USERNAME = @username";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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


        public DBOutput GetListPenelitianByUsername(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT     silppm.TBL_PENELITIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, 
                      silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, siatmax.MST_UNIT.NAMA_UNIT AS 'FAK', MST_UNIT_1.NAMA_UNIT AS 'PRODI', 
                      siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK, silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI AS STATUS, 
                      silppm.TBL_PENELITIAN.DANA_PRIBADI, silppm.TBL_PENELITIAN.DANA_EKSTERNAL, silppm.TBL_PENELITIAN.DANA_KERJASAMA, 
                      silppm.TBL_PENELITIAN.DANA_UAJY, silppm.TBL_PERSONIL_PENELITIAN.NPP,
                      case when TBL_PERSONIL_PENELITIAN.NPP = TBL_PENELITIAN.NPP then 'ketua' else 'anggota' end Peran
FROM         siatmax.MST_UNIT INNER JOIN
                      simka.MST_KARYAWAN ON siatmax.MST_UNIT.ID_UNIT = simka.MST_KARYAWAN.ID_UNIT INNER JOIN
                      siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                      silppm.TBL_PENELITIAN INNER JOIN
                      silppm.TBL_PERSONIL_PENELITIAN ON silppm.TBL_PENELITIAN.ID_PROPOSAL = silppm.TBL_PERSONIL_PENELITIAN.ID_PROPOSAL INNER JOIN
                      silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                      silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                      siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK ON 
                      simka.MST_KARYAWAN.NPP = silppm.TBL_PERSONIL_PENELITIAN.NPP and simka.MST_KARYAWAN.USERNAME = @username";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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

        public DBOutput GetListPengabdianByUsername(string username)
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
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENGABDIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK where simka.MST_KARYAWAN.USERNAME = @username";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { username = username });

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
        public DBOutput GetFeedbackProdi(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select* from silppm.TBL_FEEDBACK_PENELITIAN f join[siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE 
                    where s.ID_SISTEM_INFORMASI= 4 and r.DESKRIPSI= 'Prodi' and f.ID_PROPOSAL = @id_proposal";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_proposal = id_proposal });

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
        public DBOutput GetDataAnggotaPenelitian(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"SELECT [ID_PERSONIL_PENELITIAN],[NPP],[NAMA_LENGKAP_GELAR],[TEMPAT_LAHIR],
                    [TGL_LAHIR],[JNS_KEL],[EMAIL],[ID_REF_FUNGSIONAL],[ID_UNIT],[ID_UNIT_AKADEMIK],[ID_REF_GOLONGAN]
                    ,[ID_REF_JBTN_AKADEMIK],[NO_TELPON_RUMAH],[NO_TELPON_HP],[WARGANEGARA],[NPWP],[NIP_PNS],[NIDN]
                    ,[ALAMAT_KOTA],[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS],[ID_PROPOSAL],[INSTITUSI_ASAL],[BIDANG_KEAHLIAN_PENELITIAN]
                    FROM [PORTAL_DOSEN].[silppm].[TBL_PERSONIL_PENELITIAN] where ID_PROPOSAL= @id_proposal;";

                    var param = new { id_proposal = id_proposal };
                    var data = conn.Query<dynamic>(query, param).ToList();

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
        public DBOutput GetAnggota()
        {

            DBOutput output = new DBOutput();
            output.status = true;
            
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT simka.MST_KARYAWAN.NPP, simka.MST_KARYAWAN.NAMA, simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR, simka.MST_KARYAWAN.NICKNAME, 
                      simka.MST_KARYAWAN.MST_ID_UNIT, siatmax.MST_UNIT.NAMA_UNIT FROM simka.MST_KARYAWAN LEFT OUTER JOIN siatmax.MST_UNIT ON simka.MST_KARYAWAN.MST_ID_UNIT = siatmax.MST_UNIT.ID_UNIT";
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
        public DBOutput GetAnggotaByNPP(string npp)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT     simka.MST_KARYAWAN.NPP, simka.MST_KARYAWAN.NAMA, simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR, simka.MST_KARYAWAN.NICKNAME, 
                      simka.MST_KARYAWAN.MST_ID_UNIT, siatmax.MST_UNIT.NAMA_UNIT
                        FROM         simka.MST_KARYAWAN LEFT OUTER JOIN
                                              siatmax.MST_UNIT ON simka.MST_KARYAWAN.MST_ID_UNIT = siatmax.MST_UNIT.ID_UNIT where MST_KARYAWAN.NPP = @npp" ;
                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { npp = npp });

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


        public DBOutput AddAnggotaUAJY(int id_proposal, string npp)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"insert into silppm.TBL_PERSONIL_PENELITIAN([NPP]
            ,[NAMA_LENGKAP_GELAR],[TEMPAT_LAHIR],[TGL_LAHIR],[JNS_KEL]
            ,[EMAIL],[ID_REF_FUNGSIONAL],[ID_UNIT],[ID_UNIT_AKADEMIK]
            ,[ID_REF_GOLONGAN],[ID_REF_JBTN_AKADEMIK],[NO_TELPON_RUMAH]
            ,[NO_TELPON_HP],[WARGANEGARA],[NPWP],[NIP_PNS],[NIDN]
            ,[ALAMAT_KOTA],[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS]
            ,[ID_PROPOSAL] )
            SELECT  [NPP],[NAMA_LENGKAP_GELAR],[TEMPAT_LAHIR],[TGL_LAHIR],[JNS_KEL]
            ,[EMAIL],[ID_REF_FUNGSIONAL],[ID_UNIT],[ID_UNIT_AKADEMIK]
            ,[ID_REF_GOLONGAN],[ID_REF_JBTN_AKADEMIK],[NO_TELPON_RUMAH]
            ,[NO_TELPON_HP],[WARGANEGARA],[NPWP],[NIP_PNS],[NIDN],[ALAMAT_KOTA]
            ,[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS],@id_proposal
             FROM  simka.MST_KARYAWAN where [NPP] = @npp;";
                    var param = new {  id_proposal = id_proposal, npp = npp };


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
        public DBOutput AddAnggotaNonUAJY(string npp, string nama_lengkap_gelar, string email, string no_telpon_rumah, string no_telpon_hp,
            string npwp, string nip_pns, string nidn, string alamat_kota, string alamat, string alamat_provinsi, string alamat_kodepos, int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"insert into silppm.TBL_PERSONIL_PENELITIAN(
            NPP,[NAMA_LENGKAP_GELAR],[EMAIL],[NO_TELPON_RUMAH]
            ,[NO_TELPON_HP],[NPWP],[NIP_PNS],[NIDN]
            ,[ALAMAT_KOTA],[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS]
            ,[ID_PROPOSAL] )
            SELECT @npp, @nama_lengkap_gelar,@email,@no_telpon_rumah
            ,@no_telpon_hp,@npwp,@nip_pns,@nidn,@alamat_kota
            ,@alamat,@alamat_provinsi,@alamat_kodepos,@id_proposal";
                    var param = new { npp = npp, nama_lengkap_gelar = nama_lengkap_gelar, email = email, no_telpon_rumah=no_telpon_rumah, no_telpon_hp=no_telpon_hp, npwp=npwp,
                    nip_pns=nip_pns, nidn=nidn, alamat_kota=alamat_kota, alamat=alamat, alamat_provinsi=alamat_provinsi, alamat_kodepos = alamat_kodepos, id_proposal= id_proposal};


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

        public DBOutput UbahPenelitian(int ID_TAHUN_ANGGARAN, int NO_SEMESTER, int ID_KATEGORI, int ID_ROAD_MAP_PENELITIAN, int ID_SKIM, int ID_TEMA_UNIVERSITAS, 
            string JENIS, string JUDUL,string LOKASI,string NPP,  string AWAL, string AKHIR,  string NPP_REVIEWER, string REVIEWER1, string REVIEWER2, 
            string IS_SETUJU_LPPM, int BEBAN_SKS, float DANA_USUL, float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY, float DANA_SETUJU, string KEYWORD,string OUTCOME, string LONGITUDE, string LATITUDE, string INSERT_DATE,  string USER_ID, string KETERANGAN_DANA_EKSTERNAL, string ID_PROPOSAL)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"UPDATE [silppm].[TBL_PENELITIAN] SET
                    [ID_TAHUN_ANGGARAN] = @ID_TAHUN_ANGGARAN,[NO_SEMESTER] = @NO_SEMESTER ,[ID_KATEGORI] = @ID_KATEGORI,[ID_ROAD_MAP_PENELITIAN] = @ID_ROAD_MAP_PENELITIAN
                    ,[ID_SKIM] = @ID_SKIM,[ID_TEMA_UNIVERSITAS] = @ID_TEMA_UNIVERSITAS,[JENIS] = @JENIS
                    ,[JUDUL] = @JUDUL,[LOKASI] = @LOKASI,[NPP] = @NPP,[AWAL] = @AWAL,[AKHIR] = @AKHIR,[IS_CHECKED] = 0,[IS_DROPPED] = 0
                    ,[IS_SETUJU_PRODI] = 1,[IS_SETUJU_DEKAN] = 1,[NPP_REVIEWER] = @NPP_REVIEWER,[REVIEWER1]  = @REVIEWER1
                    ,[REVIEWER2] = @REVIEWER2,[IS_SETUJU_LPPM] = @IS_SETUJU_LPPM,[BEBAN_SKS]  = @BEBAN_SKS, [DANA_USUL] = @DANA_USUL, [DANA_PRIBADI] = @DANA_PRIBADI, 
                    [DANA_EKSTERNAL] = @DANA_EKSTERNAL, [DANA_KERJASAMA] = @DANA_KERJASAMA, [DANA_UAJY] = @DANA_UAJY, [DANA_SETUJU] = @DANA_SETUJU, [KEYWORD] = @KEYWORD
                    ,[OUTCOME]  = @OUTCOME,[LONGITUDE] = @LONGITUDE,[LATITUDE] = @LATITUDE,[INSERT_DATE] = @INSERT_DATE
                    ,[USER_ID] = @USER_ID,[KETERANGAN_DANA_EKSTERNAL] = @KETERANGAN_DANA_EKSTERNAL  where ID_PROPOSAL = @ID_PROPOSAL";
                  

                    var param = new { ID_TAHUN_ANGGARAN = ID_TAHUN_ANGGARAN, NO_SEMESTER = NO_SEMESTER, ID_KATEGORI = ID_KATEGORI, ID_ROAD_MAP_PENELITIAN = ID_ROAD_MAP_PENELITIAN, ID_SKIM = ID_SKIM, ID_TEMA_UNIVERSITAS = ID_TEMA_UNIVERSITAS, 
                     JENIS=JENIS, JUDUL = JUDUL, LOKASI = LOKASI, NPP = NPP, AWAL = AWAL, AKHIR= AKHIR,NPP_REVIEWER = NPP_REVIEWER, REVIEWER1 = REVIEWER1, REVIEWER2 = REVIEWER2, IS_SETUJU_LPPM = IS_SETUJU_LPPM,  BEBAN_SKS = BEBAN_SKS, 
                    DANA_USUL = DANA_USUL, DANA_PRIBADI = DANA_PRIBADI, DANA_EKSTERNAL = DANA_EKSTERNAL, DANA_KERJASAMA = DANA_KERJASAMA, DANA_UAJY = DANA_UAJY, DANA_SETUJU = DANA_SETUJU, KEYWORD = KEYWORD, OUTCOME = OUTCOME, LONGITUDE = LONGITUDE, 
                        LATITUDE = LATITUDE, INSERT_DATE = INSERT_DATE,  USER_ID = USER_ID, KETERANGAN_DANA_EKSTERNAL = KETERANGAN_DANA_EKSTERNAL, ID_PROPOSAL = ID_PROPOSAL};


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
                        DANA_PRIBADI = DANA_PRIBADI, DANA_EKSTERNAL = DANA_EKSTERNAL, DANA_KERJASAMA=DANA_KERJASAMA, DANA_UAJY=DANA_UAJY, INSERT_DATE = INSERT_DATE
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

      
        public DBOutput GetDataPropo(string username)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select d.id_proposal,d.Judul,s.DESKRIPSI from silppm.TBL_PENELITIAN d join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s 
                    on s.ID_STATUS_PENELITIAN=d.ID_STATUS_PENELITIAN where d.NPP= @npp and IS_DROPPED=0 ";
                
                    var data = conn.Query<dynamic>(query, new { npp = username }).ToList();

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
        public DBOutput GetDataPropoPengabdian(string username)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT* FROM silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s 
            on s.ID_STATUS_PENELITIAN= p.ID_STATUS where NPP = @npp and IS_DROPPED = 0 ";

                    var data = conn.Query<dynamic>(query, new { npp = username }).ToList();

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

        public DBOutput GetDataPropoPengabdianByID(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT* FROM silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s 
            on s.ID_STATUS_PENELITIAN= p.ID_STATUS where  IS_DROPPED = 0 and p.ID_PROPOSAL = @id_proposal";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_proposal = id_proposal});

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
        //Query untuk proposal penelitian yang diterima
        public DBOutput GetPenelitianDiterima(string username)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select e.id_proposal,e.JUDUL,s.DESKRIPSI,e.NPP, s.ID_STATUS_PENELITIAN
from silppm.TBL_PENELITIAN_LOLOS e join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s 
on s.ID_STATUS_PENELITIAN=e.ID_STATUS_PENELITIAN where NPP = @npp";

                    var data = conn.Query<dynamic>(query, new { npp = username }).ToList();

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
        public DBOutput GetPengabdianDiterima(string username)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select e.id_proposal,e.JUDUL_KEGIATAN,s.DESKRIPSI,e.NPP, s.ID_STATUS_PENELITIAN
from silppm.TBL_PENGABDIAN_LOLOS e join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s 
on s.ID_STATUS_PENELITIAN=e.ID_STATUS where NPP =  @npp";

                    var data = conn.Query<dynamic>(query, new { npp = username }).ToList();

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

        public DBOutput GetDataPropoByID(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select d.id_proposal,d.Judul,s.DESKRIPSI from silppm.TBL_PENELITIAN d join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s 
                    on s.ID_STATUS_PENELITIAN=d.ID_STATUS_PENELITIAN where d.id_proposal = @id_proposal and IS_DROPPED=0 ";

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
        //MENGHITUNG JUMLAH ROW NILAI REVIEW
        public DBOutput GetCountNilaiReview(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT COUNT (ID_NILAI_REVIEW) AS JUMLAH FROM silppm.TBL_NILAI_REVIEW_PENELITIAN WHERE ID_PROPOSAL = @id_proposal ";

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
        public DBOutput GetCountReviewer1(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT  count( silppm.TBL_PENELITIAN.ID_PROPOSAL) AS JUMLAH
                      FROM [PORTAL_DOSEN].[silppm].[TBL_PENELITIAN] join silppm.TBL_NILAI_REVIEW_PENELITIAN on silppm.TBL_NILAI_REVIEW_PENELITIAN.ID_PROPOSAL = silppm.TBL_PENELITIAN.ID_PROPOSAL 
                    WHERE silppm.TBL_NILAI_REVIEW_PENELITIAN.ID_REVIEWER = silppm.TBL_PENELITIAN.REVIEWER1 AND TBL_PENELITIAN.ID_PROPOSAL = @id_proposal";

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
        public DBOutput GetCountReviewer2(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT  count( silppm.TBL_PENELITIAN.ID_PROPOSAL) AS JUMLAH
                      FROM [PORTAL_DOSEN].[silppm].[TBL_PENELITIAN] join silppm.TBL_NILAI_REVIEW_PENELITIAN on silppm.TBL_NILAI_REVIEW_PENELITIAN.ID_PROPOSAL = silppm.TBL_PENELITIAN.ID_PROPOSAL 
                    WHERE silppm.TBL_NILAI_REVIEW_PENELITIAN.ID_REVIEWER = silppm.TBL_PENELITIAN.REVIEWER2 AND TBL_PENELITIAN.ID_PROPOSAL = @id_proposal";

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
        public DBOutput GetCountReviewer1Pengabdian(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT  count( silppm.TBL_PENGABDIAN.ID_PROPOSAL) AS JUMLAH
                      FROM [PORTAL_DOSEN].[silppm].[TBL_PENGABDIAN] join silppm.TBL_NILAI_REVIEW_PENGABDIAN on silppm.TBL_NILAI_REVIEW_PENGABDIAN.ID_PROPOSAL = silppm.TBL_PENGABDIAN.ID_PROPOSAL 
                    WHERE silppm.TBL_NILAI_REVIEW_PENGABDIAN.ID_REVIEWER = silppm.TBL_PENGABDIAN.REVIEWER1 AND TBL_PENGABDIAN.ID_PROPOSAL = @id_proposal";

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
        public DBOutput GetDataReview(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT [ID_NILAI_REVIEW] ,[ID_PROPOSAL] ,[ID_REVIEWER] ,[COUNT_REVISI]
                    ,[N1_FIELD1] ,[N1_FIELD2] ,[N1_FIELD3] ,[N1_FIELD4] ,[N1_FIELD5] ,[N1_FIELD6]
                    ,[N1_FIELD7] ,[N1_JUSTIFIKASI1] ,[N1_JUSTIFIKASI2] ,[N1_JUSTIFIKASI3]
                    ,[N1_JUSTIFIKASI4] ,[N1_JUSTIFIKASI5] ,[N1_JUSTIFIKASI6] ,[N1_JUSTIFIKASI7]
                    ,[DANA_REKOMENDASI] ,[DANA_SETUJU] FROM
                    [PORTAL_DOSEN].[silppm].[TBL_NILAI_REVIEW_PENELITIAN] WHERE ID_PROPOSAL = @id_proposal
                     ";

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
        public DBOutput GetDataReviewByID(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT [ID_NILAI_REVIEW] ,[ID_PROPOSAL] ,[ID_REVIEWER] ,[COUNT_REVISI]
                    ,[N1_FIELD1] ,[N1_FIELD2] ,[N1_FIELD3] ,[N1_FIELD4] ,[N1_FIELD5] ,[N1_FIELD6]
                    ,[N1_FIELD7] ,[N1_JUSTIFIKASI1] ,[N1_JUSTIFIKASI2] ,[N1_JUSTIFIKASI3]
                    ,[N1_JUSTIFIKASI4] ,[N1_JUSTIFIKASI5] ,[N1_JUSTIFIKASI6] ,[N1_JUSTIFIKASI7]
                    ,[DANA_REKOMENDASI] ,[DANA_SETUJU] FROM
                    [PORTAL_DOSEN].[silppm].[TBL_NILAI_REVIEW_PENELITIAN] WHERE ID_PROPOSAL = @id_proposal
                     ";

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
        public DBOutput GetDataNilaiReviewer1Pengabdian(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @" SELECT  p.[ID_PROPOSAL],ID_REVIEWER, SKOR1,SKOR2,SKOR3,SKOR4, SKOR5, SKOR6, JUSTIFIKASI1,JUSTIFIKASI2, JUSTIFIKASI3, JUSTIFIKASI4, JUSTIFIKASI5, JUSTIFIKASI6
                  FROM [PORTAL_DOSEN].[silppm].[TBL_NILAI_REVIEW_PENGABDIAN] s join silppm.TBL_PENGABDIAN p on s.ID_PROPOSAL = p.ID_PROPOSAL
                  INTERSECT SELECT  q.ID_PROPOSAL, REVIEWER1, SKOR1,SKOR2,SKOR3,SKOR4, SKOR5, SKOR6, JUSTIFIKASI1,JUSTIFIKASI2, JUSTIFIKASI3, JUSTIFIKASI4, JUSTIFIKASI5, JUSTIFIKASI6 FROM silppm.TBL_PENGABDIAN q 
                  join silppm.TBL_NILAI_REVIEW_PENGABDIAN r on q.ID_PROPOSAL = r.ID_PROPOSAL WHERE q.ID_PROPOSAL = @id_proposal";

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
        public DBOutput GetDataNilaiReviewer1(int id_proposal)
        {
          
            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"   SELECT  p.[ID_PROPOSAL],ID_REVIEWER, N1_FIELD1,N1_FIELD2,N1_FIELD3,N1_FIELD4, N1_FIELD5, N1_FIELD6, N1_FIELD7, N1_JUSTIFIKASI1,N1_JUSTIFIKASI2, N1_JUSTIFIKASI3, N1_JUSTIFIKASI4, N1_JUSTIFIKASI5, N1_JUSTIFIKASI6, N1_JUSTIFIKASI7
                  FROM [PORTAL_DOSEN].[silppm].[TBL_NILAI_REVIEW_PENELITIAN] s join silppm.TBL_PENELITIAN p on s.ID_PROPOSAL = p.ID_PROPOSAL
                  INTERSECT SELECT  q.ID_PROPOSAL, REVIEWER1, N1_FIELD1, N1_FIELD2,N1_FIELD3,N1_FIELD4, N1_FIELD5, N1_FIELD6, N1_FIELD7, N1_JUSTIFIKASI1,N1_JUSTIFIKASI2, N1_JUSTIFIKASI3, N1_JUSTIFIKASI4, N1_JUSTIFIKASI5, N1_JUSTIFIKASI6, N1_JUSTIFIKASI7 FROM silppm.TBL_PENELITIAN q 
                  join silppm.TBL_NILAI_REVIEW_PENELITIAN r on q.ID_PROPOSAL = r.ID_PROPOSAL WHERE q.ID_PROPOSAL = @id_proposal";

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

        public DBOutput GetDataNilaiReviewer2(int id_proposal)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"   SELECT  p.[ID_PROPOSAL],ID_REVIEWER, N1_FIELD1,N1_FIELD2,N1_FIELD3,N1_FIELD4, N1_FIELD5, N1_FIELD6, N1_FIELD7, N1_JUSTIFIKASI1,N1_JUSTIFIKASI2, N1_JUSTIFIKASI3, N1_JUSTIFIKASI4, N1_JUSTIFIKASI5, N1_JUSTIFIKASI6, N1_JUSTIFIKASI7
                  FROM [PORTAL_DOSEN].[silppm].[TBL_NILAI_REVIEW_PENELITIAN] s join silppm.TBL_PENELITIAN p on s.ID_PROPOSAL = p.ID_PROPOSAL
                  INTERSECT SELECT  q.ID_PROPOSAL, REVIEWER2, N1_FIELD1, N1_FIELD2,N1_FIELD3,N1_FIELD4, N1_FIELD5, N1_FIELD6, N1_FIELD7, N1_JUSTIFIKASI1,N1_JUSTIFIKASI2, N1_JUSTIFIKASI3, N1_JUSTIFIKASI4, N1_JUSTIFIKASI5, N1_JUSTIFIKASI6, N1_JUSTIFIKASI7 FROM silppm.TBL_PENELITIAN q 
                  join silppm.TBL_NILAI_REVIEW_PENELITIAN r on q.ID_PROPOSAL = r.ID_PROPOSAL WHERE q.ID_PROPOSAL = @id_proposal";

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
        public DBOutput GetHistoryPenelitianByNPP(string username)
        {

            DBOutput output = new DBOutput();
            output.status = true;

            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT     silppm.TBL_PENELITIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, 
                      silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, siatmax.MST_UNIT.NAMA_UNIT AS 'FAK', MST_UNIT_1.NAMA_UNIT AS 'PRODI', 
                      siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK, silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI AS STATUS, 
                      silppm.TBL_PENELITIAN.DANA_PRIBADI, silppm.TBL_PENELITIAN.DANA_EKSTERNAL, silppm.TBL_PENELITIAN.DANA_KERJASAMA, 
                      silppm.TBL_PENELITIAN.DANA_UAJY, silppm.TBL_PERSONIL_PENELITIAN.NPP,
                      case when TBL_PERSONIL_PENELITIAN.NPP = TBL_PENELITIAN.NPP then 'ketua' else 'anggota' end Peran
FROM         siatmax.MST_UNIT INNER JOIN
                      simka.MST_KARYAWAN ON siatmax.MST_UNIT.ID_UNIT = simka.MST_KARYAWAN.ID_UNIT INNER JOIN
                      siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                      silppm.TBL_PENELITIAN INNER JOIN
                      silppm.TBL_PERSONIL_PENELITIAN ON silppm.TBL_PENELITIAN.ID_PROPOSAL = silppm.TBL_PERSONIL_PENELITIAN.ID_PROPOSAL INNER JOIN
                      silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                      silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                      siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK ON 
                      simka.MST_KARYAWAN.NPP = silppm.TBL_PERSONIL_PENELITIAN.NPP
                      where TBL_PERSONIL_PENELITIAN.NPP =@npp ";

                    var data = conn.Query<dynamic>(query, new { npp = username }).ToList();

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