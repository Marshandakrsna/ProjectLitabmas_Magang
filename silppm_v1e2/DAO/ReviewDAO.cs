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

    public class ReviewDAO
    {
        private SqlConnection sqlConn;
        SqlCommand cmd;
        SqlDataReader reader;
        private Connection conn = new Connection();
        private DataTable dt = new DataTable();
        private DataSet dataset = new DataSet();
        private DataSet dataset1 = new DataSet();
        public ReviewDAO() {
            sqlConn = conn.getConnection();
        }
        //Get rakap nilai
        public DataTable getRekapNilai(string id)
        {
            string select = @"SELECT silppm.TBL_NILAI_PENELITIAN.ID_PROPOSAL, silppm.TBL_NILAI_PENELITIAN.nilai, silppm.TBL_NILAI_PENELITIAN.jumlah
                FROM silppm.TBL_NILAI_PENELITIAN INNER JOIN
                silppm.TBL_PENELITIAN ON silppm.TBL_NILAI_PENELITIAN.ID_PROPOSAL = silppm.TBL_PENELITIAN.ID_PROPOSAL
                WHERE (silppm.TBL_NILAI_PENELITIAN.ID_PROPOSAL = @ID_PROPOSAL)";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@ID_PROPOSAL", id);
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
        //public bool addNilaiPenelitian(string id, string rev,int ctRev, double N1Field1, double N1Field2, double N1Field3, double N1Field4, double N1Field5, double N1Field6, double N1Field7, string N1Jusifikasi1, string N1Jusifikasi2, string N1Jusifikasi3, string N1Jusifikasi4, string N1Jusifikasi5, string N1Jusifikasi6, string N1Jusifikasi7,int danaRekomen,int danaSetuju)
        //{
        //    try
        //    {
        //        if (sqlConn.State == ConnectionState.Closed)
        //            sqlConn.Open();

        //        string query = @"insert into silppm.TBL_NILAI_REVIEW_PENELITIAN
        //            ([ID_PROPOSAL],[ID_REVIEWER],[COUNT_REVISI],[N1_FIELD1],[N1_FIELD2],[N1_FIELD3],
        //            [N1_FIELD4],[N1_FIELD5],[N1_FIELD6],[N1_FIELD7],
        //            [N1_JUSTIFIKASI1],[N1_JUSTIFIKASI2],[N1_JUSTIFIKASI3],[N1_JUSTIFIKASI4],[N1_JUSTIFIKASI5]
        //            ,[N1_JUSTIFIKASI6],[N1_JUSTIFIKASI7],[DANA_REKOMENDASI],[DANA_SETUJU])
        //            values (@id,@rev,@ctRev,@N1Field1,@N1Field2,@N1Field3,@N1Field4,
        //            @N1Field5,@N1Field6,@N1Field7,@N1Jusifikasi1,@N1Jusifikasi2,@N1Jusifikasi3,
        //            @N1Jusifikasi4,@N1Jusifikasi5,@N1Jusifikasi6,@N1Jusifikasi7,@danaRekomen,@danaSetuju);";
        //        cmd = new SqlCommand(query, sqlConn);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        cmd.Parameters.AddWithValue("@rev", rev);
        //        cmd.Parameters.AddWithValue("@ctRev", ctRev);
        //        cmd.Parameters.AddWithValue("@N1Field1", N1Field1);
        //        cmd.Parameters.AddWithValue("@N1Field2", N1Field2);
        //        cmd.Parameters.AddWithValue("@N1Field3", N1Field3);
        //        cmd.Parameters.AddWithValue("@N1Field4", N1Field4);
        //        cmd.Parameters.AddWithValue("@N1Field5", N1Field5);
        //        cmd.Parameters.AddWithValue("@N1Field6", N1Field6);
        //        cmd.Parameters.AddWithValue("@N1Field7", N1Field7);
        //        cmd.Parameters.AddWithValue("@N1Jusifikasi1", N1Jusifikasi1);
        //        cmd.Parameters.AddWithValue("@N1Jusifikasi2", N1Jusifikasi2);
        //        cmd.Parameters.AddWithValue("@N1Jusifikasi3", N1Jusifikasi3);
        //        cmd.Parameters.AddWithValue("@N1Jusifikasi4", N1Jusifikasi4);
        //        cmd.Parameters.AddWithValue("@N1Jusifikasi5", N1Jusifikasi5);
        //        cmd.Parameters.AddWithValue("@N1Jusifikasi6", N1Jusifikasi6);
        //        cmd.Parameters.AddWithValue("@N1Jusifikasi7", N1Jusifikasi7);
        //        cmd.Parameters.AddWithValue("@danaRekomen", danaRekomen);
        //        cmd.Parameters.AddWithValue("@danaSetuju", danaSetuju);

                
        //        cmd.ExecuteNonQuery();


        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        return false;
        //    }
        //    finally
        //    {
        //        sqlConn.Close();
        //    }

        //}

        public bool addNilaiPenelitian(string id, string rev, int ctRev, double N1Field1, double N1Field2, double N1Field3, double N1Field4, double N1Field5, double N1Field6, double N1Field7, string N1Jusifikasi1, string N1Jusifikasi2, string N1Jusifikasi3, string N1Jusifikasi4, string N1Jusifikasi5, string N1Jusifikasi6, string N1Jusifikasi7)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = @"insert into silppm.TBL_NILAI_REVIEW_PENELITIAN
                    ([ID_PROPOSAL],[ID_REVIEWER],[COUNT_REVISI],[N1_FIELD1],[N1_FIELD2],[N1_FIELD3],
                    [N1_FIELD4],[N1_FIELD5],[N1_FIELD6],[N1_FIELD7],
                    [N1_JUSTIFIKASI1],[N1_JUSTIFIKASI2],[N1_JUSTIFIKASI3],[N1_JUSTIFIKASI4],[N1_JUSTIFIKASI5]
                    ,[N1_JUSTIFIKASI6],[N1_JUSTIFIKASI7],[DANA_REKOMENDASI],[DANA_SETUJU])
                    values (@id,@rev,@ctRev,@N1Field1,@N1Field2,@N1Field3,@N1Field4,
                    @N1Field5,@N1Field6,@N1Field7,@N1Jusifikasi1,@N1Jusifikasi2,@N1Jusifikasi3,
                    @N1Jusifikasi4,@N1Jusifikasi5,@N1Jusifikasi6,@N1Jusifikasi7";
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@rev", rev);
                cmd.Parameters.AddWithValue("@ctRev", ctRev);
                cmd.Parameters.AddWithValue("@N1Field1", N1Field1);
                cmd.Parameters.AddWithValue("@N1Field2", N1Field2);
                cmd.Parameters.AddWithValue("@N1Field3", N1Field3);
                cmd.Parameters.AddWithValue("@N1Field4", N1Field4);
                cmd.Parameters.AddWithValue("@N1Field5", N1Field5);
                cmd.Parameters.AddWithValue("@N1Field6", N1Field6);
                cmd.Parameters.AddWithValue("@N1Field7", N1Field7);
                cmd.Parameters.AddWithValue("@N1Jusifikasi1", N1Jusifikasi1);
                cmd.Parameters.AddWithValue("@N1Jusifikasi2", N1Jusifikasi2);
                cmd.Parameters.AddWithValue("@N1Jusifikasi3", N1Jusifikasi3);
                cmd.Parameters.AddWithValue("@N1Jusifikasi4", N1Jusifikasi4);
                cmd.Parameters.AddWithValue("@N1Jusifikasi5", N1Jusifikasi5);
                cmd.Parameters.AddWithValue("@N1Jusifikasi6", N1Jusifikasi6);
                cmd.Parameters.AddWithValue("@N1Jusifikasi7", N1Jusifikasi7);
             


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
                string query = "select id_proposal,id_reviewer from silppm.TBL_NILAI_REVIEW_PENELITIAN where id_proposal='" + id + "' and id_reviewer='" + rev + "'";
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
        public DataSet getDataReview(string id, string rev, int ct)
        {
            try
            {
                string query = @"select * from silppm.TBL_NILAI_REVIEW_PENELITIAN where ID_PROPOSAL= '" + id + 
                    "' and id_reviewer= '" + rev + "' and count_Revisi= " + ct + "";
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
        public DataSet getDataReviewPengabdian(string id, string rev, int ct)
        {
            try
            {
                string query = "select * from silppm.TBL_NILAI_REVIEW_PENGABDIAN where ID_PROPOSAL= '" + id + "' and id_reviewer= '" + rev + "' and count_Revisi= " + ct + "";
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
        public bool addUpdatePenelitian(string idPenelitian, string rev,int no_update, string tgl, object ket)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_LAP_MONEV_PENELITIAN values ('" + idPenelitian + "','" + rev + "'," + no_update + ",'" + tgl + "',@Ket);";
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@Ket", ket);

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
        public bool addUpdatePengabdian( string idPengabdian, string rev, int no_update, string tgl, object ket)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_LAP_MONEV_PENGABDIAN values ('" + idPengabdian + "','" + rev + "'," + no_update + ",'" + tgl + "',@Ket);";
                cmd = new SqlCommand(query, sqlConn);
                cmd.Parameters.AddWithValue("@Ket", ket);

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
        public int getMaxCountPenelitian(string id, string id_rev)
        {
            try
            {
                string query = "select MAX(no_update) from silppm.TBL_LAP_MONEV_penelitian where id_proposal = '" + id + "' and npp = '" + id_rev + "' ";
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
        public int getMaxCountPengabdian(string id, string id_rev)
        {
            try
            {
                string query = "select MAX(no_update) from silppm.TBL_LAP_MONEV_pengabdian where id_proposal = '" + id + "' and npp = '" + id_rev + "' ";
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
        public int getMaxctRev(string id, string id_rev)
        {
            try
            {
                string query = "select coalesce(MAX(COUNT_REVISI),0) from silppm.TBL_NILAI_REVIEW_PENELITIAN where id_proposal = '" + id + "' and id_reviewer = '" + id_rev + "' ";
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
        public int getMaxctRevPengabdian(string id, string id_rev)
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
        public DataSet getDataPerkembanganPenelitian(string id,string id_rev)
        {
            try
            {
                string query = "select * from silppm.TBL_LAP_MONEV_PENELITIAN where id_proposal = '" + id + "' and npp = '" + id_rev + "' ";
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
        public DataSet getDataPerkembanganPengabdian(string id, string id_rev)
        {
            try
            {
                string query = "select * from silppm.TBL_LAP_MONEV_PENGABDIAN where id_proposal = '" + id + "' and npp = '" + id_rev + "' ";
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
        //untuk keperluan TBL_MONEV admin
        public DataSet getAdminDataPerkembangan(string id)
        {
            try
            {
                string query = "select no_update,tanggal_upload,keterangan from silppm.TBL_LAP_MONEV_penelitian where id_proposal = '" + id + "'  ";
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
        public DataSet getAdminDataPerkembanganPengabdian(string id)
        {
            try
            {
                string query = "select no_update,tanggal_upload,keterangan from silppm.TBL_LAP_MONEV_pengabdian where id_proposal = '" + id + "'  ";
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

        //untuk keperluan TBL_MONEV prodi
        public DataSet getProdiDataPerkembanganPenelitian(string id)
        {
            try
            {
                string query = "select no_update,tanggal_upload,keterangan from silppm.TBL_LAP_MONEV_penelitian where id_proposal = '" + id + "'";
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
        public DataSet getProdiDataPerkembanganPengabdian(string id)
        {
            try
            {
                string query = "select no_update,tanggal_upload,keterangan from silppm.TBL_LAP_MONEV_PENGABDIAN where id_proposal = '" + id + "'";
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


    }
}