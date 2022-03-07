﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Windows.Forms;

namespace silppm_v1e2
{
    public partial class PenelitianUploadOutcome : System.Web.UI.Page
    {

        private ProposalDAO prop = new ProposalDAO();
        private string tmpid;
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];

        }

        protected void btnUnggah_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                Stream fs = default(Stream);
                fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                prop.UpdateLaporanOutcome(tmpid, pdfbytes);
              //  MessageBox.Show("", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data berhasil!');", true);
                Response.Redirect("Profile.aspx");
            }
            else {
                //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Anda belom menambahkan Laporan File!');", true);
            }
            
            
        }
    }
}