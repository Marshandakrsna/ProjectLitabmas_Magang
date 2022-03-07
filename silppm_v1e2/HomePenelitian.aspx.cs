﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using silppm_v1e2.Entity;
using System.IO; 
using System.Collections;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Globalization;


namespace silppm_v1e2
{
    public partial class HomePenelitian : System.Web.UI.Page
    {
        private DataTable dtTema = new DataTable();
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO datauser = new UserDAO();
        private TBL_PENELITIAN pen = new TBL_PENELITIAN();
        private string tmpnama, tmpusername,  tmpval, tmpnpp;
        public string lati, loti; 
        private int idprodi;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                Session["is_valid"] = true;
                UserEntity ue = Session["userdata"] as UserEntity;
                tmpnama = ue.NAMA;
                tmpusername = ue.Username;
                tmpnpp = ue.NPP;
                lblNpp.Text = ue.NPP;
                idprodi = datauser.getProdiByNPP(ue.NPP);
                TabPanel2.Visible = false;
                UpdatePanel4.Visible = false;
            }

            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
            if (!IsPostBack)
            {

                DataTable dtOutput = prop.getOutput();
                if (dtOutput.Rows.Count != 0)
                {
                    cblOutput.DataSource = dtOutput;
                    cblOutput.DataTextField = "DESKRIPSI";
                    cblOutput.DataValueField = "ID_OUTPUT";
                    cblOutput.DataBind();
                }
                DataTable dtPublikasi = prop.getOutcome("1");
                if (dtPublikasi.Rows.Count != 0)
                {
                    cblOutcomePublikasi.DataSource = dtPublikasi;
                    cblOutcomePublikasi.DataTextField = "DESKRIPSI";
                    cblOutcomePublikasi.DataValueField = "ID_OUTCOME";
                    cblOutcomePublikasi.DataBind();
                }
                DataTable dtHaki = prop.getOutcome("2");
                if (dtHaki.Rows.Count != 0)
                {
                    cblOutcomeHaki.DataSource = dtHaki;
                    cblOutcomeHaki.DataTextField = "DESKRIPSI";
                    cblOutcomeHaki.DataValueField = "ID_OUTCOME";
                    cblOutcomeHaki.DataBind();
                }
                if (Request.QueryString["id"] != null)
                {
                    lbl2.Text = Request.QueryString["id"];
                    getDataPen();
                    btn_simpan.Text = "Ubah Proposal";
                }
                else
                {
                    lbl2.Text = "";

                    btn_simpan.Text = "Tambah Proposal";
                }

                DataTable dtTemaPenelitian = prop.getTemaPenelitian(idprodi);
                if (dtTemaPenelitian.Rows.Count > 0)
                {
                    ddLRencanaUnit.DataSource = dtTemaPenelitian;
                    ddLRencanaUnit.DataValueField = "ID_ROAD_MAP_PENELITIAN";
                    ddLRencanaUnit.DataTextField = "DESKRIPSI";
                    ddLRencanaUnit.DataBind();
                }

                lblNamaKetua.Text = tmpnama;

                lblJabatan.Text = datauser.getPangkatByUsername(tmpusername); 
                lblNPPKetua.Text = datauser.getNPPByUsername(tmpusername);
                lblAlamatKetua.Text = datauser.getAlamatByUsername(tmpusername);
                lblEmailKetua.Text = datauser.getEmailDosen(tmpusername);
                lblFakKetua.Text = datauser.getFakultasByUsername(tmpusername);
                lblGolKetua.Text = datauser.getGolByUsername(tmpusername);
                lblTelpKetua.Text = datauser.getTelpByUsername(tmpusername);
                lblPangkatKetua.Text = datauser.getJbtnFungsional(tmpusername);
                lblNIDNKetua.Text = datauser.getNIDNbyUsername(tmpusername);
                lblJurusanKetua.Text = datauser.getjurusanByUsername(tmpusername);

                DataTable dtInstrumen = prop.getTahunAkademik();
                ddlTahun.DataSource = dtInstrumen;
                ddlTahun.DataTextField = "TAHUN_AKADEMIK";
                ddlTahun.DataValueField = "ID_TAHUN_AKADEMIK";
                ddlTahun.DataBind();
                ddlTahun_SelectedIndexChanged(sender, e);

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

                DataTable dtJenisPenelitian = prop.getJenisPenelitian();
                ddlJnsP.DataSource = dtJenisPenelitian;
                ddlJnsP.DataTextField = "JENIS_PENELITIAN";
                ddlJnsP.DataValueField = "ID_JENIS_PENELITIAN";
                ddlJnsP.DataBind();
                //ddlJnsP_SelectedIndexChanged1(sender, e);

                DataTable dtSeminar = prop.getLevelSeminar();
                ddlLevelProsiding.DataSource = dtSeminar;
                ddlLevelProsiding.DataTextField = "LEVEL";
                ddlLevelProsiding.DataValueField = "ID";
                ddlLevelProsiding.DataBind();

                DataTable dtJurnal = prop.getLevelJurnal();
                ddlJurnal.DataSource = dtJurnal;
                ddlJurnal.DataTextField = "LEVEL";
                ddlJurnal.DataValueField = "ID";
                ddlJurnal.DataBind();


                DataTable dtKategori = prop.getKategori();
                ddlKategori.DataSource = dtKategori;
                ddlKategori.DataTextField = "DESKRIPSI";
                ddlKategori.DataValueField = "ID";
                ddlKategori.DataBind();
                getHistPenelitian();
                getPenlitianFinal();
                dateMulai.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
                tanggal_selesai.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
           
            }
        }
        protected void ddlDosen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


        }

        protected void getHistPenelitian()
        {
            gvCV.DataSource = prop.getHstPenelitian(lblNPPKetua.Text);
            gvCV.DataBind();
        }
        protected void refreshgrid()
        { 
            gvAnggota.DataSource = (DataTable) Session["DataAnggota"];
            gvAnggota.DataBind();
        }
        private void getDataAnggota()
        { 
            DataTable dt = prop.getAnggotaPenelitian(lbl2.Text);
            Session["DataAnggota"] = dt;
            refreshgrid();
        }
        private void getDataRAB()
        {
            DataTable dt = prop.GetRAB(lbl2.Text);
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
            DataTable dt = prop.GetDetailRAB(lblRab.Text);
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
        private void getDataPen()
        {
            try
            {

                for (int i = 0; i < cblOutput.Items.Count; i++)
                {
                    if (prop.getOutputByPenelitian(lbl2.Text, cblOutput.Items[i].Value.ToString()))
                        cblOutput.Items[i].Selected = true;
                }
                for (int i = 0; i < cblOutcomePublikasi.Items.Count; i++)
                {
                    if (prop.getOUTCOMEByPenelitian(lbl2.Text, cblOutcomePublikasi.Items[i].Value.ToString()))
                        cblOutcomePublikasi.Items[i].Selected = true;
                }
                for (int i = 0; i < cblOutcomeHaki.Items.Count; i++)
                {
                    if (prop.getOUTCOMEByPenelitian(lbl2.Text, cblOutcomeHaki.Items[i].Value.ToString()))
                        cblOutcomeHaki.Items[i].Selected = true;
                }
                DataRow[] dr = prop.getPenelitian(lbl2.Text).Select();
                getDataAnggota();
                getDataRAB();
                dr[0]["LATITUDE"].ToString();
                dr[0]["LONGITUDE"].ToString();
                txtJudul.Text = dr[0]["JUDUL"].ToString();
                ddlSkim.SelectedValue = dr[0]["ID_SKIM"].ToString();
                ddlTahun.SelectedValue = dr[0]["ID_TAHUN_ANGGARAN"].ToString();
                ddlSemester.SelectedValue = dr[0]["NO_SEMESTER"].ToString();
                ddlTema.SelectedValue = dr[0]["ID_TEMA_UNIVERSITAS"].ToString();
                ddLRencanaUnit.SelectedValue = dr[0]["ID_ROAD_MAP_PENELITIAN"].ToString();
                ddlKategori.SelectedValue = dr[0]["ID_KATEGORI"].ToString();

                txtLokasi.Text = dr[0]["LOKASI"].ToString();
                txtDanaUajy.Text = dr[0]["DANA_UAJY"].ToString().Replace(",0000", "");
                txtDanaPribadi.Text = dr[0]["DANA_PRIBADI"].ToString().Replace(",0000", "");
                txtDanaEks.Text = dr[0]["DANA_EKSTERNAL"].ToString().Replace(",0000", "");
                txtDanaKerjasama.Text = dr[0]["DANA_KERJASAMA"].ToString().Replace(",0000", "");

                txtDanaUajy0.Text = dr[0]["DANA_UAJY"].ToString().Replace(",0000", "");
                txtDanaPribadi0.Text = dr[0]["DANA_PRIBADI"].ToString().Replace(",0000", "");
                txtDanaEks0.Text = dr[0]["DANA_EKSTERNAL"].ToString().Replace(",0000", "");
                txtDanaKerjasama0.Text = dr[0]["DANA_KERJASAMA"].ToString().Replace(",0000", "");

                txtSKSAnggota.Text = dr[0]["BEBAN_SKS_ANGGOTA"].ToString();


                txtBebanSKS.Text = dr[0]["BEBAN_SKS"].ToString();
                txtKataKunci.Text = dr[0]["KEYWORD"].ToString();
                txtJarakKM.Text = dr[0]["JARAK_KAMPUS_KM"].ToString();
                txtJarakJam.Text = dr[0]["JARAK_KAMPUS_JAM"].ToString();

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

                btn_simpan.Text = "Ubah Proposal";
            }
            catch (Exception ex) {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal! periksa kelengkapan data');", true);
            }
        }

        private TBL_PENELITIAN setDataPen()
        {
            #region
            //id penelitian diganti increment
            //int idid;
            //try { idid = prop.getMaxCount(); }
            //catch { idid = 0; }
            //pen.ID_prop = idid + 1;
            //if (tmpKategori == "InternalPerorangan")
            //{
            //    if (Convert.ToInt32(txtBebanSKS.Text) == 0)
            //    { pen.Kategori = 1; }
            //    else {pen.Kategori = 2;}
            //}
            //else if (tmpKategori == "InternalKelompok")
            //{
            //    if (Convert.ToInt32(txtBebanSKS.Text) == 0)
            //    { pen.Kategori = 3;}
            //    else
            //    {pen.Kategori = 4;}
            //}
            #endregion
            if(lbl2.Text !="")
            pen.ID_PROPOSAL = Int32.Parse(lbl2.Text);
            pen.LATITUDE = "";
            pen.LONGITUDE = "";
            pen.JUDUL = txtJudul.Text;
            pen.ID_SKIM = Int32.Parse(ddlSkim.SelectedValue.ToString());
            pen.ID_TAHUN_ANGGARAN = Int32.Parse(ddlTahun.SelectedValue.ToString());
            pen.NO_SEMESTER = Int32.Parse(ddlSemester.SelectedValue.ToString());
            pen.ID_TEMA_UNIVERSITAS = Int32.Parse(ddlTema.SelectedValue.ToString());
            if(ddLRencanaUnit.SelectedValue.ToString()!="")
            pen.ID_ROAD_MAP_PENELITIAN = Int32.Parse(ddLRencanaUnit.SelectedValue.ToString());
            pen.ID_KATEGORI = Int32.Parse(ddlKategori.SelectedValue.ToString());
            pen.ID_STATUS_PENELITIAN = 1;
            pen.JENIS = "";

            pen.LOKASI = txtLokasi.Text;
            pen.DANA_UAJY = txtDanaUajy.Text == "" ? 0 : int.Parse(txtDanaUajy.Text);
            pen.DANA_PRIBADI = txtDanaPribadi.Text=="" ? 0 : Convert.ToInt32(txtDanaPribadi.Text)  ;
            pen.DANA_EKSTERNAL = txtDanaEks.Text=="" ? 0 : Convert.ToInt32(txtDanaEks.Text);
            pen.DANA_KERJASAMA = txtDanaKerjasama.Text == "" ? 0 : Convert.ToInt32(txtDanaKerjasama.Text);
            pen.DANA_USUL = pen.DANA_UAJY + pen.DANA_PRIBADI + pen.DANA_KERJASAMA + pen.DANA_EKSTERNAL;
            pen.DANA_SETUJU = pen.DANA_USUL;
            pen.ID_JENIS_PENELITIAN= Int32.Parse(ddlJnsP.SelectedValue.ToString());

            pen.NPP = prop.getNPPbyNama(tmpnama);
            if (txtSKSAnggota.Text!="")
            { 
                pen.BEBAN_SKS_ANGGOTA = int.Parse(txtSKSAnggota.Text);
            }
            else { 
                pen.BEBAN_SKS_ANGGOTA = 0;
            }
            pen.BEBAN_SKS = Convert.ToInt32(txtBebanSKS.Text);
            pen.KEYWORD = txtKataKunci.Text;
            pen.JARAK_KAMPUS_KM = Convert.ToInt32(txtJarakKM.Text);
            pen.JARAK_KAMPUS_JAM = Convert.ToInt32(txtJarakJam.Text);
            //if (CheckBox1.Checked == true)
            //{
            //    pen.OUTCOME = CheckBox1.Text + "," + CheckBox7.Text;
            //}
            //if (CheckBox2.Checked == true)
            //{
            //    pen.OUTCOME += "," + CheckBox2.Text;
            //}
            //if (CheckBox3.Checked == true)
            //{
            //    pen.OUTCOME += "," + CheckBox3.Text;
            //}
            //if (CheckBox4.Checked == true)
            //{
            //    pen.OUTCOME += "," + CheckBox4.Text;
            //}
            //if (CheckBox5.Checked == true)
            //{
            //    pen.OUTCOME += "," + CheckBox5.Text;
            //}
            //if (CheckBox6.Checked == true)
            //{
            //    pen.OUTCOME += "," + txtTrackRecord.Text;
            //}
            List<String> listOutput = new List<string>();
            foreach (ListItem item in cblOutput.Items)
            {
                if (item.Selected)
                {
                    listOutput.Add(item.Value);
                }
            }
            String outputStr = String.Join(",", listOutput.ToArray());
            pen.OUTCOME = outputStr;
            if (FileUpload1.HasFile)
            {
                Stream fs = default(Stream);
                fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                pen.DOKUMEN = pdfbytes;
            }
            if (FileUpload2.HasFile)
            {
                Stream fs = default(Stream);
                fs = FileUpload2.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] pdfbytes = br1.ReadBytes(FileUpload2.PostedFile.ContentLength);
                pen.LEMBAR_PENGESAHAN = pdfbytes;
            }
            pen.AWAL = Convert.ToDateTime(dateMulai.Text);
            pen.AKHIR = Convert.ToDateTime(tanggal_selesai.Text);
            //pen.AKHIR = pen.Awal.AddMonths(Int32.Parse(dateSelesai.SelectedValue.ToString()));

            #region edit by rachel, untuk mendapatkan tgl akhir algoritma terlalu rumit
            //if (dateSelesai.Text == "1 bulan") {
            //    int tmpdate, tmpyear2, tmpyear1;
            //    string tmp1;
            //    tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));                
            //    tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
            //    tmpdate = Convert.ToInt32(tmp1) + 1;                
            //    if (tmpdate > 12)
            //    {
            //        tmpdate = tmpdate - 12;
            //        tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
            //    }
            //    else {
            //        tmpyear2 = tmpyear1;
            //    }
            //    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
            //    if(tmptanggal==31 || tmptanggal==30 || tmptanggal==29){
            //        if(tmpdate==2){
            //            tmptanggal = 28;
            //        }
            //        else if(tmpdate==4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11){
            //            tmptanggal = 30;
            //        }
            //    }
            //    pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/"+tmptanggal+"/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            //}
            //else if (dateSelesai.Text == "2 bulan")
            //{
            //    int tmpdate, tmpyear2, tmpyear1;
            //    string tmp1;

            //    tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
            //    tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
            //    tmpdate = Convert.ToInt32(tmp1) + 2;
            //    if (tmpdate > 12)
            //    {
            //        tmpdate = tmpdate - 12;
            //        tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
            //    }
            //    else
            //    {
            //        tmpyear2 = tmpyear1;
            //    }
            //    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
            //    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
            //    {
            //        if (tmpdate == 2)
            //        {
            //            tmptanggal = 28;
            //        }
            //        else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
            //        {
            //            tmptanggal = 30;
            //        }
            //    }
            //    pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            //}
            //else if (dateSelesai.Text == "3 bulan")
            //{
            //    int tmpdate, tmpyear2, tmpyear1;
            //    string tmp1;

            //    tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
            //    tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
            //    tmpdate = Convert.ToInt32(tmp1) + 3;
            //    if (tmpdate > 12)
            //    {
            //        tmpdate = tmpdate - 12;
            //        tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
            //    }
            //    else
            //    {
            //        tmpyear2 = tmpyear1;
            //    }
            //    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
            //    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
            //    {
            //        if (tmpdate == 2)
            //        {
            //            tmptanggal = 28;
            //        }
            //        else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
            //        {
            //            tmptanggal = 30;
            //        }
            //    }
            //    pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            //}
            //else if (dateSelesai.Text == "4 bulan")
            //{
            //    int tmpdate, tmpyear2, tmpyear1;
            //    string tmp1;

            //    tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
            //    tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
            //    tmpdate = Convert.ToInt32(tmp1) + 4;
            //    if (tmpdate > 12)
            //    {
            //        tmpdate = tmpdate - 12;
            //        tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
            //    }
            //    else
            //    {
            //        tmpyear2 = tmpyear1;
            //    }
            //    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
            //    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
            //    {
            //        if (tmpdate == 2)
            //        {
            //            tmptanggal = 28;
            //        }
            //        else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
            //        {
            //            tmptanggal = 30;
            //        }
            //    }
            //    pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            //}
            //else if (dateSelesai.Text == "5 bulan")
            //{
            //    int tmpdate, tmpyear2, tmpyear1;
            //    string tmp1;

            //    tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
            //    tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
            //    tmpdate = Convert.ToInt32(tmp1) + 5;
            //    if (tmpdate > 12)
            //    {
            //        tmpdate = tmpdate - 12;
            //        tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
            //    }
            //    else
            //    {
            //        tmpyear2 = tmpyear1;
            //    }
            //    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
            //    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
            //    {
            //        if (tmpdate == 2)
            //        {
            //            tmptanggal = 28;
            //        }
            //        else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
            //        {
            //            tmptanggal = 30;
            //        }
            //    }
            //    pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            //}
            //else if (dateSelesai.Text == "6 bulan")
            //{
            //    int tmpdate, tmpyear2, tmpyear1;
            //    string tmp1;

            //    tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
            //    tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
            //    tmpdate = Convert.ToInt32(tmp1) + 6;
            //    if (tmpdate > 12)
            //    {
            //        tmpdate = tmpdate - 12;
            //        tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
            //    }
            //    else
            //    {
            //        tmpyear2 = tmpyear1;
            //    }
            //    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
            //    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
            //    {
            //        if (tmpdate == 2)
            //        {
            //            tmptanggal = 28;
            //        }
            //        else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
            //        {
            //            tmptanggal = 30;
            //        }
            //    }
            //    pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            //}
            #endregion
            pen.IP_ADDRESS = HttpContext.Current.Request.UserHostAddress;
            pen.USER_ID = tmpusername;
            pen.INSERT_DATE = DateTime.Now;

            return pen;
        }

        protected void cbPct_CheckedChanged(object sender, EventArgs e)
        {
            DataTable dtRab = (DataTable)Session["DataRAB"];
            object sum;
            sum = dtRab.Compute("Sum(PERSENTASE)", "");

            CheckBox chkKirim = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkKirim.NamingContainer;
            string id = gvRab.DataKeys[row.RowIndex]["ID_RAB_PENELITIAN"].ToString();
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
                        prop.updatePctRAB(Int32.Parse(id), decimal.Parse(pct.Text));
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

        protected void Button1_Click1(object sender, EventArgs e)
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                          "alert('tidak boleh lebih kecil dari anggaran!');", true);
                    return;
                }

                if (prop.updateProposal(setDataPen()))
                {
                    int id_prop = Int32.Parse(lbl2.Text);
                    foreach (ListItem item in cblOutput.Items)
                    {
                        if (item.Selected)
                        {
                            prop.insertOutput(id_prop, item.Value);
                        }
                        else
                        {
                            prop.deleteOutput(id_prop, item.Value);
                        }
                    }

                    foreach (ListItem item in cblOutcomePublikasi.Items)
                    {
                        if (item.Selected)
                        {
                            prop.insertOutcome(id_prop, item.Value, "1");
                        }
                        else
                        {
                            prop.deleteOutcome(id_prop, item.Value);
                        }
                    }
                    foreach (ListItem item in cblOutcomeHaki.Items)
                    {
                        if (item.Selected)
                        {
                            prop.insertOutcome(id_prop, item.Value, "2");
                        }
                        else
                        {
                            prop.deleteOutcome(id_prop, item.Value);
                        }
                    } 
                    getDataPen();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                              "alert('Berhasil!');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                              "alert('Gagal!');", true);
            }
            else
            {
                string input = FileUpload1.FileName;
                //Match match = Regex.Match(input, @"PENELITIAN_\w{2}_\w{5}[.pdf]", RegexOptions.IgnoreCase);
                //if (!match.Success)
                //{
                //    // Finally, we get the Group value and display it.
                //    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                //                         "alert('Nama File Anda Harus Sesuai!');", true);
                //}
                //else 
                int id_prop = prop.addProposal(setDataPen());
                if (id_prop > 0)
                {
                    foreach (ListItem item in cblOutput.Items)
                    {
                        if (item.Selected)
                        {
                            prop.insertOutput(id_prop, item.Value);
                        }
                        else
                        {
                            prop.deleteOutput(id_prop, item.Value);
                        }
                    }

                    foreach (ListItem item in cblOutcomePublikasi.Items)
                    {
                        if (item.Selected)
                        {
                            prop.insertOutcome(id_prop, item.Value, "1");
                        }
                        else
                        {
                            prop.deleteOutcome(id_prop, item.Value);
                        }
                    }
                    foreach (ListItem item in cblOutcomeHaki.Items)
                    {
                        if (item.Selected)
                        {
                            prop.insertOutcome(id_prop, item.Value, "2");
                        }
                        else
                        {
                            prop.deleteOutcome(id_prop, item.Value);
                        }
                    } 
                    lbl2.Text = id_prop.ToString();
                    getDataPen();
                    //string email = datauser.getEmailProdiByNPPDosen(tmpnpp);
                    //string judul = prop.getjudulByID(txtJudul.Text);
                    ////string password = alumniMgr.getPassByUser(username);

                    //MailMessage mail = new MailMessage();
                    //mail.To.Add(email);
                    //mail.From = new MailAddress(Email.emailAccount);
                    //mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di setujui";

                    //string Body = @"Anda memiliki Permohonan proposal dengan judul :"
                    //    + "<br/>Judul : " + judul
                    //    + "  <br/>Untuk melakukan konfirmasi terhadap proposal penelitian ini, silahkan kunjungi halaman SILPPM dan buka pada panel Pengesahan Proposal Penelitian.<br/> Terimakasih.";
                    //mail.Body = Body;
                    //mail.IsBodyHtml = true;
                    //SmtpClient smtp = new SmtpClient();
                    //smtp.Host = Email.emailHost;
                    //smtp.Port = Convert.ToInt32(Email.emailPort);
                    //smtp.UseDefaultCredentials = false;
                    //smtp.Credentials = new System.Net.NetworkCredential(Email.emailAccount, Email.emailPassword);
                    //smtp.EnableSsl = false;

                    //try
                    //{
                    //    smtp.Send(mail);
                    //    //Response.Redirect("BerhasilPenelitian.aspx");
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    //              "alert('Berhasil!');", true);
                    //}
                    //catch (System.Net.Mail.SmtpFailedRecipientsException recExc)
                    //{
                    //    for (int recipient = 0; recipient < recExc.InnerExceptions.Length - 1; recipient++)
                    //    {
                    //        System.Net.Mail.SmtpStatusCode statusCode;
                    //        //Each InnerException is an System.Net.Mail.SmtpFailed RecipientException
                    //        statusCode = recExc.InnerExceptions[recipient].StatusCode;

                    //        if ((statusCode == System.Net.Mail.SmtpStatusCode.MailboxBusy) || (statusCode == System.Net.Mail.SmtpStatusCode.MailboxUnavailable))
                    //        {
                    //            //Log this to event log: recExc.InnerExceptions[recipient].FailedRecipient
                    //            System.Threading.Thread.Sleep(5000);
                    //            smtp.Send(mail);
                    //        }
                    //        else
                    //        {
                    //            //Log error to event log.
                    //            //recExc.InnerExceptions[recipient].StatusCode or use statusCode
                    //        }

                    //    }
                    //}
                    ////General SMTP execptions
                    //catch (System.Net.Mail.SmtpException)
                    //{
                    //    //Log error to event log using StatusCode information in
                    //    //smtpExc.StatusCode
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    //              "alert('Berhasil simpan proposal, namun gagal mengirim email notiikasi! Hubungi Administrator!');", true);
                    //    // System.Windows.Forms.MessageBox.Show("", "Gagal", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                    //}
                    //catch (Exception)
                    //{
                    //    //Log error to event log.
                    //}


                }
                else
                {
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                          "alert('Penambahan data gagal!');", true);
                }
            }
        }

        protected void btnShare_Click(object sender, EventArgs e)
        {
            //pnlMap.Visible = true;


        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddLRencanaUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            tmpval = ddLRencanaUnit.SelectedValue;
        }

        protected void ddlTahun_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtInstrumen = prop.getSemesterAkademik(ddlTahun.SelectedValue.ToString());
            ddlSemester.DataSource = dtInstrumen;
            ddlSemester.DataTextField = "SEMESTER_AKADEMIK";
            ddlSemester.DataValueField = "NO_SEMESTER";
            ddlSemester.DataBind();


            //DataTable dtPenelitian = prop.cekPenelitian(ddlTahun.SelectedValue.ToString(), tmpnpp);
            //if (dtPenelitian.Rows.Count > 0)
            //{
            //    btn_simpan.Visible = false;
            //    Response.Redirect("Profile.aspx");
            //}
            //else
            //    btn_simpan.Visible = true;
        }

        protected void gvAnggota_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvAnggota_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnSelesai_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        protected void btnSimpanAnggota_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable) Session["DataAnggota"]  ;
            DataRow p =dt.NewRow();
            p["ALAMAT"] = txtAlamat.Text;
            p["ALAMAT_KODEPOS"] = txtKodepos.Text;
            p["ALAMAT_KOTA"] = txtKota.Text;
            p["ALAMAT_PROVINSI"] = txtProp.Text;
            p["BIDANG_KEAHLIAN_PENELITIAN"] = txtKeahlian.Text;
            p["EMAIL"] = txtEmail.Text;
            if(lbl2.Text !="")
                p["ID_PROPOSAL"] = Int32.Parse(lbl2.Text);
            if (lbl_personil.Text != "")
                p["ID_PERSONIL_PENELITIAN"]= Int32.Parse(lbl_personil.Text);
            p["NIP_PNS"]= txt_npp_anggota.Text;
            p["NAMA_LENGKAP_GELAR"] = txt_nama_anggota.Text;
            p["NPWP"] = txtNPWP.Text;
            p["NIDN"] = txt_NIDN.Text;
            p["NO_TELPON_HP"]= txtHp.Text;
            p["NO_TELPON_RUMAH"] = txtTelp.Text;
            p["INSTITUSI_ASAL"] = txt_unit.Text;
            dt.Rows.Add(p);
            //dt.AcceptChanges();
            //Session["DataAnggota"] = dt;
            //refreshgrid();

            if (lbl2.Text != "")
            {
                prop.insertAnggotaNonUAJY(lbl2.Text, p);
                 getDataAnggota();
            }
        }

        protected void ddlSkim_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlSkim.SelectedItem.ToString().ToLower().Contains("perorangan"))
            {
                pnlAnggotaKelompok.Visible = false;
                pnlSKSAnggota.Visible = false;
                pnlAnggota.Visible = false;
                panelKaryawan.Visible = false;
            }
            else if (ddlSkim.SelectedItem.ToString().ToLower().Contains("kelompok")) 
            {
                pnlAnggotaKelompok.Visible = true;
                pnlSKSAnggota.Visible = true;
                pnlAnggota.Visible = true;
                panelKaryawan.Visible = true;
            }
        }

        protected void gvKaryawan_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string NPP = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Select")
            {
                try
                {
                    if (lbl2.Text != "") { 
                        prop.insertAnggotaPenelitian(lbl2.Text, NPP);
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

        protected void btn_cariPopKaryawan_Click(object sender, EventArgs e)
        {
            GridViewKaryawan();
            ModalPopupExtender2.Show();
        }

        protected void txtSearchKAryawan_TextChanged(object sender, EventArgs e)
        {
            refreshGridViewKaryawan();
            ModalPopupExtender2.Show();
        }

        protected void btnSelesaiKaryawak_Click(object sender, EventArgs e)
        {
            ModalPopupExtender2.Hide();
        }

        protected void gvRab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID_RAB_PENELITIAN = Convert.ToString(e.CommandArgument);
             if (e.CommandName == "Anggaran")
             {
                 clearDetail();
                 lblRab.Text = ID_RAB_PENELITIAN;
                 DataTable dt = (DataTable)Session["DataRAB"];
                 DataRow[] dr = dt.Select("ID_RAB_PENELITIAN=" + ID_RAB_PENELITIAN);
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

        protected void gvRab_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnDtlRab_Click(object sender, EventArgs e)
        {
            ModalPopupExtender3.Show();
        }

        protected void gvDtl_RAB_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID_DTL_RAB_PENELITIAN = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Select")
            {
                lblDtlRab.Text = ID_DTL_RAB_PENELITIAN;

                DataTable dt = (DataTable)Session["DataDetailRAB"];
                DataRow[] dr = dt.Select("ID_DTL_RAB_PENELITIAN=" + ID_DTL_RAB_PENELITIAN);
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



        protected void BtnProsiding_Click(object sender, EventArgs e)
        {

        }

        protected void btnSelesai4_Click(object sender, EventArgs e)
        {

        }

        protected void gvDtl_PROSIDING_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void getPenlitianFinal()
        {
            gvLaporanFinal.DataSource = prop.getHstPenelitianfinal(lblNPPKetua.Text);
            gvLaporanFinal.DataBind();
        }
        protected void ButtonDtlProsiding_Click(object sender, EventArgs e)
        {

        }

        protected void gvLaporanFinal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID_PROPOSAL = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "prosiding")
            {

                ModalPopupExtender4.Show();
                Label5.Text = ID_PROPOSAL;
                getHistoryProsidingfinal();

            }

            if (e.CommandName == "jurnal")
            {

                ModalPopupExtender5.Show();
                Label4.Text = ID_PROPOSAL;
                getHistoryJurnalfinal();

            }


        }

        protected void btnSelesaiProsiding_Click(object sender, EventArgs e)
        {
            ModalPopupExtender4.Hide();
            clearDetail();
        }
        protected void getHistoryProsidingfinal()
        {
            gvDtlProsiding.DataSource = prop.getHistoryProsiding(lblNPPKetua.Text);
            gvDtlProsiding.DataBind();
        }

        protected void getHistoryJurnalfinal()
        {
            gvJurnal.DataSource = prop.getHistoryJurnal(lblNPPKetua.Text);
            gvJurnal.DataBind();
        }
        protected void gvDtlProsiding_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID_OUTCOME_PROSIDING = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "hapus")
            {

                
                Label6.Text = ID_OUTCOME_PROSIDING;
                prop.hapusProsiding(Label6.Text);
                getHistoryProsidingfinal();


            }
        }

        protected void BtnSimpanProsiding_Click(object sender, EventArgs e)
        {
            if (Label5.Text != "")
            {
                TBL_PUBLIKASI_SEMINAR prosidingfinal = new TBL_PUBLIKASI_SEMINAR();
                prosidingfinal.JUDUL = TextBoxJudul.Text;
                prosidingfinal.ID_LEVEL_SEMINAR = Int32.Parse(ddlLevelProsiding.SelectedValue.ToString()); ;
                prosidingfinal.NAMA_JURNAL = TextBoxNamaSeminar.Text;
                prosidingfinal.ISSN = TextBoxISBN.Text;
                prosidingfinal.DOI = TextBoxDOI.Text;
                prosidingfinal.ID_PROPOSAL = Int32.Parse(Label5.Text);


                if (Label6.Text != "")
                {

                }
                else
                    prop.insertPublikasi(prosidingfinal);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                    "alert('Sukses!, Berhasil tambah Prosiding');", true);
                    clearDetail();
                    getHistoryProsidingfinal();



            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal!, dana tidak boleh lebih besar dari usualan');", true);
            }
        }

        protected void ButtonClosej_Click(object sender, EventArgs e)
        {
            ModalPopupExtender5.Hide();
            clearDetail();
        }

        protected void ButtonSimpanJ_Click(object sender, EventArgs e)
        {
            
            if (Label4.Text != "")
            {
                TBL_PUBLIKASI_JURNAL jurnalFinal = new TBL_PUBLIKASI_JURNAL();
                jurnalFinal.JUDUL = TextBoxJdlJurnal.Text;
                jurnalFinal.ID_LEVEL_JURNAL = Int32.Parse(ddlJurnal.SelectedValue.ToString()); ;
                jurnalFinal.NAMA_SEMINAR = TextBoxNamaSeminarJ.Text;
                jurnalFinal.ISSN = TextBoxISSNJ.Text;
                jurnalFinal.DOI = TextBoxDOIJ.Text;
                jurnalFinal.ID_PROPOSAL = Int32.Parse(Label4.Text);


                if (Label7.Text != "")
                {

                }
                else
                prop.insertJurnal(jurnalFinal);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                "alert('Sukses!, Berhasil tambah Jurnal');", true);

                getHistoryJurnalfinal();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal!);", true);
            }
        }

        protected void gvJurnal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
               "alert('Sukses!, Berhasil tambah Jurnal');", true);
            string ID_OUTCOME_PUBLIKASI = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "hapus")
            {


                Label7.Text = ID_OUTCOME_PUBLIKASI;
                prop.hapusJurnal(Label7.Text);
                getHistoryJurnalfinal();
            }
        }

        protected void ddlJnsP_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (id_jenis_penelitian != 2)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "hide", "changeVisibility()", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "changeVisibility()", true);
            }
            else
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "changeVisibilityShow()", true);

                ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "show", "changeVisibilityShow()", true);
            }*/

        }

        protected void ddlJnsP_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int id_jenis_penelitian= Int32.Parse(ddlJnsP.SelectedIndex.ToString());
            if (id_jenis_penelitian == 0) 
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "hide", "changeVisibility()", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "changeVisibility()", true);
                txtLokasi.Visible = false;
                txtJarakJam.Visible = false;
                txtJarakKM.Visible = false;
            }
            if ((id_jenis_penelitian == 1) || (id_jenis_penelitian == 2))
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "changeVisibilityShow()", true);
              
                txtLokasi.Visible = true;
                txtJarakJam.Visible = true;
                txtJarakKM.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "show", "changeVisibilityShow()", true);
            }
           
        }

        protected void btnSimpanDetail_Click(object sender, EventArgs e)
        {
            decimal jml = txtJumlah.Text == "" ? 0 : decimal.Parse(txtJumlah.Text);
            decimal jml_lama = txtJumlah0.Text == "" ? 0 : decimal.Parse(txtJumlah0.Text);

            decimal jmlDtl = lblTotalRAB0.Text == "" ? 0 : decimal.Parse(lblTotalRAB0.Text.Replace(",",""));

            decimal usulMin= lblMin0.Text == "" ? 0 : decimal.Parse(lblMin0.Text.Replace(",", ""));
            //decimal usulMax = lblMax0.Text == "" ? 0 : decimal.Parse(lblMax0.Text.Replace(",", ""));

            if ((jml-jml_lama+jmlDtl) <= usulMin)
            {
                DTL_RAB_PENELITIAN dtl = new DTL_RAB_PENELITIAN();
                dtl.KETERANGAN = txtRincian.Text;
                dtl.JUMLAH = txtVolume.Text == "" ? 0 : Int32.Parse(txtVolume.Text);
                dtl.ID_RAB_PENELITIAN = Int32.Parse(lblRab.Text);
                dtl.HARGA_SATUAN = txtHargaSatuan.Text == "" ? 0 : decimal.Parse(txtHargaSatuan.Text);
                dtl.JUMLAH_DANA = txtJumlah.Text == "" ? 0 : decimal.Parse(txtJumlah.Text);
                dtl.SATUAN = txtSatuan.Text;
                if (lblDtlRab.Text != "")
                {
                    dtl.ID_DTL_RAB_PENELITIAN = Int32.Parse(lblDtlRab.Text);
                    prop.updatetRAB(dtl);
                }
                else
                    prop.insertRAB(dtl);
                getDataDtlRAB();
                getDataRAB();
                clearDetail();
            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal!, dana tidak boleh lebih besar dari usualan');", true);
            }
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
            TextBoxJudul.Text = "";
            TextBoxDOIJ.Text = "";
            TextBoxJdlJurnal.Text = "";
            TextBoxISSNJ.Text = "";
            TextBoxNamaSeminarJ.Text = "";
            TextBoxNamaSeminar.Text = "";
            TextBoxISBN.Text = "";
            TextBoxDOI.Text = "";
       

        }

        protected void txtVolume_TextChanged(object sender, EventArgs e)
        {
            int JUMLAH = txtVolume.Text == "" ? 0 : Int32.Parse(txtVolume.Text);
            decimal HARGA_SATUAN = txtHargaSatuan.Text == "" ? 0 : decimal.Parse(txtHargaSatuan.Text);
            txtJumlah.Text = (JUMLAH * HARGA_SATUAN).ToString();
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

    }
}