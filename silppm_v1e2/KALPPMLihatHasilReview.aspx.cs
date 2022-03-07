using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace silppm_v1e2
{
    public partial class WebForm58 : System.Web.UI.Page
    {
        private ReviewDAO rev = new ReviewDAO();
        private ProposalDAO prop = new ProposalDAO();
        private string tmpid, tmprev1, tmprev2;
        private int maxcountrev, maxcountrev2;
        private DataSet dsRev1 = new DataSet();
        private DataSet dsRev2 = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];
            Panel2.Visible = false;
            try
            {
                tmprev1 = prop.getIDREV1ByID(tmpid);
                maxcountrev = rev.getMaxctRev(tmpid, tmprev1);
                tmprev2 = prop.getIDREV2ByID(tmpid);
                //maxcountrev2 = rev.getMaxctRev(tmpid, tmprev2);
                Panel1.Visible = false;
                
                if (tmprev2 != "kosong")
                {
                    Panel1.Visible = true;
                    
                }

                //maxcountrev = rev.getMaxctRev(tmpid, tmprev1);
                //maxcountrev2 = rev.getMaxctRev(tmpid, tmprev2);
                dsRev1.Clear();
                dsRev1 = rev.getDataReview(tmpid, tmprev1, maxcountrev);



            }
            catch
            {
                Response.Redirect("ErrorLihatReview.aspx");
            }
            lblnilai1.Text = dsRev1.Tables[0].Rows[0][4].ToString();
            lblnilai2.Text = dsRev1.Tables[0].Rows[0][5].ToString();
            lblnilai3.Text = dsRev1.Tables[0].Rows[0][6].ToString();
            lblnilai4.Text = dsRev1.Tables[0].Rows[0][7].ToString();
            lblnilai5.Text = dsRev1.Tables[0].Rows[0][8].ToString();
            lblnilai6.Text = dsRev1.Tables[0].Rows[0][9].ToString();
            lblnilai7.Text = dsRev1.Tables[0].Rows[0][10].ToString();
            lblJustifikasi1.Text = dsRev1.Tables[0].Rows[0][11].ToString();
            lblJustifikasi2.Text = dsRev1.Tables[0].Rows[0][12].ToString();
            lblJustifikasi3.Text = dsRev1.Tables[0].Rows[0][13].ToString();
            lblJustifikasi4.Text = dsRev1.Tables[0].Rows[0][14].ToString();
            lblJustifikasi5.Text = dsRev1.Tables[0].Rows[0][15].ToString();
            lblJustifikasi6.Text = dsRev1.Tables[0].Rows[0][16].ToString();
            lblJustifikasi7.Text = dsRev1.Tables[0].Rows[0][17].ToString();
            
            try {
                double tmp = Convert.ToDouble(lblnilai1.Text) + Convert.ToDouble(lblnilai2.Text) + Convert.ToDouble(lblnilai3.Text)
                    + Convert.ToDouble(lblnilai4.Text) + Convert.ToDouble(lblnilai5.Text) + Convert.ToDouble(lblnilai6.Text) +
                    Convert.ToDouble(lblnilai7.Text);
                lbljumlah1.Text = tmp.ToString();
            }
            catch {
            
            }
            try {

                dsRev1.Clear();
                maxcountrev2 = rev.getMaxctRev(tmpid, tmprev2);
                dsRev2.Clear();
                dsRev2 = rev.getDataReview(tmpid, tmprev2, maxcountrev2);
                lblnilai8.Text = dsRev2.Tables[0].Rows[0][4].ToString();
                lblnilai9.Text = dsRev2.Tables[0].Rows[0][5].ToString();
                lblnilai10.Text = dsRev2.Tables[0].Rows[0][6].ToString();
                lblnilai11.Text = dsRev2.Tables[0].Rows[0][7].ToString();
                lblnilai12.Text = dsRev2.Tables[0].Rows[0][8].ToString();
                lblnilai13.Text = dsRev2.Tables[0].Rows[0][9].ToString();
                lblnilai14.Text = dsRev2.Tables[0].Rows[0][10].ToString();
                lblJustifikasi8.Text = dsRev2.Tables[0].Rows[0][11].ToString();
                lblJustifikasi9.Text = dsRev2.Tables[0].Rows[0][12].ToString();
                lblJustifikasi10.Text = dsRev2.Tables[0].Rows[0][13].ToString();
                lblJustifikasi11.Text = dsRev2.Tables[0].Rows[0][14].ToString();
                lblJustifikasi12.Text = dsRev2.Tables[0].Rows[0][15].ToString();
                lblJustifikasi13.Text = dsRev2.Tables[0].Rows[0][16].ToString();
                lblJustifikasi14.Text = dsRev2.Tables[0].Rows[0][17].ToString();
               
                try
                {
                    double tmp = Convert.ToDouble(lblnilai8.Text) + Convert.ToDouble(lblnilai9.Text) + Convert.ToDouble(lblnilai10.Text)
                        + Convert.ToDouble(lblnilai11.Text) + Convert.ToDouble(lblnilai12.Text) + Convert.ToDouble(lblnilai13.Text) +
                        Convert.ToDouble(lblnilai14.Text);
                    lbljumlah2.Text = tmp.ToString();
                }
                catch
                {

                }
            }
            catch { }
        }
    }
}