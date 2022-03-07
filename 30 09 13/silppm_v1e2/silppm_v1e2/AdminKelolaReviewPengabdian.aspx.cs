using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Net.Mail;
using silppm_v1e2.Entity;

namespace silppm_v1e2
{
    public partial class WebForm74 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private UserDAO user = new UserDAO();
        private string tmpnpprev;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpnpprev = Request.QueryString["id"];
            if (ScriptManager.GetCurrent(Page) == null)
            {
                Page.Form.Controls.AddAt(0, new ScriptManager());
            }

            bindGridView();

        }
        private void bindGridView()
        {
            if (!IsPostBack)
            {
                dataset.Clear();
                dataset = prop.getListAdminKelolaReview();

                if (dataset.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dataset.Tables[0];
                    GridView1.DataBind();

                }
                else
                {
                    Label1.Visible = true;
                }
            }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "pilih")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);


                if (!prop.inputReview(tmpnpprev, tmp))
                {
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Tidak dapat lagi menambahkan proposal karena kuota telah tercapai.');", true);
                }
                else
                {
                    prop.updateinputReview(tmpnpprev, tmp);
                    bindGridView();
                }



                //if (prop.CekCountReview(tmp) <= 3)
                //{
                //    Response.Redirect("adminKelolaReview.aspx?id=" + tmp);
                //}
                //else
                //{
                //    MessageBox.Show("Tidak dapat lagi menambahkan proposal karena kuota telah tercapai.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string stid = string.Empty;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                System.Web.UI.WebControls.CheckBox CheckBox1 = (System.Web.UI.WebControls.CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

                if (CheckBox1 != null)
                {
                    if (CheckBox1.Checked)
                    {
                        GridViewRow row = GridView1.Rows[i];
                        stid = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                        //FindControl("CheckBox1").ToString();
                        if (!prop.inputReview(tmpnpprev, stid))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Tidak dapat lagi menambahkan proposal karena kuota telah tercapai.');", true);
                           // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            prop.updateinputReview(tmpnpprev, stid);
                            KirimEmailStaffKeReviewer(stid);
                            bindGridView();

                        }
                        GridView1.DataBind();

                    }
                }
            }

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminListKelolaReview.aspx");
        }
        public void KirimEmailStaffKeReviewer(string tmpid)
        {

            string email = user.getEmailByNPP(tmpnpprev);
            string judul = prop.getjudulByID(tmpid);
            //string password = alumniMgr.getPassByUser(username);

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(Email.emailAccount);
            mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di Review";
            string Body = @"Anda memiliki Permohonan proposal dengan judul :"
                + "<br/>Judul : " + judul
                + "  <br/>Untuk melakukan Review terhadap proposal pengabdian ini, silahkan kunjungi halaman SILPPM dan buka pada panel Review Proposal.<br/> Terimakasih.";
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