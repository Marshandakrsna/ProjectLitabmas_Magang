using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;

namespace silppm_v1e2
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        private ProposalDAO prop = new ProposalDAO();
        private UserDAO datauser = new UserDAO();
        private DataTable dtPeriode = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dtPeriode = prop.getListPeriode();
                txtPeriode.DataSource = dtPeriode;
                txtPeriode.DataValueField = "ID_TAHUN_ANGGARAN";
                txtPeriode.DataTextField = "TAHUN_ANGGARAN";
                txtPeriode.DataBind();
            }
            lblPeriode.Text = prop.getNamaPeriode();
            lblAwal.Text = prop.getawalPeriode();
            lblAkhir.Text = prop.getAkhirPeriode();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            prop.ResetPeriode();
            int tmpa;
            string tmpvalueddl=txtPeriode.SelectedValue;
            try { 
            tmpa = prop.getMaxId();
            }
            catch { tmpa = 0; }
            int tmpc = tmpa + 1;
            if (prop.addPeriode(tmpc, tmpvalueddl, Convert.ToDateTime(dateMulai.Text), Convert.ToDateTime(dateAkhir.Text)))
            {
                //MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data berhasil!');", true);
                Response.Redirect("AdminKelolaPeriode.aspx");
            }
            
        }
    }
}