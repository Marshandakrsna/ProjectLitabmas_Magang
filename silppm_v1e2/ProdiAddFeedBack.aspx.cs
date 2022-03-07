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
    public partial class WebForm50 : System.Web.UI.Page
    {
        private string tmpid,tmpRole,nppProdi,nppDekan;
        private DataSet dataset = new DataSet();
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO user = new UserDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                tmpid = Request.QueryString["id"];
                UserEntity ue = Session["userdata"] as UserEntity;

                tmpRole = ue.Role;
                    nppProdi = ue.NPP;
                    
                


            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
               
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //disini ntar save feedback + update value dari penelitian is_prodi
            if(prop.addfeedback(tmpid,nppProdi,TextBox1.Text,DateTime.Now,RadioButtonList1.Text)){
                int cek = 0,sst;
                if (RadioButtonList1.Text == "Revisi")
                {
                    sst = 4;
                }
                else {
                    sst = 5;
                }
                if (prop.updateProdi(cek,tmpid,sst)) {
                    string email = user.getEmailbyIDenelitian(tmpid);

                    string nama = user.getNamaByIDPenelitian(tmpid);
                    string namaProdi = user.getNamaByNPP(nppProdi);
                    string judul = prop.getjudulByID(tmpid);
                    //string password = alumniMgr.getPassByUser(username);

                    MailMessage mail = new MailMessage();
                    mail.To.Add(email);
                    mail.From = new MailAddress(Email.emailAccount);
                    mail.Subject = "[Pemberitahuan] Proposal anda " + judul + " mendapatkan penolakan dari Prodi";

                    string Body = @"Maaf " + nama
                        + ",<br/> Proposal anda telah mendapatkan penolakan dari Prodi &#40;" + namaProdi + "&#41;. <br/> "
                        + "<br/>Judul : " + judul
                        + "  <br/> dengan status : " + RadioButtonList1.Text + ". Untuk informasi lebih lanjut silahkan kunjungi halaman SILPPM dan buka pada panel My Profile, dan lihat review untuk mengetahui alasan penolakan ini.<br/> Terimakasih.";
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
    }
}