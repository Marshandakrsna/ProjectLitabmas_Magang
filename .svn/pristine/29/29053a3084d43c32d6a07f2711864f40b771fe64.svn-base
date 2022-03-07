using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace silppm_v1e2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public string tmp, tmpusername;
        private DataSet dataset = new DataSet();
        private DataSet dsTerima = new DataSet();
        private DataSet dsPengabdian = new DataSet();
        private DataSet dsPengabdianTerima = new DataSet();
        private ProposalDAO prop = new ProposalDAO();
        private ProposalPengabdianDAO abdi = new ProposalPengabdianDAO();
        private UserDAO datauser = new UserDAO();
        private string tmpKantor, tmpKeahlian;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["userdata"] != null)
                {
                    UserEntity ue = Session["userdata"] as UserEntity;

                    tmpusername = ue.Username;
                    lblnama.Text = ue.NAMA;
                    lblNPPKetua.Text = datauser.getNPPByUsername(tmpusername);
                    lblAlamatKetua.Text = datauser.getAlamatByUsername(tmpusername);
                    lblEmailKetua.Text = datauser.getEmailDosen(tmpusername);
                    lblFakKetua.Text = datauser.getFakultasByUsername(tmpusername);
                    lblGolKetua.Text = datauser.getGolByUsername(tmpusername);
                    lblTelpKetua.Text = datauser.getTelpByUsername(tmpusername);
                    lblPangkatKetua.Text = datauser.getPangkatByUsername(tmpusername);
                    lblNIDNKetua.Text = Convert.ToString(datauser.getNIDNbyUsername(tmpusername));
                    lblJurusanKetua.Text = datauser.getjurusanByUsername(tmpusername);
                    //tmpKantor = datauser.getalam
                    dataset.Clear();
                    dataset = prop.getDataProposal(lblNPPKetua.Text);
                    if (dataset.Tables[0].Rows.Count > 0)
                    {
                        GridView1.DataSource = dataset.Tables[0];
                        GridView1.DataBind();
                        
                    }
                    else {
                        GridView1.Visible = false;
                    }
                    dataset.Clear();

                    

                    dsTerima.Clear();
                    dsTerima = prop.getJudulTerima(lblNPPKetua.Text);
                    if (dsTerima.Tables[0].Rows.Count > 0)
                    {
                        GridView2.DataSource = dsTerima.Tables[0];
                        GridView2.DataBind();
                    }
                    else {
                        GridView2.Visible = false;
                    }
                    dsTerima.Clear();
                    dsPengabdian.Clear();
                    dsPengabdian = abdi.getDataProposalByIDKaryawan(lblNPPKetua.Text);
                    if (dsPengabdian.Tables[0].Rows.Count > 0)
                    {
                        GridViewPengabdian.DataSource = dsPengabdian.Tables[0];
                        GridViewPengabdian.DataBind();

                    }
                    else
                    {
                        GridViewPengabdian.Visible = false;
                    }
                    dsPengabdian.Clear();
                    dsPengabdianTerima.Clear();
                    dsPengabdianTerima = abdi.getDataLOLOSByIDKaryawan(lblNPPKetua.Text);
                    if (dsPengabdianTerima.Tables[0].Rows.Count > 0)
                    {
                        GridViewPengabdianLolos.DataSource = dsPengabdianTerima.Tables[0];
                        GridViewPengabdianLolos.DataBind();

                    }
                    else
                    {
                        GridViewPengabdianLolos.Visible = false;
                    }
                    
                    
                }
                else
                {
                    Response.Redirect("LoginExpired.aspx");
                }   

            }
            
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // tmp = GridView1.SelectedRow.Cells[0].Text;
           
            
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";
            byte[] temp = prop.getPropsalPenelitian(tmp);
            Response.BinaryWrite(temp);
            Response.End();
        }
        //protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        //{
            
        //    e.Rows[2].Cells[3].Visible = false;
        //}
        //gridview pertama
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
                string tmp =Convert.ToString( GridView1.DataKeys[row.RowIndex].Value);
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
                Response.Redirect("LihatProposal.aspx?id="+tmp);
            }
            
            else if (e.CommandName == "revisi")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                if (prop.cekEdit(tmp) != "Menunggu Persetujuan Prodi")
                {
                    Response.Redirect("ErorRevisi.aspx");
                }
                else {
                    Response.Redirect("EditPenelitian.aspx?id=" + tmp);
                }
                //prop.HapusProposal(tmp);
                //Response.Redirect("EditInternalNon.aspx?id="+tmp);
            }
        }
        
        protected void GridViewPengabdian_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Lihat")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewPengabdian.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdian.DataKeys[row.RowIndex].Value);
               

               
                Response.Redirect("LihatPengabdian.aspx?id=" + tmp);
            }

            else if (e.CommandName == "revisi")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridViewPengabdian.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdian.DataKeys[row.RowIndex].Value);
                if (abdi.cekEdit(tmp) != "Menunggu Persetujuan Prodi")
                {
                    Response.Redirect("ErorRevisi.aspx");
                }
                else
                {
                    Response.Redirect("EditPengabdian.aspx?id=" + tmp);
                }
                //prop.HapusProposal(tmp);
                //Response.Redirect("EditInternalNon.aspx?id=" + tmp);
            }
        }

        //buat dapet value dr dropdown

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DropDownList1.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dpdListEstatus = e.Row.FindControl("DropDownList1") as DropDownList;
                string Hasilddl = (dpdListEstatus is DropDownList) ? dpdListEstatus.SelectedValue : null;

                dpdListEstatus.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
                //return Hasilddl;
            }
            else {
                //return null;
            }
        }
        //buat rowcommand2 penelitian lolos
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)/*no use,cih...*/
        {
            if (e.CommandName == "Lihat")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = GridView2.Rows[index];
                string tmp = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);
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
                Response.Redirect("LihatProposal.aspx?id=" + tmp);
            }
            else if (e.CommandName == "cetak")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView2.Rows[index];
                string tmp = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);
             

                // Add code here to add the item to the shopping cart.
                if (!prop.CekLaporanTahap1(tmp))
                {
                    string tmpnppDosen = prop.getNppDosenbyIDProposal_Penelitian(tmp);
                    if (prop.CekPerkembanganMonev(tmp, tmpnppDosen))
                    {
                        Response.Redirect("LaporanPenelitianTahap1.aspx?id=" + tmp);
                    }
                    else {
                        Response.Redirect("ErrorSekuensLaporan.aspx");
                    }
                    
                }
                else
                {
                    Response.Redirect("ErrorLaporan.aspx?id=" + tmp);
                }
               
            }
            else if (e.CommandName == "Perbarui")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView2.Rows[index];
                string tmp = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);

                //prop.HapusProposal(tmp);
                Response.Redirect(String.Format("LaporPerkembangan.aspx?idN={0}&idG={1}", Server.UrlEncode(tmp), Server.UrlEncode("0")));
            }
            else if (e.CommandName == "unggah")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridView2.Rows[index];
                string tmp = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);

                //prop.HapusProposal(tmp);
                if (!prop.CekLaporan(tmp))
                {
                    if (prop.CekLaporanTahap1(tmp)) {
                        Response.Redirect("LaporanPenelitian.aspx?id=" + tmp);
                    }
                    else
                    {
                        Response.Redirect("ErrorSekuensLaporanFinal.aspx");
                    }
                    
                }
                else {
                    Response.Redirect("ErrorLaporan.aspx?id=" + tmp);
                }
                
            }
            else if (e.CommandName == "jadwal")
            {
                
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView2.Rows[index];
                string tmp = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);
                
                Response.Redirect("PenelitianSchedule.aspx?id=" + tmp);
            }
            //
            else if (e.CommandName == "perpanjang")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView2.Rows[index];
                string tmp = Convert.ToString(GridView2.DataKeys[row.RowIndex].Value);

                Response.Redirect("PerpanjanganPenelitian.aspx?id=" + tmp);
            }
        }

        //untuk row databound pengabdian lolos
        protected void GridViewPengabdianLolos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //DropDownList1.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList dpdListEstatus2 = e.Row.FindControl("ddlPengabdianLolos") as DropDownList;
                string Hasilddl = (dpdListEstatus2 is DropDownList) ? dpdListEstatus2.SelectedValue : null;

                dpdListEstatus2.SelectedIndexChanged += new EventHandler(ddlPengabdianLolos_SelectedIndexChanged);
                //return Hasilddl;
            }
            else
            {
                //return null;
            }
        }

        //untuk gridview pengabdian lolos
        protected void GridViewPengabdianLolos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Lihat")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewPengabdianLolos.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdianLolos.DataKeys[row.RowIndex].Value);



                Response.Redirect("LihatPengabdian.aspx?id=" + tmp);
            }
            else if (e.CommandName == "Lapor")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridViewPengabdianLolos.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdianLolos.DataKeys[row.RowIndex].Value);

                //prop.HapusProposal(tmp);
                Response.Redirect(String.Format("LaporPerkembangan.aspx?idN={0}&idG={1}", Server.UrlEncode("0"), Server.UrlEncode(tmp)));
            }
            else if (e.CommandName == "unggah")
            {

                int index = Convert.ToInt32(e.CommandArgument);


                GridViewRow row = GridViewPengabdianLolos.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdianLolos.DataKeys[row.RowIndex].Value);

                //prop.HapusProposal(tmp);
                if (!abdi.CekLaporan(tmp))
                {
                    if (abdi.CekLaporanTahap1(tmp))
                    {
                        Response.Redirect("LaporanPengabdian.aspx?id=" + tmp);
                    }
                    else
                    {
                        Response.Redirect("ErrorSekuensLaporanFinal.aspx");
                    }
                    
                }
                else
                {
                    Response.Redirect("ErrorLaporan.aspx?id=" + tmp);
                }

            }
            else if (e.CommandName == "jadwal")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewPengabdianLolos.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdianLolos.DataKeys[row.RowIndex].Value);

                Response.Redirect("PengabdianSchedule.aspx?id=" + tmp);
            }
            //
            else if (e.CommandName == "perpanjang")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridViewPengabdianLolos.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdianLolos.DataKeys[row.RowIndex].Value);

                Response.Redirect("PerpanjanganPenelitian.aspx?id=" + tmp);
            }
            else if (e.CommandName == "cetak")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewPengabdianLolos.Rows[index];
                string tmp = Convert.ToString(GridViewPengabdianLolos.DataKeys[row.RowIndex].Value);


                // Add code here to add the item to the shopping cart.
                if (!abdi.CekLaporanTahap1(tmp))
                {
                    string tmpnppDosen = abdi.getNppDosenbyIDProposal_Penelitian(tmp);
                    if (abdi.CekPerkembanganMonev(tmp, tmpnppDosen))
                    {
                        Response.Redirect("LaporanPengabdianTahap1.aspx?id=" + tmp);
                    }
                    else
                    {
                        Response.Redirect("ErrorSekuensLaporan.aspx");
                    }

                }
                else
                {
                    Response.Redirect("ErrorLaporan.aspx?id=" + tmp);
                }

            }
           
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
            string tmp = Convert.ToString(GridView2.DataKeys[gvr.RowIndex].Value);

            DropDownList dpdListEstatus = gvr.FindControl("DropDownList1") as DropDownList;
            string Hasilddl = (dpdListEstatus is DropDownList) ? dpdListEstatus.SelectedValue : null;
            if (Hasilddl == "Lapor Perkembangan")
            {
                if (!prop.cekPerpusSetuju(tmp)) {
                    Response.Redirect(String.Format("LaporPerkembangan.aspx?idN={0}&idG={1}", Server.UrlEncode(tmp), Server.UrlEncode("0")));
                }
                else
                {
                    // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                }
            }
            else if (Hasilddl == "Unggah Draft Laporan Final")
            {
                if (!prop.cekPerpusSetuju(tmp)) {
                    if (!prop.CekLaporanTahap1(tmp))
                    {
                        string tmpnppDosen = prop.getNppDosenbyIDProposal_Penelitian(tmp);
                        if (prop.CekPerkembanganMonev(tmp, tmpnppDosen))
                        {
                            Response.Redirect("LaporanPenelitianTahap1.aspx?id=" + tmp);
                        }
                        else
                        {
                            Response.Redirect("ErrorSekuensLaporan.aspx");
                        }

                    }
                    else
                    {
                        Response.Redirect("ErrorLaporanTahap1.aspx?id=" + tmp);
                    }
                }
                else {
                   // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                }
                
            }
            else if (Hasilddl == "Unggah Laporan Final")
            {
                if (!prop.cekPerpusSetuju(tmp)) {
                    if (!prop.CekLaporan(tmp))
                    {
                        if (prop.CekLaporanTahap1(tmp))
                        {
                            Response.Redirect("LaporanPenelitian.aspx?id=" + tmp);
                        }
                        else
                        {
                            Response.Redirect("ErrorSekuensLaporanFinal.aspx");
                        }

                    }
                    else
                    {
                        Response.Redirect("ErrorLaporan.aspx?id=" + tmp);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                   //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (Hasilddl == "Perpanjang Masa Akhir")
            {
                if (!prop.cekPerpusSetuju(tmp)) {
                    if (!prop.CekLaporan(tmp))
                    {
                        Response.Redirect("PerpanjanganPenelitian.aspx?id=" + tmp);
                    }
                    else {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                       "alert('Maaf anda tidak dapat melakukan aksi ini, karena Laporan Final telah dimasukkan.');", true);
                        //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else if (Hasilddl == "Lihat Review")
            {
                Response.Redirect("LihatProposal.aspx?id=" + tmp);
            }
            else if (Hasilddl == "Lihat Jadwal")
            {
                Response.Redirect("PenelitianSchedule.aspx?id=" + tmp);
            }
            //

        }

        protected void ddlPengabdianLolos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = (GridViewRow)((DropDownList)sender).Parent.Parent;
            string tmp = Convert.ToString(GridViewPengabdianLolos.DataKeys[gvr.RowIndex].Value);

            DropDownList dpdListEstatus = gvr.FindControl("ddlPengabdianLolos") as DropDownList;
            string Hasilddl = (dpdListEstatus is DropDownList) ? dpdListEstatus.SelectedValue : null;
            if (Hasilddl == "Lapor Perkembangan")
            {
                if (!abdi.cekPerpusSetuju(tmp))
                {
                    Response.Redirect(String.Format("LaporPerkembangan.aspx?idN={0}&idG={1}", Server.UrlEncode("0"), Server.UrlEncode(tmp)));
                }
                else
                {
                    // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                }
                
                //Response.Redirect(String.Format("LaporPerkembangan.aspx?idN={0}&idG={1}", Server.UrlEncode(tmp), Server.UrlEncode("0")));
            }
            else if (Hasilddl == "Unggah Draft Laporan Final")
            {
                if (!abdi.cekPerpusSetuju(tmp))
                {
                    if (!abdi.CekLaporanTahap1(tmp))
                    {
                        string tmpnppDosen = abdi.getNppDosenbyIDProposal_Penelitian(tmp);
                        if (abdi.CekPerkembanganMonev(tmp, tmpnppDosen))
                        {
                            Response.Redirect("LaporanPengabdianTahap1.aspx?id=" + tmp);
                        }
                        else
                        {
                            Response.Redirect("ErrorSekuensLaporan.aspx");
                        }

                    }
                    else
                    {
                        Response.Redirect("ErrorLaporanTahap1Pengabdian.aspx?id=" + tmp);
                    }
                }
                else
                {
                    // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                }
                
            }
            else if (Hasilddl == "Unggah Laporan Final")
            {
                if (!abdi.cekPerpusSetuju(tmp))
                {
                    if (!abdi.CekLaporan(tmp))
                    {
                        if (abdi.CekLaporanTahap1(tmp))
                        {
                            Response.Redirect("LaporanPengabdian.aspx?id=" + tmp);
                        }
                        else
                        {
                            Response.Redirect("ErrorSekuensLaporanFinal.aspx");
                        }

                    }
                    else
                    {
                        Response.Redirect("ErrorLaporanPengabdian.aspx?id=" + tmp);
                    }
                }
                else
                {
                    // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                }
                
            }
            else if (Hasilddl == "Perpanjang Masa Akhir")
            {
                if (!abdi.cekPerpusSetuju(tmp))
                {
                    if (!abdi.CekLaporan(tmp))
                    {
                        Response.Redirect("PerpanjangPengabdian.aspx?id=" + tmp);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                       "alert('Maaf anda tidak dapat melakukan aksi ini, karena Laporan Final telah dimasukkan.');", true);
                        //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Maaf anda tidak dapat melakukan aksi ini, karena Penelitian anda telah dinyatakan Berakhir.');", true);
                }
                //Response.Redirect("PerpanjanganPenelitian.aspx?id=" + tmp);
            }
            else if (Hasilddl == "Lihat Review")
            {
                Response.Redirect("LihatPengabdian.aspx?id=" + tmp);
            }
            else if (Hasilddl == "Lihat Jadwal")
            {
                Response.Redirect("PengabdianSchedule.aspx?id=" + tmp);
            }
        }

    }
}