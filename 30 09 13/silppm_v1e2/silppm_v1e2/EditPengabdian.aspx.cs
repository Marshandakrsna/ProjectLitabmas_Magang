using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace silppm_v1e2
{
    public partial class WebForm100 : System.Web.UI.Page
    {
        private UserDAO datauser = new UserDAO();
        private ProposalDAO prop = new ProposalDAO();
        private ProposalPengabdianDAO abdi = new ProposalPengabdianDAO();
        private PropPengab pengab = new PropPengab();
        private DataTable dtTema = new DataTable();
        private string tmpusername, tmpKategori,tmpnpp;
        private int idprodi;
        private string temp_idProp;
        protected void Page_Load(object sender, EventArgs e)
        {
            panelAnggota.Visible = false;
            panelSksAnggota.Visible = false;
            //tmpKategori = Request.QueryString["Type"];
            temp_idProp =  Request.QueryString["id"];
            if (Session["userdata"] != "null")
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                tmpusername = ue.Username;
                tmpnpp=ue.NPP;
                lblPeriode.Text = abdi.getNamaPeriodeByIDProposal(temp_idProp);
                lblJenisPengabdian.Text = abdi.getjenisByID(temp_idProp);
                idprodi = datauser.getProdiByNPP(ue.NPP);
                if (!Page.IsPostBack)
                {
                    dtTema.Clear();
                    dtTema = abdi.getTemaPengabdian(idprodi);
                    ddLRencanaUnit.DataSource = dtTema;
                    ddLRencanaUnit.DataValueField = "ID_ROAD_MAP_PENGABDIAN";
                    ddLRencanaUnit.DataTextField = "DESKRIPSI";
                    ddLRencanaUnit.DataBind();
                }

                


            }
        }
        private PropPengab setDataPengab()
        {
            pengab.Id_proposal = abdi.getMaxCount() + 1;
            pengab.Idkaryawan = tmpnpp;
            pengab.Review1 = "kosong";
            pengab.Review2 = "kosong";
            pengab.Jenis = lblJenisPengabdian.Text;
            pengab.Judul = txtJudul.Text;
            pengab.Landasan = txtJudulPenelitian.Text;
            if (tmpKategori == "Kelompok")
            {
                pengab.Anggota1 = txtNama1.Text;
                pengab.Anggota2 = txtNama2.Text;
                pengab.Keahlian1 = txtBidang1.Text;
                pengab.Keahlian2 = txtBidang2.Text;
                pengab.SksAnggota = Convert.ToInt32(txtSksAnggota.Text);
            }
            pengab.Mitra = txtNamaMitra.Text;
            pengab.Keahlianmitra = txtKeahlianMitra.Text;
            pengab.Lokasi = txtLokasi.Text;
            pengab.Output = txtOutput.Text;
            if (CheckBox1.Checked == true)
            {
                pengab.Outcome = CheckBox1.Text + "," + CheckBox7.Text;
            }
            if (CheckBox2.Checked == true)
            {
                pengab.Outcome += "," + CheckBox2.Text;
            }
            if (CheckBox3.Checked == true)
            {
                pengab.Outcome += "," + CheckBox3.Text;
            }
            if (CheckBox4.Checked == true)
            {
                pengab.Outcome += "," + CheckBox4.Text;
            }
            if (CheckBox5.Checked == true)
            {
                pengab.Outcome += "," + CheckBox5.Text;
            }
            if (CheckBox6.Checked == true)
            {
                pengab.Outcome += "," + txtTrackRecord.Text;
            }
            pengab.Waktu = Convert.ToDateTime(dateMulai.Text);
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
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));


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
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
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
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
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
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
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
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
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
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }
            pengab.Sasaran = txtSasaran.Text;
            pengab.SesuaiUNIT = Convert.ToInt32(ddLRencanaUnit.SelectedValue);
            //pengab.SesuaiTRACK = txtTrackRecord.Text;
            //pengab.SesuaiAGENDA = txtKegiatanPribadi.Text;
            pengab.DanaUajy = Convert.ToInt32(TextBox4.Text);
            pengab.DanaPribadi = Convert.ToInt32(TextBox5.Text);
            pengab.Status = "1";
            //int
            pengab.Id_sumber = 0;
            pengab.Id_schedule = abdi.getIDPeriodeAktif();
            pengab.JarakPTlokasi = Convert.ToInt32(txtJarak.Text);
            pengab.SksKetua = Convert.ToInt32(txtSksKetua.Text);

            if (FileUpload1.HasFile)
            {
                Stream fs = default(Stream);
                fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                pengab.Dokumen = pdfbytes;
            }
            pengab.Ip_address = HttpContext.Current.Request.UserHostAddress;
            pengab.Userid = tmpusername;
            pengab.Insert_date = DateTime.Now;

            return pengab;
        }

        protected void BtnSimpan_Click(object sender, EventArgs e)
        {
            
            string input = FileUpload1.FileName;
            Match match = Regex.Match(input, @"PENGABDIAN_\w{2}_\w{5}[.pdf]");
            if (!match.Success)
            {
                // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Nama File Anda Harus Sesuai!');", true);
            }
            else if (abdi.EditProposal(setDataPengab(), temp_idProp))
            {

                // MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data berhasil!');", true);
                Response.Redirect("Profile.aspx");



            }
            else
            {
                // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data gagal!');", true);
            }

        }
    }
}