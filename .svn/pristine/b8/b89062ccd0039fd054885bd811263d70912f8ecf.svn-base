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
    public partial class WebForm98 : System.Web.UI.Page
    {
        private string tmpusername, tmpNpp;
        private int flag = 0;
        private DataSet dataset = new DataSet();
        private UserDAO user = new UserDAO();
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private DataTable dtTahun = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userdata"] != null)
                {
                    UserEntity ue = Session["userdata"] as UserEntity;

                    tmpusername = ue.Username;

                    dtTahun = prop.getListPeriode();
                    DropDownList1.DataSource = dtTahun;
                    DropDownList1.DataValueField = "ID_TAHUN_ANGGARAN";
                    DropDownList1.DataTextField = "TAHUN_ANGGARAN";
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, new ListItem("Tampilkan Semua", "-1"));

                    dataset.Clear();
                    dataset = prop.getHistoryExec();
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
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Proposal")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/pdf";
                byte[] temp = prop.getPropsalPenelitian(tmp);
                Response.BinaryWrite(temp);
                Response.End();
            }

            else if (e.CommandName == "Draft")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                if (prop.CekLaporanTahap1(tmp))
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/pdf";
                    byte[] temp = prop.getDraftPengabdian(tmp);
                    Response.BinaryWrite(temp);
                    Response.End();
                }
                else
                {
                    // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Dosen Belum melakukan Upload Data Draft Laporan');", true);
                }

            }
            else if (e.CommandName == "Laporan")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                if (prop.CekLaporan(tmp))
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = "application/pdf";
                    byte[] temp = prop.getLaporanPengabdian(tmp);
                    Response.BinaryWrite(temp);
                    Response.End();
                }
                else
                {
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Dosen Belum melakukan Upload Data Laporan');", true);
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.ToString() == "Tampilkan Semua")
            {

                dataset.Clear();
                dataset = prop.getHistoryExec();
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    GridView1.Visible = true;
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
                dataset.Clear();
                dataset = prop.getHistoryExecByTahunAnggaran(DropDownList1.SelectedItem.ToString());
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dataset.Tables[0];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Visible = false;
                }
            }
        }

    }
}