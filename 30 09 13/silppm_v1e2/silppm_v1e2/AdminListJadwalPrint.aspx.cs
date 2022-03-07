using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace silppm_v1e2
{
    public partial class WebForm61 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private DataTable dt = new DataTable();
        private ProposalDAO prop = new ProposalDAO();
        private DateTime awal, akhir, toLabel, toLabel2, log1,log2,log3,log4,log5,log6,fin;
        private string tmpnpprev;
        private string  tmp1, row1c1,row2c1,row3c1,row4c1,row5c1,row6c1,col2,col3,col4,col5;
        private int tmpmonth, dateakhir, tglakhir, bulanakhir, logYear1, logYear2, logMonthAwal, logMonthAkhir, logDayAwal, tmpSelisihmonth, maxInit;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            bindGridView();
        }
        private void bindGridView()
        {
            dataset.Clear();
            dataset = prop.getListCetakJadwal();

            if (dataset.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = dataset.Tables[0];
                GridView1.DataBind();

            }
            else
            {
                Label1.Visible = true;
            }
        }
        protected override void InitializeCulture()
        {
            CultureInfo CI = new CultureInfo("en-US");
            DateTimeFormatInfo dtfi = CI.DateTimeFormat;
            dtfi.AbbreviatedMonthNames = new string[] { "Jan", "Feb", "Mar", 
                                                  "Apr", "May", "Jun", 
                                                  "Jul", "Aug", "Sep", 
                                                  "Oct", "Nov", "Dec", "" };
            dtfi.AbbreviatedMonthGenitiveNames = dtfi.AbbreviatedMonthNames;
            CI.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            Thread.CurrentThread.CurrentCulture = CI;
            Thread.CurrentThread.CurrentUICulture = CI;
            base.InitializeCulture();

        }
        private void generateJadwalPerpanjangan(string tmpid)
        {
            InitializeCulture();
            awal = prop.getAwalProposal(tmpid);
            akhir = prop.getAkhirProposal(tmpid);

            dateakhir = Convert.ToInt32(String.Format("{0:dd}", akhir));
            if ((dateakhir - 14) < 1)
            {

                DateTime tmpdategen, tmpdategen2;
                bulanakhir = Convert.ToInt32(String.Format("{0:MM}", akhir)) - 1;
                tglakhir = 30 + Convert.ToInt32(String.Format("{0:dd}", akhir)) - 14;
                //toLabel2 = Convert.ToDateTime(String.Format("{0:" + tglakhir + "/" + bulanakhir+"/yyyy}", akhir));
                tmpdategen = Convert.ToDateTime(String.Format("{0:dd/" + bulanakhir + "/yyyy}", akhir));
                tmpdategen2 = Convert.ToDateTime(String.Format("{0:" + tglakhir + "/MM/yyyy}", tmpdategen));
                toLabel2 = Convert.ToDateTime(String.Format("{0:dd/MM/yyyy}", tmpdategen2));
            }
            else
            {
                tglakhir = Convert.ToInt32(String.Format("{0:dd}", akhir)) - 14;
                toLabel2 = Convert.ToDateTime(String.Format("{0:" + tglakhir + "/MM/yyyy}", akhir));
            }
            col3 = toLabel2.ToString().Substring(0, 11);

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "jadwal")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);

                //generate jadwal-----------------------------------------------------------------------------------------
                InitializeCulture();
                awal = prop.getAwalProposal(tmp);
                akhir = prop.getAkhirProposal(tmp);

                dt.Columns.Add("Melakukan Update Logbook", typeof(string));
                dt.Columns.Add("Upload Laporan Pertama", typeof(string));
                dt.Columns.Add("Upload Laporan Final", typeof(string));
                dt.Columns.Add("Paling Lambat Mengajukan Perpanjangan", typeof(string));
                dt.Columns.Add("Mengumpulkan hasil Output Penelitian ke Perpustakaan", typeof(string));

                InitializeCulture();
                logMonthAwal = Convert.ToInt32(String.Format("{0:MM}", awal));
                logMonthAkhir = Convert.ToInt32(String.Format("{0:MM}", akhir));
                tmpSelisihmonth = logMonthAkhir - logMonthAwal;
                logDayAwal = Convert.ToInt32(String.Format("{0:dd}", awal));
                logYear1 = Convert.ToInt32(String.Format("{0:yyyy}", awal));
                logYear2 = Convert.ToInt32(String.Format("{0:yyyy}", akhir));
                if (logYear1 >= logYear2)
                {
                    for (int i = 1; i <= tmpSelisihmonth; i++)
                    {
                        if (i == 1)
                        {
                            DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log1);
                            row1c1 = log1.ToString().Substring(0, 11);
                        }
                        if (i == 2)
                        {
                            DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log2);
                            row2c1 = log2.ToString().Substring(0, 11);
                        }
                        if (i == 3)
                        {
                            DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log3);
                            row3c1 = log3.ToString().Substring(0, 11);
                        }
                        if (i == 4)
                        {
                            DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log4);
                            row4c1 = log4.ToString().Substring(0, 11);
                        }
                        if (i == 5)
                        {
                            DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log5);
                            row5c1 = log5.ToString().Substring(0, 11);
                        }
                        if (i == 6)
                        {
                            DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log6);
                            row6c1 = log6.ToString().Substring(0, 11);
                        }
                    }
                }
                else if (logYear1 < logYear2)
                {
                    //(MONTH(AKHIR)+12)-MONTH(AWAL)
                    int selisih2 = (logMonthAkhir + 12) - logMonthAwal;
                    for (int i = 1; i <= selisih2; i++)
                    {
                        if (logMonthAwal + i <= 12)
                        {
                            if (i == 1)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log1);
                                row1c1 = log1.ToString().Substring(0, 11);
                            }
                            if (i == 2)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log2);
                                row2c1 = log2.ToString().Substring(0, 11);
                            }
                            if (i == 3)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log3);
                                row3c1 = log3.ToString().Substring(0, 11);
                            }
                            if (i == 4)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log4);
                                row4c1 = log4.ToString().Substring(0, 11);
                            }
                            if (i == 5)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log5);
                                row5c1 = log5.ToString().Substring(0, 11);
                            }
                            if (i == 6)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (logMonthAwal + i) + "/yyyy}", awal), out log6);
                                row6c1 = log6.ToString().Substring(0, 11);
                            }
                            maxInit = i;
                        }
                        if (logMonthAwal + i > 12)
                        {
                            if (i == 1)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (i - maxInit) + "/yyyy}", akhir), out log1);
                                row1c1 = log1.ToString().Substring(0, 11);
                            }
                            if (i == 2)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (i - maxInit) + "/yyyy}", akhir), out log2);
                                row2c1 = log2.ToString().Substring(0, 11);
                            }
                            if (i == 3)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (i - maxInit) + "/yyyy}", akhir), out log3);
                                row3c1 = log3.ToString().Substring(0, 11);
                            }
                            if (i == 4)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (i - maxInit) + "/yyyy}", akhir), out log4);
                                row4c1 = log4.ToString().Substring(0, 11);
                            }
                            if (i == 5)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (i - maxInit) + "/yyyy}", akhir), out log5);
                                row5c1 = log5.ToString().Substring(0, 11);
                            }
                            if (i == 6)
                            {
                                DateTime.TryParse(String.Format("{0:dd/" + (i - maxInit) + "/yyyy}", akhir), out log6);
                                row6c1 = log6.ToString().Substring(0, 11);
                            }
                        }

                    }


                }
                //labelpertama
                InitializeCulture();
                tmp1 = String.Format("{0:MM}", akhir);
                //string akh1 = akhir.ToString();
                tmpmonth = Convert.ToInt32(tmp1) - 1;
                toLabel = Convert.ToDateTime(String.Format("{0:dd/" + tmpmonth + "/yyyy}", akhir));
                col2 = toLabel.ToString().Substring(0,11);
                //labelkedua
                generateJadwalPerpanjangan(tmp);
                //labelketiga
                DateTime.TryParse(String.Format("{0:dd/MM/yyyy}", akhir), out fin);
                col4 = fin.ToString().Substring(0, 11);

                //labelkeempat
                col5 = toLabel.ToString().Substring(0, 11);

                DataRow dr = dt.NewRow();
                dr["Melakukan Update Logbook"] = row1c1; // or dr[0]="Mohammad";
                dr["Upload Laporan Pertama"] = col2;
                dr["Upload Laporan Final"] = col4; // or dr[1]=24;
                dr["Paling Lambat Mengajukan Perpanjangan"] = col3;
                dr["Mengumpulkan hasil Output Penelitian ke Perpustakaan"] = col5;
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Melakukan Update Logbook"] = row2c1;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Melakukan Update Logbook"] = row3c1;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Melakukan Update Logbook"] = row4c1;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Melakukan Update Logbook"] = row5c1;
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Melakukan Update Logbook"] = row6c1;
                dt.Rows.Add(dr);
                //-----------generate jadwal-------------------------------------------------------------------------------

                //membuat dokumen jadwal
                Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                //iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, Color.BLACK);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();
                    //konten dokumen----------------------------------------------------------------------------------------
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("JADWAL PENELITIAN"));
                    document.Add(new Paragraph("\n"));
                    //Craete instance of the pdf table and set the number of column in that table
                    PdfPTable PdfTable = new PdfPTable(5);
                    PdfTable.WidthPercentage = 100;
                    //PdfTable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
                    float[] widths = new float[] { 50f, 50f, 50f, 50f, 60f };
                    PdfTable.SetWidths(widths);
                    PdfTable.HorizontalAlignment = 0;
                    PdfPCell PdfPCell = null;


                    //Add Header of the pdf table
                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Melakukan Update Logbook")));
                    PdfPCell.Padding = 5;
                    PdfTable.AddCell(PdfPCell);

                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Upload Laporan Pertama")));
                    PdfPCell.Padding = 5;
                    PdfTable.AddCell(PdfPCell);

                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Upload Laporan Final")));
                    PdfPCell.Padding = 5;

                    PdfTable.AddCell(PdfPCell);
                    PdfPCell.Padding = 5;
                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Paling Lambat Mengajukan Perpanjangan")));

                    PdfTable.AddCell(PdfPCell);

                    PdfPCell = new PdfPCell(new Phrase(new Chunk("Mengumpulkan hasil Output Penelitian ke Perpustakaan")));
                    PdfPCell.Padding = 5;
                    PdfTable.AddCell(PdfPCell);
                    //How add the data from datatable to pdf table
                    for (int rows = 0; rows < dt.Rows.Count; rows++)
                    {
                        for (int column = 0; column < dt.Columns.Count; column++)
                        {
                            PdfPCell = new PdfPCell(new Phrase(new Chunk(dt.Rows[rows][column].ToString())));
                            PdfPCell.Padding = 5;

                            PdfTable.AddCell(PdfPCell);
                        }
                    }

                    PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table


                    document.Add(PdfTable); // add pdf table to the document


                    //------------------------------------------------------------------------------------------------------
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename= " + tmp + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();


                }
            }
            else if (e.CommandName == "surat")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                //membuat dokumen
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();
                    //konten dokumen-------------------------------------------------------------------------------
                    document.Add(new Paragraph("\n"));

                    //string path = ;
                    iTextSharp.text.Image chartImg = iTextSharp.text.Image.GetInstance(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\AtmaHitamPutih.png"));
                    chartImg.ScaleToFit(24f, 24f);

                    Paragraph p1 = new Paragraph("UNIVERSITAS ATMA JAYA YOGYAKARTA");
                    p1.Font.IsBold();
                    p1.Alignment = Element.ALIGN_CENTER;
                    document.Add(p1);

                    Paragraph p = new Paragraph();
                    //p.Add(new Phrase("Text next to the image "));
                    p.Add(new Chunk(chartImg,-80f,0));
                    p.Add(new Phrase("SURAT PENGANTAR PENCAIRAN DANA")); 
                    p.Alignment = Element.ALIGN_CENTER;
                    document.Add(p);
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("Nomor :"+tmp+"/LPPM-UAJY/"+DateTime.Now.ToString().Substring(0,10)+""));
                    document.Add(new Paragraph("Hal   : Permohonan Pencairan Dana"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("Kepada Yth."));
                    document.Add(new Paragraph("Bagian Keuangan UAJY Kampus 2"));
                    document.Add(new Paragraph("Di Tempat"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("Dengan Hormat,"));
                    document.Add(new Paragraph("Bersamaan dengan surat ini, kami sampaikan bahwa dosen dengan proposal yang bersangkutan :"));
                    document.Add(new Paragraph("\n"));
                    string judul= prop.getjudulByID(tmp);
                    string namaPeneliti = prop.getNamaDosenbyIDProposal_Penelitian(tmp);
                    document.Add(new Paragraph("Nama  :"+namaPeneliti));
                    document.Add(new Paragraph("Judul :"+judul));
                    double danasetuju = prop.getDanaDisetujui(tmp);
                    document.Add(new Paragraph("Telah mendapatkan persetujuan oleh pihak LPPM dan sudah mendapatkan hak untuk pencairan dana sebesar : Rp"+string.Format("{0:##,###}", (danasetuju*0.7)+",-")));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("Demikian surat permohonan dana ini kami sampaikan agar dapat diproses lebih lanjut. Terimakasih."));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    Paragraph p2 = new Paragraph("Yogyakarta, "+DateTime.Now.ToString().Substring(0, 10));
                    p2.Font.IsBold();
                    p2.Alignment = Element.ALIGN_RIGHT;
                    document.Add(p2);
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("KETUA LPPM                                                                    KETUA PENELITI"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("\n"));
                    document.Add(new Paragraph("(                           )                                                      (" + namaPeneliti + ")"));
                    //---------------------------------------------------------------------------------------------
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename= " + tmp + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();


                }

            }
            else if (e.CommandName == "surat30")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                int index = Convert.ToInt32(e.CommandArgument);

                // Retrieve the row that contains the button 
                // from the Rows collection.
                GridViewRow row = GridView1.Rows[index];
                string tmp = Convert.ToString(GridView1.DataKeys[row.RowIndex].Value);
                Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                //membuat dokumen
                if (prop.CekLaporanTahap1(tmp))
                {
                    using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                        document.Open();
                        //konten dokumen-------------------------------------------------------------------------------
                        document.Add(new Paragraph("\n"));

                        //string path = ;
                        iTextSharp.text.Image chartImg = iTextSharp.text.Image.GetInstance(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"images\AtmaHitamPutih.png"));
                        chartImg.ScaleToFit(24f, 24f);

                        Paragraph p1 = new Paragraph("UNIVERSITAS ATMA JAYA YOGYAKARTA");
                        p1.Font.IsBold();
                        p1.Alignment = Element.ALIGN_CENTER;
                        document.Add(p1);

                        Paragraph p = new Paragraph();
                        //p.Add(new Phrase("Text next to the image "));
                        p.Add(new Chunk(chartImg, -80f, 0));
                        p.Add(new Phrase("SURAT PENGANTAR PENCAIRAN DANA"));
                        p.Alignment = Element.ALIGN_CENTER;
                        document.Add(p);
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("Nomor :" + tmp + "/LPPM-UAJY/" + DateTime.Now.ToString().Substring(0, 10) + ""));
                        document.Add(new Paragraph("Hal   : Permohonan Pencairan Dana"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("Kepada Yth."));
                        document.Add(new Paragraph("Bagian Keuangan UAJY Kampus 2"));
                        document.Add(new Paragraph("Di Tempat"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("Dengan Hormat,"));
                        document.Add(new Paragraph("Bersamaan dengan surat ini, kami sampaikan bahwa dosen dengan proposal yang bersangkutan :"));
                        document.Add(new Paragraph("\n"));
                        string judul = prop.getjudulByID(tmp);
                        string namaPeneliti = prop.getNamaDosenbyIDProposal_Penelitian(tmp);
                        document.Add(new Paragraph("Nama  :" + namaPeneliti));
                        document.Add(new Paragraph("Judul :" + judul));
                        double danasetuju = prop.getDanaDisetujui(tmp);
                        document.Add(new Paragraph("Telah mendapatkan persetujuan oleh pihak LPPM dan sudah mendapatkan hak untuk pencairan dana sebesar : Rp" + string.Format("{0:##,###}", (danasetuju * 0.3) + ",-")));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("Demikian surat permohonan dana ini kami sampaikan agar dapat diproses lebih lanjut. Terimakasih."));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                        Paragraph p2 = new Paragraph("Yogyakarta, " + DateTime.Now.ToString().Substring(0, 10));
                        p2.Font.IsBold();
                        p2.Alignment = Element.ALIGN_RIGHT;
                        document.Add(p2);
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("KETUA LPPM                                                                    KETUA PENELITI"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("\n"));
                        document.Add(new Paragraph("(                           )                                                      (" + namaPeneliti + ")"));
                        //---------------------------------------------------------------------------------------------
                        document.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("Content-Disposition", "attachment; filename= " + tmp + ".pdf");
                        Response.ContentType = "application/pdf";
                        Response.Buffer = true;
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.BinaryWrite(bytes);
                        Response.End();
                        Response.Close();


                    }

                }
                else {
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('User belom menambahkan Draft Laporan Final!');", true);
                }
                

            }

        }

    }
}