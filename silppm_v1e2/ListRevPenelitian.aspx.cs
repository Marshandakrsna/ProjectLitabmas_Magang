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
    public partial class WebForm42 : System.Web.UI.Page
    {
        private DataTable dataset = new DataTable();
        private DataTable dtDana = new DataTable();
        private string index;
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO datauser = new UserDAO();
        private ReviewDAO rev = new ReviewDAO();
        private string tampungstatus, tampungidProposal, namareviewer, tmpusername, tmpnppreviewer;
        private int flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                
                UserEntity ue = Session["userdata"] as UserEntity;

                tmpnppreviewer = ue.NPP;

                dataset.Clear();
                dataset = prop.getAllDataProposal(tmpnppreviewer);

                if (dataset.Rows.Count > 0)
                {
                    GridView1.DataSource = dataset;
                    GridView1.DataBind();

                }
                else
                {
                    Label1.Visible = true;
                }
            }
            
            // dataset.Clear();
            //dataset = prop.getAllDataProposal();

            //if (dataset.Tables[0].Rows.Count > 0)
            //{
            //    GridView1.DataSource = dataset.Tables[0];
            //    GridView1.DataBind();


            //}
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Select")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);

                dataset.Clear();
                DataSet propDS;
                propDS = prop.getAllDataProposalByIDProposal(tmp);
                tampungidProposal = tmp;
                if (rev.valReview(tampungidProposal, tmpnppreviewer))
                {
                    Response.Redirect("ErrorPageRev.aspx");
                }
                else
                {
                    Response.Redirect("RevPenelitian.aspx?id=" + tmp);
                }

            }
        }


        }
 }
