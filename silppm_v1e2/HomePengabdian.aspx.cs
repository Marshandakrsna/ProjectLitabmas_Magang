using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace silppm_v1e2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private UserDAO datauser = new UserDAO();
        private ProposalDAO prop = new ProposalDAO();
        private ProposalPengabdianDAO abdi = new ProposalPengabdianDAO();
        private PropPengab pengab = new PropPengab();
        private DataTable dtTema = new DataTable();
        private string tmpusername, tmpKategori,tmpid;
        private int idprodi,tmptanggal;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                pnlAnggota.Visible = false;
                panelSksAnggota.Visible = false;
                tmpKategori = Request.QueryString["Type"];

                if (Session["userdata"] != "null")
                {
                    UserEntity ue = Session["userdata"] as UserEntity;
                    tmpusername = ue.Username; 
                    lblPeriode.Text = prop.getNamaPeriode();
                    lblNamaKetua.Text = datauser.getNamaByUsername(tmpusername);
                    lblFakKetua.Text = datauser.getFakultasByUsername(tmpusername);
                    lblGolonganKetua.Text = datauser.getGolByUsername(tmpusername);
                    lblAlamatKetua.Text = datauser.getAlamatByUsername(tmpusername);
                    lblNPPKetua.Text = datauser.getNPPByUsername(tmpusername);
                    lblNIDNKetua.Text = Convert.ToString(datauser.getNIDNbyUsername(tmpusername));
                    //lblTelpKetua.Text = datauser.getTelpByUsername(tmpusername);
                    lblJurusanKetua.Text = datauser.getjurusanByUsername(tmpusername);

                    idprodi = datauser.getProdiByNPP(ue.NPP);
                    DataTable RencanaUnit = new DataTable();
                    RencanaUnit = abdi.getTemaPengabdian(idprodi);
                    ddLRencanaUnit.DataSource = RencanaUnit;
                    ddLRencanaUnit.DataValueField = "ID_ROAD_MAP_PENGABDIAN";
                    ddLRencanaUnit.DataTextField = "DESKRIPSI";
                    ddLRencanaUnit.DataBind();

                    DataTable dtInstrumen = prop.getTahunAkademik();
                    ddlTahun.DataSource = dtInstrumen;
                    ddlTahun.DataTextField = "TAHUN_AKADEMIK";
                    ddlTahun.DataValueField = "ID_TAHUN_AKADEMIK";
                    ddlTahun.DataBind();
                    ddlTahun_SelectedIndexChanged(sender, e);

                    if (tmpKategori == "Perorangan")
                    {
                        lblJenisPengabdian.Text = "Individu";
                        pnlAnggota.Visible = false;
                        panelSksAnggota.Visible = false;
                        //generateIDPerorangan();
                    }
                    else if (tmpKategori == "Kelompok")
                    {
                        lblJenisPengabdian.Text = "Kelompok";
                        pnlAnggota.Visible = true;
                        panelSksAnggota.Visible = true;
                        //generateIDKelompok();
                    }

                    DataTable dtTema = prop.getTema();
                    ddlTema.DataSource = dtTema;
                    ddlTema.DataTextField = "DESKRIPSI";
                    ddlTema.DataValueField = "ID";
                    ddlTema.DataBind();

                    DataTable dtSkim = prop.getSkim();
                    ddlSkim.DataSource = dtSkim;
                    ddlSkim.DataTextField = "DESKRIPSI";
                    ddlSkim.DataValueField = "ID";
                    ddlSkim.DataBind();
                    ddlSkim_SelectedIndexChanged(sender, e);

                    DataTable dtKategori = prop.getKategori();
                    //ddlKategori.DataSource = dtKategori;
                    //ddlKategori.DataTextField = "DESKRIPSI";
                    //ddlKategori.DataValueField = "ID";
                    //ddlKategori.DataBind();
                }
                GridViewKaryawan(); 
                if (Request.QueryString["id"] != null)
                {
                    lbl2.Text = Request.QueryString["id"];
                    getDataPen(sender, e);
                    BtnSimpan.Text = "Ubah Proposal";
                }
                else
                {
                    lbl2.Text = "";

                    BtnSimpan.Text = "Tambah Proposal";
                }
            }
        }

        private void getDataPen(object sender, EventArgs e)
        {
            DataTable dt = abdi.getPengabdian(lbl2.Text);
            DataRow[] dr = dt.Select();
            getDataAnggota();
            getDataRAB();
            //dr[0]["LATITUDE"].ToString();
            //dr[0]["LONGITUDE"].ToString();
            txtJudul.Text = dr[0]["JUDUL_KEGIATAN"].ToString();
            txtOutput.Text = dr[0]["Output"].ToString();
            txtSasaran.Text = dr[0]["Sasaran"].ToString();
            txtJudulPenelitian.Text = dr[0]["LANDASAN_PENELITIAN"].ToString();
            txtNamaMitra.Text = dr[0]["Mitra"].ToString();
            txtKeahlianMitra.Text = dr[0]["MITRA_KEAHLIAN"].ToString();
            ddlSkim.SelectedValue = dr[0]["ID_SKIM"].ToString();
            ddlSkim_SelectedIndexChanged(sender, e);
            ddlTahun.SelectedValue = dr[0]["ID_TAHUN_ANGGARAN"].ToString();
            ddlTahun_SelectedIndexChanged(sender, e);
            ddlSemester.SelectedValue = dr[0]["NO_SEMESTER"].ToString();
            ddlTema.SelectedValue = dr[0]["ID_TEMA_UNIVERSITAS"].ToString();
            ddLRencanaUnit.SelectedValue = dr[0]["ID_ROAD_MAP"].ToString();
            //ddlKategori.SelectedValue = dr[0]["ID_KATEGORI"].ToString();

            txtLokasi.Text = dr[0]["LOKASI"].ToString();
            txtDanaUajy.Text = dr[0]["DANA_UAJY"].ToString().Replace(",0000", "");
            txtDanaPribadi.Text = dr[0]["DANA_PRIBADI"].ToString().Replace(",0000", "");
            txtDanaEks.Text = dr[0]["DANA_EKSTERNAL"].ToString().Replace(",0000", "");
            txtDanaKerjasama.Text = dr[0]["DANA_KERJASAMA"].ToString().Replace(",0000", "");

            txtDanaUajy0.Text = dr[0]["DANA_UAJY"].ToString().Replace(",0000", "");
            txtDanaPribadi0.Text = dr[0]["DANA_PRIBADI"].ToString().Replace(",0000", "");
            txtDanaEks0.Text = dr[0]["DANA_EKSTERNAL"].ToString().Replace(",0000", "");
            txtDanaKerjasama0.Text = dr[0]["DANA_KERJASAMA"].ToString().Replace(",0000", "");

            txtSksAnggota.Text = dr[0]["SKS_ANGGOTA"].ToString();


            txtSksKetua.Text = dr[0]["SKS_KETUA"].ToString();
           // txtKataKunci.Text = dr[0]["KEYWORD"].ToString();
            txtJarak.Text = dr[0]["JARAK_PT_LOKASI"].ToString();
            //txtJarakJam.Text = dr[0]["JARAK_KAMPUS_JAM"].ToString();

            //if (CheckBox1.Checked == true)
            //{
            //    dr[0]["OUTCOME"].ToString() = CheckBox1.Text + "," + CheckBox7.Text;
            //}
            //if (CheckBox2.Checked == true)
            //{
            //    dr[0]["OUTCOME += "," + CheckBox2.Text;
            //}
            //if (CheckBox3.Checked == true)
            //{
            //    dr[0]["OUTCOME += "," + CheckBox3.Text;
            //}
            //if (CheckBox4.Checked == true)
            //{
            //    dr[0]["OUTCOME += "," + CheckBox4.Text;
            //}
            //if (CheckBox5.Checked == true)
            //{
            //    dr[0]["OUTCOME += "," + CheckBox5.Text;
            //}
            //if (CheckBox6.Checked == true)
            //{
            //    dr[0]["OUTCOME += "," + txtTrackRecord.Text;
            //}

            //if (FileUpload1.HasFile)
            //{
            //    Stream fs = default(Stream);
            //    fs = FileUpload1.PostedFile.InputStream;
            //    BinaryReader br1 = new BinaryReader(fs);
            //    byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
            //    dr[0]["DOKUMEN = pdfbytes;
            //}
            //if (FileUpload2.HasFile)
            //{
            //    Stream fs = default(Stream);
            //    fs = FileUpload2.PostedFile.InputStream;
            //    BinaryReader br1 = new BinaryReader(fs);
            //    byte[] pdfbytes = br1.ReadBytes(FileUpload2.PostedFile.ContentLength);
            //    dr[0]["LEMBAR_PENGESAHAN = pdfbytes;
            //}
            dateMulai.Text = dr[0]["AWAL"].ToString();
            tanggal_selesai.Text = dr[0]["AKHIR"].ToString();

            BtnSimpan.Text = "Ubah Proposal";
        }

        protected void ddlTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtInstrumen = prop.getSemesterAkademik(ddlTahun.SelectedValue.ToString());
            ddlSemester.DataSource = dtInstrumen;
            ddlSemester.DataTextField = "SEMESTER_AKADEMIK";
            ddlSemester.DataValueField = "NO_SEMESTER";
            ddlSemester.DataBind();


            //DataTable dtPenelitian = prop.cekPenelitian(ddlTahun.SelectedValue.ToString(), tmpusername);
            //if (dtPenelitian.Rows.Count > 0)
            //{
            //    BtnSimpan.Visible = false;
            //    Response.Redirect("Profile.aspx");
            //}
            //else
            //    BtnSimpan.Visible = true;
        }

        public void generateIDPerorangan()
        {
            string idorder;
            int id = abdi.getCountPerorangan() +1;
            idorder = id.ToString();
            //tmpidproposal = "PgO" + idorder;
        }
        public void generateIDKelompok()
        {
            string idorder;
            int id = abdi.getCountKelompok() + 1; 
            idorder = id.ToString(); ;
            //tmpidproposal = "PgK" + idorder;
        }
        private PropPengab setDataPengab() {
            pengab.Id_proposal = abdi.getMaxCount()+1;
            tmpid = pengab.Id_proposal.ToString();
            pengab.Idkaryawan = lblNPPKetua.Text;
            pengab.ID_TAHUN_ANGGARAN1 = Int32.Parse(ddlTahun.SelectedValue.ToString());
            pengab.NO_SEMESTER1 = Int32.Parse(ddlSemester.SelectedValue.ToString());
            pengab.Review1 = "kosong";
            pengab.Review2 = "kosong"; 
            
            pengab.ID_SKIM = ddlSkim.SelectedValue.ToString();
            pengab.ID_TEMA_UNIVERSITAS = ddlTema.SelectedValue.ToString();
            pengab.Jenis = lblJenisPengabdian.Text;
            pengab.Judul = txtJudul.Text;
            pengab.Landasan = txtJudulPenelitian.Text;
            if (tmpKategori == "Kelompok")
            {
                pengab.Anggota1 = "";
                pengab.Anggota2 = "";
                pengab.Keahlian1 = "";
                pengab.Keahlian2 = "";
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
            int drs = Int32.Parse(dateSelesai.SelectedValue);
            pengab.Waktu = Convert.ToDateTime(dateMulai.Text);
            pengab.Durasi = Convert.ToDateTime(dateMulai.Text).AddMonths(drs);
            pengab.Sasaran = txtSasaran.Text;
            pengab.SesuaiUNIT = Convert.ToInt32(ddLRencanaUnit.SelectedValue);
            //pengab.SesuaiTRACK = txtTrackRecord.Text;
            //pengab.SesuaiAGENDA = txtKegiatanPribadi.Text;
            pengab.DanaUajy = Convert.ToInt32(txtDanaUajy.Text);
            pengab.DanaPribadi = Convert.ToInt32(txtDanaPribadi.Text);
            if (txtDanaEks.Text != "")
                pengab.DANA_EKSTERNAL1 = Convert.ToInt32(txtDanaEks.Text);
            if (txtDanaKerjasama.Text != "")
                pengab.DANA_KERJASAMA1 = Convert.ToInt32(txtDanaKerjasama.Text);
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
            //Match match = Regex.Match(input, @"PENGABDIAN_\w{2}_\w{5}[.pdf]");
            //if (!match.Success)
            //{
            //   // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
            //                          "alert('Nama File Anda Harus Sesuai!');", true);
            //}

            if (lbl2.Text == "")
            {
                sendEmail();
                int id_prop = abdi.addProposal(setDataPengab());
                if (id_prop > 0)
                {
                    lbl2.Text = id_prop.ToString();
                }
                else
                {
                    // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                          "alert('Penambahan data gagal!');", true);
                }
            }
            else {
                abdi.EditProposal(setDataPengab(), lbl2.Text);
            }
        }
        public void sendEmail() {
            string email = datauser.getEmailProdiByNPPDosen(Session["NPP"].ToString());
            string judul = prop.getjudulByID(lbl2.Text);
            //string password = alumniMgr.getPassByUser(username);

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(Email.emailAccount);
            mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di setujui";

            string Body = @",<br/> Anda memiliki Permohonan proposal dengan judul :"
                + "<br/>Judul : " + judul
                + "  <br/>Untuk melakukan konfirmasi terhadap proposal pengabdian ini, silahkan kunjungi halaman SILPPM dan buka pada panel Pengesahan Proposal Pengabdian.<br/> Terimakasih.";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Email.emailHost;
            smtp.Port = Convert.ToInt32(Email.emailPort);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(Email.emailAccount, Email.emailPassword);
            smtp.EnableSsl = false;

            try
            {
                smtp.Send(mail);
                Response.Redirect("BerhasilPENGABDIAN.aspx");
            }
            catch (System.Net.Mail.SmtpFailedRecipientsException recExc)
            {
                for (int recipient = 0; recipient < recExc.InnerExceptions.Length - 1; recipient++)
                {
                    System.Net.Mail.SmtpStatusCode statusCode;
                    //Each InnerException is an System.Net.Mail.SmtpFailed RecipientException
                    statusCode = recExc.InnerExceptions[recipient].StatusCode;

                    if ((statusCode == System.Net.Mail.SmtpStatusCode.MailboxBusy) || (statusCode == System.Net.Mail.SmtpStatusCode.MailboxUnavailable))
                    {
                        //Log this to event log: recExc.InnerExceptions[recipient].FailedRecipient
                        System.Threading.Thread.Sleep(5000);
                        smtp.Send(mail);
                    }
                    else
                    {
                        //Log error to event log.
                        //recExc.InnerExceptions[recipient].StatusCode or use statusCode
                    }

                }
            }
            //General SMTP execptions
            catch (System.Net.Mail.SmtpException)
            {
                //Log error to event log using StatusCode information in
                //smtpExc.StatusCode
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal Mengirim Email! Periksa Koneksi Internet Anda!');", true);
                // System.Windows.Forms.MessageBox.Show("", "Gagal", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            }
            catch (Exception)
            {
                //Log error to event log.
            }
               
        }

        protected void ddlSkim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSkim.SelectedItem.ToString().ToLower().Contains("perorangan"))
            {
                pnlAnggotaKelompok.Visible = false;
                panelSksAnggota.Visible = false;
                pnlAnggota.Visible = false;
                panelKaryawan.Visible = false;
            }
            else if (ddlSkim.SelectedItem.ToString().ToLower().Contains("kelompok"))
            {
                pnlAnggotaKelompok.Visible = true;
                panelSksAnggota.Visible = true;
                pnlAnggota.Visible = true;
                panelKaryawan.Visible = true;
            }
        }

        protected void ddLRencanaUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //tmpval = ddLRencanaUnit.SelectedValue;
        }

        protected void btnSimpanAnggota_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["DataAnggota"];
            DataRow p = dt.NewRow();
            p["ALAMAT"] = txtAlamat.Text;
            p["ALAMAT_KODEPOS"] = txtKodepos.Text;
            p["ALAMAT_KOTA"] = txtKota.Text;
            p["ALAMAT_PROVINSI"] = txtProp.Text;
            p["BIDANG_KEAHLIAN_PENGABDIAN"] = txtKeahlian.Text;
            p["EMAIL"] = txtEmail.Text;
            if (lbl2.Text != "")
                p["ID_PROPOSAL"] = Int32.Parse(lbl2.Text);
            if (lbl_personil.Text != "")
                p["ID_PERSONIL_PENGABDIAN"] = Int32.Parse(lbl_personil.Text);
            p["NIP_PNS"] = txt_npp_anggota.Text;
            p["NAMA_LENGKAP_GELAR"] = txt_nama_anggota.Text;
            p["NPWP"] = txtNPWP.Text;
            p["NIDN"] = txt_NIDN.Text;
            p["NO_TELPON_HP"] = txtHp.Text;
            p["NO_TELPON_RUMAH"] = txtTelp.Text;
            p["INSTITUSI_ASAL"] = txt_unit.Text;
            dt.Rows.Add(p);
            dt.AcceptChanges();
            Session["DataAnggota"] = dt;
            refreshgrid();

            if (lbl2.Text != "")
            {
                abdi.insertAnggotaNonUAJY(lbl2.Text, p);
                getDataAnggota();
            }
        }

        protected void refreshgrid()
        {
            gvAnggota.DataSource = (DataTable)Session["DataAnggota"];
            gvAnggota.DataBind();
        }
        private void getDataAnggota()
        {
            DataTable dt = abdi.getAnggotaPENGABDIAN(lbl2.Text);
            Session["DataAnggota"] = dt;
            refreshgrid();
        }
        protected void btnSelesai_Click(object sender, EventArgs e)
        {

            ModalPopupExtender1.Hide();
        }

        protected void btn_cariPopKaryawan_Click(object sender, EventArgs e)
        {

            GridViewKaryawan();
            ModalPopupExtender2.Show();
        }
        public void GridViewKaryawan()
        {
            DataTable dt = prop.GetDataKaryawan("");
            Session["DataKaryawan"] = dt;
            refreshGridViewKaryawan();
        }

        public void refreshGridViewKaryawan()
        {
            string keyword = txtSearchKAryawan.Text;
            DataTable dt = (DataTable)Session["DataKaryawan"];
            dt.DefaultView.RowFilter = "NAMA_LENGKAP_GELAR like '%" + keyword + "%' or NPP like '%" + keyword + "%'";
            gvKaryawan.DataSource = dt.DefaultView;
            gvKaryawan.DataBind();

        }

        protected void gvKaryawan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string NPP = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Select")
            {
                try
                {
                    if (lbl2.Text != "")
                    {
                        abdi.insertAnggotaPENGABDIAN(lbl2.Text, NPP);
                        getDataAnggota();
                    }

                    //DataTable dt = prop.GetDataKaryawan(NPP);
                    //txtNPP.Text = dt.Rows[0]["NPP"].ToString();
                    //txtNamaKaryawan.Text = dt.Rows[0]["NAMA_LENGKAP_GELAR"].ToString();
                    //txtUnit.Text = dt.Rows[0]["NAMA_UNIT"].ToString();
                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }

        protected void btnSelesaiKaryawak_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Hide();

        }

        protected void txtVolume_TextChanged(object sender, EventArgs e)
        {
            int JUMLAH = txtVolume.Text == "" ? 0 : Int32.Parse(txtVolume.Text);
            decimal HARGA_SATUAN = txtHargaSatuan.Text == "" ? 0 : decimal.Parse(txtHargaSatuan.Text);
            txtJumlah.Text = (JUMLAH * HARGA_SATUAN).ToString();
     
        }

        protected void btnSimpanDetail_Click(object sender, EventArgs e)
        {
            decimal jml = txtJumlah.Text == "" ? 0 : decimal.Parse(txtJumlah.Text);
            decimal jml_lama = txtJumlah0.Text == "" ? 0 : decimal.Parse(txtJumlah0.Text);

            decimal jmlDtl = lblTotalRAB0.Text == "" ? 0 : decimal.Parse(lblTotalRAB0.Text.Replace(",", ""));

            decimal usulMin = lblMin0.Text == "" ? 0 : decimal.Parse(lblMin0.Text.Replace(",", ""));
            //decimal usulMax = lblMax0.Text == "" ? 0 : decimal.Parse(lblMax0.Text.Replace(",", ""));

            if ((jml - jml_lama + jmlDtl) <= usulMin)
            {
                DTL_RAB_PENGABDIAN dtl = new DTL_RAB_PENGABDIAN();
                dtl.KETERANGAN = txtRincian.Text;
                dtl.JUMLAH = txtVolume.Text == "" ? 0 : Int32.Parse(txtVolume.Text);
                dtl.ID_RAB_PENGABDIAN = Int32.Parse(lblRab.Text);
                dtl.HARGA_SATUAN = txtHargaSatuan.Text == "" ? 0 : decimal.Parse(txtHargaSatuan.Text);
                dtl.JUMLAH_DANA = txtJumlah.Text == "" ? 0 : decimal.Parse(txtJumlah.Text);
                dtl.SATUAN = txtSatuan.Text;
                if (lblDtlRab.Text != "")
                {
                    dtl.ID_DTL_RAB_PENGABDIAN = Int32.Parse(lblDtlRab.Text);
                    abdi.updatetRAB_PENGABDIAN(dtl);
                }
                else
                    abdi.insertRAB_PENGABDIAN(dtl);
                getDataDtlRAB();
                getDataRAB();
                clearDetail();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal!, dana tidak boleh lebih besar dari usualan');", true);
            }

        }

        private void getDataRAB()
        {
            DataTable dt = abdi.GetRAB(lbl2.Text);
            Session["DataRAB"] = dt;
            refreshgridRAB();
        }
        protected void refreshgridRAB()
        {
            gvRab.DataSource = (DataTable)Session["DataRAB"];
            gvRab.DataBind();
        }
        
        private void getDataDtlRAB()
        {
            DataTable dt = abdi.GetDetailRAB(lblRab.Text);
            Session["DataDetailRAB"] = dt;
            refreshgridDtlRAB();
            if (dt.Rows.Count > 0)
            {
                object sumDtl;
                sumDtl = dt.Compute("Sum(JUMLAH_DANA)", "");
                decimal jml = decimal.Parse(sumDtl.ToString());
                lblTotalRAB0.Text = jml.ToString("#,###,###", CultureInfo.InvariantCulture);
            }
            else
                lblTotalRAB0.Text = "0";
        }
        protected void refreshgridDtlRAB()
        {
            gvDtl_RAB.DataSource = (DataTable)Session["DataDetailRAB"];
            gvDtl_RAB.DataBind();
        }
        public void clearDetail()
        {
            txtRincian.Text = "";
            txtVolume.Text = "";
            txtHargaSatuan.Text = "";
            txtJumlah.Text = "";
            txtSatuan.Text = "";
            lblDtlRab.Text = "";
            btnSimpanDetail.Text = "Simpan";
        }

        protected void cbPct_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtRab = (DataTable)Session["DataRAB"];
            object sum;
            sum = dtRab.Compute("Sum(PERSENTASE)", "");

            CheckBox chkKirim = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkKirim.NamingContainer;
            string id = gvRab.DataKeys[row.RowIndex]["ID_RAB_PENGABDIAN"].ToString();
            TextBox pct = (TextBox)row.FindControl("txtPERSENTASE");
            string min = row.Cells[3].Text;
            string max = row.Cells[4].Text;
            string lama = row.Cells[5].Text;
            if (decimal.Parse(pct.Text) + (decimal.Parse(sum.ToString()) - decimal.Parse(lama)) <= 100)
            {
                if (decimal.Parse(pct.Text) >= decimal.Parse(min) && decimal.Parse(pct.Text) <= decimal.Parse(max))
                {
                    if (chkKirim.Checked)
                    {
                        abdi.updatePctRAB(Int32.Parse(id), decimal.Parse(pct.Text));
                        chkKirim.Enabled = false;
                        getDataRAB();
                    }
                }
                else
                {
                    chkKirim.Enabled = true;
                    chkKirim.Checked = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                              "alert('Gagal! harus dibatas min dan max pct');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal! pct tidak boleh lebih dari 100%');", true);
        }
        protected void gvDtl_RAB_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID_DTL_RAB_PENGABDIAN = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Select")
            {
                lblDtlRab.Text = ID_DTL_RAB_PENGABDIAN;

                DataTable dt = (DataTable)Session["DataDetailRAB"];
                DataRow[] dr = dt.Select("ID_DTL_RAB_PENGABDIAN=" + ID_DTL_RAB_PENGABDIAN);
                txtRincian.Text = dr[0]["KETERANGAN"].ToString();
                txtVolume.Text = dr[0]["JUMLAH"].ToString().Replace(",0000", "");
                txtHargaSatuan.Text = dr[0]["HARGA_SATUAN"].ToString().Replace(",0000", "");
                txtJumlah.Text = dr[0]["JUMLAH_DANA"].ToString().Replace(",0000", "");
                txtJumlah0.Text = dr[0]["JUMLAH_DANA"].ToString().Replace(",0000", "");
                txtSatuan.Text = dr[0]["SATUAN"].ToString();
                btnSimpanDetail.Text = "Ubah";
            }

        }

        protected void btnSelesaiDtl_Click(object sender, EventArgs e)
        {
            ModalPopupExtender3.Hide();
        }

        protected void gvAnggota_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvAnggota_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void txtDanaUajy_TextChanged(object sender, EventArgs e)
        {

            decimal UAJY = txtDanaUajy.Text == "" ? 0 : decimal.Parse(txtDanaUajy.Text);
            decimal PRIBADI = txtDanaPribadi.Text == "" ? 0 : decimal.Parse(txtDanaPribadi.Text);
            decimal EKSTERNAL = txtDanaEks.Text == "" ? 0 : decimal.Parse(txtDanaEks.Text);
            decimal KERJASAMA = txtDanaKerjasama.Text == "" ? 0 : decimal.Parse(txtDanaKerjasama.Text);
            decimal USUL = UAJY + PRIBADI + KERJASAMA + EKSTERNAL;
            if (lbl2.Text != "")
            {
                decimal rab = prop.GetSumRAB(lbl2.Text);

                if (USUL < rab)
                {
                    string uajy = txtDanaUajy0.Text;
                    string pribadi = txtDanaPribadi0.Text;
                    string eksternal = txtDanaEks0.Text;
                    string kerjasama = txtDanaKerjasama0.Text;
                    txtDanaUajy.Text = uajy;
                    txtDanaPribadi.Text = pribadi;
                    txtDanaEks.Text = eksternal;
                    txtDanaKerjasama.Text = kerjasama;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                          "alert('tidak boleh lebih kecil dari anggaran!');", true);
                }
                else
                {
                }
            }
        }


        protected void btnDtlRab_Click(object sender, EventArgs e)
        {
            ModalPopupExtender3.Show();
        }

        protected void txtSearchKAryawan_TextChanged(object sender, EventArgs e)
        {
            refreshGridViewKaryawan();
            ModalPopupExtender2.Show();
        }
        protected void gvRab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID_RAB_PENGABDIAN = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Anggaran")
            {
                clearDetail();
                lblRab.Text = ID_RAB_PENGABDIAN;
                DataTable dt = (DataTable)Session["DataRAB"];
                DataRow[] dr = dt.Select("ID_RAB_PENGABDIAN=" + ID_RAB_PENGABDIAN);
                lblJenisRAB.Text = dr[0]["DESKRIPSI"].ToString();
                string pct = dr[0]["PERSENTASE"].ToString().Replace(",00", "");

                lblMin.Text = pct;

                decimal UAJY = txtDanaUajy.Text == "" ? 0 : decimal.Parse(txtDanaUajy.Text);
                decimal PRIBADI = txtDanaPribadi.Text == "" ? 0 : decimal.Parse(txtDanaPribadi.Text);
                decimal EKSTERNAL = txtDanaEks.Text == "" ? 0 : decimal.Parse(txtDanaEks.Text);
                decimal KERJASAMA = txtDanaKerjasama.Text == "" ? 0 : decimal.Parse(txtDanaKerjasama.Text);
                decimal USUL = UAJY + PRIBADI + KERJASAMA + EKSTERNAL;

                decimal minDana = decimal.Parse(pct) * USUL / 100;

                lblTotalRAB.Text = USUL.ToString("#,###,###", CultureInfo.InvariantCulture);
                lblMin0.Text = minDana.ToString("#,###,###", CultureInfo.InvariantCulture);

                getDataDtlRAB();
                ModalPopupExtender3.Show();
            }
        }



    }
}