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
    public class ProposalDAO
    {
        private SqlConnection sqlConn;
        SqlCommand cmd;
        SqlDataReader reader;
        private Connection conn = new Connection();
        //private DataTable dt = new DataTable();
        //private DataSet dataset = new DataSet();
        private DataSet dataset1 = new DataSet();
        public ProposalDAO()
        {
            sqlConn = conn.getConnection();
        }

        // insert pct RAB
        public bool updatePctRAB(int id, decimal PERSENTASE)
        {
            string query = @"update silppm.TBL_RAB_PENELITIAN set PERSENTASE =@PERSENTASE
                where ID_RAB_PENELITIAN=@ID_RAB_PENELITIAN";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_RAB_PENELITIAN", id);
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

        //Get penelitian
        public DataTable cekPenelitian(string ID_TAHUN_ANGGARAN, string npp)
        {
            string select = @"SELECT silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN, 
            silppm.TBL_PENELITIAN.NO_SEMESTER,silppm.TBL_PENELITIAN.NPP
            FROM silppm.TBL_PENELITIAN WHERE coalesce(IS_SETUJU_LPPM,1) =1 
            and (silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = @ID_TAHUN_ANGGARAN) 
            AND (silppm.TBL_PENELITIAN.NPP = @NPP)";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_TAHUN_ANGGARAN", ID_TAHUN_ANGGARAN);
                dbManager.AddParameters(1, "@NPP", npp);
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
            string select = @"SELECT  ID_RAB_PENELITIAN, ID_DTL_RAB_PENELITIAN, JUMLAH_DANA, JUMLAH, SATUAN, HARGA_SATUAN, KETERANGAN
            FROM silppm.DTL_RAB_PENELITIAN
            WHERE (ID_RAB_PENELITIAN = @ID_RAB_PENELITIAN)";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_RAB_PENELITIAN", id_rab);
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
            string select = @"SELECT SUM(silppm.DTL_RAB_PENELITIAN.JUMLAH_DANA) AS JUMLAH_DANA
                    FROM silppm.REF_PENGELUARAN_RAB INNER JOIN
                    silppm.TBL_RAB_PENELITIAN ON silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB = silppm.TBL_RAB_PENELITIAN.ID_PENGELUARAN_RAB INNER JOIN
                    silppm.DTL_RAB_PENELITIAN ON silppm.TBL_RAB_PENELITIAN.ID_RAB_PENELITIAN = silppm.DTL_RAB_PENELITIAN.ID_RAB_PENELITIAN
                    GROUP BY silppm.TBL_RAB_PENELITIAN.ID_PROPOSAL
                    HAVING (silppm.TBL_RAB_PENELITIAN.ID_PROPOSAL = @ID_PROPOSAL)";

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

        //Get RAB
        public DataTable GetRAB(string id_prop)
        {
            string select = @"SELECT    silppm.TBL_RAB_PENELITIAN.ID_RAB_PENELITIAN, silppm.TBL_RAB_PENELITIAN.ID_PROPOSAL, 
                    silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB, silppm.REF_PENGELUARAN_RAB.DESKRIPSI, silppm.TBL_RAB_PENELITIAN.JUMLAH_DANA, 
                    silppm.TBL_RAB_PENELITIAN.PERSENTASE,[MIN_PCT],[MAX_PCT]
                    FROM silppm.REF_PENGELUARAN_RAB INNER JOIN
                    silppm.TBL_RAB_PENELITIAN ON silppm.REF_PENGELUARAN_RAB.ID_PENGELUARAN_RAB = silppm.TBL_RAB_PENELITIAN.ID_PENGELUARAN_RAB
                    WHERE (silppm.TBL_RAB_PENELITIAN.ID_PROPOSAL = @ID_PROPOSAL)";

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

        //Get KARYAWAN by NPP NAMA
        public DataTable GetDataKaryawan(string KEYWORD)
        {
            string select = @"SELECT     simka.MST_KARYAWAN.NPP, simka.MST_KARYAWAN.NAMA, simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR, simka.MST_KARYAWAN.NICKNAME, 
                      simka.MST_KARYAWAN.MST_ID_UNIT, siatmax.MST_UNIT.NAMA_UNIT
                        FROM         simka.MST_KARYAWAN LEFT OUTER JOIN
                                              siatmax.MST_UNIT ON simka.MST_KARYAWAN.MST_ID_UNIT = siatmax.MST_UNIT.ID_UNIT
                        WHERE     (simka.MST_KARYAWAN.NAMA_LENGKAP_GELAR LIKE '%' + @KEYWORD + '%') OR
                                              (simka.MST_KARYAWAN.NPP LIKE '%' + @KEYWORD + '%')";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@KEYWORD", KEYWORD);
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

        // insert detail RAB
        public bool updateTotalRAB(int id)
        {
            string query = @"update silppm.TBL_RAB_PENELITIAN set JUMLAH_DANA =(
                SELECT SUM(JUMLAH_DANA) 
                FROM silppm.DTL_RAB_PENELITIAN
                where ID_RAB_PENELITIAN=@ID_RAB_PENELITIAN)
                where ID_RAB_PENELITIAN=@ID_RAB_PENELITIAN";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_RAB_PENELITIAN", id);

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

        // insert detail RAB
        public bool insertRAB(DTL_RAB_PENELITIAN tbl)
        {
            string query = @"INSERT INTO [silppm].[DTL_RAB_PENELITIAN]
            ([ID_RAB_PENELITIAN],[JUMLAH_DANA],[JUMLAH],[SATUAN]
            ,[HARGA_SATUAN],[KETERANGAN])
            VALUES (@ID_RAB_PENELITIAN,@JUMLAH_DANA,@JUMLAH
            ,@SATUAN,@HARGA_SATUAN,@KETERANGAN)";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "@ID_RAB_PENELITIAN", tbl.ID_RAB_PENELITIAN);
                dbManager.AddParameters(1, "@JUMLAH", tbl.JUMLAH);
                dbManager.AddParameters(2, "@JUMLAH_DANA", tbl.JUMLAH_DANA);
                dbManager.AddParameters(3, "@KETERANGAN", tbl.KETERANGAN);
                dbManager.AddParameters(4, "@SATUAN", tbl.SATUAN);
                dbManager.AddParameters(5, "@HARGA_SATUAN", tbl.HARGA_SATUAN);

                dbManager.ExecuteNonQuery(CommandType.Text, query);
                updateTotalRAB(tbl.ID_RAB_PENELITIAN.Value);
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
        public bool updatetRAB(DTL_RAB_PENELITIAN tbl)
        {
            string query = @"update [silppm].[DTL_RAB_PENELITIAN]
            set [JUMLAH_DANA]=@JUMLAH_DANA,
                [JUMLAH]=@JUMLAH,
                [SATUAN]=@SATUAN,
                [HARGA_SATUAN]=@HARGA_SATUAN,
                [KETERANGAN]=@KETERANGAN
            where ID_DTL_RAB_PENELITIAN=@ID_DTL_RAB_PENELITIAN";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(7);
                dbManager.AddParameters(0, "@ID_RAB_PENELITIAN", tbl.ID_RAB_PENELITIAN);
                dbManager.AddParameters(1, "@JUMLAH", tbl.JUMLAH);
                dbManager.AddParameters(2, "@JUMLAH_DANA", tbl.JUMLAH_DANA);
                dbManager.AddParameters(3, "@KETERANGAN", tbl.KETERANGAN);
                dbManager.AddParameters(4, "@SATUAN", tbl.SATUAN);
                dbManager.AddParameters(5, "@HARGA_SATUAN", tbl.HARGA_SATUAN);
                dbManager.AddParameters(6, "@ID_DTL_RAB_PENELITIAN", tbl.ID_DTL_RAB_PENELITIAN);

                dbManager.ExecuteNonQuery(CommandType.Text, query);
                updateTotalRAB(tbl.ID_RAB_PENELITIAN.Value);
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
        public bool insertAnggotaPenelitian(string idprop, string npp)
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
            string query = @"insert into silppm.TBL_PERSONIL_PENELITIAN(
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

        public bool insertPublikasi(TBL_PUBLIKASI_SEMINAR dtl)
        {
            string query = @"INSERT INTO [silppm].[TBL_PUBLIKASI_SEMINAR]
                           ([ID_PROPOSAL],[JUDUL],[ID_LEVEL_SEMINAR],[NAMA_JURNAL],[ISSN],[DOI])
                            VALUES( @ID_PROPOSAL, @JUDUL,@ID_LEVEL_SEMINAR,@NAMA_JURNAL,@ISSN,@DOI)";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "@ID_PROPOSAL", dtl.ID_PROPOSAL);
                dbManager.AddParameters(1, "@JUDUL", dtl.JUDUL);
                dbManager.AddParameters(2, "@ID_LEVEL_SEMINAR", dtl.ID_LEVEL_SEMINAR);
                dbManager.AddParameters(3, "@NAMA_JURNAL", dtl.NAMA_JURNAL);
                dbManager.AddParameters(4, "@ISSN", dtl.ISSN);
                dbManager.AddParameters(5, "@DOI", dtl.DOI);

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
        public bool hapusJurnal(string id_jurnal)
        {
            int cek = getMaxIDTema() + 1;
            try
            {
                string query = "DELETE FROM [silppm].[TBL_PUBLIKASI_JURNAL] WHERE [ID_OUTCOME_PUBLIKASI]='" + id_jurnal + "'";
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
        public bool insertJurnal(TBL_PUBLIKASI_JURNAL dtlJurnal)
        {
            string query = @"INSERT INTO [silppm].[TBL_PUBLIKASI_JURNAL]
                           ([ID_PROPOSAL],[JUDUL],[ID_LEVEL_JURNAL],[NAMA_SEMINAR],[ISSN],[DOI])
                            VALUES( @ID_PROPOSAL, @JUDUL,@ID_LEVEL_JURNAL,@NAMA_SEMINAR,@ISSN,@DOI)";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(6);
                dbManager.AddParameters(0, "@ID_PROPOSAL", dtlJurnal.ID_PROPOSAL);
                dbManager.AddParameters(1, "@JUDUL", dtlJurnal.JUDUL);
                dbManager.AddParameters(2, "@ID_LEVEL_JURNAL", dtlJurnal.ID_LEVEL_JURNAL);
                dbManager.AddParameters(3, "@NAMA_SEMINAR", dtlJurnal.NAMA_SEMINAR);
                dbManager.AddParameters(4, "@ISSN", dtlJurnal.ISSN);
                dbManager.AddParameters(5, "@DOI", dtlJurnal.DOI);

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

        public DataTable getAnggotaPenelitian(string idprop)
        {
            string query = @" SELECT [ID_PERSONIL_PENELITIAN],[NPP],[NAMA_LENGKAP_GELAR]
            ,[TEMPAT_LAHIR],[TGL_LAHIR],[JNS_KEL],[EMAIL],[ID_REF_FUNGSIONAL]
            ,[ID_UNIT],[ID_UNIT_AKADEMIK],[ID_REF_GOLONGAN],[ID_REF_JBTN_AKADEMIK]
            ,[NO_TELPON_RUMAH],[NO_TELPON_HP],[WARGANEGARA],[NPWP],[NIP_PNS]
            ,[NIDN],[ALAMAT_KOTA],[ALAMAT],[ALAMAT_PROVINSI],[ALAMAT_KODEPOS]
            ,[ID_PROPOSAL],[INSTITUSI_ASAL],[BIDANG_KEAHLIAN_PENELITIAN]
              FROM [silppm].[TBL_PERSONIL_PENELITIAN]
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

        public DataTable getPenelitian(string idprop)
        {
            string query = @"SELECT [ID_PROPOSAL],[ID_TAHUN_ANGGARAN],[NO_SEMESTER],[ID_KATEGORI]
                ,[ID_ROAD_MAP_PENELITIAN],[ID_SKIM],[ID_TEMA_UNIVERSITAS]
                ,[ID_STATUS_PENELITIAN],[JENIS],[JUDUL],[LOKASI],[NPP],[NPP1],[NPP2]
                ,[AWAL],[AKHIR],[BEBAN_SKS],[BEBAN_SKS_ANGGOTA],[DANA_USUL],[DANA_PRIBADI]
                ,[DANA_EKSTERNAL],[DANA_KERJASAMA],[DANA_UAJY],[DANA_SETUJU],[DOKUMEN]
                ,[LEMBAR_PENGESAHAN],[KEYWORD],[JARAK_KAMPUS_KM],[JARAK_KAMPUS_JAM]
                ,[OUTCOME],[LONGITUDE],[LATITUDE],KETERANGAN_DANA_EKSTERNAL
                  FROM [silppm].[TBL_PENELITIAN]
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

        public DataTable getProsidng(string idprosiding)
        {
            string query = @"SELECT [ID_OUTCOME_PROSIDING]
                          ,[ID_PROPOSAL]
                          ,[JUDUL]
                          ,[ID_LEVEL_SEMINAR]
                          ,[NAMA_JURNAL]
                          ,[ISSN]
                          ,[DOI]
                      FROM [silppm].[TBL_PUBLIKASI_SEMINAR]

                where [ID_OUTCOME_PROSIDING] =@ID_OUTCOME_PROSIDING";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_OUTCOME_PROSIDING", idprosiding);
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


        public int getMaxCountPerorangan()
        {
            try
            {
                string query = "select COUNT(id_proposal) from penelitian where ID_PROPOSAL like 'PnO%'";
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
        public int getMaxCountKelompok()
        {
            try
            {
                string query = "select COUNT(id_proposal) from penelitian where ID_PROPOSAL like 'PnK%'";
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
                string query = "select MAX(id_proposal) from silppm.tbl_penelitian";
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
        }//udah

        //untuk  ambil data tahun akademik
        public DataTable getTahunAkademik()
        {
            string select = @"SELECT [ID_TAHUN_AKADEMIK] ,[TAHUN_AKADEMIK]
                FROM [siatmax].[TBL_TAHUN_AKADEMIK] order by TAHUN_AKADEMIK desc";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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

        //untuk ambil data semester akademik
        public DataTable getSemesterAkademik(string id_tahun_akd)
        {
            string select = @"SELECT [NO_SEMESTER],[SEMESTER_AKADEMIK]  
                FROM [siatmax].[TBL_SEMESTER_AKADEMIK]
                where [ID_TAHUN_AKADEMIK] =@ID_TAHUN_AKADEMIK";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_TAHUN_AKADEMIK", id_tahun_akd);
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

        public bool updateProposal(TBL_PENELITIAN pen)
        {
            try
            {
                //int tmpcount = getMaxCountPerorangan()+1;
                //string query = @"insert into silppm.TBL_PENELITIAN values (@ID_Prop,@ID_Dosen,@ID_Jenis,@ID_Schedule,@ID_Sumber,@ID_Rev,@ID_Rev2,@Judul,@Kategori,@Lokasi,@Beban_sks,@id_status_approval,@Dana_usul,@awal,@akhir,@dokumen,@IS_DROPPED,@keyword,@jarakKM,@jarakJam,@sesuaiUnit,@OutCome,@DanaPribadi,@longitude,@latitude,@anggota1,@anggota2,NULL,NULL,@sksAnggota,NULL,NULL,NULL,@date,@ip,@userid);";

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();


                string query = @"update [silppm].[TBL_PENELITIAN] set
                    [ID_TAHUN_ANGGARAN]=@ID_TAHUN_ANGGARAN,[NO_SEMESTER]=@NO_SEMESTER,[ID_KATEGORI]=@ID_KATEGORI
                    ,[ID_ROAD_MAP_PENELITIAN]=@ID_ROAD_MAP_PENELITIAN
                    ,[ID_SKIM]=@ID_SKIM,[ID_TEMA_UNIVERSITAS]=@ID_TEMA_UNIVERSITAS,[ID_STATUS_PENELITIAN]=@ID_STATUS_PENELITIAN,[JENIS]=@JENIS
                    ,[JUDUL]=@JUDUL,[LOKASI]=@LOKASI,[NPP]=@NPP,[NPP1]=@NPP1,[NPP2]=@NPP2,[AWAL]=@AWAL,[AKHIR]=@AKHIR,[IS_CHECKED]=@IS_CHECKED
                    ,[BEBAN_SKS]=@BEBAN_SKS,[BEBAN_SKS_ANGGOTA]=@BEBAN_SKS_ANGGOTA,[DANA_USUL]=@DANA_USUL,[DANA_PRIBADI]=@DANA_PRIBADI,[DANA_EKSTERNAL]=@DANA_EKSTERNAL
                    ,[DANA_KERJASAMA]=@DANA_KERJASAMA,[DANA_UAJY]=@DANA_UAJY,[DANA_SETUJU]=@DANA_SETUJU
                    ,[KEYWORD]=@KEYWORD,[JARAK_KAMPUS_KM]=@JARAK_KAMPUS_KM,[JARAK_KAMPUS_JAM]=@JARAK_KAMPUS_JAM,[OUTCOME]=@OUTCOME,[LONGITUDE]=@LONGITUDE
                    ,[LATITUDE]=@LATITUDE, KETERANGAN_DANA_EKSTERNAL=@KETERANGAN_DANA_EKSTERNAL
                   where ID_PROPOSAL=@ID_PROPOSAL";

                string queryDOKUMEN = @"update [silppm].[TBL_PENELITIAN] set
                    [DOKUMEN]=@DOKUMEN 
                   where ID_PROPOSAL=@ID_PROPOSAL and DOKUMEN is null";
                string queryLEMBAR_PENGESAHAN = @"update [silppm].[TBL_PENELITIAN] set
                    [LEMBAR_PENGESAHAN]=@LEMBAR_PENGESAHAN 
                   where ID_PROPOSAL=@ID_PROPOSAL and LEMBAR_PENGESAHAN is null";

                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_PROPOSAL", pen.ID_PROPOSAL);
                if (pen.KETERANGAN_DANA_EKSTERNAL == null)
                    cmd.Parameters.AddWithValue("@KETERANGAN_DANA_EKSTERNAL", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@KETERANGAN_DANA_EKSTERNAL", pen.KETERANGAN_DANA_EKSTERNAL);

                if (pen.ID_TAHUN_ANGGARAN == null || pen.ID_TAHUN_ANGGARAN == 0)
                    cmd.Parameters.AddWithValue("@ID_TAHUN_ANGGARAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TAHUN_ANGGARAN", pen.ID_TAHUN_ANGGARAN);

                cmd.Parameters.AddWithValue("@NO_SEMESTER", pen.NO_SEMESTER);
                cmd.Parameters.AddWithValue("@ID_KATEGORI", pen.ID_KATEGORI);
                //cmd.Parameters.AddWithValue("@ID_ROAD_MAP_PENELITIAN", pen.ID_ROAD_MAP_PENELITIAN)

                if (pen.ID_ROAD_MAP_PENELITIAN == null)
                    cmd.Parameters.AddWithValue("@ID_ROAD_MAP_PENELITIAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_ROAD_MAP_PENELITIAN", pen.ID_ROAD_MAP_PENELITIAN);

                // cmd.Parameters.AddWithValue("@ID_SKIM", pen.ID_SKIM)
                if (pen.ID_SKIM == null)
                    cmd.Parameters.AddWithValue("@ID_SKIM", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_SKIM", pen.ID_SKIM);


                if (pen.ID_TEMA_UNIVERSITAS == null)
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", pen.ID_TEMA_UNIVERSITAS);

                if (pen.ID_STATUS_PENELITIAN == null)
                    cmd.Parameters.AddWithValue("@ID_STATUS_PENELITIAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_STATUS_PENELITIAN", pen.ID_STATUS_PENELITIAN);

                if (pen.JENIS == null)
                    cmd.Parameters.AddWithValue("@JENIS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@JENIS", pen.JENIS);

                cmd.Parameters.AddWithValue("@JUDUL", pen.JUDUL);
                cmd.Parameters.AddWithValue("@LOKASI", pen.LOKASI);
                if (pen.NPP == null)
                    cmd.Parameters.AddWithValue("@NPP", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NPP", pen.NPP);

                if (pen.NPP1 == null)
                    cmd.Parameters.AddWithValue("@NPP1", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NPP1", pen.NPP1);

                if (pen.NPP2 == null)
                    cmd.Parameters.AddWithValue("@NPP2", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NPP2", pen.NPP2);

                cmd.Parameters.AddWithValue("@AWAL", pen.AWAL);
                cmd.Parameters.AddWithValue("@AKHIR", pen.AKHIR);
                cmd.Parameters.AddWithValue("@IS_CHECKED", pen.IS_CHECKED);
                cmd.Parameters.AddWithValue("@BEBAN_SKS", pen.BEBAN_SKS);
                cmd.Parameters.AddWithValue("@BEBAN_SKS_ANGGOTA", pen.BEBAN_SKS_ANGGOTA);
                cmd.Parameters.AddWithValue("@DANA_USUL", pen.DANA_USUL);
                cmd.Parameters.AddWithValue("@DANA_PRIBADI", pen.DANA_PRIBADI);
                cmd.Parameters.AddWithValue("@DANA_EKSTERNAL", pen.DANA_EKSTERNAL);
                cmd.Parameters.AddWithValue("@DANA_KERJASAMA", pen.DANA_KERJASAMA);
                cmd.Parameters.AddWithValue("@DANA_UAJY", pen.DANA_UAJY);
                cmd.Parameters.AddWithValue("@DANA_SETUJU", pen.DANA_SETUJU);

                cmd.Parameters.AddWithValue("@KEYWORD", pen.KEYWORD);
                cmd.Parameters.AddWithValue("@JARAK_KAMPUS_JAM", pen.JARAK_KAMPUS_JAM);
                cmd.Parameters.AddWithValue("@JARAK_KAMPUS_KM", pen.JARAK_KAMPUS_KM);
                cmd.Parameters.AddWithValue("@OUTCOME", pen.OUTCOME);
                cmd.Parameters.AddWithValue("@LONGITUDE", pen.LONGITUDE);
                cmd.Parameters.AddWithValue("@LATITUDE", pen.LATITUDE);
                cmd.Parameters.AddWithValue("@INSERT_DATE", pen.INSERT_DATE);
                cmd.Parameters.AddWithValue("@IP_ADDRESS", pen.IP_ADDRESS);
                cmd.Parameters.AddWithValue("@USER_ID", pen.USER_ID);
                cmd.ExecuteNonQuery();
                if (pen.DOKUMEN != null)
                {
                    cmd = new SqlCommand(queryDOKUMEN, sqlConn);
                    cmd.Parameters.AddWithValue("@ID_PROPOSAL", pen.ID_PROPOSAL);
                    cmd.Parameters.AddWithValue("@DOKUMEN", pen.DOKUMEN);
                    cmd.ExecuteNonQuery();
                }

                if (pen.LEMBAR_PENGESAHAN != null)
                {
                    cmd = new SqlCommand(queryLEMBAR_PENGESAHAN, sqlConn);
                    cmd.Parameters.AddWithValue("@ID_PROPOSAL", pen.ID_PROPOSAL);
                    cmd.Parameters.AddWithValue("@LEMBAR_PENGESAHAN", pen.LEMBAR_PENGESAHAN);
                    cmd.ExecuteNonQuery();
                }
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

        public int addProposal(TBL_PENELITIAN pen)
        {
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();
            SqlTransaction transaction = sqlConn.BeginTransaction();
            try
            {
                //int tmpcount = getMaxCountPerorangan()+1;
                //string query = @"insert into silppm.TBL_PENELITIAN values (@ID_Prop,@ID_Dosen,@ID_Jenis,@ID_Schedule,@ID_Sumber,@ID_Rev,@ID_Rev2,@Judul,@Kategori,@Lokasi,@Beban_sks,@id_status_approval,@Dana_usul,@awal,@akhir,@dokumen,@IS_DROPPED,@keyword,@jarakKM,@jarakJam,@sesuaiUnit,@OutCome,@DanaPribadi,@longitude,@latitude,@anggota1,@anggota2,NULL,NULL,@sksAnggota,NULL,NULL,NULL,@date,@ip,@userid);";



                string query = @"INSERT INTO [SIATMAX].[silppm].[TBL_PENELITIAN]
                    ([ID_TAHUN_ANGGARAN],[NO_SEMESTER],[ID_KATEGORI],[ID_ROAD_MAP_PENELITIAN]
                    ,[ID_SKIM],[ID_TEMA_UNIVERSITAS],[ID_STATUS_PENELITIAN],[JENIS]
                    ,[JUDUL],[LOKASI],[NPP],[NPP1],[NPP2],[AWAL],[AKHIR],[IS_CHECKED],[IS_DROPPED],[IS_SETUJU_PRODI],[IS_SETUJU_DEKAN]
                    --,[NPP_REVIEWER],[REVIEWER1],[REVIEWER2],[IS_SETUJU_LPPM]
                    ,[BEBAN_SKS],[BEBAN_SKS_ANGGOTA],[DANA_USUL],[DANA_PRIBADI],[DANA_EKSTERNAL]
                    ,[DANA_KERJASAMA],[DANA_UAJY],[DANA_SETUJU]--,[DOKUMEN],[LEMBAR_PENGESAHAN]
                    ,[KEYWORD],[JARAK_KAMPUS_KM],[JARAK_KAMPUS_JAM],[OUTCOME],[LONGITUDE]
                    ,[LATITUDE]
                    ,[INSERT_DATE],[IP_ADDRESS],[USER_ID],KETERANGAN_DANA_EKSTERNAL)  OUTPUT  INSERTED.ID_PROPOSAL
                    VALUES (@ID_TAHUN_ANGGARAN,@NO_SEMESTER,@ID_KATEGORI,@ID_ROAD_MAP_PENELITIAN
                    ,@ID_SKIM,@ID_TEMA_UNIVERSITAS,6,@JENIS
                    ,@JUDUL,@LOKASI,@NPP,@NPP1,@NPP2,@AWAL,@AKHIR,@IS_CHECKED,0,1,1
                    --,@NPP_REVIEWER,@REVIEWER1,@REVIEWER2,@IS_SETUJU_LPPM
                    ,@BEBAN_SKS,@BEBAN_SKS_ANGGOTA,@DANA_USUL,@DANA_PRIBADI,@DANA_EKSTERNAL
                    ,@DANA_KERJASAMA,@DANA_UAJY,@DANA_SETUJU--,@DOKUMEN,@LEMBAR_PENGESAHAN
                    ,@KEYWORD,@JARAK_KAMPUS_KM,@JARAK_KAMPUS_JAM,@OUTCOME,@LONGITUDE,@LATITUDE
                    ,@INSERT_DATE,@IP_ADDRESS,@USER_ID,@KETERANGAN_DANA_EKSTERNAL)";

                cmd = new SqlCommand(query, sqlConn);
                cmd.Transaction = transaction;

                if (pen.KETERANGAN_DANA_EKSTERNAL == null)
                    cmd.Parameters.AddWithValue("@KETERANGAN_DANA_EKSTERNAL", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@KETERANGAN_DANA_EKSTERNAL", pen.KETERANGAN_DANA_EKSTERNAL);
                if (pen.ID_TAHUN_ANGGARAN == null)
                    cmd.Parameters.AddWithValue("@ID_TAHUN_ANGGARAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TAHUN_ANGGARAN", pen.ID_TAHUN_ANGGARAN);

                if (pen.NPP == null)
                    cmd.Parameters.AddWithValue("@NO_SEMESTER", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NO_SEMESTER", pen.NO_SEMESTER);

                if (pen.ID_KATEGORI == null)
                    cmd.Parameters.AddWithValue("@ID_KATEGORI", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_KATEGORI", pen.ID_KATEGORI);

                if (pen.ID_ROAD_MAP_PENELITIAN == null)
                    cmd.Parameters.AddWithValue("@ID_ROAD_MAP_PENELITIAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_ROAD_MAP_PENELITIAN", pen.ID_ROAD_MAP_PENELITIAN);

                if (pen.ID_SKIM == null)
                    cmd.Parameters.AddWithValue("@ID_SKIM", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_SKIM", pen.ID_SKIM);

                if (pen.ID_TEMA_UNIVERSITAS == null)
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_TEMA_UNIVERSITAS", pen.ID_TEMA_UNIVERSITAS);

                if (pen.ID_STATUS_PENELITIAN == null)
                    cmd.Parameters.AddWithValue("@ID_STATUS_PENELITIAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ID_STATUS_PENELITIAN", pen.ID_STATUS_PENELITIAN);

                if (pen.JENIS == null)
                    cmd.Parameters.AddWithValue("@JENIS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@JENIS", pen.JENIS);

                if (pen.JUDUL == null)
                    cmd.Parameters.AddWithValue("@JUDUL", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@JUDUL", pen.JUDUL);

                if (pen.LOKASI == null)
                    cmd.Parameters.AddWithValue("@LOKASI", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LOKASI", pen.LOKASI);

                if (pen.NPP == null)
                    cmd.Parameters.AddWithValue("@NPP", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NPP", pen.NPP);

                if (pen.NPP1 == null)
                    cmd.Parameters.AddWithValue("@NPP1", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NPP1", pen.NPP1);

                if (pen.NPP2 == null)
                    cmd.Parameters.AddWithValue("@NPP2", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@NPP2", pen.NPP2);


                if (pen.AWAL == null)
                    cmd.Parameters.AddWithValue("@AWAL", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@AWAL", pen.AWAL);

                if (pen.AKHIR == null)
                    cmd.Parameters.AddWithValue("@AKHIR", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@AKHIR", pen.AKHIR);

                if (pen.IS_CHECKED == null)
                    cmd.Parameters.AddWithValue("@IS_CHECKED", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@IS_CHECKED", pen.IS_CHECKED);

                if (pen.BEBAN_SKS == null)
                    cmd.Parameters.AddWithValue("@BEBAN_SKS", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@BEBAN_SKS", pen.BEBAN_SKS);

                if (pen.BEBAN_SKS_ANGGOTA == null)
                    cmd.Parameters.AddWithValue("@BEBAN_SKS_ANGGOTA", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@BEBAN_SKS_ANGGOTA", pen.BEBAN_SKS_ANGGOTA);

                if (pen.DANA_USUL == null)
                    cmd.Parameters.AddWithValue("@DANA_USUL", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DANA_USUL", pen.DANA_USUL);

                if (pen.DANA_PRIBADI == null)
                    cmd.Parameters.AddWithValue("@DANA_PRIBADI", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DANA_PRIBADI", pen.DANA_PRIBADI);

                if (pen.DANA_EKSTERNAL == null)
                    cmd.Parameters.AddWithValue("@DANA_EKSTERNAL", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DANA_EKSTERNAL", pen.DANA_EKSTERNAL);

                if (pen.DANA_KERJASAMA == null)
                    cmd.Parameters.AddWithValue("@DANA_KERJASAMA", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DANA_KERJASAMA", pen.DANA_KERJASAMA);

                if (pen.DANA_UAJY == null)
                    cmd.Parameters.AddWithValue("@DANA_UAJY", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DANA_UAJY", pen.DANA_UAJY);

                if (pen.DANA_SETUJU == null)
                    cmd.Parameters.AddWithValue("@DANA_SETUJU", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DANA_SETUJU", pen.DANA_SETUJU);
                if (pen.DOKUMEN == null)
                    cmd.Parameters.AddWithValue("@DOKUMEN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DOKUMEN", pen.DOKUMEN);

                if (pen.LEMBAR_PENGESAHAN == null)
                    cmd.Parameters.AddWithValue("@LEMBAR_PENGESAHAN", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@LEMBAR_PENGESAHAN", pen.LEMBAR_PENGESAHAN);

                cmd.Parameters.AddWithValue("@KEYWORD", pen.KEYWORD);
                cmd.Parameters.AddWithValue("@JARAK_KAMPUS_JAM", pen.JARAK_KAMPUS_JAM);
                cmd.Parameters.AddWithValue("@JARAK_KAMPUS_KM", pen.JARAK_KAMPUS_KM);
                cmd.Parameters.AddWithValue("@OUTCOME", pen.OUTCOME);
                cmd.Parameters.AddWithValue("@LONGITUDE", pen.LONGITUDE);
                cmd.Parameters.AddWithValue("@LATITUDE", pen.LATITUDE);
                cmd.Parameters.AddWithValue("@INSERT_DATE", pen.INSERT_DATE);
                cmd.Parameters.AddWithValue("@IP_ADDRESS", pen.IP_ADDRESS);
                cmd.Parameters.AddWithValue("@USER_ID", pen.USER_ID);
                int ID_PROPOSAL = Int32.Parse(cmd.ExecuteScalar().ToString());

                string insertRAB = @"insert into silppm.TBL_RAB_PENELITIAN ([ID_PROPOSAL],[ID_PENGELUARAN_RAB],JUMLAH_DANA,PERSENTASE)
                    SELECT  @ID_PROPOSAL ,[ID_PENGELUARAN_RAB], 0 JUMLAH_DANA,0 FROM  silppm.REF_PENGELUARAN_RAB";

                cmd = new SqlCommand(insertRAB, sqlConn);
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@ID_PROPOSAL", ID_PROPOSAL);
                cmd.ExecuteScalar();
                insertAnggotaPenelitian(ID_PROPOSAL.ToString(), pen.NPP);
                transaction.Commit();

                return ID_PROPOSAL;
            }
            catch (Exception e)
            {

                transaction.Rollback();
                return 0;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public bool RevisiPenelitian1(PropPen pen, string id)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN set JENIS=@Jenis,IS_CHECKED=0,REVIEWER1='null',JUDUL=@Judul,keyword=@katakunci,ID_KATEGORI=@Kategori,LOKASI=@Lokasi,BEBAN_SKS=@Beban_sks,ID_STATUS_PENELITIAN=1,DANA_USUL=@Dana_usul,dana_pribadi=@dana_pribadi,awal=@awal,akhir=@akhir,dokumen=@dokumen,IS_DROPPED=0,JARAK_KAMPUS_KM=@jarakKM,JARAK_KAMPUS_JAM=@jarakJam,ID_ROAD_MAP_PENELITIAN=@sesuaiUnit,Outcome=@sesuaiRecord,NPP1=@anggota1,NPP2=@anggota2 where ID_PROPOSAL=@id;";
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Jenis", pen.ID_jenis);
                cmd.Parameters.AddWithValue("@ID_Sumber", pen.Cek_Rev);
                cmd.Parameters.AddWithValue("@Judul", pen.Judul);
                cmd.Parameters.AddWithValue("@katakunci", pen.Keyword);
                cmd.Parameters.AddWithValue("@Kategori", pen.Kategori);
                cmd.Parameters.AddWithValue("@Lokasi", pen.Lokasi);
                cmd.Parameters.AddWithValue("@Beban_sks", pen.Sks);
                cmd.Parameters.AddWithValue("@Dana_usul", pen.Dana);
                cmd.Parameters.AddWithValue("@awal", pen.Awal);
                cmd.Parameters.AddWithValue("@akhir", pen.Akhir);
                cmd.Parameters.AddWithValue("@dokumen", pen.Dokumen);
                cmd.Parameters.AddWithValue("@jarakKM", pen.JarakKM);
                cmd.Parameters.AddWithValue("@jarakJam", pen.JarakJAM);
                cmd.Parameters.AddWithValue("@sesuaiUnit", pen.SesuaiUnit);
                cmd.Parameters.AddWithValue("@sesuaiRecord", pen.Outcome);
                ;
                cmd.Parameters.AddWithValue("@anggota1", pen.Anggota1);
                cmd.Parameters.AddWithValue("@anggota2", pen.Anggota2);
                cmd.Parameters.AddWithValue("@dana_pribadi", pen.DanaPribadi);
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

        }//not sure, status
        public bool RevisiPenelitian2(PropPen pen, string id)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN set JENIS=@Jenis,cek_rev=0,REVIEWER2='NULL',JUDUL=@Judul,keyword=@katakunci,KATEGORI=@Kategori,LOKASI=@Lokasi,BEBAN_SKS=@Beban_sks,STATUS_APPROVAL='Menunggu Review 2',DANA_USUL=@Dana_usul,dana_pribadi=@dana_pribadi,awal=@awal,akhir=@akhir,dokumen=@dokumen,IS_DROPPED=0,jarakKampusKM=@jarakKM,jarakKampusJam=@jarakJam,sesuaiRencanaUnit=@sesuaiUnit,Outcome=@sesuaiRecord,anggota1=@anggota1,anggota2=@anggota2 where ID_PROPOSAL=@id;";
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Jenis", pen.ID_jenis);
                cmd.Parameters.AddWithValue("@ID_Sumber", pen.Cek_Rev);
                cmd.Parameters.AddWithValue("@Judul", pen.Judul);
                cmd.Parameters.AddWithValue("@katakunci", pen.Keyword);
                cmd.Parameters.AddWithValue("@Kategori", pen.Kategori);
                cmd.Parameters.AddWithValue("@Lokasi", pen.Lokasi);
                cmd.Parameters.AddWithValue("@Beban_sks", pen.Sks);
                cmd.Parameters.AddWithValue("@Dana_usul", pen.Dana);
                cmd.Parameters.AddWithValue("@awal", pen.Awal);
                cmd.Parameters.AddWithValue("@akhir", pen.Akhir);
                cmd.Parameters.AddWithValue("@dokumen", pen.Dokumen);
                cmd.Parameters.AddWithValue("@jarakKM", pen.JarakKM);
                cmd.Parameters.AddWithValue("@jarakJam", pen.JarakJAM);
                cmd.Parameters.AddWithValue("@sesuaiUnit", pen.SesuaiUnit);
                cmd.Parameters.AddWithValue("@sesuaiRecord", pen.Outcome);

                cmd.Parameters.AddWithValue("@anggota1", pen.Anggota1);
                cmd.Parameters.AddWithValue("@anggota2", pen.Anggota2);
                cmd.Parameters.AddWithValue("@dana_pribadi", pen.DanaPribadi);
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

        }//not sure, status
        public string getusernameByIDProposal(string id)
        {
            try
            {
                string query = "select d.username from silppm.TBL_PENELITIAN p join simka.MST_KARYAWAN d on d.NPP=p.NPP where ID_PROPOSAL = '" + id + "' ";

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

        public DataTable getTemaPenelitian(int idprodi)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "select ID_ROAD_MAP_PENELITIAN,DESKRIPSI from silppm.REF_ROAD_MAP_PENELITIAN where IS_DELETED=0 and ID_UNIT_AKADEMIK =" + idprodi + "";
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

        public DataTable getOutput()
        {
            try
            {

                DataTable dt = new DataTable();
                string query = "select ID_OUTPUT, DESKRIPSI from silppm.REF_OUTPUT";
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

        public bool getOutputByPenelitian(string id_proposal, string id_output)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT      ID_PROPOSAL, ID_OUTPUT 
FROM            silppm.TBL_OUTPUT_PENELITIAN
WHERE   ID_PROPOSAL  = '" + id_proposal + "' and   ID_OUTPUT = '" + id_output + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
                //reader.Close();
            }
        }

        public bool insertOutput(int id_proposal, string id_output)
        {
            string query = @"
if not exists (SELECT ID_PROPOSAL 
FROM silppm.TBL_OUTPUT_PENELITIAN
WHERE   ID_PROPOSAL  =@ID_PROPOSAL and ID_OUTPUT=@ID_OUTPUT)
            INSERT INTO [silppm].[TBL_OUTPUT_PENELITIAN]
            (ID_PROPOSAL, ID_OUTPUT)
            VALUES (@ID_PROPOSAL, @ID_OUTPUT)";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_PROPOSAL", id_proposal);
                dbManager.AddParameters(1, "@ID_OUTPUT", id_output);

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
        public bool deleteOutput(int id_proposal, string id_output)
        {
            string query = @"delete 
FROM silppm.TBL_OUTPUT_PENELITIAN
WHERE   ID_PROPOSAL  =@ID_PROPOSAL and ID_OUTPUT=@ID_OUTPUT";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_PROPOSAL", id_proposal);
                dbManager.AddParameters(1, "@ID_OUTPUT", id_output);

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

        public DataTable getOutcome(string @id)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT  ID_OUTCOME, ID_JENIS_OUTCOME, DESKRIPSI
                FROM silppm.REF_OUTCOME WHERE  ID_JENIS_OUTCOME = '" + @id + "' and IS_DELETED='false'";
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

        public bool getOUTCOMEByPenelitian(string id_proposal, string ID_OUTCOME)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT silppm.TBL_OUTCOME_PENELITIAN.ID_PROPOSAL, silppm.TBL_OUTCOME_PENELITIAN.ID_OUTCOME
FROM            silppm.REF_OUTCOME INNER JOIN
                         silppm.TBL_OUTCOME_PENELITIAN ON silppm.REF_OUTCOME.ID_OUTCOME = silppm.TBL_OUTCOME_PENELITIAN.ID_OUTCOME
WHERE   TBL_OUTCOME_PENELITIAN.ID_PROPOSAL  = '" + id_proposal + "' and   TBL_OUTCOME_PENELITIAN.ID_OUTCOME = '" + ID_OUTCOME + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
                //reader.Close();
            }
        }

        public bool insertOutcome(int id_proposal, string ID_OUTCOME, string ID_JENIS_OUTCOME)
        {
            string query = @"
if not exists (SELECT ID_PROPOSAL 
FROM silppm.TBL_OUTCOME_PENELITIAN
WHERE   ID_PROPOSAL  =@ID_PROPOSAL and ID_OUTCOME=@ID_OUTCOME)
            INSERT INTO [silppm].[TBL_OUTCOME_PENELITIAN]
            (ID_PROPOSAL, ID_OUTCOME)
            VALUES (@ID_PROPOSAL, @ID_OUTCOME)";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_PROPOSAL", id_proposal);
                dbManager.AddParameters(1, "@ID_OUTCOME", ID_OUTCOME);

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
        public bool deleteOutcome(int id_proposal, string ID_OUTCOME)
        {
            string query = @"
delete FROM silppm.TBL_OUTCOME_PENELITIAN
WHERE   ID_PROPOSAL  =@ID_PROPOSAL and ID_OUTCOME=@ID_OUTCOME";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(2);
                dbManager.AddParameters(0, "@ID_PROPOSAL", id_proposal);
                dbManager.AddParameters(1, "@ID_OUTCOME", ID_OUTCOME);

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

        public DataTable getOutcome(int jenis)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"SELECT        silppm.REF_OUTCOME.ID_OUTCOME, silppm.REF_OUTCOME.DESKRIPSI, silppm.REF_JENIS_OUTCOME.DESKRIPSI AS JENIS
FROM            silppm.REF_OUTCOME INNER JOIN
                         silppm.REF_JENIS_OUTCOME ON silppm.REF_OUTCOME.ID_JENIS_OUTCOME = silppm.REF_JENIS_OUTCOME.ID_JENIS_OUTCOME
WHERE        (silppm.REF_OUTCOME.ID_JENIS_OUTCOME = '" + jenis + "')";
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



        public DataTable getKategori()
        {
            string query = @"SELECT [ID_KATEGORI]  id ,[DESKRIPSI] FROM [silppm].[REF_KATEGORI]
                where [DESKRIPSI] is not null";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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
        public DataTable getTema()
        {
            string query = @"SELECT ID_TEMA_UNIVERSITAS id ,[DESKRIPSI] FROM silppm.REF_TEMA_UNIVERSITAS ";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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
        public DataTable getJenisPenelitian()
        {
            string query = @"SELECT [ID_JENIS_PENELITIAN]
                          ,[JENIS_PENELITIAN]
                      FROM [SIATMAX].[silppm].[REF_JENIS_PENELITIAN] ";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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
        public DataTable getSkim()
        {
            string query = @"SELECT [ID_SKIM] id ,[DESKRIPSI] FROM [silppm].[REF_SKIM]";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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

        public DataTable getLevelSeminar()
        {
            string query = @"SELECT [ID_LEVEL_SEMINAR] id ,[LEVEL] FROM [silppm].[REF_LEVEL_SEMINAR]";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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

        public DataTable getLevelJurnal()
        {
            string query = @"SELECT [ID_LEVEL_JURNAL] id ,[LEVEL] FROM [silppm].[REF_LEVEL_JURNAL]";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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

        public DataTable getJustifikasinilai(int idKriteria)
        {
            string query = @"SELECT [ID_SKOR]
              ,[ID_KRITERIA_PENILAIAN]
              ,[RANGE_AWAL]
              ,[RANGE_AKHIR]
              ,[DESKRIPSI]
              ,[SKOR]
          FROM [silppm].[TBL_SKOR_KRITERIA_PENILAIAN] where [ID_KRITERIA_PENILAIAN] ='" + idKriteria + "'";
            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
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
        ///////////////////////////
        //        public bool addProposalLolos(string id, int rekomen, double pajak, int isSelesai)
        //        {
        //            try
        //            {
        //                //int tmpcount = getMaxCount() + 1;

        //                //int droptmp = 0;
        //                if (sqlConn.State == ConnectionState.Closed)
        //                    sqlConn.Open();

        //                string query = @"insert into silppm.TBL_PENELITIAN_LOLOS (
        //ID_PROPOSAL ,NPP,JENIS,ID_TAHUN_ANGGARAN,IS_CHECKED,REVIEWER1,REVIEWER2,JUDUL,ID_KATEGORI,
        //LOKASI,BEBAN_SKS,ID_STATUS_PENELITIAN,DANA_USUL,AWAL,AKHIR,DOKUMEN,IS_DROPPED,KEYWORD,JARAK_KAMPUS_KM,
        //JARAK_KAMPUS_JAM,ID_ROAD_MAP_PENELITIAN,OUTCOME,DANA_PRIBADI,LONGITUDE,LATITUDE,NPP1,NPP2,IS_SETUJU_PRODI,
        //IS_SETUJU_DEKAN,BEBAN_SKS_ANGGOTA,IS_SETUJU_LPPM,NPP_REVIEWER,DANA_SETUJU,PAJAK,DANA_REKOMEN
        //,LAPORAN,IS_SETUJU_PUSTAKAWAN,IS_SELESAI,LAPORAN1,INSERT_DATE,IP_ADDRESS,USER_ID)
        //select ID_PROPOSAL,NPP,JENIS,ID_TAHUN_ANGGARAN,IS_CHECKED,REVIEWER1,REVIEWER2,JUDUL,ID_KATEGORI,
        //LOKASI,BEBAN_SKS,ID_STATUS_PENELITIAN,DANA_USUL,AWAL,AKHIR,DOKUMEN,IS_DROPPED,KEYWORD,JARAK_KAMPUS_KM,
        //JARAK_KAMPUS_JAM,ID_ROAD_MAP_PENELITIAN,OUTCOME,DANA_PRIBADI,LONGITUDE,LATITUDE,NPP1,NPP2,IS_SETUJU_PRODI,
        //IS_SETUJU_DEKAN,BEBAN_SKS_ANGGOTA,IS_SETUJU_LPPM,NPP_REVIEWER,DANA_SETUJU," + pajak
        //+ "," + rekomen + ",NULL,NULL," + isSelesai
        //+ ",NULL,getdate(),NULL,NULL from silppm.TBL_PENELITIAN where ID_PROPOSAL ='" + id + "'";
        //                cmd = new SqlCommand(query, sqlConn);

        //                cmd.ExecuteNonQuery();


        //                return true;
        //            }
        //            catch (Exception e)
        //            {

        //                return false;
        //            }
        //            finally
        //            {
        //                sqlConn.Close();
        //            }

        //        }


        public bool addProposalLolos(string id,int isSelesai)
        {
            try
            {
                //int tmpcount = getMaxCount() + 1;

                //int droptmp = 0;
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = @"insert into silppm.TBL_PENELITIAN_LOLOS (
ID_PROPOSAL ,NPP,JENIS,ID_TAHUN_ANGGARAN,IS_CHECKED,REVIEWER1,REVIEWER2,JUDUL,ID_KATEGORI,
LOKASI,BEBAN_SKS,ID_STATUS_PENELITIAN,DANA_USUL,AWAL,AKHIR,DOKUMEN,IS_DROPPED,KEYWORD,JARAK_KAMPUS_KM,
JARAK_KAMPUS_JAM,ID_ROAD_MAP_PENELITIAN,OUTCOME,DANA_PRIBADI,LONGITUDE,LATITUDE,NPP1,NPP2,IS_SETUJU_PRODI,
IS_SETUJU_DEKAN,BEBAN_SKS_ANGGOTA,IS_SETUJU_LPPM,NPP_REVIEWER,DANA_SETUJU,PAJAK,DANA_REKOMEN
,LAPORAN,IS_SETUJU_PUSTAKAWAN,IS_SELESAI,LAPORAN1,INSERT_DATE,IP_ADDRESS,USER_ID)
select ID_PROPOSAL,NPP,JENIS,ID_TAHUN_ANGGARAN,IS_CHECKED,REVIEWER1,REVIEWER2,JUDUL,ID_KATEGORI,
LOKASI,BEBAN_SKS,ID_STATUS_PENELITIAN,DANA_USUL,AWAL,AKHIR,DOKUMEN,IS_DROPPED,KEYWORD,JARAK_KAMPUS_KM,
JARAK_KAMPUS_JAM,ID_ROAD_MAP_PENELITIAN,OUTCOME,DANA_PRIBADI,LONGITUDE,LATITUDE,NPP1,NPP2,IS_SETUJU_PRODI,
IS_SETUJU_DEKAN,BEBAN_SKS_ANGGOTA,IS_SETUJU_LPPM,NPP_REVIEWER,DANA_SETUJU,NULL,NULL," + isSelesai
+ ",NULL,getdate(),NULL,NULL from silppm.TBL_PENELITIAN where ID_PROPOSAL ='" + id + "'";
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
        public string getNamaDosenbyIDProposal_Penelitian(string uname)
        {
            try
            {
                string query = "select d.NAMA from silppm.TBL_PENELITIAN p join simka.MST_KARYAWAN d on d.NPP=p.NPP where p.ID_PROPOSAL = '" + uname + "' ";
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
        }//udah
        public string getNppDosenbyIDProposal_Penelitian(string uname)
        {
            try
            {
                string query = "select d.NPP from silppm.TBL_PENELITIAN p join simka.MST_KARYAWAN d on d.NPP=p.NPP where ID_PROPOSAL = '" + uname + "' ";
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
        }//udah

        public string getNPPbyNama(string uname)
        {
            try
            {
                string query = "select NPP from Simka.MST_KARYAWAN where NAMA = '" + uname + "' ";
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
        }//udah
        public string getJenisPenelitianByID(string id)
        {
            try
            {
                string query = "select k.detail_pelaku from silppm.TBL_PENELITIAN p join silppm.REF_KATEGORI k on p.ID_KATEGORI=k.ID_KATEGORI where p.ID_PROPOSAL = '" + id + "' and p.IS_DROPPED=0";
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
        }//not sure, dropped
        public string getJenisByID(string id)
        {
            try
            {
                string query = "select jenis from silppm.TBL_PENELITIAN where ID_PROPOSAL = '" + id + "'";
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
        }//udah
        public string getStatusPenelitianByID(string id)
        {
            try
            {
                string query = "select r.DESKRIPSI from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN r on r.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN where ID_PROPOSAL = '" + id + "' and IS_DROPPED=0";
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
        }//no, tambah join ke ref
        //public string getNPPReviewerNama(string nama)
        //{
        //    try
        //    {
        //        string query = "select ID_REVIEWER from MST_REVIEWER where NAMA_REVIEWER = '" + nama + "'";
        //        if (sqlConn.State.ToString() != "Open")
        //            sqlConn.Open();
        //        cmd = new SqlCommand(query, sqlConn);
        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            string temp = reader.GetValue(0).ToString();
        //            return temp;
        //            //return reader.GetInt32(0);
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        sqlConn.Close();
        //        reader.Close();
        //    }
        //}
        public bool ReviewProposalPenelitian(string id, string reviewer)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN set REVIEWER1=@ID_Rev where ID_PROPOSAL=@ID_Prop;";
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

        }//udah
        public bool ReviewProposalPenelitian2(string id, string reviewer)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN set REVIEWER2=@ID_Rev where ID_PROPOSAL=@ID_Prop;";
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

        }//udah
        public bool UpdateStatusDiterima(string id)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN set ID_STATUS_PENELITIAN=14 where ID_PROPOSAL=@ID_Prop;";
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

        }//reff, join , ntar dulu
        public bool UpdateStatusMenungguReview2(string id)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update TBL_PENELITIAN set ID_STATUS_PENELITIAN=7 where ID_PROPOSAL=@ID_Prop;";

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
        public bool UpdateLaporanTahap1(string id, object laporan)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN_LOLOS set laporan1=@laporan where ID_PROPOSAL=@ID_Prop;";
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
        public bool uploadOutcome(string id, object laporan)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN_LOLOS set FILE_OUTCOME=@laporan where ID_PROPOSAL=@ID_Prop;";
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

        public bool UpdateLaporanOutcome(string id, object laporan)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN_LOLOS set FILE_OUTCOME=@laporan where ID_PROPOSAL=@ID_Prop;";
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

        public bool UpdateLaporan(string id, object laporan)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.TBL_PENELITIAN_LOLOS set laporan=@laporan where ID_PROPOSAL=@ID_Prop;";
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
        public bool CekLaporanTahap1(string id)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "select laporan1 from silppm.TBL_PENELITIAN_LOLOS where ID_PROPOSAL='" + id + "'";
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
        public bool CekPerkembanganMonev(string id, string npp)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "select ID_PROPOSAL,NPP from silppm.TBL_LAP_MONEV_PENELITIAN where ID_PROPOSAL='" + id + "' and NPP ='" + npp + "'";
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

                string query = "select laporan from silppm.TBL_PENELITIAN_LOLOS where ID_PROPOSAL='" + id + "'";
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
        public string[] getSbrDana()
        {
            try
            {
                string query = "select distinct NAMA_INSTANSI from REF_SUMBER_DANA ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                adapter.Fill(dataset1);
                int length1 = dataset1.Tables[0].Rows.Count;
                if (length1 > 0)
                {
                    string[] arr1 = new string[length1];
                    for (int i = 0; i < length1; i++)
                    {
                        arr1[i] = dataset1.Tables[0].Rows[i][0].ToString();
                    }
                    return arr1;
                }
                else
                {
                    return null;
                }

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
        public byte[] getPengesahanPenelitian(string index)
        {
            try
            {
                string query = @"select LEMBAR_PENGESAHAN from silppm.TBL_PENELITIAN where dokumen is not null
                    and id_proposal= '" + index + "' ;";
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
        public byte[] getPropsalPenelitian(string index)
        {
            try
            {
                string query = @"select dokumen from silppm.TBL_PENELITIAN where dokumen is not null
                    and id_proposal= '" + index + "' ;";
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
        public byte[] getLaporanPenelitian(string index)
        {
            try
            {
                string query = "select laporan from silppm.TBL_PENELITIAN_LOLOS where id_proposal= '" + index + "' ";
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
        public byte[] getDraftPenelitian(string index)
        {
            try
            {
                string query = "select laporan1 from silppm.TBL_PENELITIAN_LOLOS where id_proposal= '" + index + "' ";
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
                string query = "select no_update from silppm.tbl_lap_monev_penelitian where id_proposal=" + numb + "";
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
        }//udah
        public byte[] getMONEVPenelitian(string index, int no)
        {
            try
            {
                string query = "select KETERANGAN from silppm.TBL_LAP_MONEV_penelitian where id_proposal= '" + index + "' and no_update = " + no + " ;";
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
        public DataSet getDataProposal(string id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select d.id_proposal,d.Judul,s.DESKRIPSI from silppm.TBL_PENELITIAN d join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=d.ID_STATUS_PENELITIAN where d.NPP= '" + id + "' and IS_DROPPED=0 ;";
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
        }//ada status
        public DataTable getAllDataProposal(string npp)//ada status, ID KATEGORI, IS_ADMIN_CHECK
        {
            string query = @"select p.id_proposal,p.Judul,r.DESKRIPSI,k.KATEGORI,
                k.DETAIL_PELAKU,p.lokasi,p.akhir,p.dana_usul 
                from silppm.TBL_PENELITIAN p join 
                silppm.REF_KATEGORI k on k.ID_KATEGORI=p.ID_KATEGORI join 
                silppm.REF_STATUS_PENELITIAN_PENGABDIAN r  on r.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN 
                where p.IS_SETUJU_PRODI=1 and IS_SETUJU_DEKAN=1 -- and p.IS_DROPPED=0 
                and p.IS_CHECKED=0 --and (REVIEWER1 is null  or REVIEWER2 is null ) 
                
and (REVIEWER1 = @npp  or REVIEWER2 = @npp )
                and p.id_proposal not in( select ID_PROPOSAL 
                    FROM silppm.TBL_NILAI_REVIEW_PENELITIAN where ID_REVIEWER = @npp)
/**/
                ";


            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@NPP", npp);
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
        public DataTable getAllDataProposalBy_IDProposal(string id)//ada status, ID KATEGORI, IS_ADMIN_CHECK
        {
            string query = @"select p.id_proposal,p.Judul,r.DESKRIPSI,k.KATEGORI,
                k.DETAIL_PELAKU,p.lokasi,p.akhir,p.dana_usul 
                from silppm.TBL_PENELITIAN p join 
                silppm.REF_KATEGORI k on k.ID_KATEGORI=p.ID_KATEGORI join 
                silppm.REF_STATUS_PENELITIAN_PENGABDIAN r  on r.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN 
                where p.IS_SETUJU_PRODI=1 and IS_SETUJU_DEKAN=1 -- and p.IS_DROPPED=0 
                and p.IS_CHECKED=0 --and (REVIEWER1 is null  or REVIEWER2 is null ) 
                
and  p.id_proposal = @id 
/**/
                ";


            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@id", id);
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
        public DataSet getAllDataProposalByIDProposal(string id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = @"select p.id_proposal,p.Judul,r.DESKRIPSI,k.KATEGORI,k.DETAIL_PELAKU,
                    p.lokasi,p.akhir,p.dana_usul from silppm.TBL_PENELITIAN p join silppm.REF_KATEGORI k 
                    on k.ID_KATEGORI=p.ID_KATEGORI join silppm.REF_STATUS_PENELITIAN_PENGABDIAN r 
                    on r.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN where id_proposal='" + id
                    + "'and IS_DROPPED=0 ;";
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
        }//ada status
        public DataSet getProdiDataProposalByIDProposal(string id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select * from silppm.TBL_PENELITIAN  where id_proposal='" + id + "'";
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
        public DataSet getJudulTerima(string id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = @"select e.id_proposal,e.Judul,s.DESKRIPSI 
from silppm.TBL_PENELITIAN_LOLOS e join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s 
on s.ID_STATUS_PENELITIAN=e.ID_STATUS_PENELITIAN where NPP= '" + id + "';";
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
        public DataSet getSemuaJudulTerima()
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select id_proposal,Judul from silppm.TBL_PENELITIAN_LOLOS where IS_SELESAI = 0";
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
        public DataSet getJudulTerimaByProdi(int subid)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select d.nama,p.id_proposal,p.Judul from silppm.TBL_PENELITIAN_LOLOS p join Simka.mst_karyawan d on d.npp=p.NPP where d.ID_UNIT_AKADEMIK=" + subid + " and p.IS_SELESAI!=1 ";
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
                DataSet dataset = new DataSet();
                string query = "select d.nama,p.id_proposal,p.Judul from silppm.TBL_PENELITIAN_LOLOS p join Simka.mst_karyawan d on d.npp=p.NPP where d.ID_UNIT = (Select ID_UNIT From siatmax.MST_UNIT where NPP ='" + subid + "' and IS_PALSU=0) and p.IS_SELESAI!=1";
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

        public void HideProposal(string id)
        {
            try
            {
                string query = "update silppm.TBL_PENELITIAN set IS_DROPPED = 1 where id_proposal ='" + id + "'";
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
        public string getjudulByID(string id)
        {
            try
            {
                string query = "select judul from silppm.TBL_PENELITIAN where id_proposal = '" + id + "' ";
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
        public string getIDREV1ByID(string id)
        {
            try
            {
                string query = "select REVIEWER1 from silppm.TBL_PENELITIAN where id_proposal = '" + id + "' ";
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
                string query = "select REVIEWER2 from silppm.TBL_PENELITIAN where id_proposal = '" + id + "' ";
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
        public bool cekEdit(string id_prop)
        {
            try
            {
                string query = @"select d.DESKRIPSI from silppm.TBL_PENELITIAN p join 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN d on d.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN 
                    where COALESCE(IS_LOCK,0) =0 AND id_proposal = '" + id_prop + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
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
        public bool updateStatusRevisi(int cek, string id_prop)
        {
            try
            {
                string query = "update silppm.TBL_Penelitian set IS_CHECKED=" + cek + ",ID_STATUS_PENELITIAN=10 where id_proposal = '" + id_prop + "' ";
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
        }//ada statusnya
        public bool updateStatusDITOLAK(int cek, string id_prop)
        {
            try
            {
                string query = "update silppm.TBL_Penelitian set IS_CHECKED=" + cek + ",ID_STATUS_PENELITIAN=11,IS_DROPPED=1 where id_proposal = '" + id_prop + "' ";
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
        //ubah tipe dari int ke bit
        public string getawalPeriode()
        {
            try
            {
                string query = "select awal from silppm.REF_SCHEDULE where IS_LOCKED=0";
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
        public string getAkhirPeriode()
        {
            try
            {
                string query = "select akhir from silppm.REF_SCHEDULE where is_locked=0";
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
                string query = "select DISTINCT t.TAHUN_ANGGARAN from silppm.TBL_PENELITIAN p join silppm.REF_SCHEDULE s on s.ID_TAHUN_ANGGARAN=p.ID_TAHUN_ANGGARAN join sikeu.TBL_TAHUN_ANGGARAN t on t.ID_TAHUN_ANGGARAN=s.ID_TAHUN_ANGGARAN where p.ID_PROPOSAL='" + id + "'";
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
        public DataTable getListPeriode()
        {
            try
            {
                DataTable dt = new DataTable();
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
        }//udah

        public string getTemaPenelitian(string id)
        {
            try
            {
                string query = "select d.DESKRIPSI from silppm.TBL_PENELITIAN p join silppm.REF_ROAD_MAP_PENELITIAN d on d.ID_ROAD_MAP_PENELITIAN=p.ID_ROAD_MAP_PENELITIAN where p.ID_PROPOSAL='" + id + "'";
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

        public bool addPeriode(int id, string periode, DateTime awal, DateTime akhir)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.ref_schedule values ('" + id + "','" + awal + "','" + akhir + "','" + periode + "', 0);";
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

        }//ada periode
        public bool ResetPeriode()
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update silppm.ref_schedule set is_locked =1;";
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

        }//udah
        public int getMaxId()
        {
            try
            {
                string query = "select max(ID_SCHEDULE) from silppm.REF_SCHEDULE";
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
        //
        public DataSet getListLaporanPustaka()
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select p.id_proposal,p.Judul,d.nama, CASE WHEN p.IS_SETUJU_PUSTAKAWAN is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENELITIAN_LOLOS p join simka.Mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_PUSTAKAWAN is NULL";
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
        public DataSet getListLaporanDekan(int idDekan)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select p.id_proposal,p.Judul,d.nama, CASE WHEN p.IS_SETUJU_DEKAN is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENELITIAN p join simka.mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_DEKAN is NULL AND IS_SETUJU_PRODI=1 AND IS_DROPPED=0 and d.ID_UNIT=" + idDekan + "";
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
        public DataSet getListLaporanProdi(int idProdi)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = @"select p.id_proposal,p.Judul,d.nama, CASE WHEN p.IS_SETUJU_PRODI is NULL THEN 'Menunggu Konfirmasi' END 
AS Status  from silppm.TBL_PENELITIAN p join simka.mst_karyawan d on d.npp=p.NPP 
where -- p.IS_SETUJU_PRODI is NULL AND 
IS_DROPPED=0 and d.ID_UNIT_AKADEMIK=" + idProdi + "";
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
        public DataSet getListLaporanKALPPM()
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select p.id_proposal,p.Judul,d.nama, CASE WHEN p.IS_SETUJU_LPPM is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENELITIAN p join simka.mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_LPPM is NULL --AND REVIEWER1!='kosong' AND IS_DROPPED=0";
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
        public DataSet getListAdminKelolaReview()
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select p.id_proposal,p.Judul,d.nama from silppm.TBL_PENELITIAN p join simka.mst_karyawan d on d.npp=p.NPP where NPP_REVIEWER is NULL and IS_SETUJU_DEKAN=1 AND IS_SETUJU_PRODI=1";
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
                DataSet dataset = new DataSet();
                //DataSet dataset = new DataSet();
                string query = "select p.id_proposal,p.Judul,d.nama from silppm.TBL_PENELITIAN_LOLOS p join simka.mst_karyawan d on d.npp=p.NPP where IS_SETUJU_DEKAN=1 AND IS_SETUJU_PRODI=1 and IS_SELESAI!=1";
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
        //pustakawan
        public DataSet getDataPustaka(string id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select * from silppm.TBL_PENELITIAN_LOLOS where id_proposal ='" + id + "'";
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
                string query = "update silppm.TBL_Penelitian_lolos set IS_SETUJU_PUSTAKAWAN=1 , is_selesai=1 where id_proposal = '" + id_prop + "' ";
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
        public bool updatePustakaAppove(string id_prop)
        {
            try
            {
                string query = "update silppm.TBL_PENELITIAN_LOLOS set ID_STATUS_PENELITIAN=15 where id_proposal = '" + id_prop + "' ";
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

        //prodi
        public int getMaxIDFeedback()
        {
            try
            {
                string query = "select COUNT(*) from silppm.TBL_FEEDBACK_PENELITIAN";
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
        //feedback untuk semua belum diperbaiki
        public bool addfeedback(string tmpid, string npp, string feedback, DateTime tgl, string status)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_FEEDBACK_PENELITIAN values ('" + tmpid + "','" + npp + "','" + feedback + "','" + tgl + "','" + status + "');";
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
                DataSet dataset = new DataSet();
                string query = "select * from silppm.TBL_FEEDBACK_PENELITIAN f join [siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='Prodi' and f.ID_PROPOSAL = '" + id + "'";
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

        public bool updateProdi(int cek, string id_prop, int status)
        {
            try
            {
                string query = "update silppm.TBL_PENELITIAN set IS_SETUJU_PRODI=" + cek + ",ID_STATUS_PENELITIAN='" + status + "' where id_proposal = '" + id_prop + "' ";
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
                string query = "update silppm.TBL_PENELITIAN set DANA_SETUJU =" + dana + " where id_proposal ='" + id_prop + "' ";
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
        public Double getBiayaDisetujui(string id_prop)
        {
            try
            {
                string query = "select DANA_SETUJU from silppm.TBL_PENELITIAN where id_proposal='" + id_prop + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Double id;
                    Double.TryParse(reader.GetValue(0).ToString(), out id);
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

        public DataSet getProdiTemaPenelitian(int id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select ID_ROAD_MAP_PENELITIAN,DESKRIPSI from silppm.REF_ROAD_MAP_PENELITIAN where ID_UNIT_AKADEMIK=" + id + " and is_deleted=0";
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
                string query = "select COUNT(*) from silppm.ref_ROAD_MAP_penelitian";
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
        public bool addTema(int id_prodi, string detail)
        {
            int cek = getMaxIDTema() + 1;
            try
            {
                string query = "insert into silppm.ref_road_map_penelitian values(" + cek + "," + id_prodi + ",'" + detail + "',0) ";
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
            int cek = getMaxIDTema() + 1;
            try
            {
                string query = "update silppm.ref_road_map_penelitian set is_deleted=1 where id_road_map_penelitian='" + id_key + "'";
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

        public bool hapusProsiding(string id_prosiding)
        {
            int cek = getMaxIDTema() + 1;
            try
            {
                string query = "DELETE FROM [silppm].[TBL_PUBLIKASI_SEMINAR] WHERE [ID_OUTCOME_PROSIDING]='" + id_prosiding + "'";
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
        //feedback Dekan
        public bool updateDekan(int cek, string id_prop, int status)
        {
            try
            {
                string query = "update silppm.TBL_PENELITIAN set IS_SETUJU_DEKAN=" + cek + ",ID_STATUS_PENELITIAN='" + status + "' where id_proposal = '" + id_prop + "' ";
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
                DataSet dataset = new DataSet();
                string query = "select * from silppm.TBL_FEEDBACK_PENELITIAN f join [siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='Dekan' and f.ID_PROPOSAL = '" + id + "'";
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
        //KALPPM
        public DataSet getKALPPMDataProposalByIDProposal(string id)
        {
            try
            {
                string query = "select * from silppm.TBL_PENELITIAN_LOLOS  where id_proposal='" + id + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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
                string query = "update silppm.TBL_PENELITIAN set IS_SETUJU_LPPM=" + cek + ",ID_STATUS_PENELITIAN='" + status + "' where id_proposal = '" + id_prop + "' ";
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
        }//ada status
        public DataSet getFeedbackKALPPM(string id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "select * from silppm.TBL_FEEDBACK_PENELITIAN f join [siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='KALPPM' and f.ID_PROPOSAL = '" + id + "'";
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

        public DataSet getScheduleLogBook(string id)
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = "DECLARE @intFlag INT DECLARE @tes INT DECLARE @tes1 INT DECLARE @tes2 INT DECLARE @tes3 INT DECLARE @maxflag INT DECLARE @tmp varchar SET @intFlag = 1 SET @tes = (select MONTH(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='" + id + "') set @tes1 = (select DAY(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='" + id + "') set @tes2 = (select YEAR(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='" + id + "') set @tes3 = (select YEAR(AKHIR) from TBL_PENELITIAN where ID_PROPOSAL='" + id + "') IF(@tes2>=@tes3) WHILE (@intFlag <=(select MONTH(AKHIR)-MONTH(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='" + id + "')) BEGIN Insert into freetbl values (cast(@tes1 as varchar(2))+'-'+ cast((@tes+@intFlag) as varchar(2))+'-'+ cast(@tes2 as varchar(4))) SET @intFlag = @intFlag + 1 END ELSE IF(@tes2<@tes3) WHILE (@intFlag <=(select (MONTH(AKHIR)+12)-MONTH(AWAL)  from TBL_PENELITIAN where ID_PROPOSAL='" + id + "')) BEGIN IF(@tes+@intFlag <=12) Insert into freetbl values (cast(@tes1 as varchar(2))+'-'+ cast((@tes+@intFlag) as varchar(2))+'-'+ cast(@tes2 as varchar(4)))  IF(@tes+@intFlag <=12) SET @maxflag = @intFlag IF(@tes+@intFlag >12) Insert into freetbl values (cast(@tes1 as varchar(2))+'-'+ cast((@intFlag-@maxflag) as varchar(2))+'-'+ cast(@tes3 as varchar(4))) SET @intFlag = @intFlag + 1 END Select value from freetbl";
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
        public bool deletefreetbl()
        {
            try
            {
                string query = "delete freetbl";
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
        public DateTime getAwalProposal(string idp)
        {
            try
            {
                string query = "select AWAL from silppm.TBL_PENELITIAN_LOLOS Where id_proposal = '" + idp + "'";
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
                string query = "select Akhir from silppm.TBL_PENELITIAN_LOLOS Where id_proposal = '" + idp + "'";
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
        //review
        public int CekCountReview(string npp)
        {
            try
            {
                string query = "select Count(NPP) from silppm.TBL_MAPPING_PENELITIAN where npp = '" + npp + "'";
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
        public int CekCountReviewPenelitian(string npp)
        {
            try
            {
                string query = "select Count(IS_ADMIN_CHECK) from silppm.TBL_PENELITIAN where IS_ADMIN_CHECK = '" + npp + "'";
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
        public bool inputReview(string npp, string idProp)
        {
            try
            {
                string query = "insert into silppm.TBL_MAPPING_PENELITIAN values('" + idProp + "','" + npp + "')";
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
        public bool setReviewPenelitian(string npp, string npp2, string id_prop)
        {
            try
            {
                string query = @"update silppm.TBL_PENELITIAN set 
                REVIEWER2 = @REVIEWER2 , REVIEWER1=@REVIEWER1
                where id_proposal = @id_proposal ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.Add("@REVIEWER2", npp2);
                cmd.Parameters.Add("@REVIEWER1", npp);
                cmd.Parameters.Add("@id_proposal", id_prop);
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
                string query = "update silppm.TBL_PENELITIAN set NPP_REVIEWER = '" + npp + "' where id_proposal = '" + idProp + "'";
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
                string query = "select dana_setuju from silppm.tbl_penelitian_lolos where id_proposal = " + idprop + "";
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
        public bool PerpanjangPeriodePenelitian(string id_prop, int count, DateTime awal, DateTime akhir, DateTime insertDate, string ip, string userid)
        {
            try
            {
                string query = "insert into silppm.TBL_PERPANJANGAN_PENELITIAN values('" + id_prop + "'," + count + ",@awal,@akhir,@insDate,@ip,@userid)";
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
        public int getCountPerpanjanganPenelitian(string npp)
        {
            try
            {
                string query = "select count(id_proposal) from silppm.TBL_PERPANJANGAN_PENELITIAN where id_proposal = '" + npp + "'";
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
                DataSet dataset = new DataSet();
                string query = "select *,e.judul from silppm.TBL_PERPANJANGAN_PENELITIAN p join silppm.tbl_penelitian e on e.id_proposal=p.id_proposal where p.id_proposal = '" + id + "'";
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

        public DataSet getHistoryExec()
        {
            try
            {
                DataSet dataset = new DataSet();
                string query = @"select p.id_proposal,k.NAMA,p.JUDUL,s.DESKRIPSI,a.TAHUN_ANGGARAN,u.NAMA_UNIT AS 'FAK',
uu.NAMA_UNIT AS 'PRODI' from silppm.TBL_PENELITIAN p 
join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN 
join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN 
join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT 
join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT order by a.TAHUN_ANGGARAN";
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


        public DataSet getHstPenelitian(string npp)
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
                      where TBL_PERSONIL_PENELITIAN.NPP ='" + npp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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
        public DataSet getHstPenelitianfinal(string npp)
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
                      where TBL_PERSONIL_PENELITIAN.NPP ='" + npp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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
        public DataSet getPenelitianAll(string tahun, string npp)
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
                    where 1 = 1
                    ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                if (tahun != "-1")
                    query = query + " and TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK like '" + tahun + "'";
                if (npp != "")
                    query = query + " and TBL_PENELITIAN.npp like '%" + npp + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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

        public DataSet getPenelitian4setReviewer(string tahun, string npp)
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
                    where REVIEWER1 is null and REVIEWER2 is null
                    ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                if (tahun != "-1")
                    query = query + " and TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK like '" + tahun + "'";
                if (npp != "")
                    query = query + " and TBL_PENELITIAN.npp like '%" + npp + "%'";
                DataSet dataset = new DataSet();
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
        public DataSet getPenelitianReviewer(string tahun, string npp)
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
                    where REVIEWER1 is not null and REVIEWER2 is not null
                    ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                if (tahun != "-1")
                    query = query + " and TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK like '" + tahun + "'";
                if (npp != "")
                    query = query + " and TBL_PENELITIAN.npp like '%" + npp + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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
                string query = @"SELECT silppm.TBL_PENELITIAN.ID_PROPOSAL, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, siatmax.MST_UNIT.NAMA_UNIT AS 'FAK', MST_UNIT_1.NAMA_UNIT AS 'PRODI', 
                    siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK
                    FROM silppm.TBL_PENELITIAN INNER JOIN
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                    simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENELITIAN.NPP INNER JOIN
                    siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                    siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK
                    ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                if (tahun != "-1")
                    query = query + " where TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK like '" + tahun + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);
                DataSet dataset = new DataSet();
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
                string query = "select * from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT_AKADEMIK=u.ID_UNIT where k.ID_UNIT_AKADEMIK = (select ID_UNIT from siatmax.MST_UNIT where NPP='" + NppProdi + "')";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();

                DataSet dataset = new DataSet();
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

        public DataSet getHistoryProsiding(string npp)
        {
            try
            {
                string query = "select ps.ID_OUTCOME_PROSIDING,ps.JUDUL,r.LEVEL,ps.NAMA_JURNAL,ps.NAMA_JURNAL,ps.DOI,ps.ISSN from silppm.TBL_PUBLIKASI_SEMINAR ps  join silppm.TBL_PENELITIAN p on p.ID_PROPOSAL=ps.ID_PROPOSAL join silppm.REF_LEVEL_SEMINAR r on ps.ID_LEVEL_SEMINAR=r.ID_LEVEL_SEMINAR where p.NPP='" + npp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();

                DataSet dataset = new DataSet();
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
        public DataSet getHistoryJurnal(string npp)
        {
            try
            {
                string query = "select j.ID_OUTCOME_PUBLIKASI,j.JUDUL,r.LEVEL,j.NAMA_SEMINAR,j.DOI,j.ISSN from silppm.TBL_PUBLIKASI_JURNAL j  join silppm.TBL_PENELITIAN p on p.ID_PROPOSAL=J.ID_PROPOSAL join silppm.REF_LEVEL_JURNAL r on j.ID_LEVEL_JURNAL=r.ID_LEVEL_JURNAL where p.NPP='" + npp + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();

                DataSet dataset = new DataSet();
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
        public DataSet getHistoryProdiByTahunAnggaran(string NppProdi, string Tahun)
        {
            try
            {
                string query = @"SELECT siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, 
                silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI
                FROM silppm.TBL_PENELITIAN INNER JOIN
                silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENELITIAN.NPP INNER JOIN
                siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK
                where MST_KARYAWAN.ID_UNIT_AKADEMIK = (select ID_UNIT from siatmax.MST_UNIT where NPP='" + NppProdi + "') and TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK='" + Tahun + "'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                if (Tahun == "-1")
                {
                    query = @"SELECT siatmax.TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK, simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI
                    FROM silppm.TBL_PENELITIAN INNER JOIN
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                    simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENELITIAN.NPP INNER JOIN
                    siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK
                    where MST_KARYAWAN.ID_UNIT_AKADEMIK = (select ID_UNIT from siatmax.MST_UNIT where NPP='" + NppProdi + "')";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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
                string query = @"select k.NAMA,p.JUDUL,s.DESKRIPSI,a.TAHUN_ANGGARAN,uu.NAMA_UNIT 
from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT where k.ID_UNIT = (select ID_UNIT from siatmax.MST_UNIT where NPP= '" + NppFak + "' and IS_PALSU=0)";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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
        public DataSet getHistoryFakultasByTahunAnggaran(string NppFak, string Tahun)
        {
            try
            {
                string query = @"SELECT  TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK,simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, MST_UNIT_1.NAMA_UNIT
                FROM silppm.TBL_PENELITIAN INNER JOIN
                silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENELITIAN.NPP INNER JOIN
                siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK
                where MST_KARYAWAN.ID_UNIT = (select ID_UNIT from siatmax.MST_UNIT 
                where NPP= '" + NppFak + "' and IS_PALSU=0) and siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK = " + Tahun + "";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                if (Tahun == "Tampilkan Semua")
                {
                    query = @"SELECT TBL_TAHUN_AKADEMIK.TAHUN_AKADEMIK,simka.MST_KARYAWAN.NAMA, silppm.TBL_PENELITIAN.JUDUL, silppm.REF_STATUS_PENELITIAN_PENGABDIAN.DESKRIPSI, MST_UNIT_1.NAMA_UNIT
                    FROM silppm.TBL_PENELITIAN INNER JOIN
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN ON 
                    silppm.REF_STATUS_PENELITIAN_PENGABDIAN.ID_STATUS_PENELITIAN = silppm.TBL_PENELITIAN.ID_STATUS_PENELITIAN INNER JOIN
                    simka.MST_KARYAWAN ON simka.MST_KARYAWAN.NPP = silppm.TBL_PENELITIAN.NPP INNER JOIN
                    siatmax.MST_UNIT ON simka.MST_KARYAWAN.ID_UNIT = siatmax.MST_UNIT.ID_UNIT INNER JOIN
                    siatmax.MST_UNIT AS MST_UNIT_1 ON simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = MST_UNIT_1.ID_UNIT INNER JOIN
                    siatmax.TBL_TAHUN_AKADEMIK ON silppm.TBL_PENELITIAN.ID_TAHUN_ANGGARAN = siatmax.TBL_TAHUN_AKADEMIK.ID_TAHUN_AKADEMIK
                    where MST_KARYAWAN.ID_UNIT = (select ID_UNIT from siatmax.MST_UNIT 
                    where NPP= '" + NppFak + "' and IS_PALSU=0)";
                }
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConn);

                DataSet dataset = new DataSet();
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

        public bool cekPerpusSetuju(string idprop)
        {
            try
            {
                string query = "select IS_SETUJU_PUSTAKAWAN from silppm.TBL_PENELITIAN_LOLOS where id_proposal = '" + idprop + "'";
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
        public bool cekProdiSetuju(string idprop)
        {
            try
            {
                string query = "select IS_SETUJU_PRODI from silppm.TBL_PENELITIAN where id_proposal = '" + idprop + "'";
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
                string query = "select IS_SETUJU_DEKAN from silppm.TBL_PENELITIAN where id_proposal = '" + idprop + "'";
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
                string query = "select IS_SETUJU_LPPM from silppm.TBL_PENELITIAN where id_proposal = '" + idprop + "'";
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

        public bool cekPenelitianSelesai(string npp)
        {
            try
            {
                string query = "select IS_SELESAI from silppm.TBL_PENELITIAN_LOLOS where NPP = '" + npp + "' and IS_SELESAI = 0";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id;
                    int.TryParse(reader.GetValue(0).ToString(), out id);
                    if (id == 1)
                        return true;
                    else return false;
                }
                else
                    return true;

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