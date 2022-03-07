using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using silppm_v1e2.Entity;
using System.Globalization;
using System.Threading;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.IO;
using System.Windows.Forms;

namespace silppm_v1e2
{
    public partial class WebForm73 : System.Web.UI.Page
    {
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private DataSet dataset = new DataSet();
        private DataSet dsRev1 = new DataSet();
        private DataTable dt = new DataTable();
        private ReviewDAO rev = new ReviewDAO();
        private UserDAO user = new UserDAO();
        public byte[] jadwal;
        private string tmpNppLPPM, tmpid, tmprev;
        private int maxcountrev;
        private double db1, db2, dana1, dana2;
        private DateTime awal, akhir, toLabel, toLabel2, fin, log1, log2, log3, log4, log5, log6;
        private string tmpnpprev,tmpusername;
        private string tmp1, row1c1, row2c1, row3c1, row4c1, row5c1, row6c1, col2, col3, col4, col5;
        private int tmpmonth, dateakhir, tglakhir, bulanakhir, logYear1, logYear2, logMonthAwal, logMonthAkhir, logDayAwal, tmpSelisihmonth, maxInit, tmpyear,tmptanggal;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                tmpid = Request.QueryString["id"];
                UserEntity ue = Session["userdata"] as UserEntity;

                tmpNppLPPM = ue.NPP;
                tmpusername = ue.Username;
                tmprev = prop.getIDREV1ByID(tmpid);
                maxcountrev = rev.getMaxctRevPengabdian(tmpid, tmprev);
                

                //ddlDana.DataSource = prop.getSbrDana();
                //ddlDana.DataBind();

                dataset.Clear();
                dataset = prop.getProdiDataProposalByIDProposal(tmpid);
                lblPeriode.Text = prop.getNamaPeriodeByIDProposal(tmpid);
                lblJudul.Text = dataset.Tables[0].Rows[0][6].ToString(); 
                lblLandasan.Text = dataset.Tables[0].Rows[0][7].ToString(); 
                lblJenis.Text = dataset.Tables[0].Rows[0][8].ToString(); 
                lblDosenPengusul.Text = prop.getNamaDosenbyIDProposal_Penelitian(tmpid);
                lblAnggota1.Text = user.getNamaByNPP(dataset.Tables[0].Rows[0][09].ToString());//10
                lblAnggota2.Text = user.getNamaByNPP(dataset.Tables[0].Rows[0][11].ToString());//12
                lblMitra.Text = dataset.Tables[0].Rows[0][13].ToString(); 
                lblLokasi.Text = dataset.Tables[0].Rows[0][15].ToString(); 
                lblJarak.Text = dataset.Tables[0].Rows[0][16].ToString(); 
                lblOutput.Text = dataset.Tables[0].Rows[0][17].ToString(); 
                lblOutcome.Text = dataset.Tables[0].Rows[0][18].ToString(); 
                lblAwal.Text = dataset.Tables[0].Rows[0][19].ToString(); 
                lblAkhir.Text = dataset.Tables[0].Rows[0][20].ToString(); 
                lblSasaran.Text = dataset.Tables[0].Rows[0][21].ToString(); 
                lblSKSKetua.Text = dataset.Tables[0].Rows[0][22].ToString(); 
                lblSKSAnggota.Text = dataset.Tables[0].Rows[0][23].ToString();
                lblTopik.Text = prop.getNamaTemaPengabdian(tmpid);
                lblDanaUajy.Text = dataset.Tables[0].Rows[0][25].ToString(); 
                lblDanaPribadi.Text = dataset.Tables[0].Rows[0][26].ToString();

                dataset.Clear();
                dsRev1.Clear();
                dsRev1 = rev.getDataReviewPengabdian(tmpid, tmprev, maxcountrev);
                db2 = double.Parse(dsRev1.Tables[0].Rows[0][22].ToString());
                //db1 = double.Parse(dsRev1.Tables[0].Rows[0][17].ToString());
                lblBiayaRekomendasi.Text = string.Format("{0:##,###}", db2);
                lblBiayaSetuju.Text = prop.getDanaDisetujui(tmpid).ToString();

