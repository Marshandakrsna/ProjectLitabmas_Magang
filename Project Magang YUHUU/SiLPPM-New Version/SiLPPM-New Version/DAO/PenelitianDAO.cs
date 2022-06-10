using SiLPPM_New_Version.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SiLPPM_New_Version.DAO
{
    public class PenelitianDAO
    {

        public DBOutput GetRefSkim()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT ID_SKIM
      ,KATEGORI
      ,DESKRIPSI
  FROM PORTAL_DOSEN.silppm.REF_SKIM";

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
        public DBOutput GetRefTahunAka()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"
SELECT ID_TAHUN_AKADEMIK
      ,TAHUN_AKADEMIK
  FROM PORTAL_DOSEN.siatmax.TBL_TAHUN_AKADEMIK ORDER BY TAHUN_AKADEMIK ASC";

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
        public DBOutput GetRefSemester()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT DISTINCT NO_SEMESTER
      ,SEMESTER_AKADEMIK
     
  FROM PORTAL_DOSEN.siatmax.TBL_SEMESTER_AKADEMIK";

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
        public DBOutput GetRefOutput()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT ID_OUTPUT
      ,DESKRIPSI
  FROM PORTAL_DOSEN.silppm.REF_OUTPUT";

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
        public DBOutput GetRefJenis()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT ID_JENIS_PENELITIAN
                      ,JENIS_PENELITIAN
                  FROM PORTAL_DOSEN.silppm.REF_JENIS_PENELITIAN";

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
        public DBOutput GetRefTema()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT ID_TEMA_UNIVERSITAS
      ,KATEGORI
      ,DESKRIPSI
  FROM silppm.REF_TEMA_UNIVERSITAS;";

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
        public DBOutput GetRefKategori()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT ID_KATEGORI
      ,DESKRIPSI
  FROM silppm.REF_KATEGORI WHERE DESKRIPSI IS NOT NULL;";

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
        public DBOutput GetRefGolongan()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT ID_REF_GOLONGAN
      ,DESKRIPSI
  FROM simka.REF_GOLONGAN";

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
        public DBOutput GetJabatanAkaByUsername(string username)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"SELECT simka.MST_KARYAWAN.NPP, simka.MST_KARYAWAN.NAMA,  
                      simka.REF_JABATAN_AKADEMIK.DESKRIPSI, MST_UNIT_1.NAMA_UNIT AS FAKULTAS FROM         
                      siatmax.MST_UNIT AS MST_UNIT_1 RIGHT OUTER JOIN
                      siatmax.MST_UNIT ON MST_UNIT_1.ID_UNIT = siatmax.MST_UNIT.MST_ID_UNIT RIGHT OUTER JOIN
                      simka.REF_JABATAN_AKADEMIK RIGHT OUTER JOIN
                      simka.MST_KARYAWAN ON simka.REF_JABATAN_AKADEMIK.ID_REF_JBTN_AKADEMIK = simka.MST_KARYAWAN.ID_REF_JBTN_AKADEMIK ON 
                      simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = siatmax.MST_UNIT.ID_UNIT LEFT OUTER JOIN
                      simka.REF_GOLONGAN ON simka.MST_KARYAWAN.ID_REF_GOLONGAN = simka.REF_GOLONGAN.ID_REF_GOLONGAN 
WHERE     (NOT (simka.MST_KARYAWAN.NPP IN (N'00.00.001', N'xx.xx.001'))) and MST_KARYAWAN.USERNAME =@username";

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
        public DBOutput GetListPenelitian()
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
                    where 1 = 1 ";

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
        //INSERT DATA PROSIDING PENELITIAN
        public DBOutput AddPublikasi(string npp, int id_proposal,string judul, int id_level_seminar,string nama_jurnal, string issn, string doi)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"INSERT INTO [silppm].[TBL_PUBLIKASI_SEMINAR]
                           ([ID_PROPOSAL],[JUDUL],[ID_LEVEL_SEMINAR],[NAMA_JURNAL],[ISSN],[DOI])
                            VALUES( @id_proposal, @judul,@id_level_seminar,@nama_jurnal,@issn,@doi)";
                    var param = new { npp= npp, id_proposal = id_proposal, judul = judul, id_level_seminar= id_level_seminar, nama_jurnal= nama_jurnal, issn= issn, doi= doi };

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
        public DBOutput AddJurnal(string npp, int id_proposal, string judul, int id_level_jurnal, string nama_seminar, string issn, string doi)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"INSERT INTO [silppm].[TBL_PUBLIKASI_JURNAL]
                           ([ID_PROPOSAL],[JUDUL],[ID_LEVEL_JURNAL],[NAMA_SEMINAR],[ISSN],[DOI])
                            VALUES( @id_proposal, @judul,@id_level_jurnal,@nama_seminar,@issn,@doi)";
                    var param = new { npp = npp, id_proposal = id_proposal, judul = judul, id_level_jurnal = id_level_jurnal, nama_seminar = nama_seminar, issn= issn, doi = doi };


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
        public DBOutput GetHistoryProsiding()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"select ps.ID_OUTCOME_PROSIDING, ps.ID_PROPOSAL,ps.JUDUL,r.ID_LEVEL_SEMINAR,r.LEVEL,ps.NAMA_JURNAL,ps.DOI,ps.ISSN from silppm.TBL_PUBLIKASI_SEMINAR ps  join silppm.TBL_PENELITIAN p on p.ID_PROPOSAL=ps.ID_PROPOSAL join silppm.REF_LEVEL_SEMINAR r on ps.ID_LEVEL_SEMINAR=r.ID_LEVEL_SEMINAR ";


                    var data = conn.Query<dynamic>(query).ToList();

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

        public DBOutput GetHistoryJurnal()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"select j.ID_OUTCOME_PUBLIKASI,j.ID_PROPOSAL,j.JUDUL,r.ID_LEVEL_JURNAL,r.LEVEL,j.NAMA_SEMINAR,j.DOI,j.ISSN from silppm.TBL_PUBLIKASI_JURNAL j  join silppm.TBL_PENELITIAN p on p.ID_PROPOSAL=J.ID_PROPOSAL join silppm.REF_LEVEL_JURNAL r on j.ID_LEVEL_JURNAL=r.ID_LEVEL_JURNAL";

                    var data = conn.Query<dynamic>(query).ToList();

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

        public DBOutput GetRefLevelSeminar()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"
SELECT  [ID_LEVEL_SEMINAR]
      ,[LEVEL]
  FROM [PORTAL_DOSEN].[silppm].[REF_LEVEL_SEMINAR]";

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
        public DBOutput GetRefLevelJurnal()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"
SELECT [ID_LEVEL_JURNAL]
      ,[LEVEL]
  FROM [PORTAL_DOSEN].[silppm].[REF_LEVEL_JURNAL]";

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
        public DBOutput GetRefLevelSeminarByID(int Id)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT  [ID_LEVEL_SEMINAR]
      ,[LEVEL]
  FROM [PORTAL_DOSEN].[silppm].[REF_LEVEL_SEMINAR] where ID_LEVEL_SEMINAR = @Id;";

                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { Id= Id });

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
        public DBOutput DeleteProsiding(int id_outcome_prosiding)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"DELETE FROM [silppm].[TBL_PUBLIKASI_SEMINAR] WHERE [ID_OUTCOME_PROSIDING]=@id_outcome_prosiding";

                    //var param = new { id_outcome_prosiding = id_outcome_prosiding };

                    //// Tampung hasil qxecute ke output

                    //conn.Execute(query, param);
                    //return output;
                    var param = new { id_outcome_prosiding=id_outcome_prosiding };
                   
                    

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

        public DBOutput DeleteJurnal(int id_outcome_publikasi)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"DELETE FROM [silppm].[TBL_PUBLIKASI_JURNAL] WHERE [ID_OUTCOME_PUBLIKASI]=@id_outcome_publikasi";

                    var param = new { id_outcome_publikasi = id_outcome_publikasi};
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

        public DBOutput GetHistoryProsidingByID(int id_outcome_prosiding)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"select ps.ID_OUTCOME_PROSIDING, ps.ID_PROPOSAL, ps.JUDUL,r.ID_LEVEL_SEMINAR,r.LEVEL,ps.NAMA_JURNAL,ps.DOI,ps.ISSN from silppm.TBL_PUBLIKASI_SEMINAR ps  join silppm.TBL_PENELITIAN p on p.ID_PROPOSAL=ps.ID_PROPOSAL 
join silppm.REF_LEVEL_SEMINAR r on ps.ID_LEVEL_SEMINAR=r.ID_LEVEL_SEMINAR where ps.ID_OUTCOME_PROSIDING = @id_outcome_prosiding";


                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_outcome_prosiding = id_outcome_prosiding });

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
        public DBOutput GetHistoryJurnalByID(int id_outcome_publikasi)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select j.ID_OUTCOME_PUBLIKASI,j.ID_PROPOSAL,j.JUDUL,r.ID_LEVEL_JURNAL,r.LEVEL,j.NAMA_SEMINAR,j.DOI,j.ISSN from silppm.TBL_PUBLIKASI_JURNAL j 
                                    join silppm.TBL_PENELITIAN p on p.ID_PROPOSAL = J.ID_PROPOSAL join silppm.REF_LEVEL_JURNAL r on j.ID_LEVEL_JURNAL = r.ID_LEVEL_JURNAL Where j.ID_OUTCOME_PUBLIKASI = @id_outcome_publikasi";



                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_outcome_publikasi = id_outcome_publikasi});

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
        public DBOutput CekSetujuProdi(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select IS_SETUJU_PRODI from silppm.TBL_PENELITIAN where id_proposal = @id_proposal";



                    var data = conn.QueryFirstOrDefault<dynamic>(query, new { id_proposal= id_proposal });

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
        public DBOutput CekSetujuDekan(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select IS_SETUJU_DEKAN from silppm.TBL_PENELITIAN where id_proposal = @id_proposal";



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
        public DBOutput CekSetujuLPPM(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select IS_SETUJU_LPPM from silppm.TBL_PENELITIAN where id_proposal = @id_proposal";



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

        public DBOutput GetKriteriaPenilaian()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"SELECT  [ID_KRITERIA_PENILAIAN],[KRITERIA],[BOBOT],[IS_DELETED] 
                    FROM [PORTAL_DOSEN].[silppm].[REF_KRITERIA_PENILAIAN_PENELITIAN] Where IS_DELETED =0;";

                    var data = conn.Query<dynamic>(query).ToList();

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

        //untuk HAKI
        public DBOutput GetOutcome()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"SELECT  ID_OUTCOME, ID_JENIS_OUTCOME, DESKRIPSI
                    FROM silppm.REF_OUTCOME WHERE  IS_DELETED='false'";

                    var data = conn.Query<dynamic>(query).ToList();

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
        public DBOutput CekSetujuProdiPengabdian(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select IS_SETUJU_PRODI from silppm.TBL_PENGABDIAN where id_proposal = @id_proposal";



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
        public DBOutput CekSetujuDekanPengabdian(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select IS_SETUJU_DEKAN from silppm.TBL_PENGABDIAN where id_proposal = @id_proposal";



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
        public DBOutput CekSetujuLPPMPengabdian(int id_proposal)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select IS_SETUJU_LPPM from silppm.TBL_PENGABDIAN where id_proposal = @id_proposal";



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
        public DBOutput GetKriteriaPenilaianPengabdian()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {

                    string query = @"SELECT  [ID_KRITERIA_PENILAIAN],[KRITERIA],[BOBOT],[IS_DELETED] 
                    FROM [PORTAL_DOSEN].[silppm].[REF_KRITERIA_PENILAIAN_PENELITIAN] Where IS_DELETED =1;";

                    var data = conn.Query<dynamic>(query).ToList();

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
        public DBOutput UpdateSetReviewer(int id_proposal, string reviewer1, string reviewer2)
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"update silppm.TBL_PENELITIAN set REVIEWER1 = @reviewer1 , REVIEWER2=@reviewer2 where id_proposal = @id_proposal";

                    var param = new { ID_PROPOSAL = id_proposal, REVIEWER1 = reviewer1, REVIEWER2 = reviewer2 };
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
        public DBOutput GetPenelitianReviewerByID(int id_proposal)
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
                    where REVIEWER1 is not null and REVIEWER2 is not null and id_proposal = @id_proposal ";


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
        public DBOutput GetPenelitianSetReviewerByID(int id_proposal)
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
                    where REVIEWER1 is null and REVIEWER2 is null and id_proposal = @id_proposal";

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
        public DBOutput GetRefGetReviewer()
        {
            DBOutput output = new DBOutput();
            output.status = true;
            using (SqlConnection conn = new SqlConnection(DBKoneksi.connectDB))
            {
                try
                {
                    string query = @"select DISTINCT m.NPP,m.NAMA,m.NAMA_LENGKAP_GELAR from simka.MST_KARYAWAN m join  [siatmax].[TBL_USER_ROLE] s on s.NPP=m.NPP join [siatmax].[REF_ROLE] r  
                    on r.id_role=s.id_role where r.DESKRIPSI='Assesor' and s.ID_SISTEM_INFORMASI=8 and s.IS_ACTIVE='1'";

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
