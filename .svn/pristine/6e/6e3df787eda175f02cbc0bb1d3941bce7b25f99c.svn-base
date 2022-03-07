using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using silppm_v1e2.Entity;

namespace silppm_v1e2
{
    public class ProposalDAO
    {
        private SqlConnection sqlConn;
        SqlCommand cmd;
        SqlDataReader reader;
        private Connection conn = new Connection();
        private DataTable dt = new DataTable();
        private DataSet dataset = new DataSet();
        private DataSet dataset1 = new DataSet();
        public ProposalDAO()
        {
            sqlConn = conn.getConnection();
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
        public bool addProposal(PropPen pen)
        {
            try
            {
                //int tmpcount = getMaxCountPerorangan()+1;
                
                int droptmp = 0;
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_PENELITIAN values (@ID_Prop,@ID_Dosen,@ID_Jenis,@ID_Schedule,@ID_Sumber,@ID_Rev,@ID_Rev2,@Judul,@Kategori,@Lokasi,@Beban_sks,@id_status_approval,@Dana_usul,@awal,@akhir,@dokumen,@IS_DROPPED,@keyword,@jarakKM,@jarakJam,@sesuaiUnit,@OutCome,@DanaPribadi,@longitude,@latitude,@anggota1,@anggota2,NULL,NULL,@sksAnggota,NULL,NULL,NULL,@date,@ip,@userid);";
                cmd = new SqlCommand(query, sqlConn);

                cmd.Parameters.AddWithValue("@ID_Prop", pen.ID_prop);
                cmd.Parameters.AddWithValue("@ID_Dosen", pen.NPP);
                cmd.Parameters.AddWithValue("@ID_Jenis", pen.ID_jenis);
                cmd.Parameters.AddWithValue("@ID_Schedule", pen.ID_Schedule);
                cmd.Parameters.AddWithValue("@ID_Sumber", pen.Cek_Rev);
                cmd.Parameters.AddWithValue("@ID_Rev", pen.ID_Review1);
                cmd.Parameters.AddWithValue("@ID_Rev2", pen.ID_Review2);
                cmd.Parameters.AddWithValue("@Judul", pen.Judul);
                cmd.Parameters.AddWithValue("@Kategori", pen.Kategori);
                cmd.Parameters.AddWithValue("@Lokasi", pen.Lokasi);
                cmd.Parameters.AddWithValue("@Beban_sks", pen.Sks);
                cmd.Parameters.AddWithValue("@id_status_approval", pen.ID_Approval);
                cmd.Parameters.AddWithValue("@Dana_usul", pen.Dana);
                cmd.Parameters.AddWithValue("@awal", pen.Awal);
                cmd.Parameters.AddWithValue("@akhir", pen.Akhir);
                cmd.Parameters.AddWithValue("@dokumen", pen.Dokumen);
                cmd.Parameters.AddWithValue("@IS_DROPPED", droptmp);
                
                cmd.Parameters.AddWithValue("@keyword", pen.Keyword);
                cmd.Parameters.AddWithValue("@jarakKM", pen.JarakKM);
                cmd.Parameters.AddWithValue("@jarakJam", pen.JarakJAM);
                cmd.Parameters.AddWithValue("@sesuaiUnit", pen.SesuaiUnit);
                cmd.Parameters.AddWithValue("@OutCome", pen.Outcome);
                
                cmd.Parameters.AddWithValue("@DanaPribadi", pen.DanaPribadi);
                cmd.Parameters.AddWithValue("@longitude", pen.Longitude);
                cmd.Parameters.AddWithValue("@latitude", pen.Latitude);
                //cmd.Parameters.AddWithValue("@ct", tmpcount);
                cmd.Parameters.AddWithValue("@anggota1", pen.Anggota1);
                cmd.Parameters.AddWithValue("@anggota2", pen.Anggota2);
                cmd.Parameters.AddWithValue("@sksAnggota", pen.SksAnggota);
                cmd.Parameters.AddWithValue("@date", pen.Insert_date);
                cmd.Parameters.AddWithValue("@ip", pen.Ip_address);
                cmd.Parameters.AddWithValue("@userid", pen.Userid);
                
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

        }//not sure
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
        }//udah
        public DataTable getTemaPenelitian(int idprodi) {
            try
            {
                string query = "select ID_ROAD_MAP_PENELITIAN,DESKRIPSI from silppm.REF_ROAD_MAP_PENELITIAN where IS_DELETED=0 and ID_UNIT_AKADEMIK ="+idprodi+"";
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

        //public int getIDroadmap(string nama)
        //{
        //    try
        //    {
        //        string query = "select ID_ROAD_MAP from REF_ROAD_MAP where DETAIL_ROAD_MAP='"+nama+"'";
        //        if (sqlConn.State.ToString() != "Open")
        //            sqlConn.Open();
        //        cmd = new SqlCommand(query, sqlConn);
        //        reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            int id = int.Parse(reader.GetValue(0).ToString());
        //            //int.Parse(reader.GetInt32(0).ToString());
        //            //
        //            return id;
        //        }
        //        else
        //            return 0;

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        sqlConn.Close();
        //    }
        //}

        ///////////////////////////
        public bool addProposalLolos(string id,int rekomen,double pajak, int isSelesai)
        {
            try
            {
                //int tmpcount = getMaxCount() + 1;

                //int droptmp = 0;
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into silppm.TBL_PENELITIAN_LOLOS select [ID_PROPOSAL],[NPP],[JENIS],[ID_TAHUN_ANGGARAN],[IS_CHECKED],[REVIEWER1],[REVIEWER2],[JUDUL],[ID_KATEGORI],[LOKASI],[BEBAN_SKS],[ID_STATUS_PENELITIAN],[DANA_USUL],[AWAL],[AKHIR],[DOKUMEN],[IS_DROPPED],[KEYWORD],[JARAK_KAMPUS_KM],[JARAK_KAMPUS_JAM],[ID_ROAD_MAP_PENELITIAN],[OUTCOME],[DANA_PRIBADI],[LONGITUDE],[LATITUDE],[NPP1],[NPP2],[IS_SETUJU_PRODI],[IS_SETUJU_DEKAN],[BEBAN_SKS_ANGGOTA],[IS_SETUJU_LPPM],[NPP_REVIEWER],[DANA_SETUJU]," + pajak + "," + rekomen + ",NULL,NULL," + isSelesai + ",NULL,NULL,NULL,NULL from silppm.TBL_PENELITIAN where ID_PROPOSAL ='" + id + "'";
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
        public bool ReviewProposalPenelitian(string id,string reviewer)
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
        public bool CekPerkembanganMonev(string id,string npp)
        {
            try
            {

                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "select ID_PROPOSAL,NPP from silppm.TBL_LAP_MONEV_PENELITIAN where ID_PROPOSAL='" + id + "' and NPP ='"+npp+"'";
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
        public byte[] getPropsalPenelitian(string index)
        {
            try
            {
                string query = "select dokumen from silppm.TBL_PENELITIAN where id_proposal= '" + index + "' ;";
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
        public DataSet getAllDataProposal(string npp)//ada status, ID KATEGORI, IS_ADMIN_CHECK
        {
            try
            {
                string query = "select p.id_proposal,p.Judul,r.DESKRIPSI,k.KATEGORI,k.DETAIL_PELAKU,p.lokasi,p.akhir,p.dana_usul from silppm.TBL_PENELITIAN p join silppm.REF_KATEGORI k on k.ID_KATEGORI=p.ID_KATEGORI join silppm.REF_STATUS_PENELITIAN_PENGABDIAN r  on r.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN where p.IS_SETUJU_PRODI=1 and IS_SETUJU_DEKAN=1 and p.IS_DROPPED=0 and p.IS_CHECKED=0 and NPP_REVIEWER ='" + npp + "' and REVIEWER1='kosong';";
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
        public DataSet getAllDataProposalByIDProposal(string id)
        {
            try
            {
                string query = "select p.id_proposal,p.Judul,r.DESKRIPSI,k.KATEGORI,k.DETAIL_PELAKU,p.lokasi,p.akhir,p.dana_usul from silppm.TBL_PENELITIAN p join silppm.REF_KATEGORI k on k.ID_KATEGORI=p.ID_KATEGORI join silppm.REF_STATUS_PENELITIAN_PENGABDIAN r on r.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN where id_proposal='" + id + "'and IS_DROPPED=0 ;";
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
                string query = "select e.id_proposal,e.Judul,s.DESKRIPSI from silppm.TBL_PENELITIAN_LOLOS e join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=e.ID_STATUS_PENELITIAN where NPP= '" + id + "';";
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
                string query = "select d.nama,p.id_proposal,p.Judul from silppm.TBL_PENELITIAN_LOLOS p join Simka.mst_karyawan d on d.npp=p.NPP where d.ID_UNIT_AKADEMIK="+subid+" and p.IS_SELESAI!=1 ";
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
        public string cekEdit(string id_prop)
        {
            try
            {
                string query = "select d.DESKRIPSI from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN d on d.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN where id_proposal = '" + id_prop + "' ";
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
        public bool updateStatusRevisi(int cek,string id_prop)
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
                string query = "update TBL_Penelitian set IS_CHECKED=" + cek + ",ID_STATUS_PENELITIAN=11,IS_DROPPED=1 where id_proposal = '" + id_prop + "' ";
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
                string query = "select DISTINCT t.TAHUN_ANGGARAN from silppm.TBL_PENELITIAN p join silppm.REF_SCHEDULE s on s.ID_TAHUN_ANGGARAN=p.ID_TAHUN_ANGGARAN join sikeu.TBL_TAHUN_ANGGARAN t on t.ID_TAHUN_ANGGARAN=s.ID_TAHUN_ANGGARAN where p.ID_PROPOSAL='"+id+"'";
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
                string query = "select p.id_proposal,p.Judul,d.nama, CASE WHEN p.IS_SETUJU_PRODI is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENELITIAN p join simka.mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_PRODI is NULL AND IS_DROPPED=0 and d.ID_UNIT_AKADEMIK="+idProdi+"";
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
                string query = "select p.id_proposal,p.Judul,d.nama, CASE WHEN p.IS_SETUJU_LPPM is NULL THEN 'Menunggu Konfirmasi' END AS Status  from silppm.TBL_PENELITIAN p join simka.mst_karyawan d on d.npp=p.NPP where p.IS_SETUJU_LPPM is NULL AND REVIEWER1!='kosong' AND IS_DROPPED=0";
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
        public bool addfeedback(string tmpid,string npp, string feedback, DateTime tgl,string status)
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
                string query = "select * from silppm.TBL_FEEDBACK_PENELITIAN f join [SIATMAX].[siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='Prodi' and f.ID_PROPOSAL = '"+id+"'";
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

        public bool updateProdi(int cek, string id_prop,int status)
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
                string query = "select * from silppm.TBL_FEEDBACK_PENELITIAN f join [SIATMAX].[siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='Dekan' and f.ID_PROPOSAL = '" + id + "'";
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
                string query = "select * from silppm.TBL_FEEDBACK_PENELITIAN f join [SIATMAX].[siatmax].[TBL_USER_ROLE] s on s.NPP=f.NPP join siatmax.REF_ROLE r on r.ID_ROLE=s.ID_ROLE where s.ID_SISTEM_INFORMASI=4 and r.DESKRIPSI='KALPPM' and f.ID_PROPOSAL = '" + id + "'";
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
                string query = "DECLARE @intFlag INT DECLARE @tes INT DECLARE @tes1 INT DECLARE @tes2 INT DECLARE @tes3 INT DECLARE @maxflag INT DECLARE @tmp varchar SET @intFlag = 1 SET @tes = (select MONTH(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='"+id+"') set @tes1 = (select DAY(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='"+id+"') set @tes2 = (select YEAR(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='"+id+"') set @tes3 = (select YEAR(AKHIR) from TBL_PENELITIAN where ID_PROPOSAL='"+id+"') IF(@tes2>=@tes3) WHILE (@intFlag <=(select MONTH(AKHIR)-MONTH(AWAL) from TBL_PENELITIAN where ID_PROPOSAL='"+id+"')) BEGIN Insert into freetbl values (cast(@tes1 as varchar(2))+'-'+ cast((@tes+@intFlag) as varchar(2))+'-'+ cast(@tes2 as varchar(4))) SET @intFlag = @intFlag + 1 END ELSE IF(@tes2<@tes3) WHILE (@intFlag <=(select (MONTH(AKHIR)+12)-MONTH(AWAL)  from TBL_PENELITIAN where ID_PROPOSAL='"+id+"')) BEGIN IF(@tes+@intFlag <=12) Insert into freetbl values (cast(@tes1 as varchar(2))+'-'+ cast((@tes+@intFlag) as varchar(2))+'-'+ cast(@tes2 as varchar(4)))  IF(@tes+@intFlag <=12) SET @maxflag = @intFlag IF(@tes+@intFlag >12) Insert into freetbl values (cast(@tes1 as varchar(2))+'-'+ cast((@intFlag-@maxflag) as varchar(2))+'-'+ cast(@tes3 as varchar(4))) SET @intFlag = @intFlag + 1 END Select value from freetbl";
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
        public bool PerpanjangPeriodePenelitian(string id_prop, int count, DateTime awal, DateTime akhir,DateTime insertDate,string ip,string userid)
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
                string query = "select p.id_proposal,k.NAMA,p.JUDUL,s.DESKRIPSI,a.TAHUN_ANGGARAN,u.NAMA_UNIT AS 'FAK',uu.NAMA_UNIT AS 'PRODI' from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT order by a.TAHUN_ANGGARAN";
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
                string query = "select p.id_proposal,k.NAMA,p.JUDUL,s.DESKRIPSI,a.TAHUN_ANGGARAN,u.NAMA_UNIT AS 'FAK',uu.NAMA_UNIT AS 'PRODI' from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT where a.TAHUN_ANGGARAN like '"+tahun+"' order by a.TAHUN_ANGGARAN";
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
                string query = "select * from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT_AKADEMIK=u.ID_UNIT where k.ID_UNIT_AKADEMIK = (select ID_UNIT from siatmax.MST_UNIT where NPP='" + NppProdi + "')";
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
                string query = "select * from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT_AKADEMIK=u.ID_UNIT where k.ID_UNIT_AKADEMIK = (select ID_UNIT from siatmax.MST_UNIT where NPP='" + NppProdi + "') and a.Tahun_Anggaran='"+Tahun+"'";
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
                string query = "select k.NAMA,p.JUDUL,s.DESKRIPSI,a.TAHUN_ANGGARAN,uu.NAMA_UNIT from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT where k.ID_UNIT = (select ID_UNIT from siatmax.MST_UNIT where NPP= '" + NppFak + "' and IS_PALSU=0)";
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
                string query = "select k.NAMA,p.JUDUL,s.DESKRIPSI,a.TAHUN_ANGGARAN,uu.NAMA_UNIT from silppm.TBL_PENELITIAN p join silppm.REF_STATUS_PENELITIAN_PENGABDIAN s on s.ID_STATUS_PENELITIAN=p.ID_STATUS_PENELITIAN join sikeu.TBL_TAHUN_ANGGARAN a on a.ID_TAHUN_ANGGARAN= p.ID_TAHUN_ANGGARAN join simka.MST_KARYAWAN k on k.NPP=p.NPP join siatmax.MST_UNIT u on k.ID_UNIT=u.ID_UNIT join siatmax.MST_UNIT uu on k.ID_UNIT_AKADEMIK=uu.ID_UNIT where k.ID_UNIT = (select ID_UNIT from siatmax.MST_UNIT where NPP= '" + NppFak + "' and a.Tahun_Anggaran = '"+Tahun+"' and IS_PALSU=0)";
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
                    string id=reader.GetValue(0).ToString();
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
                string query = "select IS_SELESAI from silppm.TBL_PENELITIAN_LOLOS where NPP = '"+npp+"' and IS_SELESAI = 0";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id;
                    int.TryParse(reader.GetValue(0).ToString(),out id);
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