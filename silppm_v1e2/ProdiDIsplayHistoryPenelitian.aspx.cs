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
    public partial class WebForm82 : System.Web.UI.Page
    {
        private string tmpusername, tmpNpp;
        private int flag = 0;
        private DataSet dataset = new DataSet();
        private UserDAO user = new UserDAO();
        private ProposalDAO prop = new ProposalDAO();
        private DataTable dtTahun = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session["userdata"] != null)
                {
                    UserEntity ue = Session["userdata"] as UserEntity;

                    tmpusername = ue.Username;
                    tmpNpp = ue.NPP;
                    dataset.Clear();
                    dataset = prop.getHistoryProdi(tmpNpp);
                    if (!IsPostBack)
                    {
                        if (dataset.Tables[0].Rows.Count > 0)
                        {
                            GridView1.DataSource = dataset.Tables[0];
                            GridView1.DataBind();
                        }
                        else
                        {
                            GridView1.Visible = false;
                        }

                        DataTable dtTahun = prop.getTahunAkademik();

                        DropDownList1.DataSource = dtTahun;
                        DropDownList1.DataValueField = "ID_TAHUN_AKADEMIK";
                        DropDownList1.DataTextField = "TAHUN_AKADEMIK";
                        DropDownList1.DataBind();
                        DropDownList1.Items.Insert(0, new ListItem("Tampilkan Semua", "-1"));
                    }



                }
                else
                {
                    Response.Redirect("LoginExpired.aspx");
                }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
                dataset.Clear();
                dataset = prop.getHistoryProdiByTahunAnggaran(tmpNpp,DropDownList1.SelectedValue.ToString());
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    Label3.Visible = false;
                    GridView1.DataSource = dataset.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Visible = false;
                    Label3.Visible = true;
                }
        }
    }
}