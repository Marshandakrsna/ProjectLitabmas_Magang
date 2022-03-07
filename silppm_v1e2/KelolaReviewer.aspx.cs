﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using silppm_v1e2.Entity;
using System.Net.Mail;

namespace silppm_v1e2.UI
{
    public partial class KelolaReviewer : System.Web.UI.Page
    {
        private string tmpusername ;
        private DataSet dataset = new DataSet();
        private DataSet dataset1 = new DataSet();
        private UserDAO user = new UserDAO();
        private ProposalDAO prop = new ProposalDAO();
        private DataTable dtTahun = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userdata"] != null)
                {
                    UserEntity ue = Session["userdata"] as UserEntity;

                    tmpusername = ue.Username;
                    dataset.Clear();
                    dataset1.Clear();
                    dataset = prop.getHistoryExec();
                    if (dataset.Tables[0].Rows.Count > 0)
                    {
                        gvPenelitian.DataSource = dataset.Tables[0];
                        gvPenelitian.DataBind();
                    }
                    else
                    {
                        gvPenelitian.Visible = false;
                    }
                    dataset1 = prop.getPenelitianReviewer(DropDownList1.SelectedValue.ToString(), txtNppDosen.Text.Trim());
                    if (dataset1.Tables[0].Rows.Count > 0)
                    {
                        gvPenelitian0.Visible = true;
                        Session["reviewerPenelitian"] = dataset1.Tables[0];
                        gvPenelitian0.DataSource = dataset1.Tables[0];
                        gvPenelitian0.DataBind();
                    }
                    else
                    {
                        gvPenelitian0.Visible = false;
                    }
                    DataTable dtTahun = prop.getTahunAkademik();

                    DropDownList1.DataSource = dtTahun;
                    DropDownList1.DataValueField = "ID_TAHUN_AKADEMIK";
                    DropDownList1.DataTextField = "TAHUN_AKADEMIK";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Tampilkan Semua", "-1"));

                    DropDownList1_SelectedIndexChanged(sender, e);


                    DataSet dsReviewer = new UserDAO().getUserRoleAssessor();
                    ddRev1.DataSource = dsReviewer.Tables[0];
                    ddRev1.DataValueField ="NPP";
                    ddRev1.DataTextField = "NAMA";
                    ddRev1.DataBind();
                    ddRev1.Items.Insert(0, new ListItem("Pilih", "-1"));

                    ddRev2.DataSource = dsReviewer.Tables[0];
                    ddRev2.DataValueField = "NPP";
                    ddRev2.DataTextField = "NAMA";
                    ddRev2.DataBind();
                    ddRev2.Items.Insert(0, new ListItem("Pilih", "-1"));
                }
                else
                {
                    Response.Redirect("LoginExpired.aspx");
                }
                ModalPopupExtender1.Hide();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataset.Clear();
            dataset = prop.getPenelitian4setReviewer(DropDownList1.SelectedValue.ToString(),txtNppDosen.Text.Trim());
            if (dataset.Tables[0].Rows.Count > 0)
            {
                gvPenelitian.Visible = true;
                Session["dataPenelitian"] = dataset.Tables[0];
                gvPenelitian.DataSource = dataset.Tables[0];
                gvPenelitian.DataBind();
            }
            else
            {
                gvPenelitian.Visible = false;
            } 
            dataset1.Clear();
            dataset1 = prop.getPenelitianReviewer(DropDownList1.SelectedValue.ToString(), txtNppDosen.Text.Trim());
            if (dataset1.Tables[0].Rows.Count > 0)
            {
                gvPenelitian0.Visible = true;
                Session["reviewerPenelitian"] = dataset1.Tables[0];
                gvPenelitian0.DataSource = dataset1.Tables[0];
                gvPenelitian0.DataBind();
            }
            else
            {
                gvPenelitian0.Visible = false;
            }
        }

        protected void gvPenelitian_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvPenelitian_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Pilih")
            {
                DataTable dt = (DataTable)Session["dataPenelitian"];
                btnMunculReview_Click(sender, e);
                DataRow[] dr = dt.Select("ID_PROPOSAL=" + id);
                txtDosen.Text = dr[0]["nama"].ToString();
                txtJudul.Text = dr[0]["JUDUL"].ToString();
                lblIdProp.Text = id.ToString();
            }
        }

        protected void btnBatalKeg_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void btnMunculReview_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }

        protected void BtnSimpan_Click(object sender, EventArgs e)
        {
            if (ddRev1.SelectedValue.ToString() != ddRev2.SelectedValue.ToString())
            {
                prop.setReviewPenelitian(ddRev1.SelectedValue.ToString(),
                    ddRev2.SelectedValue.ToString(),
                    lblIdProp.Text);
                //KirimEmailStaffKeReviewer(ddRev1.SelectedValue.ToString());
                //KirimEmailStaffKeReviewer(ddRev2.SelectedValue.ToString());
                DropDownList1_SelectedIndexChanged(sender, e);
                ModalPopupExtender1.Hide();
            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal!, Reviewer tidak boleh sama');", true);
            }
        }

        public void KirimEmailStaffKeReviewer(string npp)
        {

            string email = user.getEmailByNPP(npp);
            string judul = txtJudul.Text;
            //string password = alumniMgr.getPassByUser(username);

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(Email.emailAccount);
            mail.Subject = "[Pemberitahuan] Permohonan Review Proposal :" + judul + "";
            string Body = @"Anda diminta untuk melakukan review terhadap proposal penelitian dengan judul :"
                + "<br/>Judul : " + judul
                + ".<br/>silahkan kunjungi halaman SILPPM dan buka pada panel Review Proposal.<br/> Terimakasih.";
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

        protected void gvPenelitian0_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "rev1")
            {
                DataTable dt = (DataTable)Session["reviewerPenelitian"];
                DataRow[] dr = dt.Select("ID_PROPOSAL="+id);
                string REVIEWER1 = dr[0]["REVIEWER1"].ToString();

                Response.Redirect("adminREVPenelitian.aspx?ID=" + id + "&npp=" + REVIEWER1);
            }
            else if (e.CommandName == "rev2")
            {
                DataTable dt = (DataTable)Session["reviewerPenelitian"];
                DataRow[] dr = dt.Select("ID_PROPOSAL=" + id);
                string REVIEWER2 = dr[0]["REVIEWER2"].ToString();

                Response.Redirect("adminREVPenelitian.aspx?ID=" + id + "&npp=" + REVIEWER2);
            }
        }

        protected void gvPenelitian0_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void gvPenelitian_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

    }
}