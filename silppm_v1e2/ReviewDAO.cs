using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using silppm_v1e2.Entity;


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
        public bool addNilaiPenelitian(string id, string rev,int ctRev, double N1Field1, double N1Field2, double N1Field3, double N1Field4, double N1Field5, double N1Field6, double N1Field7, string N1Jusifikasi1, string N1Jusifikasi2, string N1Jusifikasi3, string N1Jusifikasi4, string N1Jusifikasi5, string N1Jusifikasi6, string N1Jusifikasi7,int danaRekomen,int danaSetuju)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_NILAI_REVIEW_PENELITIAN values ('" + id + "','" + rev + "'," + ctRev + "," + N1Field1 + "," + N1Field2 + "," + N1Field3 + "," + N1Field4 + "," + N1Field5 + "," + N1Field6 + "," + N1Field7 + ",'" + N1Jusifikasi1 + "','" + N1Jusifikasi2 + "','" + N1Jusifikasi3 + "','" + N1Jusifikasi4 + "','" + N1Jusifikasi5 + "','" + N1Jusifikasi6 + "','" + N1Jusifikasi7 + "'," + danaRekomen + "," + danaSetuju + ");";
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
                string query = "select * from silppm.TBL_NILAI_REVIEW_PENELITIAN where ID_PROPOSAL= '" + id + "' and id_reviewer= '" + rev + "' and count_Revisi= " + ct + "";
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
                string query = "select MAX(COUNT_REVISI) from silppm.TBL_NILAI_REVIEW_PENELITIAN where id_proposal = '" + id + "' and id_reviewer = '" + id_rev + "' ";
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