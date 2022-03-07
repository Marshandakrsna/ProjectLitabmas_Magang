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
    public partial class WebForm31 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private string namareviewer, tmpnppreviewer;
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;

                namareviewer = ue.NAMA;
                tmpnppreviewer = ue.NPP;

                dataset.Clear();
                dataset = prop.getAllDataProposal(tmpnppreviewer);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = dataset.Tables[0];
                    GridView1.DataBind();

                }
                else
                {
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
            if (e.CommandName == "pilih")
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
                //Response.Clear();
                //Response.Buffer = true;
                //Response.Charset = "";
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.ContentType = "application/pdf";
                //byte[] temp = prop.getPropsalPenelitian(tmp);
                //Response.BinaryWrite(temp);
                //Response.End();
                Response.Redirect("RevPengabdian.aspx?id=" + tmp);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}