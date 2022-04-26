﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Softlib.Data;

namespace silppm_v1e2
{
    public class UserDAO
    {
        private SqlConnection sqlConn;
        SqlCommand cmd;
        SqlDataReader reader;
        private Connection conn = new Connection();
        private DataSet dataset = new DataSet();
        public UserDAO()
        {
            sqlConn = conn.getConnection();
        }
        public bool val_user_REV(string username, string password)
        {
            try
            {
               //string query = "select username from MST_user where username='" + username + "' and password='" + password + "'";
                 string query = "select username,password from SIMKA.MST_KARYAWAN where username='" + username + "' and password='" + password + "'";
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
        public bool val_pass_REV(string username, string password)
        {
            try
            {
                // string query = "select password from MST_user where username='" + username + "' and password='" + password + "'";
               string query = "select username,password from SIMKA.MST_KARYAWAN where username='" + username + "' and password='" + password + "'";
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
        public string getRoleByUsername(string uname)
        {
            try
            {
                //string query = "select e.role from MST_user m join REF_ROLEDB e on e.ID_ROLE=m.user_role where username = '" + uname + "' ";
                string query = "select [DESKRIPSI] from [siatmax].[REF_ROLE] r join [siatmax].[TBL_USER_ROLE] s on r.id_role=s.id_role where s.npp = '" + uname + "'and s.ID_SISTEM_INFORMASI=8 ";
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
        public string getNamaByUsername(string uname)
        {
            try
            {
               // string query = "select NAMA from MST_user where username = '" + uname + "' ";
                string query = "select NAMA from SIMKA.MST_KARYAWAN where username = '" + uname + "' ";
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
        public string getNamaByNPP(string uname)
        {
            try
            {
               // string query = "select NAMA from MST_user where npp = '" + uname + "' ";
                string query = "select NAMA from SIMKA.MST_KARYAWAN where npp = '" + uname + "' ";
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
        public string getNamaByIDPenelitian(string uname)
        {
            try
            {
               // string query = "select u.NAMA from MST_user u join TBL_PENELITIAN p on u.npp=p.npp where p.id_proposal =  '" + uname + "' ";
                string query = "select u.NAMA from SIMKA.MST_KARYAWAN u join SILPPM.TBL_PENELITIAN p on u.npp=p.npp where p.id_proposal= " + uname + " ";
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
        public string getNamaByIDPengabdian(string uname)
        {
            try
            {
                // string query = "select u.NAMA from MST_user u join TBL_PENELITIAN p on u.npp=p.npp where p.id_proposal =  '" + uname + "' ";
                string query = "select u.NAMA from SIMKA.MST_KARYAWAN u join SILPPM.TBL_PENGABDIAN p on u.npp=p.npp where p.id_proposal= " + uname + " ";
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

        public string getAlamatByUsername(string uname)
        {
            try
            {
                //string query = "select alamat from MST_user where username = '" + uname + "' ";
                 string query = "select alamat from SIMKA.MST_KARYAWAN where username = '" + uname + "' ";
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
        public string getFakultasByUsername(string uname)
        {
            //dunno what the 8 column.......................
            try
            {
                //string query = "select ID_UNIT from Mst_user where username = '" + uname + "' ";
                string query = "select n.NAMA_UNIT from siatmax.MST_UNIT n join simka.MST_KARYAWAN p on p.ID_UNIT=n.ID_UNIT where p.USERNAME = '" + uname + "' ";
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
        public string getGolByUsername(string uname)
        {
            try
            {
                string query = @"select d.ID_REF_GOLONGAN from SIMKA.REF_GOLONGAN d 
                join SIMKA.MST_KARYAWAN p on p.ID_REF_GOLONGAN=d.ID_REF_GOLONGAN 
where p.USERNAME = '" + uname + "' ";
                
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
        public string getPangkatByUsername(string uname)
        {
            try
            {

                //  string query = "select d.DESKRIPSI from SIMKA.REF_JABATAN_AKADEMIK d join SIMKA.MST_KARYAWAN p on p.ID_REF_JBTN_AKADEMIK=d.ID_REF_JBTN_AKADEMIK where p.USERNAME= '" + uname + "' ";
                string query = "select d.DESKRIPSI from SIMKA.REF_GOLONGAN d join SIMKA.MST_KARYAWAN p on p.ID_REF_GOLONGAN=d.ID_REF_GOLONGAN where p.USERNAME= '" + uname + "' ";
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
        public string getTelpByUsername(string uname)
        {
            try
            {
                //string query = "select NO_TELPON_HP from MST_user where username = '" + uname + "' ";
                string query = "select NO_TELPON_HP from SIMKA.MST_KARYAWAN where username = '" + uname + "' ";
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

        public string getNamaLengkap(string uname)
        {
            try
            {
                //string query = "select NPP from MST_user where username = '" + uname + "' ";
                string query = "select NAMA_LENGKAP_GELAR from SIMKA.MST_KARYAWAN where username = '" + uname + "' ";
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

        public string getJbtnFungsional(string uname)
        {
            try
            {

                string query = "select d.DESKRIPSI from SIMKA.REF_JABATAN_AKADEMIK d join SIMKA.MST_KARYAWAN p on p.ID_REF_JBTN_AKADEMIK=d.ID_REF_JBTN_AKADEMIK where p.USERNAME= '" + uname + "' ";
                //string query = "select d.DESKRIPSI from SIMKA.REF_GOLONGAN d join SIMKA.MST_KARYAWAN p on p.ID_REF_GOLONGAN=d.ID_REF_GOLONGAN where p.USERNAME= '" + uname + "' ";

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
        public string getNPPByUsername(string uname)
        {
            try
            {
                 //string query = "select NPP from MST_user where username = '" + uname + "' ";
               string query = "select NPP from SIMKA.MST_KARYAWAN where username = '" + uname + "' ";
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
        public string getEmailDosen(string uname)
        {
            try
            {
                string query = "select EMAIL_INSTITUSI from SIMKA.MST_KARYAWAN where username = '" + uname + "' ";
               
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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
        public string getEmailProdiByNPPDosen(string NPP)
        {
            try
            {
                string query = "select EMAIL from simka.MST_KARYAWAN where NPP= '" + NPP + "' ";

                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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

        public string getEmailDekanByNPPProdi(string NPP)
        {
            try
            {
                string query = "select EMAIL from simka.MST_KARYAWAN  where NPP= '" + NPP + "' ";

                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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

        public string getEmailStaff()
        {
            try
            {
                string query = "select m.EMAIL from simka.MST_KARYAWAN m join siatmax.TBL_USER_ROLE u on u.NPP=m.NPP where u.ID_ROLE=1 and u.ID_SISTEM_INFORMASI=8";

                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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
        public string getEmailByNPP(string NPP)
        {
            try
            {
                string query = "select email from simka.MST_KARYAWAN where NPP = '" + NPP + "' ";

                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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
        public string getEmailKALPPM()
        {
            try
            {
                string query = "select m.EMAIL from simka.MST_KARYAWAN m join siatmax.TBL_USER_ROLE u on u.NPP=m.NPP where u.ID_ROLE=17 and u.ID_SISTEM_INFORMASI=8";

                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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
        public string getEmailPustakawan()
        {
            try
            {
                string query = "select m.EMAIL from simka.MST_KARYAWAN m join siatmax.TBL_USER_ROLE u on u.NPP=m.NPP where u.ID_ROLE=5 and u.ID_SISTEM_INFORMASI=8";

                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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

        public string getEmailbyIDenelitian(string uname)
        {
            try
            {
                string query = "select u.EMAIL from SIMKA.MST_KARYAWAN u join SILPPM.TBL_PENELITIAN p on u.npp=p.npp where p.id_proposal = '" + uname + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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
        public string getEmailbyIDPengabdian(string uname)
        {
            try
            {
                string query = "select u.EMAIL from SIMKA.MST_KARYAWAN u join SILPPM.TBL_PENGABDIAN p on u.npp=p.npp where p.id_proposal = '" + uname + "' ";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return reader.GetString(0);
                }
                else
                    return "";
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
        //Get Karyawan
        public DataTable getKaryawan(string npp)
        {
            string select = @"SELECT     simka.MST_KARYAWAN.NPP, simka.MST_KARYAWAN.NAMA, simka.MST_KARYAWAN.ALAMAT, simka.MST_KARYAWAN.EMAIL, 
                      simka.MST_KARYAWAN.NO_TELPON_HP, siatmax.MST_UNIT.NAMA_UNIT, simka.REF_GOLONGAN.ID_REF_GOLONGAN, simka.MST_KARYAWAN.NIDN, 
                      simka.REF_JABATAN_AKADEMIK.DESKRIPSI, MST_UNIT_1.NAMA_UNIT AS FAKULTAS, simka.REF_FUNGSIONAL.DESKRIPSI AS FUNGSIONAL
FROM         siatmax.MST_UNIT AS MST_UNIT_1 RIGHT OUTER JOIN
                      siatmax.MST_UNIT ON MST_UNIT_1.ID_UNIT = siatmax.MST_UNIT.MST_ID_UNIT RIGHT OUTER JOIN
                      simka.REF_JABATAN_AKADEMIK RIGHT OUTER JOIN
                      simka.MST_KARYAWAN ON simka.REF_JABATAN_AKADEMIK.ID_REF_JBTN_AKADEMIK = simka.MST_KARYAWAN.ID_REF_JBTN_AKADEMIK ON 
                      simka.MST_KARYAWAN.ID_UNIT_AKADEMIK = siatmax.MST_UNIT.ID_UNIT LEFT OUTER JOIN
                      simka.REF_GOLONGAN ON simka.MST_KARYAWAN.ID_REF_GOLONGAN = simka.REF_GOLONGAN.ID_REF_GOLONGAN LEFT OUTER JOIN
                      simka.REF_FUNGSIONAL ON simka.MST_KARYAWAN.ID_REF_FUNGSIONAL = simka.REF_FUNGSIONAL.ID_REF_FUNGSIONAL
WHERE     (NOT (simka.MST_KARYAWAN.NPP IN (N'00.00.001', N'xx.xx.001'))) and MST_KARYAWAN.NPP=@npp";

            DataTable dt = new DataTable();
            IDBManager dbManager = new DBManager(DBKoneksi.DB_PROVIDER, DBKoneksi.CONN_STRING);
            try
            {
                dbManager.Open();
                dbManager.CreateParameters(1);
                dbManager.AddParameters(0, "@NPP", npp);
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
         
        public string getjurusanByUsername(string uname)
        {
            try
            {
                string query = "select n.NAMA_UNIT from siatmax.MST_UNIT n join simka.MST_KARYAWAN p on p.ID_UNIT_AKADEMIK=n.ID_UNIT where p.USERNAME = '" + uname + "' ";
                
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
        public string getNIDNbyUsername(string uname)
        {
            try
            {
                string query = "select nidn from SIMKA.MST_KARYAWAN where username = '" + uname + "' ";
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
                    return "";

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
        public DataSet getAllDatauser(string npp)
        {
            try
            {
                string query = @"select distinct k.NPP,k.NAMA,r.DESKRIPSI from simka.MST_KARYAWAN k join siatmax.TBL_USER_ROLE u 
on u.NPP=k.NPP join siatmax.REF_ROLE r on r.ID_ROLE=u.ID_ROLE where ( r.DESKRIPSI= 'Dosen' and u.ID_SISTEM_INFORMASI=8  or r.DESKRIPSI='Assesor' 
and u.ID_SISTEM_INFORMASI=8 and u.IS_ACTIVE='1') and (k.NPP like '%" + npp + "%' or k.NAMA like '%" + npp + "%') order by r.DESKRIPSI";
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

        public DataSet getAllDatauserBySI(string npp, int role)
        {
            try
            {
                string query = @"select * from siatmax.TBL_USER_ROLE where ID_ROLE = " + role + " and NPP = '" + npp + "' and ID_SISTEM_INFORMASI=8";
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

        public bool UpdateRole(string id, int role)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "update siatmax.TBL_USER_ROLE set ID_ROLE = "+role+" where NPP = '"+id+"' and ID_SISTEM_INFORMASI=8";
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

        public bool insertRole(string id, int role)
        {
            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                string query = "insert into siatmax.TBL_USER_ROLE (ID_SISTEM_INFORMASI,ID_ROLE,NPP,IS_ACTIVE) values(8," + role + ",'" + id + "',1)";
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


        public DataSet getUserRoleAssessor2()
        {
            try
            {
                //string query = "select * from mst_user where user_role=5;";
                string query = "select distinct m.NPP, m.NAMA from simka.MST_KARYAWAN m join  [siatmax].[TBL_USER_ROLE] s on s.NPP=m.NPP join [siatmax].[REF_ROLE] r  on r.id_role=s.id_role where r.DESKRIPSI='Assesor' and s.ID_SISTEM_INFORMASI=8";
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
       
        public DataSet getUserRoleAssessor()
        {
            try
            {
                //string query = "select * from mst_user where user_role=5;";
                string query = "select * from simka.MST_KARYAWAN m join  [siatmax].[TBL_USER_ROLE] s on s.NPP=m.NPP join [siatmax].[REF_ROLE] r  on r.id_role=s.id_role where r.DESKRIPSI='Assesor' and s.ID_SISTEM_INFORMASI=8 and s.IS_ACTIVE='1'";
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
        public int getProdiByNPP(string npp)
        {
            try
            {
                
                string query = "select ID_UNIT_AKADEMIK from simka.MST_KARYAWAN where NPP='"+npp+"'";
                if (sqlConn.State.ToString() != "Open")
                    sqlConn.Open();
                cmd = new SqlCommand(query, sqlConn);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if(reader.GetValue(0).ToString()!="")
                    return int.Parse(reader.GetValue(0).ToString());
                    else return 0;
                    //int.Parse(reader.GetInt32(0).ToString());
                    //

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
        public int getKaProdiByNPP(string npp)
        {
            try
            {

                string query = "select ID_UNIT from siatmax.MST_UNIT where NPP='" + npp + "'";
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
        public int getDekanByNPP(string npp)
        {
            try
            {

                string query = "select ID_UNIT from siatmax.MST_UNIT where NPP='" + npp + "'";
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

        public DataTable getAllMenu(string NPP, int ID_SISTEM_INFORMASI)
        {
                        DataSet ds = new DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(@"
                    select ROW_NUMBER() over (order by parentid,NO_URUT) urut,*
                    from ( SELECT DISTINCT TBL_SI_MENU.ID_SI_MENU menuid, NO_URUT, TBL_SI_MENU.DESKRIPSI menuname
                          ,TBL_SI_MENU.LINK menulocation, 0 parentid  FROM siatmax.TBL_ROLE_SUBMENU INNER JOIN
                      siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE INNER JOIN
                      siatmax.REF_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.REF_ROLE.ID_ROLE AND                       siatmax.TBL_USER_ROLE.ID_ROLE = siatmax.REF_ROLE.ID_ROLE INNER JOIN
                      siatmax.TBL_SI_SUBMENU ON siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU INNER JOIN
                      siatmax.TBL_SI_MENU ON siatmax.TBL_SI_SUBMENU.ID_SI_MENU = siatmax.TBL_SI_MENU.ID_SI_MENU
                    WHERE (NPP = @NPP) and siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI =@ID_SISTEM_INFORMASI 
and TBL_USER_ROLE.IS_ACTIVE=1  and TBL_SI_SUBMENU.IsActive=1
                     union all
                    SELECT  distinct TBL_SI_SUBMENU.ID_SI_SUBMENU, NO_URUT, TBL_SI_SUBMENU.DESKRIPSI ,TBL_SI_SUBMENU.LINK
                    ,TBL_SI_SUBMENU.ID_SI_MENU  FROM         siatmax.TBL_SI_MENU INNER JOIN
                      siatmax.TBL_SI_SUBMENU ON siatmax.TBL_SI_MENU.ID_SI_MENU = siatmax.TBL_SI_SUBMENU.ID_SI_MENU INNER JOIN
                      siatmax.TBL_ROLE_SUBMENU ON siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU INNER JOIN
                      siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE AND 
                      siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI = siatmax.TBL_USER_ROLE.ID_SISTEM_INFORMASI
                    WHERE (NPP = @NPP) and siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI =@ID_SISTEM_INFORMASI 
and TBL_USER_ROLE.IS_ACTIVE=1 and TBL_SI_SUBMENU.IsActive=1  ) menu", sqlConn);

            cmd.Parameters.AddWithValue("@NPP", NPP);
            cmd.Parameters.AddWithValue("@ID_SISTEM_INFORMASI", ID_SISTEM_INFORMASI);

            dataadapter.SelectCommand = cmd;
            dataadapter.Fill(ds, "Menu");

            return ds.Tables[0];

        }
        public DataTable getAllMenu(string role)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(@"
                    select ROW_NUMBER() over (order by parentid,menuid) urut,*
                    from ( SELECT DISTINCT TBL_SI_MENU.ID_SI_MENU menuid, TBL_SI_MENU.DESKRIPSI menuname
                          ,'' menulocation, 0 parentid  FROM siatmax.TBL_ROLE_SUBMENU INNER JOIN
                      siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE INNER JOIN
                      siatmax.REF_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.REF_ROLE.ID_ROLE AND                       siatmax.TBL_USER_ROLE.ID_ROLE = siatmax.REF_ROLE.ID_ROLE INNER JOIN
                      siatmax.TBL_SI_SUBMENU ON siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU INNER JOIN
                      siatmax.TBL_SI_MENU ON siatmax.TBL_SI_SUBMENU.ID_SI_MENU = siatmax.TBL_SI_MENU.ID_SI_MENU
                    WHERE (siatmax.REF_ROLE.DESKRIPSI = @role) and TBL_SI_SUBMENU.IsActive=1 and TBL_SI_MENU.ID_SISTEM_INFORMASI=8
                     union all                                      SELECT  distinct TBL_SI_SUBMENU.ID_SI_SUBMENU, TBL_SI_SUBMENU.DESKRIPSI                           ,TBL_SI_SUBMENU.LINK
                          ,TBL_SI_SUBMENU.ID_SI_MENU                     FROM siatmax.TBL_ROLE_SUBMENU INNER JOIN
                      siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE INNER JOIN
                      siatmax.REF_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.REF_ROLE.ID_ROLE AND                       siatmax.TBL_USER_ROLE.ID_ROLE = siatmax.REF_ROLE.ID_ROLE INNER JOIN
                      siatmax.TBL_SI_SUBMENU ON siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU INNER JOIN
                      siatmax.TBL_SI_MENU ON siatmax.TBL_SI_SUBMENU.ID_SI_MENU = siatmax.TBL_SI_MENU.ID_SI_MENU
                    WHERE (siatmax.REF_ROLE.DESKRIPSI = @role) and TBL_SI_SUBMENU.IsActive=1 and TBL_SI_MENU.ID_SISTEM_INFORMASI=8 ) menu", sqlConn);

            cmd.Parameters.AddWithValue("@role", role);

            dataadapter.SelectCommand = cmd;
            dataadapter.Fill(ds, "Menu");

            return ds.Tables[0];

        }
        public DataSet getMenu(string role)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(@"SELECT DISTINCT 
                      siatmax.TBL_SI_MENU.ID_SI_MENU, siatmax.TBL_SI_MENU.DESKRIPSI, siatmax.TBL_SI_MENU.IsActive, siatmax.TBL_SI_MENU.ID_SISTEM_INFORMASI
                    FROM siatmax.TBL_ROLE_SUBMENU INNER JOIN
                      siatmax.TBL_USER_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.TBL_USER_ROLE.ID_ROLE INNER JOIN
                      siatmax.REF_ROLE ON siatmax.TBL_ROLE_SUBMENU.ID_ROLE = siatmax.REF_ROLE.ID_ROLE AND 
                      siatmax.TBL_USER_ROLE.ID_ROLE = siatmax.REF_ROLE.ID_ROLE INNER JOIN
                      siatmax.TBL_SI_SUBMENU ON siatmax.TBL_ROLE_SUBMENU.ID_SI_SUBMENU = siatmax.TBL_SI_SUBMENU.ID_SI_SUBMENU INNER JOIN
                      siatmax.TBL_SI_MENU ON siatmax.TBL_SI_SUBMENU.ID_SI_MENU = siatmax.TBL_SI_MENU.ID_SI_MENU
                    WHERE (siatmax.REF_ROLE.DESKRIPSI = @role) and TBL_SI_SUBMENU.IsActive=1 and TBL_SI_MENU.ID_SISTEM_INFORMASI=8", sqlConn);

            cmd.Parameters.AddWithValue("@role", role);

            dataadapter.SelectCommand = cmd;
            dataadapter.Fill(ds, "Menu");

            return ds;

        }
    }
}
    