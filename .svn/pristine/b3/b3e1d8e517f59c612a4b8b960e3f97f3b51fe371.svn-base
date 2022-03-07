using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace silppm_v1e2
{
    public partial class WebForm101 : System.Web.UI.Page
    {
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private DataSet dsRev1 = new DataSet();
        private DataSet dsRev2 = new DataSet();
        private ReviewDAO rev = new ReviewDAO();
        private DataSet reviewProdi = new DataSet();
        private DataSet reviewDekan = new DataSet();
        private DataSet reviewLPPM = new DataSet();
        private string tmpid, tmprev1, tmprev2;
        private int maxcountrev, maxcountrev2;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];



            try
            {

                try { tmprev1 = prop.getIDREV1ByID(tmpid); }
                catch { tmprev1 = "kosong"; }
                try { maxcountrev = rev.getMaxctRevPengabdian(tmpid, tmprev1); }
                catch { maxcountrev = 0; }
                
                
                dsRev1.Clear();
                dsRev1 = prop.getDataReview(tmpid, tmprev1, maxcountrev);
            }
            catch
            {
                Response.Redirect("ErrorLihatReview.aspx");
            }

            try
            {

                lblNilai1.Text = dsRev1.Tables[0].Rows[0][4].ToString();
                lblNilai2.Text = dsRev1.Tables[0].Rows[0][5].ToString();
                lblNilai3.Text = dsRev1.Tables[0].Rows[0][6].ToString();
                lblNilai4.Text = dsRev1.Tables[0].Rows[0][7].ToString();
                lblNilai5.Text = dsRev1.Tables[0].Rows[0][8].ToString();
                lblNilai6.Text = dsRev1.Tables[0].Rows[0][9].ToString();
                lblJusti1.Text = dsRev1.Tables[0].Rows[0][10].ToString();
                lblJusti2.Text = dsRev1.Tables[0].Rows[0][11].ToString();
                lblJusti3.Text = dsRev1.Tables[0].Rows[0][12].ToString();
                lblJusti4.Text = dsRev1.Tables[0].Rows[0][13].ToString();
                lblJusti5.Text = dsRev1.Tables[0].Rows[0][14].ToString();
                lblJusti6.Text = dsRev1.Tables[0].Rows[0][15].ToString();
                lblCatatan1.Text = dsRev1.Tables[0].Rows[0][16].ToString();
                lblCatatan2.Text = dsRev1.Tables[0].Rows[0][17].ToString();
                lblCatatan3.Text = dsRev1.Tables[0].Rows[0][18].ToString();
                lblCatatan4.Text = dsRev1.Tables[0].Rows[0][19].ToString();
                lblCatatan5.Text = dsRev1.Tables[0].Rows[0][20].ToString();
                lblKesimpulan.Text = dsRev1.Tables[0].Rows[0][21].ToString();
                lblAnggaran.Text = dsRev1.Tables[0].Rows[0][22].ToString();
                lblAnggaranHuruf.Text = dsRev1.Tables[0].Rows[0][23].ToString();
                lblUsulan.Text = dsRev1.Tables[0].Rows[0][24].ToString();
                dsRev1.Clear();
            }
            catch { }
               
        }
    }
}