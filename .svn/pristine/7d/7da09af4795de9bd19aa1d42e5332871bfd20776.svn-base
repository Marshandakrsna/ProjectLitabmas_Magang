using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace silppm_v1e2
{
    public partial class WebForm32 : System.Web.UI.Page
    {
        
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private DataSet dsRev1 = new DataSet();
        private DataSet dsRev2 = new DataSet();
        private ReviewDAO rev = new ReviewDAO();
        private DataSet reviewProdi = new DataSet();
        private DataSet reviewDekan = new DataSet();
        private DataSet reviewLPPM = new DataSet();
        private string tmpid,tmprev1,tmprev2;
        private int maxcountrev, maxcountrev2;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];

            

            try {
                
                try { tmprev1 = prop.getIDREV1ByID(tmpid); }
                catch { tmprev1 = "kosong"; }
                try { maxcountrev = rev.getMaxctRevPengabdian(tmpid, tmprev1); }
                catch { maxcountrev = 0; }
                try
                {


                    tmprev2 = prop.getIDREV2ByID(tmpid);
                }
                catch
                {

                    tmprev2 = "kosong";

                }
                Panel1.Visible = false;
                Panel2.Visible = false;
                if (tmprev2 != "kosong") {
                    Panel1.Visible = true;
                    Panel2.Visible = true;
                }
                dsRev1.Clear();
                dsRev1 = prop.getDataReview(tmpid, tmprev1, maxcountrev);
            }
            catch {
                Response.Redirect("ErrorLihatReview.aspx");
            }
           
            try {
               
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
                maxcountrev2 = prop.getMaxctRev(tmpid, tmprev2);
                dsRev2.Clear();
                dsRev2 = prop.getDataReview(tmpid, tmprev2, maxcountrev2);
                lblNilai7.Text = dsRev2.Tables[0].Rows[0][4].ToString();
                lblNilai8.Text = dsRev2.Tables[0].Rows[0][5].ToString();
                lblNilai9.Text = dsRev2.Tables[0].Rows[0][6].ToString();
                lblNilai10.Text = dsRev2.Tables[0].Rows[0][7].ToString();
                lblNilai11.Text = dsRev2.Tables[0].Rows[0][8].ToString();
                lblNilai12.Text = dsRev2.Tables[0].Rows[0][9].ToString();
                lblJusti7.Text = dsRev2.Tables[0].Rows[0][10].ToString();
                lblJusti8.Text = dsRev2.Tables[0].Rows[0][11].ToString();
                lblJusti9.Text = dsRev2.Tables[0].Rows[0][12].ToString();
                lblJusti10.Text = dsRev2.Tables[0].Rows[0][13].ToString();
                lblJusti11.Text = dsRev2.Tables[0].Rows[0][14].ToString();
                lblJusti12.Text = dsRev2.Tables[0].Rows[0][15].ToString();
                lblCatatan6.Text = dsRev2.Tables[0].Rows[0][16].ToString();
                lblCatatan7.Text = dsRev2.Tables[0].Rows[0][17].ToString();
                lblCatatan8.Text = dsRev2.Tables[0].Rows[0][18].ToString();
                lblCatatan9.Text = dsRev2.Tables[0].Rows[0][19].ToString();
                lblCatatan10.Text = dsRev2.Tables[0].Rows[0][20].ToString();
                lblKesimpulan0.Text = dsRev2.Tables[0].Rows[0][21].ToString();
                lblAnggaran0.Text = dsRev2.Tables[0].Rows[0][22].ToString();
                lblAnggaranHuruf0.Text = dsRev2.Tables[0].Rows[0][23].ToString();
                lblUsulan0.Text = dsRev2.Tables[0].Rows[0][24].ToString();
            }
            catch { }

            reviewProdi.Clear();
            reviewProdi = prop.getFeedbackProdi(tmpid);
            if (reviewProdi.Tables[0].Rows.Count > 0)
            {
                lblTglProdi.Text = reviewProdi.Tables[0].Rows[0][4].ToString();
                lblFeedBackProdi.Text = reviewProdi.Tables[0].Rows[0][3].ToString();
                lblProdiStatus.Text = reviewProdi.Tables[0].Rows[0][5].ToString();
                reviewProdi.Clear();
            }
            else
            {
                if (prop.cekProdiSetuju(tmpid))
                {
                    lblSetuju.Visible = true;
                    lblSetuju1.Visible = true;
                }
                else
                {
                    lblSetuju.Visible = false;
                    lblSetuju1.Visible = false;
                }

                Panel3.Visible = false;
            }
            reviewProdi.Clear();
            reviewDekan.Clear();
            reviewDekan = prop.getFeedbackDekan(tmpid);
            if (reviewDekan.Tables[0].Rows.Count > 0)
            {
                lblTglDekan.Text = reviewDekan.Tables[0].Rows[0][4].ToString();
                lblFeedBackDekan.Text = reviewDekan.Tables[0].Rows[0][3].ToString();
                lblDekanStatus.Text = reviewDekan.Tables[0].Rows[0][5].ToString();
                reviewDekan.Clear();
            }
            else
            {
                if (prop.cekDekanSetuju(tmpid))
                {
                    lblSetuju2.Visible = true;
                    lblSetuju3.Visible = true;
                }
                else
                {
                    lblSetuju2.Visible = false;
                    lblSetuju3.Visible = false;
                }

                Panel4.Visible = false;
            }
            reviewDekan.Clear();
            reviewLPPM.Clear();
            reviewLPPM = prop.getFeedbackKALPPM(tmpid);
            if (reviewLPPM.Tables[0].Rows.Count > 0)
            {
                lblTglDekan0.Text = reviewLPPM.Tables[0].Rows[0][4].ToString();
                lblFeedBackDekan0.Text = reviewLPPM.Tables[0].Rows[0][3].ToString();
                lblDekanStatus0.Text = reviewLPPM.Tables[0].Rows[0][5].ToString();
                reviewLPPM.Clear();
            }
            else
            {
                if (prop.cekLPPMSetuju(tmpid))
                {
                    lblSetuju4.Visible = true;

                }
                else
                {
                    lblSetuju4.Visible = false;
                }

                Panel5.Visible = false;
            }
            reviewLPPM.Clear();
            
        }
    }
}