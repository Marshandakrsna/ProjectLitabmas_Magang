using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.IO;
using System.Windows.Forms;

namespace silppm_v1e2
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private string tmpnama;
        private ProposalDAO prop = new ProposalDAO();
        private PropPen pen = new PropPen();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                UserEntity ue = Session["userdata"] as UserEntity;
                tmpnama = ue.NAMA;
                


            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }

        
        //private PropPen setDataPen() {
        //    pen.Judul = txtJudul.Text;
        //    pen.ID_jenis = "Mandiri";
        //    //pen.Kategori = "internal Sks";
        //    pen.Lokasi = txtLokasi.Text;
        //    pen.Dana = int.Parse(TextBox4.Text);
        //    pen.NPP = prop.getNPPbyNama(tmpnama);
        //    pen.ID_Schedule = "1";
        //    //pen.ID_Sumber = 1;
        //    pen.ID_Review1 = "1";
        //    pen.ID_Review2 = "2";
        //    pen.Sks = Convert.ToInt32(bebantxt.Text);
        //    pen.ID_Approval = "Menunggu Review 1";
        //    if (FileUpload1.HasFile)
        //    {
        //        Stream fs = default(Stream);
        //        fs = FileUpload1.PostedFile.InputStream;
        //        BinaryReader br1 = new BinaryReader(fs);
        //        byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
        //        pen.Dokumen = pdfbytes;
        //    }
        //    pen.Awal = String.Format("{0:MM/dd/yyyy}", dateAwal.SelectedDate);

        //    if (dateSelesai.Text == "1 bulan")
        //    {
        //        int tmpdate;
        //        string tmp1;
        //        tmp1 = String.Format("{0:MM}", dateAwal.SelectedDate);
        //        tmpdate = Convert.ToInt32(tmp1) + 1;
        //        pen.Akhir = String.Format("{0:" + tmpdate + "/dd/yyyy}", dateAwal.SelectedDate);


        //    }
        //    else if (dateSelesai.Text == "2 bulan")
        //    {
        //        int tmpdate;
        //        string tmp1;
        //        tmp1 = String.Format("{0:MM}", dateAwal.SelectedDate);
        //        tmpdate = Convert.ToInt32(tmp1) + 2;
        //        pen.Akhir = String.Format("{0:" + tmpdate + "/dd/yyyy}", dateAwal.SelectedDate);
        //    }
        //    else if (dateSelesai.Text == "3 bulan")
        //    {
        //        int tmpdate;
        //        string tmp1;
        //        tmp1 = String.Format("{0:MM}", dateAwal.SelectedDate);
        //        tmpdate = Convert.ToInt32(tmp1) + 3;
        //        pen.Akhir = String.Format("{0:" + tmpdate + "/dd/yyyy}", dateAwal.SelectedDate);
        //    }
        //    else if (dateSelesai.Text == "4 bulan")
        //    {
        //        int tmpdate;
        //        string tmp1;
        //        tmp1 = String.Format("{0:MM}", dateAwal.SelectedDate);
        //        tmpdate = Convert.ToInt32(tmp1) + 4;
        //        pen.Akhir = String.Format("{0:" + tmpdate + "/dd/yyyy}", dateAwal.SelectedDate);
        //    }
        //    else if (dateSelesai.Text == "5 bulan")
        //    {
        //        int tmpdate;
        //        string tmp1;
        //        tmp1 = String.Format("{0:MM}", dateAwal.SelectedDate);
        //        tmpdate = Convert.ToInt32(tmp1) + 5;
        //        pen.Akhir = String.Format("{0:" + tmpdate + "/dd/yyyy}", dateAwal.SelectedDate);
        //    }
        //    else if (dateSelesai.Text == "6 bulan")
        //    {
        //        int tmpdate;
        //        string tmp1;
        //        tmp1 = String.Format("{0:MM}", dateAwal.SelectedDate);
        //        tmpdate = Convert.ToInt32(tmp1) + 6;
        //        pen.Akhir = String.Format("{0:" + tmpdate + "/dd/yyyy}", dateAwal.SelectedDate);
        //    }
            
        //    return pen;
        //}
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //if (prop.addProposal(setDataPen()))
            //{

            //    MessageBox.Show("Penambahan data berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
            //else
            //{
            //    MessageBox.Show("Penambahan data gagal!", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}