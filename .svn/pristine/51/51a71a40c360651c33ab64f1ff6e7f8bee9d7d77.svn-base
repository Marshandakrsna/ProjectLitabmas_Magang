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
    public partial class WebForm34 : System.Web.UI.Page
    {
        private DataSet dsTerima = new DataSet();
        private DataSet dataset = new DataSet();
        private ReviewDAO rev = new ReviewDAO();
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO user = new UserDAO();
        private string tmpusername,tmpnpp, index;
        private int prodi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;

                tmpusername = ue.Username;
                tmpnpp = ue.NPP;
                prodi = user.getKaProdiByNPP(tmpnpp);
                
                Panel1.Visible = false;
                dsTerima.Clear();
                dsTerima = prop.getJudulTerimaByProdi(prodi);
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
                dataset = rev.getProdiDataPerkembanganPenelitian(HiddenField1.Value);
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
            Response.Redirect("ProdiMonevPenelitian.aspx");
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
                temp = prop.getMONEVPenelitian(HiddenField1.Value, Convert.ToInt32(tmp));
                Response.BinaryWrite(temp);
                Response.End();



                //Response.Redirect("LihatProposal.aspx?id=" + tmp);
            }


        }

    }
}