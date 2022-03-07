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
    public partial class WebForm27 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ReviewDAO rev = new ReviewDAO();
        private UserDAO datauser = new UserDAO();
        private string tmpid, tmpnpp;
        private ProposalDAO prop = new ProposalDAO();
        private ProposalPengabdianDAO abdi = new ProposalPengabdianDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                tmpnpp = datauser.getNPPByUsername(ue.Username);
                //lblTanggal.Text = DateTime.Now.ToString();
                dataset.Clear();
                dataset = rev.getAdminDataPerkembangan(tmpid);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    Label1.Visible = false;
                    GridView1.DataSource = dataset.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    Label1.Visible = true;
                    GridView1.Visible = false;
                }
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Lihat")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                //string tmp=row.Cells[0].Text;

                // Add code here to add the item to the shopping cart.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/pdf";
                byte[] temp;
                
                    //int noupdate = prop.getNoUpdate(tmp);
                    temp = prop.getMONEVPenelitian(tmpid, Convert.ToInt32(tmp));
                    Response.BinaryWrite(temp);
                    Response.End();
                
                


                //Response.Redirect("LihatProposal.aspx?id=" + tmp);
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminListUpdatePenelitian.aspx");
        }
    }
}