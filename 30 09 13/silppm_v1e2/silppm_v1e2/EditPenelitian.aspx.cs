using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace silppm_v1e2
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private DataTable dtTema = new DataTable();
        public ProposalDAO prop = new ProposalDAO();
        private PropPen pen = new PropPen();
        private string tmpnama,ktgr,tmpawal,tmpakhir, tmpusername;
        private int idprodi;
        private UserDAO datauser = new UserDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            string temp_idProp = Request.QueryString["id"];
            
            
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                tmpnama = ue.NAMA;
                //ddlDosen.DataSource = prop.getNamaDosen();
                //ddlDosen.DataBind();
                //ddlDosen.SelectedIndex = -1;
                idprodi = datauser.getProdiByNPP(ue.NPP);
                if (!Page.IsPostBack)
                {
                    dtTema = prop.getTemaPenelitian(idprodi);
                    ddLRencanaUnit.DataSource = dtTema;
                    ddLRencanaUnit.DataValueField = "ID_ROAD_MAP_PENELITIAN";
                    ddLRencanaUnit.DataTextField = "DESKRIPSI";
                    ddLRencanaUnit.DataBind();
                }
                ktgr = prop.getJenisPenelitianByID(temp_idProp);
                tmpusername = ue.Username;
            tmpawal = prop.getawalPeriode();
            tmpakhir = prop.getAkhirPeriode();
            //tmptoday = DateTime.Today.ToString();
            //if (DateTime.Today < Convert.ToDateTime(tmpawal) || DateTime.Today > Convert.ToDateTime(tmpakhir)) {
            //    Response.Redirect("ErrorPeriode.aspx");
            //}
            
            
            //pnlMap.Visible = false;
           //dtDosen = ;
            
                lblPeriode.Text = prop.getNamaPeriode();
                
                lblNamaKetua.Text = tmpnama;
                
                if (ktgr == "PERORANGAN") {
                    pnlAnggotaKelompok.Visible = false;
                    pnlSKSAnggota.Visible = false;
                    //generateIDPerorangan();
                }
                else if (ktgr == "KELOMPOK") {
                    pnlAnggotaKelompok.Visible = true;
                    pnlSKSAnggota.Visible = true;
                    //generateIDKelompok();
                }

            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }
        private PropPen setDataPen()
        {

            pen.Latitude = "";
            pen.Longitude = "";
            int idid;
            try { idid = prop.getMaxCount(); }
            catch { idid = 0; }
            pen.Latitude = "";
            pen.Longitude = "";
            pen.ID_prop = idid + 1;
            pen.Judul = txtJudul.Text;
            pen.ID_jenis = ddlJenis.Text;
            //pen.Kategori = tmpKategori;
            if (ktgr == "PERORANGAN")
            {
                if (Convert.ToInt32(txtBebanSKS.Text) == 0)
                { pen.Kategori = 1; }
                else { pen.Kategori = 2; }
            }
            else if (ktgr == "KELOMPOK")
            {
                if (Convert.ToInt32(txtBebanSKS.Text) == 0)
                { pen.Kategori = 3; }
                else
                { pen.Kategori = 4; }
            }
            pen.Lokasi = txtLokasi.Text;
            pen.Dana = int.Parse(TextBox4.Text);
            pen.NPP = prop.getNPPbyNama(tmpnama);
            if (ktgr == "InternalKelompok")
            {
                pen.Anggota1 = txtNPPAnggota1.Text;
                pen.Anggota2 = txtNPPAnggota2.Text;
                pen.SksAnggota = int.Parse(txtSKSAnggota.Text);
            }
            pen.ID_Schedule = "1";
            pen.Cek_Rev = false;
            pen.ID_Review1 = "kosong";
            pen.ID_Review2 = "kosong";
            pen.Sks = Convert.ToInt32(txtBebanSKS.Text);
            pen.ID_Approval = 1;
            pen.Keyword = txtKataKunci.Text;
            pen.JarakKM = Convert.ToInt32(txtJarakKM.Text);
            pen.JarakJAM = Convert.ToInt32(txtJarakJam.Text);
            pen.SesuaiUnit = Convert.ToInt32(ddLRencanaUnit.SelectedValue);
            if (CheckBox1.Checked == true)
            {
                pen.Outcome = CheckBox1.Text + "," + CheckBox7.Text;
            }
            if (CheckBox2.Checked == true)
            {
                pen.Outcome += "," + CheckBox2.Text;
            }
            if (CheckBox3.Checked == true)
            {
                pen.Outcome += "," + CheckBox3.Text;
            }
            if (CheckBox4.Checked == true)
            {
                pen.Outcome += "," + CheckBox4.Text;
            }
            if (CheckBox5.Checked == true)
            {
                pen.Outcome += "," + CheckBox5.Text;
            }
            if (CheckBox6.Checked == true)
            {
                pen.Outcome += "," + txtTrackRecord.Text;
            }
            //pen.Outcome = txtTrackRecord.Text;
            //pen.SesuaiAgenda = txtKegiatanPribadi.Text;
            pen.DanaPribadi = Convert.ToInt32(TextBox5.Text);

            if (FileUpload1.HasFile)
            {
                Stream fs = default(Stream);
                fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                pen.Dokumen = pdfbytes;
            }
            pen.Awal = Convert.ToDateTime(dateMulai.Text);

            if (dateSelesai.Text == "1 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 1;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));


            }
            else if (dateSelesai.Text == "2 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 2;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }
            else if (dateSelesai.Text == "3 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 3;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }
            else if (dateSelesai.Text == "4 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 4;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }
            else if (dateSelesai.Text == "5 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 5;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }
            else if (dateSelesai.Text == "6 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 6;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }


            return pen;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string temp_idProp = Request.QueryString["id"];
            string trev1, trev2;
            trev1 = prop.getIDREV1ByID(temp_idProp);
            trev2 = prop.getIDREV2ByID(temp_idProp);
            if (trev1 == "kosong" && trev2 == "kosong")
            {
                if (prop.RevisiPenelitian1(setDataPen(), temp_idProp))
                {

                    //MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Perubahan data berhasil!');", true);
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                  //  MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Perubahan data gagal!');", true);
                }
            }
            else if (trev1 != "kosong" && trev2 != "kosong")
            {
                if (prop.RevisiPenelitian2(setDataPen(), temp_idProp))
                {

                    //MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Perubahan data berhasil!');", true);
                    Response.Redirect("Profile.aspx");
                }
                else
                {
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Perubahan data gagal!');", true);
                }
            }
            else {
                Response.Redirect("ErorRevisi.aspx");
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void ddLRencanaUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}