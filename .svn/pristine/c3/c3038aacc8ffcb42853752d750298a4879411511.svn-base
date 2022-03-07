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
    public partial class WebForm65 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private UserDAO user = new UserDAO();
        private string tmpNppProdi;
        private int tmpIDProdi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;


                tmpNppProdi = ue.NPP;
                tmpIDProdi = user.getKaProdiByNPP(tmpNppProdi);
                //ddlDana.DataSource = prop.getSbrDana();
                //ddlDana.DataBind();
                bindGridView();
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }
        private void bindGridView()
        {
            dataset.Clear();
            dataset = prop.getProdiTemaPengabdian(tmpIDProdi);

            if (dataset.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                //Panel1.Visible = false;
                //GridView1.Visible = false;
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "hapus")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);

                //dataset = rev.getAdminDataPerkembangan(HiddenField1.Value);
                prop.hapusTema(tmp);
                bindGridView();

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (prop.addTema(tmpIDProdi, TextBox1.Text))
            {
                bindGridView();
                GridView1.DataBind();
            }
        }



    }
}