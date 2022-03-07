using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using silppm_v1e2.Entity;
using System.IO;

namespace silppm_v1e2
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private ReviewDAO rev = new ReviewDAO();
        private UserDAO datauser = new UserDAO();
        private ProposalDAO prop = new ProposalDAO();
        private ProposalPengabdianDAO abdi = new ProposalPengabdianDAO();
        private string tmpid, tmpnpp, tmppengabdian, subid, tmpKategori, tmpidG;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["idN"];
            tmpidG = Request.QueryString["idG"];
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                tmpnpp = datauser.getNPPByUsername(ue.Username);
                lblTanggal.Text = DateTime.Now.ToString();
                bindGridView();
            }
            else {
                Response.Redirect("LoginExpired.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
        private void bindGridView()
        {
            dataset.Clear();
            
            if (tmpid!="0")
            {
                tmpKategori = "Penelitian";
                dataset = rev.getDataPerkembanganPenelitian(tmpid, tmpnpp);
                
            }
            else
            {
                tmpKategori = "Pengabdian";
                dataset = rev.getDataPerkembanganPengabdian(tmpidG, tmpnpp);
            }

            
            if (dataset.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                Label1.Visible = true;
                //GridView1.Visible = false;
            }
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int tmpupdate=0;
            
            try
            {
                if (tmpKategori == "Penelitian")
                {
                    tmpupdate = rev.getMaxCountPenelitian(tmpid, tmpnpp) + 1;

                }
                else
                {
                    tmpupdate = rev.getMaxCountPengabdian(tmpidG, tmpnpp) + 1;
                }

                
            }
            catch { 
            
            }
            if (tmpupdate == 0)
            {
                tmpupdate = 1;
            }
            if (tmpKategori == "Penelitian")
            {
                
                if (FileUpload1.HasFile)
                {
                    Stream fs = default(Stream);
                    fs = FileUpload1.PostedFile.InputStream;
                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                   // pen.Dokumen = pdfbytes;
                    //melakukan upload dokumen logbook
                    if (rev.addUpdatePenelitian(tmpid,  tmpnpp, tmpupdate, lblTanggal.Text, pdfbytes))
                    {


                       // MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data berhasil!');", true);
                        GridView1.DataBind();
                        //txtKeterangan.Text = "";
                        bindGridView();


                    }
                    else
                    {
                        //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data gagal!');", true);
                    }
                }
                
            }
            else
            {
                
                
                if (FileUpload1.HasFile)
                {
                    Stream fs = default(Stream);
                    fs = FileUpload1.PostedFile.InputStream;
                    BinaryReader br1 = new BinaryReader(fs);
                    byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                   // pen.Dokumen = pdfbytes;
                    //melakukan upload dokumen logbook
                    if (rev.addUpdatePengabdian(tmpidG, tmpnpp, tmpupdate, lblTanggal.Text, pdfbytes))
                    {
                       // MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data berhasil!');", true);
                        GridView1.DataBind();
                   // txtKeterangan.Text = "";
                        
                        bindGridView();
                    }
                    else
                    {
                       // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data gagal!');", true);
                    }
                }
                
            }
               

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
                if (tmpKategori == "Penelitian")
                {
                    //int noupdate = prop.getNoUpdate(tmp);
                    temp = prop.getMONEVPenelitian(tmpid,Convert.ToInt32(tmp));
                    Response.BinaryWrite(temp);
                    Response.End();
                }
                else if (tmpKategori == "Pengabdian")
                {
                    int noupdate = prop.getNoUpdate(tmp);
                    temp = abdi.getMONEVPengabdian(tmpidG, Convert.ToInt32(tmp));
                    Response.BinaryWrite(temp);
                    Response.End();
                }
               
                
                //Response.Redirect("LihatProposal.aspx?id=" + tmp);
            }

            
        }


           
            
        }
    }
