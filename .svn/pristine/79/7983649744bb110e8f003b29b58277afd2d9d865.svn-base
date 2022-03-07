using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

namespace silppm_v1e2
{
    public partial class WebForm59 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private UserDAO user = new UserDAO();
        private ProposalDAO prop = new ProposalDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                blindGridView();
            }

            
        }
        private void blindGridView() {
            dataset.Clear();
            dataset = user.getUserRoleAssessor();
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
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "pilih")
            {
               int index = Convert.ToInt32(e.CommandArgument);
               GridViewRow row = GridView1.Rows[index];
               string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                
                    Response.Redirect("adminKelolaReview.aspx?id=" + tmp);
                
            }
            else if (e.CommandName == "pilihPengabdian")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);

                Response.Redirect("adminKelolaReviewPengabdian.aspx?id=" + tmp);

            }
        }

    }
}