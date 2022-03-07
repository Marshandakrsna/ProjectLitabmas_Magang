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
    public partial class WebForm36 : System.Web.UI.Page
    {
        private DataSet dsTerima = new DataSet();
        private DataSet dataset = new DataSet();
        private ReviewDAO rev = new ReviewDAO();
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private string tmpusername, index;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;

                tmpusername = ue.Username;

                //tmpKantor = datauser.getalam
                Panel1.Visible = false;
                dsTerima.Clear();
                dsTerima = prop.getDataLolosSemua();
                if (dsTerima.Tables[0].Rows.Count > 0)
                {
                    GridView2.DataSource = dsTerima.Tables[0];
                    GridView2.DataBind();
                }
                else
                {
                    GridView2.Visible = false;
                }



            }

            else
            {
                Response.Redirect("LoginExpired.aspx");
            }   
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "lihat")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView2.Rows[index];
                string tmp = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);

                //prop.HapusProposal(tmp);
                HiddenField1.Value = tmp;
                Panel1.Visible = true;
                GridView2.Visible = false;
                dataset.Clear();
                dsTerima.Clear();
                dataset = rev.getAdminDataPerkembangan(HiddenField1.Value);
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Response.Redirect("monevPengabdian.aspx");
        }

    }
}