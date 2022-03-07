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
    public partial class WebForm94 : System.Web.UI.Page
    {
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private DataSet dataset = new DataSet();
        private string tmpid, tmpusername;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ScriptManager.GetCurrent(Page) == null)
            {
                Page.Form.Controls.AddAt(0, new ScriptManager());
            }
            tmpid = Request.QueryString["id"];
            if (!IsPostBack)
            {
                bindGridview();
            }
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;

                tmpusername = ue.Username;
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }

        private void bindGridview()
        {
            dataset.Clear();
            dataset = prop.getDataPerpanjangan(tmpid);
            if (dataset.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                //Label1.Visible = true;
                //GridView1.Visible = false;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void Simpan_Click(object sender, EventArgs e)
        {
            int tmpdate, tmpyear2, tmpyear1;
            string tmp1;
            DateTime akhir = DateTime.Today;


            if (dateSelesai.Text == "1 bulan")
            {
                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 1;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }
            else if (dateSelesai.Text == "2 bulan")
            {
                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 2;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                akhir = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/dd/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));
            }
            int tmpcount = prop.getCountPerpanjanganPengabdian(tmpid) + 1;
            if (tmpcount <= 1)
            {
                DateTime datenow = DateTime.Now;
                string ip = HttpContext.Current.Request.UserHostAddress;
                if (prop.PerpanjangPeriodePengabdian(tmpid, tmpcount, Convert.ToDateTime(dateMulai.Text), akhir, datenow, ip, tmpusername))
                {
                    bindGridview();
                }

            }
            else
            {
                //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Anda hanya dapat melakukan perpanjangan 1 kali saja!');", true);
                bindGridview();
                //Response.Redirect("PerpanjangPengabdian.aspx?id=" + tmpid);
            }

        }
    }
}