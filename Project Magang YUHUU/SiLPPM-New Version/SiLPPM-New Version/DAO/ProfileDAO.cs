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
                    string query = @"SELECT     simka.MST_KARYAWAN.NPP, simka.MST_KARYAWAN.NAMA, simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR, simka.MST_KARYAWAN.NICKNAME, 
                      simka.MST_KARYAWAN.MST_ID_UNIT, siatmax.MST_UNIT.NAMA_UNIT
                        FROM         simka.MST_KARYAWAN LEFT OUTER JOIN
                                              siatmax.MST_UNIT ON simka.MST_KARYAWAN.MST_ID_UNIT = siatmax.MST_UNIT.ID_UNIT";
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
            int ID_STATUS_PENELITIAN, string JENIS, string JUDUL,string LOKASI,string NPP,  string AWAL, string AKHIR,  string NPP_REVIEWER, string REVIEWER1, string REVIEWER2, 
            string IS_SETUJU_LPPM, int BEBAN_SKS, string KEYWORD,string OUTCOME, string LONGITUDE, string LATITUDE, string INSERT_DATE,  string USER_ID, string KETERANGAN_DANA_EKSTERNAL, string ID_PROPOSAL)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"UPDATE [silppm].[TBL_PENELITIAN] SET
                    [ID_TAHUN_ANGGARAN] = @ID_TAHUN_ANGGARAN,[NO_SEMESTER] = @NO_SEMESTER ,[ID_KATEGORI] = @ID_KATEGORI,[ID_ROAD_MAP_PENELITIAN] = @ID_ROAD_MAP_PENELITIAN
                    ,[ID_SKIM] = @ID_SKIM,[ID_TEMA_UNIVERSITAS] = @ID_TEMA_UNIVERSITAS,[ID_STATUS_PENELITIAN] = 6,[JENIS] = @JENIS
                    ,[JUDUL] = @JUDUL,[LOKASI] = @LOKASI,[NPP] = @NPP,[AWAL] = @AWAL,[AKHIR] = @AKHIR,[IS_CHECKED] = 0,[IS_DROPPED] = 0
                    ,[IS_SETUJU_PRODI] = 1,[IS_SETUJU_DEKAN] = 1--,[NPP_REVIEWER] = @NPP_REVIEWER,[REVIEWER1]  = @REVIEWER1
                    ,[REVIEWER2] = @REVIEWER2,[IS_SETUJU_LPPM] = @IS_SETUJU_LPPM,[BEBAN_SKS]  = @BEBAN_SKS,[KEYWORD] = @KEYWORD
                    ,[OUTCOME]  = @OUTCOME,[LONGITUDE] = @LONGITUDE,[LATITUDE] = @LATITUDE,[INSERT_DATE] = @INSERT_DATE
                    ,[USER_ID] = @USER_ID,[KETERANGAN_DANA_EKSTERNAL] = @KETERANGAN_DANA_EKSTERNAL  where ID_PROPOSAL = @ID_PROPOSAL";
                  

                    var param = new { ID_TAHUN_ANGGARAN = ID_TAHUN_ANGGARAN, NO_SEMESTER = NO_SEMESTER, ID_KATEGORI = ID_KATEGORI, ID_ROAD_MAP_PENELITIAN = ID_ROAD_MAP_PENELITIAN, ID_SKIM = ID_SKIM, ID_TEMA_UNIVERSITAS = ID_TEMA_UNIVERSITAS, 
                    ID_STATUS_PENELITIAN = ID_STATUS_PENELITIAN, JENIS=JENIS, JUDUL = JUDUL, LOKASI = LOKASI, NPP = NPP, AWAL = AWAL, AKHIR= AKHIR,NPP_REVIEWER = NPP_REVIEWER, REVIEWER1 = REVIEWER1, REVIEWER2 = REVIEWER2, IS_SETUJU_LPPM = IS_SETUJU_LPPM,  BEBAN_SKS = BEBAN_SKS, 
                    KEYWORD = KEYWORD, OUTCOME = OUTCOME, LONGITUDE = LONGITUDE, LATITUDE = LATITUDE, INSERT_DATE = INSERT_DATE,  USER_ID = USER_ID, KETERANGAN_DANA_EKSTERNAL = KETERANGAN_DANA_EKSTERNAL, ID_PROPOSAL = ID_PROPOSAL};


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