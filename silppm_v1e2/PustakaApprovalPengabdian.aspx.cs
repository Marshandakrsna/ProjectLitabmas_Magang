using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using silppm_v1e2.Entity;

namespace silppm_v1e2
{
    public partial class WebForm79 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private string tmpid;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];
            Panel1.Visible = false;
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                dataset.Clear();
                dataset = prop.getDataPustaka(tmpid);
                lblJudul.Text = dataset.Tables[0].Rows[0][6].ToString();
                lblJenis.Text = dataset.Tables[0].Rows[0][8].ToString();
                lblKeyword.Text = dataset.Tables[0].Rows[0][7].ToString();
                lblLokasi.Text = dataset.Tables[0].Rows[0][15].ToString();

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
                Response.Redirect("PustakaBerhasilApprove.aspx");
            }
            else
            {

            }
        }

        protected void BtnLihat_Click(object sender, EventArgs e)
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
    }
}