                dsRev1.Clear();
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";
            byte[] temp = prop.getPropsalPenelitian(tmpid);
            Response.BinaryWrite(temp);
            Response.End();
        }
        protected override void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("en-US");
            DateTimeFormatInfo dtfi = CI.DateTimeFormat;
            dtfi.AbbreviatedMonthNames = new string[] { "Jan", "Feb", "Mar", 
                                                  "Apr", "May", "Jun", 
                                                  "Jul", "Aug", "Sep", 
                                                  "Oct", "Nov", "Dec", "" };
            dtfi.AbbreviatedMonthGenitiveNames = dtfi.AbbreviatedMonthNames;
            CI.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
            base.InitializeCulture();

        }
        private void generateJadwalPerpanjangan(string tmpid)
        {
            InitializeCulture();
            awal = prop.getAwalProposal(tmpid);
            akhir = prop.getAkhirProposal(tmpid);

            dateakhir = Convert.ToInt32(String.Format("{0:dd}", akhir));
            if ((dateakhir - 14) < 1)
            {

                DateTime tmpdategen, tmpdategen2;
                bulanakhir = Convert.ToInt32(String.Format("{0:MM}", akhir)) - 1;
                tglakhir = 30 + Convert.ToInt32(String.Format("{0:dd}", akhir)) - 14;
                //toLabel2 = Convert.ToDateTime(String.Format("{0:" + tglakhir + "/" + bulanakhir+"/yyyy}", akhir));
                tmpdategen = Convert.ToDateTime(String.Format("{0:dd/" + bulanakhir + "/yyyy}", akhir));
                tmpdategen2 = Convert.ToDateTime(String.Format("{0:" + tglakhir + "/MM/yyyy}", tmpdategen));
                toLabel2 = Convert.ToDateTime(String.Format("{0:dd/MM/yyyy}", tmpdategen2));
            }
            else
            {
                tglakhir = Convert.ToInt32(String.Format("{0:dd}", akhir)) - 14;
                toLabel2 = Convert.ToDateTime(String.Format("{0:" + tglakhir + "/MM/yyyy}", akhir));
            }
            col3 = toLabel2.ToString().Substring(0, 11);

        }

        public void KirimEmailPustakawan()
        {

            string email = user.getEmailPustakawan();
            string judul = prop.getjudulByID(tmpid);
            //string password = alumniMgr.getPassByUser(username);

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(Email.emailAccount);
            mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di Disetujui";
            string Body = @"Anda memiliki Permohonan proposal dengan judul :"
                + "<br/>Judul : " + judul
                + "  <br/>Untuk dapat melakukan persetujuan terhadap proposal pengabdian ini, silahkan kunjungi halaman SILPPM dan buka pada panel Pengesahan.<br/> Terimakasih.";
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int cek = 1;
            int stt = 14;
            if (prop.updateKALPPM(cek, tmpid, stt))
            {

                if (prop.addProposalLolos(tmpid, int.Parse(lblBiayaRekomendasi.Text, NumberStyles.Currency), DateTime.Now, HttpContext.Current.Request.UserHostAddress,tmpusername))
                {

                    prop.HideProposal(tmpid);

                    if (prop.UpdateStatusDiterima(tmpid))
                    {

                        //generate jadwal
                        InitializeCulture();
                        awal = prop.getAwalProposal(tmpid);
                        akhir = prop.getAkhirProposal(tmpid);

                        dt.Columns.Add("Melakukan Update Logbook", typeof(string));
                        dt.Columns.Add("Upload Laporan Pertama", typeof(string));
                        dt.Columns.Add("Upload Laporan Final", typeof(string));
                        dt.Columns.Add("Paling Lambat Mengajukan Perpanjangan", typeof(string));
                        dt.Columns.Add("Mengumpulkan Outcome ke Perpustakaan", typeof(string));

                        InitializeCulture();
                        logMonthAwal = Convert.ToInt32(String.Format("{0:MM}", awal));
                        logMonthAkhir = Convert.ToInt32(String.Format("{0:MM}", akhir));
                        tmpSelisihmonth = logMonthAkhir - logMonthAwal;
                        logDayAwal = Convert.ToInt32(String.Format("{0:dd}", awal));
                        logYear1 = Convert.ToInt32(String.Format("{0:yyyy}", awal));
                        logYear2 = Convert.ToInt32(String.Format("{0:yyyy}", akhir));
                        if (logYear1 >= logYear2)
                        {
                            for (int i = 1; i <= tmpSelisihmonth; i++)
                            {
                                if (i == 1)
                                {
                                    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                    {
                                        if ((logMonthAwal + i) == 2)
                                        {
                                            tmptanggal = 28;
                                        }
                                        else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                        {
                                            tmptanggal = 30;
                                        }
                                    }
                                    DateTime.TryParse(String.Format("{0:"+tmptanggal+"/" + (logMonthAwal + i) + "/yyyy}", awal), out log1);
                                    row1c1 = log1.ToString().Substring(0, 11);
                                }
                                if (i == 2)
                                {
                                    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                    {
                                        if ((logMonthAwal + i) == 2)
                                        {
                                            tmptanggal = 28;
                                        }
                                        else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                        {
                                            tmptanggal = 30;
                                        }
                                    }
                                    DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log2);
                                    row2c1 = log2.ToString().Substring(0, 11);
                                }
                                if (i == 3)
                                {
                                    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                    {
                                        if ((logMonthAwal + i) == 2)
                                        {
                                            tmptanggal = 28;
                                        }
                                        else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                        {
                                            tmptanggal = 30;
                                        }
                                    }
                                    DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log3);
                                    row3c1 = log3.ToString().Substring(0, 11);
                                }
                                if (i == 4)
                                {
                                    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                    {
                                        if ((logMonthAwal + i) == 2)
                                        {
                                            tmptanggal = 28;
                                        }
                                        else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                        {
                                            tmptanggal = 30;
                                        }
                                    }
                                    DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log4);
                                    row4c1 = log4.ToString().Substring(0, 11);
                                }
                                if (i == 5)
                                {
                                    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                    {
                                        if ((logMonthAwal + i) == 2)
                                        {
                                            tmptanggal = 28;
                                        }
                                        else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                        {
                                            tmptanggal = 30;
                                        }
                                    }
                                    DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log5);
                                    row5c1 = log5.ToString().Substring(0, 11);
                                }
                                if (i == 6)
                                {
                                    tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                    if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                    {
                                        if ((logMonthAwal + i) == 2)
                                        {
                                            tmptanggal = 28;
                                        }
                                        else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                        {
                                            tmptanggal = 30;
                                        }
                                    }
                                    DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log6);
                                    row6c1 = log6.ToString().Substring(0, 11);
                                }
                            }
                        }
                        else if (logYear1 < logYear2)
                        {
                            //(MONTH(AKHIR)+12)-MONTH(AWAL)
                            int selisih2 = (logMonthAkhir + 12) - logMonthAwal;
                            for (int i = 1; i <= selisih2; i++)
                            {
                                if (logMonthAwal + i <= 12)
                                {
                                    if (i == 1)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((logMonthAwal + i) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log1);
                                        row1c1 = log1.ToString().Substring(0, 11);
                                    }
                                    if (i == 2)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((logMonthAwal + i) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log2);
                                        row2c1 = log2.ToString().Substring(0, 11);
                                    }
                                    if (i == 3)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((logMonthAwal + i) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log3);
                                        row3c1 = log3.ToString().Substring(0, 11);
                                    }
                                    if (i == 4)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((logMonthAwal + i) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log4);
                                        row4c1 = log4.ToString().Substring(0, 11);
                                    }
                                    if (i == 5)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((logMonthAwal + i) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log5);
                                        row5c1 = log5.ToString().Substring(0, 11);
                                    }
                                    if (i == 6)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((logMonthAwal + i) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log6);
                                        row6c1 = log6.ToString().Substring(0, 11);
                                    }
                                    maxInit = i;
                                }
                                if (logMonthAwal + i > 12)
                                {
                                    if (i == 1)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((i - maxInit) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log1);
                                        row1c1 = log1.ToString().Substring(0, 11);
                                    }
                                    if (i == 2)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((i - maxInit) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log2);
                                        row2c1 = log2.ToString().Substring(0, 11);
                                    }
                                    if (i == 3)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((i - maxInit) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log3);
                                        row3c1 = log3.ToString().Substring(0, 11);
                                    }
                                    if (i == 4)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((i - maxInit) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log4);
                                        row4c1 = log4.ToString().Substring(0, 11);
                                    }
                                    if (i == 5)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((i - maxInit) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log5);
                                        row5c1 = log5.ToString().Substring(0, 11);
                                    }
                                    if (i == 6)
                                    {
                                        tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                        if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                        {
                                            if ((i - maxInit) == 2)
                                            {
                                                tmptanggal = 28;
                                            }
                                            else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                            {
                                                tmptanggal = 30;
                                            }
                                        }
                                        DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log6);
                                        row6c1 = log6.ToString().Substring(0, 11);
                                    }
                                }

                            }


                        }
                        //labelpertama
                        InitializeCulture();
                        tmp1 = String.Format("{0:MM}", akhir);
                        //string akh1 = akhir.ToString();
                        tmpmonth = Convert.ToInt32(tmp1) - 1;
                        int.TryParse(String.Format("{0:yyyy}", akhir), out tmpyear);
                        if (tmpmonth == 0)
                        {
                            tmpmonth = 12;
                            tmpyear = tmpyear - 1;
                        }
                        toLabel = Convert.ToDateTime(String.Format("{0:dd/" + tmpmonth + "/" + tmpyear + "}", akhir));
                        //toLabel = Convert.ToDateTime(String.Format("{0:dd/" + tmpmonth + "/yyyy}", akhir));
                        col2 = toLabel.ToString().Substring(0, 11);
                        //labelkedua
                        generateJadwalPerpanjangan(tmpid);
                        //labelketiga
                        DateTime.TryParse(String.Format("{0:dd/MM/yyyy}", akhir),out fin);
                        col4 = fin.ToString().Substring(0, 11);

                        //labelkeempat
                        col5 = toLabel.ToString().Substring(0, 11);

                        DataRow dr = dt.NewRow();
                        dr["Melakukan Update Logbook"] = row1c1; // or dr[0]="Mohammad";
                        dr["Upload Laporan Pertama"] = col2;
                        dr["Upload Laporan Final"] = col4; // or dr[1]=24;
                        dr["Paling Lambat Mengajukan Perpanjangan"] = col3;
                        dr["Mengumpulkan Outcome ke Perpustakaan"] = col5;
                        dt.Rows.Add(dr);

                        dr = dt.NewRow();
                        dr["Melakukan Update Logbook"] = row2c1;
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                        dr["Melakukan Update Logbook"] = row3c1;
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                        dr["Melakukan Update Logbook"] = row4c1;
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                        dr["Melakukan Update Logbook"] = row5c1;
                        dt.Rows.Add(dr);
                        dr = dt.NewRow();
                        dr["Melakukan Update Logbook"] = row6c1;
                        dt.Rows.Add(dr);
                        //-----------generate jadwal-------------------------------------------------------------------------------

                        //membuat dokumen jadwal
                        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                        //iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, Color.BLACK);
                        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                        {
                            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                            document.Open();
                            //konten dokumen----------------------------------------------------------------------------------------
                            document.Add(new Paragraph("\n"));
                            document.Add(new Paragraph("JADWAL PENGABDIAN"));
                            document.Add(new Paragraph("\n"));
                            //Craete instance of the pdf table and set the number of column in that table
                            PdfPTable PdfTable = new PdfPTable(5);
                            PdfTable.WidthPercentage = 100;
                            //PdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                            float[] widths = new float[] { 50f, 50f, 50f, 50f, 60f };
                            PdfTable.SetWidths(widths);
                            PdfTable.HorizontalAlignment = 0;
                            PdfPCell PdfPCell = null;


                            //Add Header of the pdf table
                            PdfPCell = new PdfPCell(new Phrase(new Chunk("Melakukan Update Logbook")));
                            PdfPCell.Padding = 5;
                            PdfTable.AddCell(PdfPCell);

                            PdfPCell = new PdfPCell(new Phrase(new Chunk("Upload Laporan Pertama")));
                            PdfPCell.Padding = 5;
                            PdfTable.AddCell(PdfPCell);

                            PdfPCell = new PdfPCell(new Phrase(new Chunk("Upload Laporan Final")));
                            PdfPCell.Padding = 5;

                            PdfTable.AddCell(PdfPCell);
                            PdfPCell.Padding = 5;
                            PdfPCell = new PdfPCell(new Phrase(new Chunk("Paling Lambat Mengajukan Perpanjangan")));

                            PdfTable.AddCell(PdfPCell);

                            PdfPCell = new PdfPCell(new Phrase(new Chunk("Mengumpulkan Outcome ke Perpustakaan")));
                            PdfPCell.Padding = 5;
                            PdfTable.AddCell(PdfPCell);
                            //How add the data from datatable to pdf table
                            for (int rows = 0; rows < dt.Rows.Count; rows++)
                            {
                                for (int column = 0; column < dt.Columns.Count; column++)
                                {
                                    PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString())));
                                    PdfPCell.Padding = 5;

                                    PdfTable.AddCell(PdfPCell);
                                }
                            }

                            PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table


                            document.Add(PdfTable); // add pdf table to the document


                            //------------------------------------------------------------------------------------------------------
                            document.Close();
                            jadwal = memoryStream.ToArray();
                            memoryStream.Close();
                        }
                        //kirim email
                        string email = user.getEmailbyIDPengabdian(tmpid);
                        string judul = prop.getjudulByID(tmpid);
                        string nama = user.getNamaByIDPengabdian(tmpid);
                        //kirim email jadwal
                        MailMessage mail = new MailMessage();
                        mail.To.Add(email.Trim());
                        mail.From = new MailAddress(Email.emailAccount);
                        mail.Subject = "[Pemberitahuan] Selamat Proposal anda " + judul + " mendapatkan approval dari KA LPPM";

                        string Body = @"Selamat " + nama
                    + ",<br/> Proposal anda telah mendapatkan persetujuan dari KA LPPM. <br/> " 
                    + "<br/>Judul : " + judul
                    + "<br/> Berikut telah dilampirkan jadwal pengabdian anda.  <br/> Selanjutnya silahkan datang ke LPPM untuk mencetak surat pengantar pencairan dana.<br/> Terimakasih.";
                        mail.Body = Body;
                        mail.IsBodyHtml = true;


                        Stream stream = new MemoryStream(jadwal);
                        string nama_file;
                        nama_file = "Jadwal " + judul;
                        nama_file = nama_file.Replace(" ", "_");

                        mail.Attachments.Add(new Attachment(stream, nama_file, System.Net.Mime.MediaTypeNames.Application.Pdf));



                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = Email.emailHost;
                        smtp.Port = Convert.ToInt32(Email.emailPort);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(Email.emailAccount, Email.emailPassword);
                        smtp.EnableSsl = false;

                        try
                        {
                            smtp.Send(mail);
                            KirimEmailPustakawan();
                            //System.Windows.Forms.MessageBox.Show("", "Informasi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Jadwal berhasil dikirim!');", true);
                            prop.HideProposal(tmpid);
                            Response.Redirect("KALPPMBerhasilUpdate.aspx");
                            //Exception contains information on each failed receipient
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
                                    KirimEmailPustakawan();
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
                                      "alert('Jadwal gagal dikirim! Mohon coba lagi!');", true);
                           // System.Windows.Forms.MessageBox.Show("", "Gagal", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                        }
                        catch (Exception)
                        {
                            //Log error to event log.
                        }


                    }

                    //update is drop, mauskin penilaian
                }
                else
                {
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Terjadi Kesalahan');", true);
                }
            }

        }

        protected void LblRevisi_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //belum
            Response.Redirect("KALPPMLihatHasilReview.aspx?id=" + tmpid);
        }
    }
}