using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.Data;
using System.Net.Mail;

namespace silppm_v1e2
{
    public partial class WebForm41 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO user = new UserDAO();
        private string tmpid,tmpNppProdi;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];
            Panel1.Visible = false;
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                dataset.Clear();
                dataset = prop.getDataPustaka(tmpid);
                lblJudul.Text = dataset.Tables[0].Rows[0][7].ToString();
                lblJenis.Text = dataset.Tables[0].Rows[0][2].ToString();
                lblKeyword.Text = dataset.Tables[0].Rows[0][17].ToString();
                lblLokasi.Text = dataset.Tables[0].Rows[0][9].ToString();
                
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            if (prop.updateApprovalPustakawan(tmpid))
            {
                if (prop.updatePustakaAppove(tmpid)) {
                    string email = user.getEmailbyIDenelitian(tmpid);

                    string nama = user.getNamaByIDPenelitian(tmpid);
                    string namaProdi = user.getNamaByNPP(tmpNppProdi);
                    string judul = prop.getjudulByID(tmpid);
                    //string password = alumniMgr.getPassByUser(username);

                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress(Email.emailAccount);
                    mail.Subject = "[Pemberitahuan] Selamat Penelitian anda " + judul + " telah dinyatakan Selesai!";

                    string Body = @"Selamat " + nama
                        + ",<br/> Laporan anda telah mendapatkan persetujuan dari Pustakawan &#40;" + namaProdi + "&#41;. <br/>"
                        + "<br/>Judul : " + judul
                        + "  <br/>Terimakasih<br/>Best Regards, <br/> Lembaga Penelitian dan Pengabdian Masyarakat<br/> Universitas Atma Jaya Yogyakarta.";
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
                        Response.Redirect("PustakaBerhasilApprove.aspx");
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
                        //System.Windows.Forms.MessageBox.Show("", "Gagal", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Gagal Mengirim Email Pemberitahuan ke dosen!');", true);

                    }
                    catch (Exception)
                    {
                        //Log error to event log.
                    }
                    
                    

                }
                
            }
            else { 
            
            }
        }

        protected void BtnLihat_Click(object sender, EventArgs e)
        {
            if (prop.CekLaporan(tmpid))
            {
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/pdf";
                byte[] temp = prop.getLaporanPenelitian(tmpid);
                Response.BinaryWrite(temp);
                Response.End();
            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                          "alert('Dosen Belum melakukan Upload Laporan!');", true);
            }
        }
    }
}