﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using silppm_v1e2.Entity;
using Softlib.Data;

namespace silppm_v1e2
{
    public class ProposalPengabdianDAO
    {
        private SqlConnection sqlConn;
        SqlCommand cmd;
        SqlDataReader reader;
        private Connection conn = new Connection();
        private DataTable dt = new DataTable();
        private DataSet dataset = new DataSet();
        private DataSet dataset1 = new DataSet();
        public ProposalPengabdianDAO() {
            sqlConn = conn.getConnection();
        }

        public DataSet getPenelitian4setReviewer(string tahun)
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
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENGABDIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK

                    ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                if (tahun != "-1")
                    query = query + " and TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK like '" + tahun + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataSet getHstPengabdian(string npp)
        {
            try
            {
                string query = @"SELECT silppm.TBL_PENGABDIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENGABDIAN.JUDUL_KEGIATAN JUDUL, 
                     silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, siatmax.MST_UNIT.NAMA_UNIT AS 'FAK', MST_UNIT_1.NAMA_UNIT AS 'PRODI', 
                     siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK, silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI AS STATUS, 
                     silppm.TBL_PENGABDIAN.DANA_PRIBADI, silppm.TBL_PENGABDIAN.DANA_EKSTERNAL, silppm.TBL_PENGABDIAN.DANA_KERJASAMA, 
                     silppm.TBL_PENGABDIAN.DANA_UAJY, silppm.TBL_PERSONIL_PENGABDIAN.NPP,
                     case when TBL_PERSONIL_PENGABDIAN.NPP = TBL_PENGABDIAN.NPP then 'ketua' else 'anggota' end Peran
                    FROM siatmax.MST_UNIT INNER JOIN
                     simka.MST_KARYAWAN ON siatmax.MST_UNIT.ID_UNIT = simka.MST_KARYAWAN.ID_UNIT INNER JOIN
                     siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                     silppm.TBL_PENGABDIAN INNER JOIN
                     silppm.TBL_PERSONIL_PENGABDIAN ON silppm.TBL_PENGABDIAN.ID_PROPOSAL = silppm.TBL_PERSONIL_PENGABDIAN.ID_PROPOSAL INNER JOIN
                     silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                     silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENGABDIAN.ID_STATUS INNER JOIN
                     siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENGABDIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK ON 
                     simka.MST_KARYAWAN.NPP = silppm.TBL_PERSONIL_PENGABDIAN.NPP
                      where TBL_PERSONIL_PENGABDIAN.NPP ='" + npp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        //dihilangkan
        public int getCountPerorangan()
        {
            try
            {
                string query = "select COUNT(id_proposal) from silppm.TBL_pengabdian where ID_PROPOSAL like 'PgO%'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id = int.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public int getCountKelompok()
        {
            try
            {
                string query = "select COUNT(id_proposal) from pengabdian where ID_PROPOSAL like 'PgK%'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id = int.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public int getMaxCount()
        {
            try
            {
                string query = "select MAX(id_proposal) from silppm.tbl_pengabdian";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id; int.TryParse(reader.GetValue(0).ToString(), out id);
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public int addProposal(PropPengab pen)
        {
            try
            {
                bool tmpdrop = false;
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = @"insert into silppm.TBL_PENGABDIAN (
[NPP],[ID_SUMBER],[REVIEWER1],[REVIEWER2],[JUDUL_KEGIATAN],[LANDASAN_PENELITIAN],
[JENIS_PENGABDIAN],[ANGGOTA1],[ANGGOTA1_KEAHLIAN],[ANGGOTA2],[ANGGOTA2_KEAHLIAN],[MITRA]
,[MITRA_KEAHLIAN],[LOKASI],
[JARAK_PT_LOKASI],[OUTPUT],[OUTCOME],[AWAL],[AKHIR],
[SASARAN],[SKS_KETUA],[SKS_ANGGOTA],
[ID_ROAD_MAP],[DANA_UAJY],[DANA_PRIBADI]
,[IS_DROPPED],[ID_STATUS],[IS_CHECKED],[IS_SETUJU_PRODI]
,[IS_SETUJU_DEKAN],[IS_SETUJU_LPPM],[NPP_REVIEWER],[DANA_SETUJU]
,[INSERT_DATE],[IP_ADDRESS],[USER_ID],[ID_SKIM],[ID_TEMA_UNIVERSITAS],
ID_TAHUN_ANGGARAN,NO_SEMESTER
)   OUTPUT  INSERTED.ID_PROPOSAL values 
(@npp,@id_sumber,@rev1,@rev2,@judul,@landasan,@jenis,@anggota1,@keahlian1,@anggota2,@keahlian2,@mitra,@keahlianmitra,@lokasi,
@jarak,@output,@outcome,@waktu,@durasi,@sasaran,@sksKetua,@sksAnggota,@unit,@danaUajy,@danaPribadi,
@IS_DROPPED,@status,@cekRev,1,1,NULL,NULL,0,@insertDate,@ip,@userid,@ID_SKIM,
@ID_TEMA_UNIVERSITAS,@ID_TAHUN_ANGGARAN,@NO_SEMESTER);";
               
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@npp", pen.Idkaryawan);
                cmd.Parameters.AddWithValue("@id_sumber", pen.Id_sumber);
                if (pen.Id_schedule == null)
                    cmd.Parameters.AddWithValue("@id_schedule", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@id_schedule", pen.Id_schedule);

                if (pen.NO_SEMESTER1 == null)
                    cmd.Parameters.AddWithValue("@NO_SEMESTER", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NO_SEMESTER", pen.NO_SEMESTER1);

                if (pen.ID_TAHUN_ANGGARAN1 == null)
                    cmd.Parameters.AddWithValue("@ID_TAHUN_ANGGARAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TAHUN_ANGGARAN", pen.ID_TAHUN_ANGGARAN1);

                cmd.Parameters.AddWithValue("@rev1", pen.Review1);
                cmd.Parameters.AddWithValue("@rev2", pen.Review2);
                cmd.Parameters.AddWithValue("@judul", pen.Judul);
                cmd.Parameters.AddWithValue("@landasan", pen.Landasan);
                cmd.Parameters.AddWithValue("@jenis", pen.Jenis);
                cmd.Parameters.AddWithValue("@anggota1", pen.Anggota1);
                cmd.Parameters.AddWithValue("@keahlian1", pen.Keahlian1);
                cmd.Parameters.AddWithValue("@anggota2", pen.Anggota2);
                cmd.Parameters.AddWithValue("@keahlian2", pen.Keahlian2);
                cmd.Parameters.AddWithValue("@mitra", pen.Mitra);
                cmd.Parameters.AddWithValue("@keahlianmitra", pen.Keahlianmitra);
                cmd.Parameters.AddWithValue("@lokasi", pen.Lokasi);
                cmd.Parameters.AddWithValue("@jarak", pen.JarakPTlokasi);
                cmd.Parameters.AddWithValue("@output", pen.Output);
                cmd.Parameters.AddWithValue("@outcome", pen.Outcome);
                cmd.Parameters.AddWithValue("@waktu", pen.Waktu);
                cmd.Parameters.AddWithValue("@durasi", pen.Durasi);
                cmd.Parameters.AddWithValue("@sasaran", pen.Sasaran);
                cmd.Parameters.AddWithValue("@sksKetua", pen.SksKetua);
                cmd.Parameters.AddWithValue("@sksAnggota", pen.SksAnggota);
                if(pen.SesuaiUNIT!=0)
                cmd.Parameters.AddWithValue("@unit", pen.SesuaiUNIT);
                else
                cmd.Parameters.AddWithValue("@unit", DBNull.Value);

                cmd.Parameters.AddWithValue("@danaUajy", pen.DanaUajy);
                cmd.Parameters.AddWithValue("@danaPribadi", pen.DanaPribadi);
                if (pen.ID_SKIM == null)
                    cmd.Parameters.AddWithValue("@ID_SKIM", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_SKIM", pen.ID_SKIM);
                if (pen.ID_TEMA_UNIVERSITAS == null)
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", pen.ID_TEMA_UNIVERSITAS);
                if (pen.Dokumen != null)
                {
                    cmd.Parameters.AddWithValue("@dokumen", pen.Dokumen);
                }else
                    cmd.Parameters.AddWithValue("@dokumen", DBNull.Value);

                cmd.Parameters.AddWithValue("@IS_DROPPED", tmpdrop);
                cmd.Parameters.AddWithValue("@status", pen.Status);
                cmd.Parameters.AddWithValue("@cekRev", tmpdrop);
                //@,@,@
                cmd.Parameters.AddWithValue("@insertDate", pen.Insert_date);
                cmd.Parameters.AddWithValue("@ip", pen.Ip_address);
                if (pen.Dokumen != null)
                {
                    cmd.Parameters.AddWithValue("@userid", pen.Userid);
                }
                else
                    cmd.Parameters.AddWithValue("@userid", DBNull.Value);
                //setelah lolos
                //cmd.Parameters.AddWithValue("@rekomen", pen.DanaRekomen);
                //cmd.Parameters.AddWithValue("@setuju", pen.DanaSetuju);
                //cmd.Parameters.AddWithValue("@laporan", pen.Laporan);
                //cmd.Parameters.AddWithValue("@islppm", pen.IsLPPM);
                //cmd.Parameters.AddWithValue("@ispustakawan", pen.IsPustakawan);


                int ID_PROPOSAL = Int32.Parse(cmd.ExecuteScalar().ToString());

                string insertRAB = @"insert into silppm.TBL_RAB_PENGABDIAN 
                    ([ID_PROPOSAL],[ID_PENGELUARAN_RAB],JUMLAH_DANA,PERSENTASE)
                    SELECT  @ID_PROPOSAL ,[ID_PENGELUARAN_RAB], 0 JUMLAH_DANA,0 FROM  silppm.REF_PENGELUARAN_RAB";

                cmd = new SqlCommand(insertRAB, sqlConn); 

                cmd.Parameters.AddWithValue("@ID_PROPOSAL", ID_PROPOSAL);
                cmd.ExecuteScalar();

                insertAnggotaPENGABDIAN(ID_PROPOSAL.ToString(), pen.Idkaryawan);
                return ID_PROPOSAL;
            }
            catch (Exception e)
            {

                return 0;
            }
            finally
            {
                sqlConn.Close();
            }

        }

        // insert detail RAB
        public bool insertRAB_PENGABDIAN(DTL_RAB_PENGABDIAN tbl)
        {
            string query = @"INSERT INTO [silppm].[DTL_RAB_PENGABDIAN]
            ([ID_RAB_PENGABDIAN],[JUMLAH_DANA],[JUMLAH],[SATUAN]
            ,[HARGA_SATUAN],[KETERANGAN])
            VALUES (@ID_RAB_PENGABDIAN,@JUMLAH_DANA,@JUMLAH
            ,@SATUAN,@HARGA_SATUAN,@KETERANGAN)";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "@ID_RAB_PENGABDIAN", tbl.ID_RAB_PENGABDIAN);
                dbManager.AddParameters(1, "@JUMLAH", tbl.JUMLAH);
                dbManager.AddParameters(2, "@JUMLAH_DANA", tbl.JUMLAH_DANA);
                dbManager.AddParameters(3, "@KETERANGAN", tbl.KETERANGAN);
                dbManager.AddParameters(4, "@SATUAN", tbl.SATUAN);
                dbManager.AddParameters(5, "@HARGA_SATUAN", tbl.HARGA_SATUAN);

                dbManager.ExecuteNonQuery(CommandType.Text, query);
                updateTotalRAB(tbl.ID_RAB_PENGABDIAN.Value);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        // insert detail RAB
        public bool updateTotalRAB(int id)
        {
            string query = @"update silppm.TBL_RAB_PENGABDIAN set JUMLAH_DANA =(
                SELECT SUM(JUMLAH_DANA) 
                FROM silppm.DTL_RAB_PENGABDIAN
                where ID_RAB_PENGABDIAN=@ID_RAB_PENGABDIAN)
                where ID_RAB_PENGABDIAN=@ID_RAB_PENGABDIAN";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_RAB_PENGABDIAN", id);

                dbManager.ExecuteNonQuery(CommandType.Text, query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        // update detail RAB
        public bool updatetRAB_PENGABDIAN(DTL_RAB_PENGABDIAN tbl)
        {
            string query = @"update [silppm].[DTL_RAB_PENGABDIAN]
            set [JUMLAH_DANA]=@JUMLAH_DANA,
                [JUMLAH]=@JUMLAH,
                [SATUAN]=@SATUAN,
                [HARGA_SATUAN]=@HARGA_SATUAN,
                [KETERANGAN]=@KETERANGAN
            where ID_DTL_RAB_PENGABDIAN=@ID_DTL_RAB_PENGABDIAN";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(7);
                dbManager.AddParameters(0, "@ID_RAB_PENGABDIAN", tbl.ID_RAB_PENGABDIAN);
                dbManager.AddParameters(1, "@JUMLAH", tbl.JUMLAH);
                dbManager.AddParameters(2, "@JUMLAH_DANA", tbl.JUMLAH_DANA);
                dbManager.AddParameters(3, "@KETERANGAN", tbl.KETERANGAN);
                dbManager.AddParameters(4, "@SATUAN", tbl.SATUAN);
                dbManager.AddParameters(5, "@HARGA_SATUAN", tbl.HARGA_SATUAN);
                dbManager.AddParameters(6, "@ID_DTL_RAB_PENGABDIAN", tbl.ID_DTL_RAB_PENGABDIAN);

                dbManager.ExecuteNonQuery(CommandType.Text, query);
                updateTotalRAB(tbl.ID_RAB_PENGABDIAN.Value);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        // insert anggota uajy
        public bool insertAnggotaPENGABDIAN(string idprop, string npp)
        {
            string query = @"insert into silppm.TBL_PERSONIL_PENGABDIAN([NPP]
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
            ,[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS],@ID_PROPOSAL 
             FROM  simka.MST_KARYAWAN where [NPP] = @npp";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_PROPOSAL", idprop);
                dbManager.AddParameters(1, "@npp", npp);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        // insert anggota uajy
        public bool insertAnggotaNonUAJY(string idprop, DataRow dr)
        {
            string query = @"insert into silppm.TBL_PERSONIL_PENGABDIAN(
            NPP,[NAMA_LENGKAP_GELAR],[EMAIL],[NO_TELPON_RUMAH]
            ,[NO_TELPON_HP],[NPWP],[NIP_PNS],[NIDN]
            ,[ALAMAT_KOTA],[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS]
            ,[ID_PROPOSAL] )
            SELECT @NIP_PNS, @NAMA_LENGKAP_GELAR,@EMAIL,@NO_TELPON_RUMAH
            ,@NO_TELPON_HP,@NPWP,@NIP_PNS,@NIDN,@ALAMAT_KOTA
            ,@ALAMAT,@ALAMAT_PROVINSI,@ALAMAT_KODEPOS,@ID_PROPOSAL";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(12);
                dbManager.AddParameters(0, "@ID_PROPOSAL", dr["ID_PROPOSAL"]);
                dbManager.AddParameters(1, "@NAMA_LENGKAP_GELAR", dr["NAMA_LENGKAP_GELAR"]);
                dbManager.AddParameters(2, "@EMAIL", dr["EMAIL"]);
                dbManager.AddParameters(3, "@NO_TELPON_RUMAH", dr["NO_TELPON_RUMAH"]);
                dbManager.AddParameters(4, "@NO_TELPON_HP", dr["NO_TELPON_HP"]);
                dbManager.AddParameters(5, "@NPWP", dr["NPWP"]);
                dbManager.AddParameters(6, "@NIP_PNS", dr["NIP_PNS"]);
                dbManager.AddParameters(7, "@NIDN", dr["NIDN"]);
                dbManager.AddParameters(8, "@ALAMAT_KOTA", dr["ALAMAT_KOTA"]);
                dbManager.AddParameters(9, "@ALAMAT", dr["ALAMAT"]);
                dbManager.AddParameters(10, "@ALAMAT_PROVINSI", dr["ALAMAT_PROVINSI"]);
                dbManager.AddParameters(11, "@ALAMAT_KODEPOS", dr["ALAMAT_KODEPOS"]);
                dbManager.ExecuteNonQuery(CommandType.Text, query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        public DataTable getAnggotaPENGABDIAN(string idprop)
        {
            string query = @" SELECT [ID_PERSONIL_PENGABDIAN],[NPP],[NAMA_LENGKAP_GELAR]
            ,[TEMPAT_LAHIR],[TGL_LAHIR],[JNS_KEL],[EMAIL],[ID_REF_FUNGSIONAL]
            ,[ID_UNIT],[ID_UNIT_AKADEMIK],[ID_REF_GOLONGAN],[ID_REF_JBTN_AKADEMIK]
            ,[NO_TELPON_RUMAH],[NO_TELPON_HP],[WARGANEGARA],[NPWP],[NIP_PNS]
            ,[NIDN],[ALAMAT_KOTA],[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS]
            ,[ID_PROPOSAL],[INSTITUSI_ASAL],[BIDANG_KEAHLIAN_PENGABDIAN]
              FROM [silppm].[TBL_PERSONIL_PENGABDIAN]
                where [ID_PROPOSAL] =@ID_PROPOSAL";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_PROPOSAL", idprop);
                dt = dbManager.ExecuteDataTable(CommandType.Text, query);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }
        public int updateProposal(PropPengab pen)
        {
            try
            {
                bool tmpdrop = false;
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = @"update silppm.TBL_PENGABDIAN 
set [],[NPP],[ID_SUMBER],[ID_TAHUN_ANGGARAN],[REVIEWER1],[REVIEWER2],[JUDUL_KEGIATAN],[LANDASAN_PENELITIAN],
[JENIS_PENGABDIAN],[ANGGOTA1],[ANGGOTA1_KEAHLIAN],[ANGGOTA2],[ANGGOTA2_KEAHLIAN],[MITRA]
,[MITRA_KEAHLIAN],[LOKASI],
[JARAK_PT_LOKASI],[OUTPUT],[OUTCOME],[AWAL],[AKHIR],
[SASARAN],[SKS_KETUA],[SKS_ANGGOTA],
[ID_ROAD_MAP],[DANA_UAJY],[DANA_PRIBADI]
,[IS_DROPPED],[ID_STATUS],[IS_CHECKED],[IS_SETUJU_PRODI]
,[IS_SETUJU_DEKAN],[IS_SETUJU_LPPM],[NPP_REVIEWER],[DANA_SETUJU]
,[INSERT_DATE],[IP_ADDRESS],[USER_ID],[ID_SKIM],[ID_TEMA_UNIVERSITAS])   OUTPUT  INSERTED.ID_PROPOSAL values (@ID_Prop,@npp,@id_sumber,@id_schedule,
@rev1,@rev2,@judul,@landasan,@jenis,@anggota1,@keahlian1,@anggota2,@keahlian2,@mitra,@keahlianmitra,@lokasi,
@jarak,@output,@outcome,@waktu,@durasi,@sasaran,@sksKetua,@sksAnggota,@unit,@danaUajy,@danaPribadi,
@IS_DROPPED,@status,@cekRev,NULL,NULL,NULL,NULL,0,@insertDate,@ip,@userid,@ID_SKIM,@ID_TEMA_UNIVERSITAS)
where ID_PROPOSAL =@ID_PROPOSAL;";

                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", pen.Id_proposal);
                cmd.Parameters.AddWithValue("@npp", pen.Idkaryawan);
                cmd.Parameters.AddWithValue("@id_sumber", pen.Id_sumber);
                cmd.Parameters.AddWithValue("@id_schedule", pen.Id_schedule);
                cmd.Parameters.AddWithValue("@rev1", pen.Review1);
                cmd.Parameters.AddWithValue("@rev2", pen.Review2);
                cmd.Parameters.AddWithValue("@judul", pen.Judul);
                cmd.Parameters.AddWithValue("@landasan", pen.Landasan);
                cmd.Parameters.AddWithValue("@jenis", pen.Jenis);
                cmd.Parameters.AddWithValue("@anggota1", pen.Anggota1);
                cmd.Parameters.AddWithValue("@keahlian1", pen.Keahlian1);
                cmd.Parameters.AddWithValue("@anggota2", pen.Anggota2);
                cmd.Parameters.AddWithValue("@keahlian2", pen.Keahlian2);
                cmd.Parameters.AddWithValue("@mitra", pen.Mitra);
                cmd.Parameters.AddWithValue("@keahlianmitra", pen.Keahlianmitra);
                cmd.Parameters.AddWithValue("@lokasi", pen.Lokasi);
                cmd.Parameters.AddWithValue("@jarak", pen.JarakPTlokasi);
                cmd.Parameters.AddWithValue("@output", pen.Output);
                cmd.Parameters.AddWithValue("@outcome", pen.Outcome);
                cmd.Parameters.AddWithValue("@waktu", pen.Waktu);
                cmd.Parameters.AddWithValue("@durasi", pen.Durasi);
                cmd.Parameters.AddWithValue("@sasaran", pen.Sasaran);
                cmd.Parameters.AddWithValue("@sksKetua", pen.SksKetua);
                cmd.Parameters.AddWithValue("@sksAnggota", pen.SksAnggota);
                cmd.Parameters.AddWithValue("@unit", pen.SesuaiUNIT);
                cmd.Parameters.AddWithValue("@danaUajy", pen.DanaUajy);
                cmd.Parameters.AddWithValue("@danaPribadi", pen.DanaPribadi);
                if (pen.ID_SKIM == null)
                    cmd.Parameters.AddWithValue("@ID_SKIM", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_SKIM", pen.ID_SKIM);
                if (pen.ID_TEMA_UNIVERSITAS == null)
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", pen.ID_TEMA_UNIVERSITAS);
                if (pen.Dokumen != null)
                {
                    cmd.Parameters.AddWithValue("@dokumen", pen.Dokumen);
                }
                else
                    cmd.Parameters.AddWithValue("@dokumen", DBNull.Value);

                cmd.Parameters.AddWithValue("@IS_DROPPED", tmpdrop);
                cmd.Parameters.AddWithValue("@status", pen.Status);
                cmd.Parameters.AddWithValue("@cekRev", tmpdrop);
                //@,@,@
                cmd.Parameters.AddWithValue("@insertDate", pen.Insert_date);
                cmd.Parameters.AddWithValue("@ip", pen.Ip_address);
                if (pen.Dokumen != null)
                {
                    cmd.Parameters.AddWithValue("@userid", pen.Userid);
                }
                else
                    cmd.Parameters.AddWithValue("@userid", DBNull.Value);
                //setelah lolos
                //cmd.Parameters.AddWithValue("@rekomen", pen.DanaRekomen);
                //cmd.Parameters.AddWithValue("@setuju", pen.DanaSetuju);
                //cmd.Parameters.AddWithValue("@laporan", pen.Laporan);
                //cmd.Parameters.AddWithValue("@islppm", pen.IsLPPM);
                //cmd.Parameters.AddWithValue("@ispustakawan", pen.IsPustakawan);


                int ID_PROPOSAL = Int32.Parse(cmd.ExecuteScalar().ToString());


                return ID_PROPOSAL;
            }
            catch (Exception e)
            {

                return 0;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool EditProposal(PropPengab pen, string ID)
        {
            try
            {
                bool tmpdrop = false;
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = @"Update silppm.TBL_PENGABDIAN Set Judul_Kegiatan=@judul,
Landasan_Penelitian=@landasan,JENIS_PENGABDIAN=@jenis,ANGGOTA1=@anggota1,
ANGGOTA1_KEAHLIAN=@keahlian1,ANGGOTA2=@anggota2,ANGGOTA2_KEAHLIAN=@keahlian2,
MITRA=@mitra,MITRA_KEAHLIAN=@keahlianmitra,LOKASI=@lokasi,JARAK_PT_LOKASI=@jarak,
OUTPUT=@output,OUTCOME=@outcome,AWAL=@waktu,AKHIR=@durasi,SASARAN=@sasaran,
SKS_KETUA=@sksKetua,SKS_ANGGOTA=@sksAnggota,ID_ROAD_MAP=@unit,DANA_UAJY=@danaUajy,
DANA_PRIBADI=@danaPribadi,DOKUMEN=@dokumen,IS_DROPPED=@IS_DROPPED,ID_STATUS=@status,
IS_CHECKED=@cekRev,ID_TAHUN_ANGGARAN=@ID_TAHUN_ANGGARAN,ID_SKIM=@ID_SKIM,ID_TEMA_UNIVERSITAS=@ID_TEMA_UNIVERSITAS,
NO_SEMESTER=@NO_SEMESTER, DANA_EKSTERNAL=@DANA_EKSTERNAL,
DANA_KERJASAMA=@DANA_KERJASAMA
where ID_PROPOSAL=@id";//,@rekomen,@setuju,@laporan,@islppm,@ispustakawan);";


                if (pen.Dokumen== null)
                    query = query.Replace(",DOKUMEN=@dokumen", " ");
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@id", ID);
                if (pen.ID_SKIM == null)
                    cmd.Parameters.AddWithValue("@ID_SKIM", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_SKIM", pen.ID_SKIM);
                if (pen.ID_TEMA_UNIVERSITAS == null)
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", pen.ID_TEMA_UNIVERSITAS);
                
                cmd.Parameters.AddWithValue("@ID_TAHUN_ANGGARAN", pen.ID_TAHUN_ANGGARAN1);
                cmd.Parameters.AddWithValue("@NO_SEMESTER", pen.NO_SEMESTER1);
                cmd.Parameters.AddWithValue("@DANA_EKSTERNAL", pen.DANA_EKSTERNAL1);
                cmd.Parameters.AddWithValue("@DANA_KERJASAMA", pen.DANA_KERJASAMA1);                
                cmd.Parameters.AddWithValue("@judul", pen.Judul);
                cmd.Parameters.AddWithValue("@landasan", pen.Landasan);
                cmd.Parameters.AddWithValue("@jenis", pen.Jenis);
                cmd.Parameters.AddWithValue("@anggota1", pen.Anggota1);
                cmd.Parameters.AddWithValue("@keahlian1", pen.Keahlian1);
                cmd.Parameters.AddWithValue("@anggota2", pen.Anggota2);
                cmd.Parameters.AddWithValue("@keahlian2", pen.Keahlian2);
                cmd.Parameters.AddWithValue("@mitra", pen.Mitra);
                cmd.Parameters.AddWithValue("@keahlianmitra", pen.Keahlianmitra);
                cmd.Parameters.AddWithValue("@lokasi", pen.Lokasi);
                cmd.Parameters.AddWithValue("@jarak", pen.JarakPTlokasi);
                cmd.Parameters.AddWithValue("@output", pen.Output);
                cmd.Parameters.AddWithValue("@outcome", pen.Outcome);
                cmd.Parameters.AddWithValue("@waktu", pen.Waktu);
                cmd.Parameters.AddWithValue("@durasi", pen.Durasi);
                cmd.Parameters.AddWithValue("@sasaran", pen.Sasaran);
                cmd.Parameters.AddWithValue("@sksKetua", pen.SksKetua);
                cmd.Parameters.AddWithValue("@sksAnggota", pen.SksAnggota);
                cmd.Parameters.AddWithValue("@unit", pen.SesuaiUNIT);
                cmd.Parameters.AddWithValue("@danaUajy", pen.DanaUajy);
                cmd.Parameters.AddWithValue("@danaPribadi", pen.DanaPribadi);
                if (pen.Dokumen != null)
                    cmd.Parameters.AddWithValue("@dokumen", pen.Dokumen); 
                cmd.Parameters.AddWithValue("@IS_DROPPED", tmpdrop);
                cmd.Parameters.AddWithValue("@status", pen.Status);
                cmd.Parameters.AddWithValue("@cekRev", tmpdrop);
                //@,@,@
                //cmd.Parameters.AddWithValue("@insertDate", pen.Insert_date);
                //cmd.Parameters.AddWithValue("@ip", pen.Ip_address);
                //cmd.Parameters.AddWithValue("@userid", pen.Userid);
                //setelah lolos
                //cmd.Parameters.AddWithValue("@rekomen", pen.DanaRekomen);
                //cmd.Parameters.AddWithValue("@setuju", pen.DanaSetuju);
                //cmd.Parameters.AddWithValue("@laporan", pen.Laporan);
                //cmd.Parameters.AddWithValue("@islppm", pen.IsLPPM);
                //cmd.Parameters.AddWithValue("@ispustakawan", pen.IsPustakawan);


                cmd.ExecuteNonQuery();


                string insertRAB = @"if not exists (SELECT [ID_RAB_PENGABDIAN]
                      FROM [SIATMAX].[silppm].[TBL_RAB_PENGABDIAN]
                    where [ID_PROPOSAL] =1)
                    insert into silppm.TBL_RAB_PENGABDIAN 
                   ([ID_PROPOSAL],[ID_PENGELUARAN_RAB],JUMLAH_DANA,PERSENTASE)
                    SELECT  @ID_PROPOSAL ,[ID_PENGELUARAN_RAB], 0 JUMLAH_DANA,0 FROM  silppm.REF_PENGELUARAN_RAB";

                cmd = new SqlCommand(insertRAB, sqlConn);

                cmd.Parameters.AddWithValue("@ID_PROPOSAL", ID);
                cmd.ExecuteScalar();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        // insert pct RAB
        public bool updatePctRAB(int id, decimal PERSENTASE)
        {
            string query = @"update silppm.TBL_RAB_PENGABDIAN set PERSENTASE =@PERSENTASE
                where ID_RAB_PENGABDIAN=@ID_RAB_PENGABDIAN";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_RAB_PENGABDIAN", id);
                dbManager.AddParameters(1, "@PERSENTASE", PERSENTASE);

                dbManager.ExecuteNonQuery(CommandType.Text, query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }
       
        //Get RAB
        public DataTable GetRAB(string id_prop)
        {
            string select = @"SELECT    ID_RAB_PENGABDIAN, silppm.TBL_RAB_PENGABDIAN.ID_PROPOSAL, 
                    silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB, silppm.REF_PENGELUARAN_RAB.DESKRIPSI, silppm.TBL_RAB_PENGABDIAN.JUMLAH_DANA, 
                    silppm.TBL_RAB_PENGABDIAN.PERSENTASE,[MIN_PCT],[MAX_PCT]
                    FROM silppm.REF_PENGELUARAN_RAB INNER JOIN
                    silppm.TBL_RAB_PENGABDIAN ON silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB = silppm.TBL_RAB_PENGABDIAN.ID_PENGELUARAN_RAB
                    WHERE (ID_PROPOSAL = @ID_PROPOSAL)";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_PROPOSAL", id_prop);
                dt = dbManager.ExecuteDataTable(CommandType.Text, select);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }
        //Get detail RAB
        public DataTable GetDetailRAB(string id_rab)
        {
            string select = @"SELECT  ID_RAB_PENGABDIAN, ID_DTL_RAB_PENGABDIAN, JUMLAH_DANA, JUMLAH, SATUAN, HARGA_SATUAN, KETERANGAN
            FROM silppm.DTL_RAB_PENGABDIAN
            WHERE (ID_RAB_PENGABDIAN = @ID_RAB_PENGABDIAN)";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_RAB_PENGABDIAN", id_rab);
                dt = dbManager.ExecuteDataTable(CommandType.Text, select);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        //Get RAB
        public decimal GetSumRAB(string id_prop)
        {
            string select = @"SELECT SUM(silppm.DTL_RAB_PENGABDIAN.JUMLAH_DANA) AS JUMLAH_DANA
                    FROM silppm.REF_PENGELUARAN_RAB INNER JOIN
                    silppm.TBL_RAB_PENGABDIAN ON silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB = silppm.TBL_RAB_PENGABDIAN.ID_PENGELUARAN_RAB INNER JOIN
                    silppm.DTL_RAB_PENGABDIAN ON silppm.TBL_RAB_PENGABDIAN.ID_RAB_PENGABDIAN = silppm.DTL_RAB_PENGABDIAN.ID_RAB_PENGABDIAN
                    GROUP BY silppm.TBL_RAB_PENGABDIAN.ID_PROPOSAL
                    HAVING (silppm.TBL_RAB_PENGABDIAN.ID_PROPOSAL = @ID_PROPOSAL)";

            decimal dt = new decimal();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_PROPOSAL", id_prop);
                dt = decimal.Parse(dbManager.ExecuteScalar(CommandType.Text, select).ToString());

                return dt;
            }
            catch (Exception ex)
            {
                return 0;
                //throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        
        public string cekEdit(string id_prop)
        {
            try
            {
                string query = "select d.DESKRIPSI from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN d on d.ID_STATUS_PENELITIAN=p.ID_STATUS where id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataTable getPengabdian(string idprop)
        {
            string query = @"SELECT [ID_PROPOSAL],NO_SEMESTER
,[NPP],[ID_SUMBER],[ID_TAHUN_ANGGARAN],[REVIEWER1],[REVIEWER2]
,[JUDUL_KEGIATAN],[LANDASAN_PENELITIAN],[JENIS_PENGABDIAN],[ANGGOTA1]
,[ANGGOTA1_KEAHLIAN],[ANGGOTA2],[ANGGOTA2_KEAHLIAN],[MITRA]
,[MITRA_KEAHLIAN],[LOKASI],[JARAK_PT_LOKASI],[OUTPUT],[OUTCOME]
,[AWAL],[AKHIR],[SASARAN],[SKS_KETUA],[SKS_ANGGOTA],[ID_ROAD_MAP]
,[DANA_UAJY],[DANA_PRIBADI],[DOKUMEN],[IS_DROPPED],[ID_STATUS]
,[IS_CHECKED],[IS_SETUJU_PRODI],[IS_SETUJU_DEKAN],[IS_SETUJU_LPPM]
,[NPP_REVIEWER],[DANA_SETUJU],[INSERT_DATE],[IP_ADDRESS]
,[USER_ID],[ID_SKIM],[ID_TEMA_UNIVERSITAS],DANA_KERJASAMA,DANA_EKSTERNAL
  FROM [silppm].[TBL_PENGABDIAN]
                where [ID_PROPOSAL] =@ID_PROPOSAL";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_PROPOSAL", idprop);
                dt = dbManager.ExecuteDataTable(CommandType.Text, query);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbManager.Dispose();
            }
        }

        public DataSet getAllDataProposal(string npp)
        {
            try
            {
                string query = "select p.id_proposal,p.Judul_kegiatan,d.DESKRIPSI,p.jenis_pengabdian,p.lokasi,p.AKHIR,p.dana_uajy from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN d on d.ID_STATUS_PENELITIAN=p.ID_STATUS where IS_SETUJU_PRODI=1 and IS_SETUJU_DEKAN=1 and IS_DROPPED=0 and IS_CHECKED=0 and p.NPP_REVIEWER ='"+npp+"' and REVIEWER1='kosong';";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getDataProposalByIDKaryawan(string id)
        {
            try
            {
                string query = "SELECT *  FROM silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS where NPP='"+id+"' and IS_DROPPED =0;";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        //untuk profile
        public DataSet getDataLOLOSByIDKaryawan(string id)
        {
            try
            {
                string query = "SELECT *  FROM silppm.TBL_PENGABDIAN_LOLOS p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS where NPP='" + id + "' and IS_DROPPED =0;";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        //untuk reviewer
        public DataSet getDataLolosSemua()
        {
            try
            {
                string query = "select id_proposal,judul_kegiatan from silppm.TBL_PENGABDIAN_LOLOS ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getDataProposalByIDProposal(string id)
        {
            try
            {
                string query = "SELECT *  FROM silppm.TBL_PENGABDIAN where id_proposal='" + id + "' and IS_DROPPED =0;";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public string getusernameByIDProposal(string id)
        {
            try
            {
                string query = "select d.username from silppm.TBL_PENGABDIAN p join simka.mst_karyawan d on d.NPP=p.NPP where p.ID_PROPOSAL = '" + id + "' ";

                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                    //return reader.GetInt32(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public byte[] getPropsalPenelitian(string index)
        {
            try
            {
                string query = "select dokumen from silppm.TBL_PENGABDIAN where id_proposal= '" + index + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return (byte[])reader.GetValue(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public string getStatusPenelitianByID(string id)
        {
            try
            {
                string query = "select d.DESKRIPSI from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN d on d.ID_STATUS_PENELITIAN=p.ID_STATUS where ID_PROPOSAL = '"+id+"' and IS_DROPPED=0";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                    //return reader.GetInt32(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public bool ReviewProposalPenelitian(string id, string reviewer)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENGABDIAN set REVIEWER1=@ID_Rev where ID_PROPOSAL=@ID_Prop;";
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", id);
                cmd.Parameters.AddWithValue("@ID_Rev", reviewer);



                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool ReviewProposalPenelitian2(string id, string reviewer)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENGABDIAN set REVIEWER2=@ID_Rev where ID_PROPOSAL=@ID_Prop;";
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", id);
                cmd.Parameters.AddWithValue("@ID_Rev", reviewer);



                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public int getMaxctRev(string id, string id_rev)
        {
            try
            {
                string query = "select MAX(COUNT_REVISI) from silppm.TBL_NILAI_REVIEW_PENGABDIAN where id_proposal = '" + id + "' and id_reviewer = '" + id_rev + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int count = int.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return count;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool addNilaiPengabdian(string id, string rev, int ctRev, double N1Field1, double N1Field2, double N1Field3, double N1Field4, double N1Field5, double N1Field6, string N1Jusifikasi1, string N1Jusifikasi2, string N1Jusifikasi3, string N1Jusifikasi4, string N1Jusifikasi5, string N1Jusifikasi6,  string N2Field1, string N2Field2, string N2Field3, string N2Field4, string N2Field5, string Kesimpulan, int anggaran, string anggaranHuruf, string Keunikan)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_NILAI_REVIEW_PENGABDIAN values ('" + id + "','" + rev + "'," + ctRev + "," + N1Field1 + "," + N1Field2 + "," + N1Field3 + "," + N1Field4 + "," + N1Field5 + "," + N1Field6 + ",'" + N1Jusifikasi1 + "','" + N1Jusifikasi2 + "','" + N1Jusifikasi3 + "','" + N1Jusifikasi4 + "','" + N1Jusifikasi5 + "','" + N1Jusifikasi6 + "','" + N2Field1 + "','" + N2Field2 + "','" + N2Field3 + "','" + N2Field4 + "','" + N2Field5 + "','" + Kesimpulan + "'," + anggaran + ",'" + anggaranHuruf + "','" + Keunikan + "');";
                cmd = new SqlCommand(query, sqlConn);


                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool UpdateStatusMenungguReview2(string id)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENGABDIAN set STATUS='Menunggu Review 2' where ID_PROPOSAL=@ID_Prop;";

                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", id);




                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool updateStatusDITOLAK(int cek, string id_prop)
        {
            try
            {
                string query = "update TBL_Pengabdian set IS_CHECKED=" + cek + ",ID_STATUS_PENELITIAN=11,IS_DROPPED=1 where id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public bool addProposalLolos(string id, int rekomen, DateTime insDate, string ipaddress, string userid)
        {
            try
            {
                //int tmpcount = getMaxCount() + 1;

                //int droptmp = 0;
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_PENGABDIAN_LOLOS select [ID_PROPOSAL],[NPP],[ID_SUMBER],[ID_TAHUN_ANGGARAN],[REVIEWER1],[REVIEWER2],[JUDUL_KEGIATAN],[LANDASAN_PENELITIAN],[JENIS_PENGABDIAN],[ANGGOTA1],[ANGGOTA1_KEAHLIAN],[ANGGOTA2],[ANGGOTA2_KEAHLIAN],[MITRA],[MITRA_KEAHLIAN],[LOKASI],[JARAK_PT_LOKASI],[OUTPUT],[OUTCOME],[AWAL],[AKHIR],[SASARAN],[SKS_KETUA],[SKS_ANGGOTA],[ID_ROAD_MAP],[DANA_UAJY],[DANA_PRIBADI],[DOKUMEN],[IS_DROPPED],[ID_STATUS],[IS_CHECKED],[IS_SETUJU_PRODI],[IS_SETUJU_DEKAN],[IS_SETUJU_LPPM],[NPP_REVIEWER],[DANA_SETUJU]," + rekomen + ",NULL,NULL,NULL,@insDate,@ipaddress,@userid from silppm.TBL_PENGABDIAN where ID_PROPOSAL ='" + id + "'";
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@insDate", insDate);
                cmd.Parameters.AddWithValue("@ipaddress", ipaddress);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public void HideProposal(string id)
        {
            try
            {
                string query = "update silppm.TBL_PENGABDIAN set IS_DROPPED = 1 where id_proposal ='" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool UpdateStatusDiterima(string id)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENGABDIAN set ID_STATUS=14 where ID_PROPOSAL=@ID_Prop;";
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", id);




                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool valReview(string id, string rev)
        {
            try
            {
                string query = "select id_proposal,id_reviewer from silppm.TBL_NILAI_REVIEW_PENGABDIAN where id_proposal='" + id + "' and id_reviewer='" + rev + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public string getIDREV1ByID(string id)
        {
            try
            {
                string query = "select REVIEWER1 from silppm.TBL_PENGABDIAN where id_proposal = '" + id + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public string getIDREV2ByID(string id)
        {
            try
            {
                string query = "select REVIEWER2 from silppm.TBL_PENGABDIAN where id_proposal = '" + id + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public DataSet getDataReview(string id,string rev, int ct)
        {
            try
            {
                string query = "select * from silppm.TBL_NILAI_REVIEW_PENGABDIAN where ID_PROPOSAL= '" + id + "' and id_reviewer= '" + rev + "' and count_REVISI= " + ct + "";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool UpdateLaporan(string id, object laporan)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENGABDIAN_LOLOS set laporan=@laporan where ID_PROPOSAL=@ID_Prop;";
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", id);
                cmd.Parameters.AddWithValue("@laporan", laporan);



                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        //cek cek cek
        public bool CekLaporanTahap1(string id)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "select laporan1 from silppm.TBL_PENGABDIAN_LOLOS where ID_PROPOSAL='" + id + "'";
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string tmp = reader.GetValue(0).ToString();
                    if (tmp != "")
                        return true;
                    else return false;
                }
                else
                    return false;



            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool CekLaporan(string id)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "select laporan from silppm.TBL_PENGABDIAN_LOLOS where ID_PROPOSAL='" + id + "'";
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string tmp = reader.GetValue(0).ToString();
                    if (tmp != "")
                        return true;
                    else return false;
                }
                else
                    return false;



            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool cekPerpusSetuju(string idprop)
        {
            try
            {
                string query = "select IS_SETUJU_PUSTAKAWAN from silppm.TBL_PENGABDIAN_LOLOS where id_proposal = '" + idprop + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetValue(0).ToString();
                    if (id == "True")
                        return true;
                    else return false;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public bool cekStatusRevisi(string id_prop)
        {
            try
            {
                string query = "select IS_CHECKED from silppm.TBL_PENGABDIAN where id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return true;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public byte[] getMONEVPengabdian(string index,int numb)
        {
            try
            {
                string query = "select KETERANGAN from silppm.TBL_LAP_MONEV_pengabdian where id_proposal= '" + index + "' and no_update = " + numb + ";";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return (byte[])reader.GetValue(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public int getNoUpdate(string numb)
        {
            try
            {
                string query = "select no_update from silppm.tbl_monev_penelitian where id_proposal=" + numb + "";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id = int.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        //untuk prodi
        public string getNamaTemaPengabdian(string id)
        {
            try
            {
                string query = "select d.DESKRIPSI from silppm.TBL_Pengabdian p join silppm.REF_ROAD_MAP_PENGABDIAN d on d.ID_ROAD_MAP_PENGABDIAN=p.ID_ROAD_MAP where p.ID_PROPOSAL='" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }//udah

        public DataSet getProdiTemaPengabdian(int id)
        {
            try
            {
                string query = "select ID_ROAD_MAP_PENGABDIAN,DESKRIPSI from silppm.REF_ROAD_MAP_PENGABDIAN where ID_UNIT_AKADEMIK=" + id + " and is_deleted=0";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                adapter.Fill(dataset);
                return dataset;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public int getMaxIDTema()
        {
            try
            {
                string query = "select COUNT(*) from silppm.ref_ROAD_MAP_pengabdian";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id = int.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataTable getTemaPengabdian(int idprodi)
        {
            try
            {
                string query = "select ID_ROAD_MAP_PENGABDIAN,DESKRIPSI from silppm.REF_ROAD_MAP_PENGABDIAN where IS_DELETED=0 and ID_UNIT_AKADEMIK =" + idprodi + "";
                //string query = "select distinct NAMA from Simka.MST_KARYAWAN ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool addTema(int id_prodi, string detail)
        {
            int cek = getMaxIDTema() + 1;
            try
            {
                string query = "insert into silppm.ref_ROAD_MAP_pengabdian values(" + cek + "," + id_prodi + ",'" + detail + "',0) ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool hapusTema(string id_key)
        {
            
            try
            {
                string query = "update silppm.ref_ROAD_MAP_pengabdian set is_deleted=1 where id_road_map_pengabdian='" + id_key + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getListLaporanProdi(int idProdi)
        {
            try
            {
                string query = "select p.id_proposal,p.Judul_kegiatan,d.nama, CASE WHEN p.IS_SETUJU_PRODI is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENGABDIAN p join simka.Mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_PRODI is NULL AND IS_DROPPED=0 and d.ID_UNIT_AKADEMIK=" + idProdi + "";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getProdiDataProposalByIDProposal(string id)
        {
            try
            {
                string query = "select * from silppm.TBL_PENGABDIAN  where id_proposal='" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public string getNamaDosenbyIDProposal_Penelitian(string uname)
        {
            try
            {
                string query = "select d.NAMA from silppm.TBL_PENGABDIAN p join simka.Mst_karyawan d on d.NPP=p.NPP where ID_PROPOSAL = '" + uname + "' ";
                //string query = "select NPP from SIMKA.MST_KARYAWAN where NAMA = '" + uname + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                    //return reader.GetInt32(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public bool updateProdi(int cek, string id_prop, int status)
        {
            try
            {
                string query = "update silppm.TBL_PENGABDIAN set IS_SETUJU_PRODI=" + cek + ",ID_STATUS='" + status + "' where id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool updateBiayaProdi(int dana, string id_prop)
        {
            try
            {
                string query = "update silppm.TBL_PENGABDIAN set DANA_SETUJU =" + dana + " where id_proposal ='" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }//sampek sini dulu
        public string getjudulByID(string id)
        {
            try
            {
                string query = "select judul_kegiatan from silppm.TBL_PENGABDIAN where id_proposal = '" + id + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public string getjenisByID(string id)
        {
            try
            {
                string query = "select JENIS_PENGABDIAN from silppm.TBL_PENGABDIAN where id_proposal = '" + id + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }

        //masih npp dekan prodi dll
        public bool addfeedback(string tmpid, string nppProdi, string nppDekan, string nppLppm, string feedback, DateTime tgl, string status)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_FEEDBACK_PENGABDIAN values ('" + tmpid + "','" + nppProdi + "','" + nppDekan + "','" + nppLppm + "','" + feedback + "','" + tgl + "','" + status + "');";
                cmd = new SqlCommand(query, sqlConn);


                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool addfeedback(string tmpid, string npp, string feedback, DateTime tgl, string status)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_FEEDBACK_PENGABDIAN values ('" + tmpid + "','" + npp + "','" + feedback + "','" + tgl + "','" + status + "');";
                cmd = new SqlCommand(query, sqlConn);


                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public DataSet getFeedbackProdi(string id)
        {
            try
            {
                string query = "select * from silppm.TBL_FEEDBACK_PENGABDIAN f join [siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='Prodi' and f.ID_PROPOSAL = '" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        //monev prodi dan dekan
        public DataSet getJudulTerimaByProdi(int subid)
        {
            try
            {
                string query = "select d.nama,p.id_proposal,p.Judul_kegiatan from silppm.TBL_PENGABDIAN_LOLOS p join Simka.mst_karyawan d on d.npp=p.NPP where d.ID_UNIT_AKADEMIK=" + subid + " and p.IS_SETUJU_PUSTAKAWAN is null ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getJudulTerimaByDekan(string subid)
        {
            try
            {
                string query = "select d.nama,p.id_proposal,p.Judul_kegiatan from silppm.TBL_PENGABDIAN_LOLOS p join Simka.mst_karyawan d on d.npp=p.NPP where d.ID_UNIT = (Select ID_UNIT From siatmax.MST_UNIT where NPP ='" + subid + "' and IS_PALSU=0) and p.IS_SETUJU_PUSTAKAWAN is null";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getSemuaJudulTerima()
        {
            try
            {
                string query = "select d.nama,p.id_proposal,p.Judul_kegiatan from silppm.TBL_PENGABDIAN_LOLOS p join Simka.mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_PUSTAKAWAN is null";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }//udah

        //cek Setuju
        public bool cekProdiSetuju(string idprop)
        {
            try
            {
                string query = "select IS_SETUJU_PRODI from silppm.TBL_PENGABDIAN where id_proposal = '" + idprop + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetValue(0).ToString();
                    if (id == "True")
                        return true;
                    else return false;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool cekDekanSetuju(string idprop)
        {
            try
            {
                string query = "select IS_SETUJU_DEKAN from silppm.TBL_PENGABDIAN where id_proposal = '" + idprop + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetValue(0).ToString();
                    if (id == "True")
                        return true;
                    else return false;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool cekLPPMSetuju(string idprop)
        {
            try
            {
                string query = "select IS_SETUJU_LPPM from silppm.TBL_PENGABDIAN where id_proposal = '" + idprop + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string id = reader.GetValue(0).ToString();
                    if (id == "True")
                        return true;
                    else return false;
                }
                else
                    return false;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }


        //Dekan
        public DataSet getListLaporanDekan(int idDekan)
        {
            try
            {
                string query = "select p.id_proposal,p.Judul_kegiatan,d.nama, CASE WHEN p.IS_SETUJU_DEKAN is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENGABDIAN p join simka.Mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_DEKAN is NULL AND IS_SETUJU_PRODI=1 AND IS_DROPPED=0 and d.ID_UNIT=" + idDekan + "";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool updateDekan(int cek, string id_prop, int status)
        {
            try
            {
                string query = "update silppm.TBL_PENGABDIAN set IS_SETUJU_DEKAN=" + cek + ",ID_STATUS='" + status + "' where id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getFeedbackDekan(string id)
        {
            try
            {
                string query = "select * from silppm.TBL_FEEDBACK_PENGABDIAN f join [siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='Dekan' and f.ID_PROPOSAL = '" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }//ada npp dekan

        //admin
        public DataSet getListAdminKelolaReview()
        {
            try
            {
                string query = "select p.id_proposal,p.Judul_kegiatan,d.nama from silppm.TBL_PENGABDIAN p join simka.mst_karyawan d on d.npp=p.NPP where NPP_REVIEWER is NULL and IS_SETUJU_DEKAN=1 AND IS_SETUJU_PRODI=1";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool inputReview(string npp, string idProp)
        {
            try
            {
                string query = "insert into silppm.TBL_MAPPING_PENGABDIAN values('" + idProp + "','" + npp + "')";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool updateinputReview(string npp, string idProp)
        {
            try
            {
                string query = "update silppm.TBL_PENGABDIAN set NPP_REVIEWER = '" + npp + "' where id_proposal = '" + idProp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }


        //KALPPM
        public DataSet getListLaporanKALPPM()
        {
            try
            {
                string query = "select p.id_proposal,p.Judul_kegiatan,d.nama, CASE WHEN p.IS_SETUJU_LPPM is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENGABDIAN p join simka.mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_LPPM is NULL AND REVIEWER1!='kosong' AND IS_DROPPED=0";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public string getNamaPeriode()
        {
            try
            {
                string query = "select t.TAHUN_ANGGARAN from silppm.REF_SCHEDULE s join sikeu.TBL_TAHUN_ANGGARAN t on s.ID_TAHUN_ANGGARAN=t.ID_TAHUN_ANGGARAN where s.is_locked=0";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public string getNamaPeriodeByIDProposal(string id)
        {
            try
            {
                string query = "select DISTINCT t.TAHUN_ANGGARAN from silppm.TBL_PENGABDIAN p join silppm.REF_SCHEDULE s on s.ID_TAHUN_ANGGARAN=p.ID_TAHUN_ANGGARAN join sikeu.TBL_TAHUN_ANGGARAN t on t.ID_TAHUN_ANGGARAN=s.ID_TAHUN_ANGGARAN where p.ID_PROPOSAL='" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }

        public DateTime getAwalProposal(string idp)
        {
            try
            {
                string query = "select AWAL from silppm.TBL_PENGABDIAN_LOLOS Where id_proposal = '" + idp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    DateTime id = DateTime.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return DateTime.MinValue;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DateTime getAkhirProposal(string idp)
        {
            try
            {
                string query = "select AKHIR from silppm.TBL_PENGABDIAN_LOLOS Where id_proposal = '" + idp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    DateTime id = DateTime.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return DateTime.MinValue;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getKALPPMDataProposalByIDProposal(string id)
        {
            try
            {
                string query = "select * from silppm.TBL_PENGABDIAN_LOLOS  where id_proposal='" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool updateKALPPM(int cek, string id_prop, int status)
        {
            try
            {
                string query = "update silppm.TBL_PENGABDIAN set IS_SETUJU_LPPM=" + cek + ",ID_STATUS='" + status + "' where id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public double getDanaDisetujui(string idprop)
        {
            try
            {
                string query = "select dana_setuju from silppm.tbl_pengabdian where id_proposal = " + idprop + "";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    double id = Double.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public string getNppDosenbyIDProposal_Penelitian(string uname)
        {
            try
            {
                string query = "select d.NPP from silppm.TBL_PENGABDIAN p join simka.Mst_karyawan d on d.NPP=p.NPP where ID_PROPOSAL = '" + uname + "' ";
                
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                    //return reader.GetInt32(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }
        public bool CekPerkembanganMonev(string id, string npp)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "select ID_PROPOSAL,NPP from silppm.TBL_LAP_MONEV_PENGABDIAN where ID_PROPOSAL='" + id + "' and NPP ='" + npp + "'";
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string tmp = reader.GetValue(0).ToString();
                    if (tmp != "")
                        return true;
                    else return false;
                }
                else
                    return false;



            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public bool UpdateLaporanTahap1(string id, object laporan)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENGABDIAN_LOLOS set laporan1=@laporan where ID_PROPOSAL=@ID_Prop;";
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", id);
                cmd.Parameters.AddWithValue("@laporan", laporan);



                cmd.ExecuteNonQuery();


                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }

        }
        public DataSet getFeedbackKALPPM(string id)
        {
            try
            {
                string query = "select * from silppm.TBL_FEEDBACK_PENGABDIAN f join [siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='KALPPM' and f.ID_PROPOSAL = '" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }//ada npp dekan



        public DataSet getListLaporanPustaka()
        {
            try
            {
                string query = "select p.id_proposal,p.Judul_kegiatan,d.nama, CASE WHEN p.IS_SETUJU_PUSTAKAWAN is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENGABDIAN_LOLOS p join simka.Mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_PUSTAKAWAN is NULL";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public byte[] getLaporanPenelitian(string index)
        {
            try
            {
                string query = "select laporan from silppm.TBL_PENGABDIAN_LOLOS where id_proposal= '" + index + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return (byte[])reader.GetValue(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getDataPustaka(string id)
        {
            try
            {
                string query = "select * from silppm.TBL_PENGABDIAN_LOLOS where id_proposal ='" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool updateApprovalPustakawan(string id_prop)
        {
            try
            {
                string query = "update silppm.TBL_Pengabdian_lolos set IS_SETUJU_PUSTAKAWAN=1 where id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public string getIDPeriodeAktif()
        {
            try
            {
                string query = "select t.ID_TAHUN_ANGGARAN from silppm.REF_SCHEDULE s join sikeu.TBL_TAHUN_ANGGARAN t on s.ID_TAHUN_ANGGARAN=t.ID_TAHUN_ANGGARAN where s.is_locked=0";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string temp = reader.GetValue(0).ToString();
                    return temp;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                reader.Close();
            }
        }

        public int getCountPerpanjanganPengabdian(string npp)
        {
            try
            {
                string query = "select count(id_proposal) from silppm.TBL_PERPANJANGAN_PENGABDIAN where id_proposal = '" + npp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id = int.Parse(reader.GetValue(0).ToString());
                    //int.Parse(reader.GetInt32(0).ToString());
                    //
                    return id;
                }
                else
                    return 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getDataPerpanjangan(string id)
        {
            try
            {
                string query = "select *,e.judul_kegiatan from silppm.TBL_PERPANJANGAN_PENGABDIAN p join silppm.tbl_pengabdian e on e.id_proposal=p.id_proposal where p.id_proposal = '" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                adapter.Fill(dataset);
                return dataset;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public bool PerpanjangPeriodePengabdian(string id_prop, int count, DateTime awal, DateTime akhir, DateTime insertDate, string ip, string userid)
        {
            try
            {
                string query = "insert into silppm.TBL_PERPANJANGAN_PENGABDIAN values('" + id_prop + "'," + count + ",@awal,@akhir,@insDate,@ip,@userid)";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@awal", awal);
                cmd.Parameters.AddWithValue("@akhir", akhir);
                cmd.Parameters.AddWithValue("@insDate", insertDate);
                cmd.Parameters.AddWithValue("@ip", ip);
                cmd.Parameters.AddWithValue("@userid", userid);
                reader = cmd.ExecuteReader();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        //arsip
        public byte[] getPropsalPengabdian(string index)
        {
            try
            {
                string query = "select dokumen from silppm.TBL_PENGABDIAN where id_proposal= '" + index + "' and IS_DROPPED=0 ;";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return (byte[])reader.GetValue(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }//udah
        public byte[] getLaporanPengabdian(string index)
        {
            try
            {
                string query = "select laporan from silppm.TBL_PENGABDIAN_LOLOS where id_proposal= '" + index + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return (byte[])reader.GetValue(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public byte[] getDraftPengabdian(string index)
        {
            try
            {
                string query = "select laporan1 from silppm.TBL_PENGABDIAN_LOLOS where id_proposal= '" + index + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return (byte[])reader.GetValue(0);
                }
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getHistoryExec()
        {
            try
            {
                string query = "select p.id_proposal,k.NAMA,p.JUDUL_KEGIATAN,s.DESKRIPSI,a.TAHUN_ANGGARAN,u.NAMA_UNIT AS 'FAK',uu.NAMA_UNIT AS 'PRODI' from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getHistoryExecByTahunAnggaran(string tahun)
        {
            try
            {
                string query = "select p.id_proposal,k.NAMA,p.JUDUL_KEGIATAN,s.DESKRIPSI,a.TAHUN_ANGGARAN,u.NAMA_UNIT AS 'FAK',uu.NAMA_UNIT AS 'PRODI' from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT where a.TAHUN_ANGGARAN like '" + tahun + "' order by a.TAHUN_ANGGARAN";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataSet getHistoryProdi(string NppProdi)
        {
            try
            {
                string query = "select * from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT_AKADEMIK=u.ID_UNIT where k.ID_UNIT_AKADEMIK = (select ID_UNIT from siatmax.MST_UNIT where NPP= '" + NppProdi + "')";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getHistoryProdiByTahunAnggaran(string NppProdi,string Tahun)
        {
            try
            {
                string query = "select * from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT_AKADEMIK=u.ID_UNIT where k.ID_UNIT_AKADEMIK = (select ID_UNIT from siatmax.MST_UNIT where NPP= '" + NppProdi + "') and a.Tahun_anggaran = '"+Tahun+"'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataSet getHistoryFakultas(string NppFak)
        {
            try
            {
                string query = "select k.NAMA,p.JUDUL_KEGIATAN,s.DESKRIPSI,a.TAHUN_ANGGARAN,uu.NAMA_UNIT from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT where k.ID_UNIT = (select ID_UNIT from siatmax.MST_UNIT where NPP=  '" + NppFak + "' and IS_PALSU=0)";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataSet getHistoryFakultasByTahunAnggaran(string NppFak,string Tahun)
        {
            try
            {
                string query = "select k.NAMA,p.JUDUL_KEGIATAN,s.DESKRIPSI,a.TAHUN_ANGGARAN,uu.NAMA_UNIT from silppm.TBL_PENGABDIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT where k.ID_UNIT = (select ID_UNIT from siatmax.MST_UNIT where NPP=  '" + NppFak + "' and a.Tahun_Anggaran='"+Tahun+"' and IS_PALSU=0)";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataSet getListCetakJadwal()
        {
            try
            {
                string query = "select p.id_proposal,p.Judul_kegiatan,d.nama from silppm.TBL_PENGABDIAN_LOLOS p join simka.mst_karyawan d on d.npp=p.NPP where IS_SETUJU_DEKAN=1 AND IS_SETUJU_PRODI=1 and IS_SETUJU_PUSTAKAWAN is null";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset);
                return dataset;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        public DataTable getListPeriode()
        {
            try
            {
                string query = "select * from  sikeu.TBL_TAHUN_ANGGARAN";
                //string query = "select distinct NAMA from Simka.MST_KARYAWAN ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dt);
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }

    }
}