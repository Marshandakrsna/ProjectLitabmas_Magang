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
    public partial class WebForm26 : System.Web.UI.Page
    {
        private DataSet dsTerima = new DataSet();
        private ProposalDAO prop = new ProposalDAO();
        private string tmpusername;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
                {
                    UserEntity ue = Session["userdata"] as UserEntity;

                    tmpusername = ue.Username;
                    
                    //tmpKantor = datauser.getalam
                   
                    dsTerima.Clear();
                    dsTerima = prop.getSemuaJudulTerima();
                    if (dsTerima.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = dsTerima.Tables[0];
                        GridView2.DataBind();
                    }
                    else {
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
                Response.Redirect("AdminPreviewUpdate.aspx?id=" + tmp);
            }
        }
        }

}
   