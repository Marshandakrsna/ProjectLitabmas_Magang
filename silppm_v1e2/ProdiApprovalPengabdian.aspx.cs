using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using silppm_v1e2.Entity;
using System.Net.Mail;

namespace silppm_v1e2
{
    public partial class WebForm67 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private UserDAO user = new UserDAO();
        //private Email email = new Email();
        private string tmpNppProdi, tmpid;
        private double dana1, dana2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                tmpid = Request.QueryString["id"];
                UserEntity ue = Session["userdata"] as UserEntity;


                tmpNppProdi = ue.NPP;

                //ddlDana.DataSource = prop.getSbrDana();
                //ddlDana.DataBind();

                dataset.Clear();
                dataset = prop.getProdiDataProposalByIDProposal(tmpid);
                lblPeriode.Text = prop.getNamaPeriodeByIDProposal(tmpid);
                lblJudul.Text = dataset.Tables[0].Rows[0][7].ToString(); ;
                lblLandasan.Text = dataset.Tables[0].Rows[0][7].ToString(); ;
                lblJenis.Text = dataset.Tables[0].Rows[0][8].ToString(); ;
                lblDosenPengusul.Text =  prop.getNamaDosenbyIDProposal_Penelitian(tmpid);
                lblAnggota1.Text = user.getNamaByNPP(dataset.Tables[0].Rows[0][09].ToString());//10
                lblAnggota2.Text = user.getNamaByNPP(dataset.Tables[0].Rows[0][11].ToString());//12
                lblMitra.Text = dataset.Tables[0].Rows[0][13].ToString(); ;
                lblLokasi.Text = dataset.Tables[0].Rows[0][15].ToString(); ;
                lblJarak.Text = dataset.Tables[0].Rows[0][16].ToString(); ;
                lblOutput.Text = dataset.Tables[0].Rows[0][17].ToString(); ;
                lblOutcome.Text = dataset.Tables[0].Rows[0][18].ToString(); ;
                lblAwal.Text = dataset.Tables[0].Rows[0][19].ToString(); ;
                lblAkhir.Text = dataset.Tables[0].Rows[0][20].ToString(); ;
                lblSasaran.Text = dataset.Tables[0].Rows[0][21].ToString(); ;
                lblSKSKetua.Text = dataset.Tables[0].Rows[0][22].ToString(); ;
                lblSKSAnggota.Text = dataset.Tables[0].Rows[0][23].ToString(); ;
                lblTopik.Text = prop.getNamaTemaPengabdian(tmpid);
                lblDanaUajy.Text = dataset.Tables[0].Rows[0][25].ToString(); ;
                lblDanaPribadi.Text = dataset.Tables[0].Rows[0][26].ToString(); ;
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int cek = 1;
            int stt = 2;
            if (prop.updateProdi(cek, tmpid, stt))
            {
                if (prop.updateBiayaProdi(Convert.ToInt32(txtBiayaSetuju.Text), tmpid))
                {
                    string email = user.getEmailbyIDPengabdian(tmpid);

                    string nama = user.getNamaByIDPengabdian(tmpid);
                    string namaProdi = user.getNamaByNPP(tmpNppProdi);
                    string judul = prop.getjudulByID(tmpid);
                    

                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress(Email.emailAccount);
                    mail.Subject = "[Pemberitahuan] Selamat Proposal anda " + judul + " mendapatkan approval dari Prodi";

                    string Body = @"Selamat " + nama
                        + ",<br/> Proposal anda telah mendapatkan persetujuan dari Prodi &#40;" + namaProdi + "&#41;. <br/>"
                        + "<br/>Judul : " + judul
                        + "  <br/> Selanjutnya silahkan tunggu konfirmasi dari Dekan, Assessor dan KA LPPM.<br/> Terimakasih.";
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
                        kirimEmailProdiKeDekan();
                        Response.Redirect("ProdiBerhasilUpdate.aspx");
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
                                kirimEmailProdiKeDekan();
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
            }
        }

        protected void LblRevisi_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProdiAddFeedBackPengabdian.aspx?id=" + tmpid);
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
        public void kirimEmailProdiKeDekan() {

            string email = user.getEmailDekanByNPPProdi(tmpNppProdi);
            string judul = prop.getjudulByID(tmpid);
            //string password = alumniMgr.getPassByUser(username);

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(Email.emailAccount);
            mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di setujui";

            string Body = @"Anda memiliki Permohonan proposal dengan judul :"
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
    }
}