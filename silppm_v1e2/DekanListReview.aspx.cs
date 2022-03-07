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
    public partial class WebForm47 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO user = new UserDAO();
        private string tmpNppDekan;
        private int idDekan;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;


                tmpNppDekan = ue.NPP;
                idDekan = user.getDekanByNPP(tmpNppDekan);
                //ddlDana.DataSource = prop.getSbrDana();
                //ddlDana.DataBind();
                dataset.Clear();
                dataset = prop.getListLaporanDekan(idDekan);

                if (dataset.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dataset.Tables[0];
                    GridView1.DataBind();

                    Label1.Visible = false;

                }
                else
                    Label1.Visible = true;
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "review")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);

                //dataset = rev.getAdminDataPerkembangan(HiddenField1.Value);
                Response.Redirect("DekanApprovalProposal.aspx?id=" + tmp);

            }
        }

    }
}