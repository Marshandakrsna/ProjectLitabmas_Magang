using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using silppm_v1e2.Entity;
using System.IO;
using System.Windows.Forms;

using System.Collections;

using System.Xml.Linq;
using System.Text.RegularExpressions;


namespace silppm_v1e2
{
    public partial class HomePenelitian : System.Web.UI.Page
    {
        private DataTable dtTema = new DataTable();
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO datauser = new UserDAO();
        private PropPen pen = new PropPen();
        private string tmpnama,tmpusername,tmpidproposal,tmpawal,tmpakhir,tmpval,tmpnpp;
        public string lati,loti, tmpKategori;
        private int idprodi, tmptanggal;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                tmpnama = ue.NAMA;
                tmpusername = ue.Username;
                tmpnpp = ue.NPP;
            tmpawal = prop.getawalPeriode();
            tmpakhir = prop.getAkhirPeriode();
            
            if (DateTime.Today < Convert.ToDateTime(tmpawal) || DateTime.Today > Convert.ToDateTime(tmpakhir)) {
                Response.Redirect("ErrorPeriode.aspx");
            }
            if (!prop.cekPenelitianSelesai(ue.NPP)) {
                    Response.Redirect("ErrorPenelitianSelesai.aspx");
                }
            

            tmpKategori = Request.QueryString["id"];
            lbl2.Text = tmpKategori;
            //pnlMap.Visible = false;
           //dtDosen = ;
            
                lblPeriode.Text = prop.getNamaPeriode();
                idprodi = datauser.getProdiByNPP(ue.NPP);
                
                if (!Page.IsPostBack)
                {
                    dtTema = prop.getTemaPenelitian(idprodi);
                    ddLRencanaUnit.DataSource = dtTema;
                    ddLRencanaUnit.DataValueField = "ID_ROAD_MAP_PENELITIAN";
                    ddLRencanaUnit.DataTextField = "DESKRIPSI";
                    ddLRencanaUnit.DataBind();
                }
                lblNamaKetua.Text = tmpnama;
                lblNPPKetua.Text = datauser.getNPPByUsername(tmpusername);
                lblAlamatKetua.Text = datauser.getAlamatByUsername(tmpusername) ;
                lblEmailKetua.Text =datauser.getEmailDosen(tmpusername);
                lblFakKetua.Text = datauser.getFakultasByUsername(tmpusername);
                lblGolKetua.Text = datauser.getGolByUsername(tmpusername);
                lblTelpKetua.Text = datauser.getTelpByUsername(tmpusername);
                lblPangkatKetua.Text = datauser.getPangkatByUsername(tmpusername);
                lblNIDNKetua.Text= datauser.getNIDNbyUsername(tmpusername);
                lblJurusanKetua.Text = datauser.getjurusanByUsername(tmpusername);
                
                if (tmpKategori == "InternalPerorangan") {
                    pnlAnggotaKelompok.Visible = false;
                    pnlSKSAnggota.Visible = false;
                    //generateIDPerorangan();
                }
                else if (tmpKategori == "InternalKelompok") {
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
        //ga kepake
        public void generateIDPerorangan()
        {
            string idorder;
            int id=prop.getMaxCountPerorangan();
            idorder =  id.ToString();
            //tmpidproposal =  "PnO"+ idorder ;
        }
        public void generateIDKelompok()
        {
            string idorder;
            int id = prop.getMaxCountKelompok();
            idorder = id.ToString(); ;
            //tmpidproposal = "PnK" + idorder  ;
        }
        private PropPen setDataPen() {
            int idid;
            try { idid = prop.getMaxCount(); }
            catch { idid = 0; }
            pen.Latitude = "";
            pen.Longitude = "";
            pen.ID_prop = idid + 1;
            tmpidproposal = pen.ID_prop.ToString();
            pen.Judul = txtJudul.Text;
            pen.ID_jenis = ddlJenis.Text;
            //pen.Kategori = tmpKategori;
            if (tmpKategori == "InternalPerorangan")
            {
                if (Convert.ToInt32(txtBebanSKS.Text) == 0)
                { pen.Kategori = 1; }
                else {pen.Kategori = 2;}
            }
            else if (tmpKategori == "InternalKelompok")
            {
                if (Convert.ToInt32(txtBebanSKS.Text) == 0)
                { pen.Kategori = 3;}
                else
                {pen.Kategori = 4;}
            }
            pen.Lokasi = txtLokasi.Text;
            pen.Dana = int.Parse(TextBox4.Text);
            pen.NPP = prop.getNPPbyNama(tmpnama);
             if (tmpKategori == "InternalKelompok") {
                 pen.Anggota1 = txtNPPAnggota1.Text;
                 pen.Anggota2 = txtNPPAnggota2.Text;
                 pen.SksAnggota = int.Parse(txtSKSAnggota.Text);
                }
            pen.ID_Schedule = prop.getIDPeriodeAktif();
            pen.Cek_Rev = false;
            pen.ID_Review1 = "kosong";
            pen.ID_Review2 = "kosong";
            pen.Sks = Convert.ToInt32(txtBebanSKS.Text);
            pen.ID_Approval = 1;
            pen.Keyword = txtKataKunci.Text;
            pen.JarakKM = Convert.ToInt32(txtJarakKM.Text);
            pen.JarakJAM = Convert.ToInt32(txtJarakJam.Text);
            pen.SesuaiUnit = Convert.ToInt32(ddLRencanaUnit.SelectedValue);
            if (CheckBox1.Checked == true) {
                pen.Outcome = CheckBox1.Text+","+CheckBox7.Text;
            }
            if (CheckBox2.Checked == true)
            {
                pen.Outcome += ","+CheckBox2.Text;
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
            pen.Awal =  Convert.ToDateTime(dateMulai.Text);
            
            if (dateSelesai.Text == "1 bulan") {
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
                else {
                    tmpyear2 = tmpyear1;
                }
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if(tmptanggal==31 || tmptanggal==30 || tmptanggal==29){
                    if(tmpdate==2){
                        tmptanggal = 28;
                    }
                    else if(tmpdate==4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11){
                        tmptanggal = 30;
                    }
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/"+tmptanggal+"/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
                  

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
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

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
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

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
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

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
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

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
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pen.Akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            }
            pen.Ip_address = HttpContext.Current.Request.UserHostAddress;
            pen.Userid = tmpusername;
            pen.Insert_date = DateTime.Now;

            return pen;
        }
        protected void ddlDosen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string input = FileUpload1.FileName;
            Match match = Regex.Match(input, @"PENELITIAN_\w{2}_\w{5}[.pdf]", RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                // Finally, we get the Group value and display it.
                //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                     "alert('Nama File Anda Harus Sesuai!');", true);
            }
            else if (prop.addProposal(setDataPen()))
            {
                
                string email = datauser.getEmailProdiByNPPDosen(tmpnpp);
                string judul = prop.getjudulByID(tmpidproposal);
                //string password = alumniMgr.getPassByUser(username);

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(Email.emailAccount);
                mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di setujui";

                string Body = @"Anda memiliki Permohonan proposal dengan judul :"
                    + "<br/>Judul : " + judul
                    + "  <br/>Untuk melakukan konfirmasi terhadap proposal penelitian ini, silahkan kunjungi halaman SILPPM dan buka pada panel Pengesahan Proposal Penelitian.<br/> Terimakasih.";
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
                    Response.Redirect("BerhasilPenelitian.aspx");
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
            else
            {
                //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data gagal!');", true);
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
    }
}