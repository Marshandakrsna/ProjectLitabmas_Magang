using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using silppm_v1e2.Entity;
using System.Windows.Forms;
using System.Net.Mail;

namespace silppm_v1e2
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        private DataSet abdi = new DataSet();
        private string namareviewer, tmpnppreviewer, tmpid, tmpusername, tampungstatus;
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private UserDAO datauser = new UserDAO();
        private double dana1, dana2;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            tmpid = Request.QueryString["id"];
            if (Session["userdata"] != null)
            {
               
                UserEntity ue = Session["userdata"] as UserEntity;

                namareviewer = ue.NAMA;
                tmpnppreviewer = ue.NPP;
                if (prop.valReview(tmpid, tmpnppreviewer))
                {
                    Response.Redirect("ErrorPageRev.aspx");
                }

                tmpusername = prop.getusernameByIDProposal(tmpid);
                lblPeriode.Text = prop.getNamaPeriodeByIDProposal(tmpid);
                lblNamaKetua.Text = datauser.getNamaByUsername(tmpusername);
                lblNPPKetua.Text = datauser.getNPPByUsername(tmpusername);
                lblAlamatKetua.Text = datauser.getAlamatByUsername(tmpusername);
                //lblEmailKetua.Text = datauser.getEmailDosen(tmpusername);
                lblFakKetua.Text = datauser.getFakultasByUsername(tmpusername);
                //lblGolKetua.Text = datauser.getGolByUsername(tmpusername);
                lblTelpKetua.Text = datauser.getTelpByUsername(tmpusername);
                //lblPangkatKetua.Text = datauser.getPangkatByUsername(tmpusername);
                lblNIDNKetua.Text = Convert.ToString(datauser.getNIDNbyUsername(tmpusername));
                //lblJurusanKetua.Text = datauser.getjurusanByUsername(tmpusername);
                lblFakKetua.Text = datauser.getFakultasByUsername(tmpusername);
                lblGolKetua.Text = datauser.getGolByUsername(tmpusername);
                lblPangkatKetua.Text = datauser.getPangkatByUsername(tmpusername);
                lblJurusanKetua.Text = datauser.getjurusanByUsername(tmpusername);
                abdi.Clear();
                abdi = prop.getDataProposalByIDProposal(tmpid);
                try
                {
                    
                    lblJudul.Text = abdi.Tables[0].Rows[0][6].ToString();
                    lblLandasan.Text = abdi.Tables[0].Rows[0][7].ToString();
                    lblJenis.Text = abdi.Tables[0].Rows[0][8].ToString();
                    lblNama1.Text= abdi.Tables[0].Rows[0][9].ToString();
                    lblNama2.Text=abdi.Tables[0].Rows[0][11].ToString();
                    lblBidang1.Text=abdi.Tables[0].Rows[0][10].ToString();
                    lblBidang2.Text = abdi.Tables[0].Rows[0][12].ToString();
                    lblMitra.Text = abdi.Tables[0].Rows[0][13].ToString();
                    lblKeahlianMitra.Text = abdi.Tables[0].Rows[0][14].ToString();
                    
                    lblLokasi.Text = abdi.Tables[0].Rows[0][15].ToString();
                    lblJarak.Text = abdi.Tables[0].Rows[0][16].ToString();
                    lblOutput.Text = abdi.Tables[0].Rows[0][17].ToString();
                    lblOutcome.Text = abdi.Tables[0].Rows[0][18].ToString();
                    lblWaktu.Text = abdi.Tables[0].Rows[0][19].ToString();
                    lblAkhir.Text = abdi.Tables[0].Rows[0][20].ToString();
                    lblSasaran.Text = abdi.Tables[0].Rows[0][21].ToString();
                    lblSksKetua.Text = abdi.Tables[0].Rows[0][22].ToString();
                    lblSksAnggota.Text = abdi.Tables[0].Rows[0][23].ToString();
                    lblUnit.Text = abdi.Tables[0].Rows[0][24].ToString();
                    
                        dana1 = double.Parse(abdi.Tables[0].Rows[0][25].ToString());
                        lblDanaUajy.Text = string.Format("{0:##,###}", dana1);
                        dana2 = double.Parse(abdi.Tables[0].Rows[0][26].ToString());
                        lblDanaPengusul.Text = string.Format("{0:##,###}", dana2);
                }
                catch { 
                
                }
                
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
            }
        }

        protected void btnContinu_Click(object sender, EventArgs e)
        {
           
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";
            byte[] temp = prop.getPropsalPenelitian(tmpid);
            Response.BinaryWrite(temp);
            Response.End();
        }
        public void KirimEmailKALPPM()
        {

            string email = datauser.getEmailKALPPM();
            string judul = prop.getjudulByID(tmpid);
            //string password = alumniMgr.getPassByUser(username);

            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(Email.emailAccount);
            mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di Disetujui";
            string Body = @"Anda memiliki Permohonan proposal dengan judul :"
                + "<br/>Judul : " + judul
                + "  <br/>Untuk dapat melakukan persetujuan terhadap proposal penelitian ini, silahkan kunjungi halaman SILPPM dan buka pada panel Pengesahan.<br/> Terimakasih.";
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Email.emailHost;
            smtp.Port = Convert.ToInt32(Email.emailPort);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(Email.emailAccount, Email.emailPassword);
            smtp.EnableSsl = false;

            try
            {
                smtp.Send(mail);
            }
            catch (System.Net.Mail.SmtpFailedRecipientsException recExc)
            {
                for (int recipient = 0; recipient < recExc.InnerExceptions.Length - 1; recipient++)
                {
                    System.Net.Mail.SmtpStatusCode statusCode;
                    //Each InnerException is an System.Net.Mail.SmtpFailed RecipientException
                    statusCode = recExc.InnerExceptions[recipient].StatusCode;

                    if ((statusCode == System.Net.Mail.SmtpStatusCode.MailboxBusy) || (statusCode == System.Net.Mail.SmtpStatusCode.MailboxUnavailable))
                    {
                        //Log this to event log: recExc.InnerExceptions[recipient].FailedRecipient
                        System.Threading.Thread.Sleep(5000);
                        smtp.Send(mail);
                    }
                    else
                    {
                        //Log error to event log.
                        //recExc.InnerExceptions[recipient].StatusCode or use statusCode
                    }

                }
            }
            //General SMTP execptions
            catch (System.Net.Mail.SmtpException)
            {
                //Log error to event log using StatusCode information in
                //smtpExc.StatusCode
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                          "alert('Gagal Mengirim Email! Periksa Koneksi Internet Anda!');", true);
                // System.Windows.Forms.MessageBox.Show("", "Gagal", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            }
            catch (Exception)
            {
                //Log error to event log.
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            tampungstatus = prop.getStatusPenelitianByID(tmpid);
            if (tampungstatus == "Menunggu Review Assesor")
            {
                //update ke review 2
                if (prop.ReviewProposalPenelitian(tmpid, tmpnppreviewer))
                {   //insert detail penilaian ke db
                    double tmpSkor1, tmpSkor2, tmpSkor3, tmpSkor4, tmpSkor5, tmpSkor6;
                    tmpSkor1 = Convert.ToInt32(Label1.Text);
                    tmpSkor2 = Convert.ToInt32(Label2.Text);
                    tmpSkor3 = Convert.ToInt32(Label3.Text);
                    tmpSkor4 = Convert.ToInt32(Label4.Text);
                    tmpSkor5 = Convert.ToInt32(Label5.Text);
                    tmpSkor6 = Convert.ToInt32(Label6.Text);
                    
                    int ctrev = 0;
                    try
                    {
                        ctrev = prop.getMaxctRev(tmpid, tmpnppreviewer);
                        ctrev += 1;
                    }
                    catch
                    {

                    }
                    if (prop.addNilaiPengabdian(tmpid, tmpnppreviewer, ctrev, tmpSkor1,
                tmpSkor2, tmpSkor3, tmpSkor4,
                tmpSkor5, tmpSkor6, txtJusti1.Text, txtJusti2.Text, txtJusti3.Text, txtJusti4.Text, txtJusti5.Text, txtJusti6.Text,txtCatatan1.Text,txtCatatan2.Text,txtCatatan3.Text,txtCatatan4.Text,txtCatatan5.Text, RadioButtonList1.Text,Convert.ToInt32(txtAnggaran.Text),txtAnggaranHuruf.Text, RadioButtonList2.Text))
                    {
                        if(Convert.ToInt32(Label7.Text)>=490){
                            if (prop.ReviewProposalPenelitian(tmpid, tmpnppreviewer))
                            {
                                string email = datauser.getEmailbyIDPengabdian(tmpid);

                                string nama = datauser.getNamaByIDPengabdian(tmpid);
                                string namaProdi = datauser.getNamaByNPP(tmpnppreviewer);
                                string judul = prop.getjudulByID(tmpid);


                                MailMessage mail = new MailMessage();
                                mail.To.Add(email);
                                mail.From = new MailAddress(Email.emailAccount);
                                mail.Subject = "[Pemberitahuan] Selamat Proposal anda " + judul + " mendapatkan approval dari Assesor";

                                string Body = @"Selamat " + nama
                                    + ",<br/> Proposal anda telah mendapatkan persetujuan dari Assessor &#40;" + namaProdi + "&#41;. <br/>" 
                                    + "<br/>Judul : " + judul
                                    + "  <br/> Selanjutnya silahkan tunggu konfirmasi dari  KA LPPM untuk mendapatkan persetujuan dana.<br/> Terimakasih.";
                                mail.Body = Body;
                                mail.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = Email.emailHost;
                                smtp.Port = Convert.ToInt32(Email.emailPort);
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new System.Net.NetworkCredential(Email.emailAccount, Email.emailPassword);
                                smtp.EnableSsl = false;

                                try
                                {
                                    smtp.Send(mail);
                                    KirimEmailKALPPM();
                                    Response.Redirect("BerhasilRev.aspx");
                                }
                                catch (System.Net.Mail.SmtpFailedRecipientsException recExc)
                                {
                                    for (int recipient = 0; recipient < recExc.InnerExceptions.Length - 1; recipient++)
                                    {
                                        System.Net.Mail.SmtpStatusCode statusCode;
                                        //Each InnerException is an System.Net.Mail.SmtpFailed RecipientException
                                        statusCode = recExc.InnerExceptions[recipient].StatusCode;

                                        if ((statusCode == System.Net.Mail.SmtpStatusCode.MailboxBusy) || (statusCode == System.Net.Mail.SmtpStatusCode.MailboxUnavailable))
                                        {
                                            //Log this to event log: recExc.InnerExceptions[recipient].FailedRecipient
                                            System.Threading.Thread.Sleep(5000);
                                            smtp.Send(mail);
                                        }
                                        else
                                        {
                                            //Log error to event log.
                                            //recExc.InnerExceptions[recipient].StatusCode or use statusCode
                                        }

                                    }
                                }
                                //General SMTP execptions
                                catch (System.Net.Mail.SmtpException)
                                {
                                    //Log error to event log using StatusCode information in
                                    //smtpExc.StatusCode
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                  "alert('Gagal Mengirim Email! Periksa Koneksi Internet Anda!');", true);
                                    // System.Windows.Forms.MessageBox.Show("", "Gagal", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                                }
                                catch (Exception)
                                {
                                    //Log error to event log.
                                }
                                //Response.Redirect("BerhasilRev.aspx");

                            }

                        }
                        //else if (tmpKeputusan == "Revisi")
                        //{
                        //    if (prop.UpdateStatusMenungguReview2(hidden1.Value))
                        //    {
                        //        Response.Redirect("BerhasilRev.aspx");
                        //    }

                        //}
                        else if (Convert.ToInt32(Label7.Text)<490)
                        {
                            int cek = 0;
                            if (prop.updateStatusDITOLAK(cek, tmpid))
                            {
                                string email = datauser.getEmailbyIDPengabdian(tmpid);

                                string nama = datauser.getNamaByIDPengabdian(tmpid);
                                string namaProdi = datauser.getNamaByNPP(tmpnppreviewer);
                                string judul = prop.getjudulByID(tmpid);
                                //string password = alumniMgr.getPassByUser(username);

                                MailMessage mail = new MailMessage();
                                mail.To.Add(email);
                                mail.From = new MailAddress(Email.emailAccount);
                                mail.Subject = "[Pemberitahuan] Konfirmasi Proposal anda " + judul + ". SILPPM ";

                                string Body = @"Maaf " + nama
                                    + ",<br/> Proposal anda belum dapat melanjutkan ke proses selanjutnya dari hasil review Assessor &#40;" + namaProdi + "&#41;. <br/> "
                                    + "<br/>Judul : " + judul
                                    + "  <br/> <br/> Terimakasih.";
                                mail.Body = Body;
                                mail.IsBodyHtml = true;
                                SmtpClient smtp = new SmtpClient();
                                smtp.Host = Email.emailHost;
                                smtp.Port = Convert.ToInt32(Email.emailPort);
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new System.Net.NetworkCredential(Email.emailAccount, Email.emailPassword);
                                smtp.EnableSsl = false;

                                try
                                {
                                    smtp.Send(mail);
                                    Response.Redirect("BerhasilRev.aspx");
                                }
                                catch (System.Net.Mail.SmtpFailedRecipientsException recExc)
                                {
                                    for (int recipient = 0; recipient < recExc.InnerExceptions.Length - 1; recipient++)
                                    {
                                        System.Net.Mail.SmtpStatusCode statusCode;
                                        //Each InnerException is an System.Net.Mail.SmtpFailed RecipientException
                                        statusCode = recExc.InnerExceptions[recipient].StatusCode;

                                        if ((statusCode == System.Net.Mail.SmtpStatusCode.MailboxBusy) || (statusCode == System.Net.Mail.SmtpStatusCode.MailboxUnavailable))
                                        {
                                            //Log this to event log: recExc.InnerExceptions[recipient].FailedRecipient
                                            System.Threading.Thread.Sleep(5000);
                                            smtp.Send(mail);
                                        }
                                        else
                                        {
                                            //Log error to event log.
                                            //recExc.InnerExceptions[recipient].StatusCode or use statusCode
                                        }

                                    }
                                }
                                //General SMTP execptions
                                catch (System.Net.Mail.SmtpException)
                                {
                                    //Log error to event log using StatusCode information in
                                    //smtpExc.StatusCode
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                  "alert('Gagal Mengirim Email! Periksa Koneksi Internet Anda!');", true);
                                    // System.Windows.Forms.MessageBox.Show("", "Gagal", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

                                }
                                catch (Exception)
                                {
                                    //Log error to event log.
                                }
                            }
                        }
                        

                    }
                    else
                    {
                        //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Terjadi Kesalahan');", true);
                    }
                }
                else
                {
                   // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Terjadi Kesalahan');", true);
                }
            }
            else if (tampungstatus == "Menunggu Review 2")
            {
                //pindah ke DB terima 
                
                if (prop.ReviewProposalPenelitian2(tmpid, tmpnppreviewer))
                {   //insert detail penilaian ke db

                    double tmpSkor1, tmpSkor2, tmpSkor3, tmpSkor4, tmpSkor5, tmpSkor6, tmpSkor7;
                    tmpSkor1 = Convert.ToInt32(Label1.Text);
                    tmpSkor2 = Convert.ToInt32(Label2.Text);
                    tmpSkor3 = Convert.ToInt32(Label3.Text);
                    tmpSkor4 = Convert.ToInt32(Label4.Text);
                    tmpSkor5 = Convert.ToInt32(Label5.Text);
                    tmpSkor6 = Convert.ToInt32(Label6.Text);
                    
                    int ctrev = 0;
                    try
                    {
                        ctrev = prop.getMaxctRev(tmpid, tmpnppreviewer);
                        ctrev += 1;
                    }
                    catch
                    {

                    }
                    if (prop.addNilaiPengabdian(tmpid, tmpnppreviewer, ctrev, tmpSkor1,
                tmpSkor2, tmpSkor3, tmpSkor4,
                tmpSkor5, tmpSkor6, txtJusti1.Text, txtJusti2.Text, txtJusti3.Text, txtJusti4.Text, txtJusti5.Text, txtJusti6.Text, txtCatatan1.Text, txtCatatan2.Text, txtCatatan3.Text, txtCatatan4.Text, txtCatatan5.Text, RadioButtonList1.Text, Convert.ToInt32(txtAnggaran.Text), txtAnggaranHuruf.Text, RadioButtonList2.Text))
                    {
                        Response.Redirect("BerhasilRev.aspx");
                        
                           

                            //update is drop, mauskin penilaian
                        

                    }
                    else
                    {
                        //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Terjadi Kesalahan');", true);
                    }
                }
                else
                {
                   // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Terjadi Kesalahan');", true);
                }

            }
            else
            {
                // jika terjadi penolakan ato revisi
                


                double tmpSkor1, tmpSkor2, tmpSkor3, tmpSkor4, tmpSkor5, tmpSkor6, tmpSkor7;
                tmpSkor1 = Convert.ToInt32(Label1.Text);
                tmpSkor2 = Convert.ToInt32(Label2.Text);
                tmpSkor3 = Convert.ToInt32(Label3.Text);
                tmpSkor4 = Convert.ToInt32(Label4.Text);
                tmpSkor5 = Convert.ToInt32(Label5.Text);
                tmpSkor6 = Convert.ToInt32(Label6.Text);
                
                int ctrev = 0;
                try
                {
                    ctrev = prop.getMaxctRev(tmpid, tmpnppreviewer);
                    ctrev += 1;
                }
                catch
                {

                }
                if (prop.addNilaiPengabdian(tmpid, tmpnppreviewer, ctrev, tmpSkor1,
               tmpSkor2, tmpSkor3, tmpSkor4,
               tmpSkor5, tmpSkor6, txtJusti1.Text, txtJusti2.Text, txtJusti3.Text, txtJusti4.Text, txtJusti5.Text, txtJusti6.Text, txtCatatan1.Text, txtCatatan2.Text, txtCatatan3.Text, txtCatatan4.Text, txtCatatan5.Text, RadioButtonList1.Text, Convert.ToInt32(txtAnggaran.Text), txtAnggaranHuruf.Text, RadioButtonList2.Text))
                {

                    Response.Redirect("BerhasilRev.aspx");


                }
                else
                {
                    //MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Terjadi Kesalahan');", true);
                }

            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = Convert.ToInt32(DropDownList1.SelectedValue) * 20;
            Label1.Text = tmp.ToString(); jumlah();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = Convert.ToInt32(DropDownList2.SelectedValue) * 15;
            Label2.Text = tmp.ToString(); jumlah();
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = Convert.ToInt32(DropDownList3.SelectedValue) * 20;
            Label3.Text = tmp.ToString(); jumlah();
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = Convert.ToInt32(DropDownList4.SelectedValue) * 15;
            Label4.Text = tmp.ToString(); jumlah();
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = Convert.ToInt32(DropDownList5.SelectedValue) * 10;
            Label5.Text = tmp.ToString(); jumlah();
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmp = Convert.ToInt32(DropDownList6.SelectedValue) * 20;
            Label6.Text = tmp.ToString(); jumlah();
        }
        private void jumlah()
        {
            try
            {
                int tmp1, tmp2, tmp3, tmp4, tmp5, tmp6;
                try { tmp1 = Convert.ToInt32(Label1.Text); }
                catch { tmp1 = 0; }
                try { tmp2 = Convert.ToInt32(Label2.Text); }
                catch { tmp2 = 0; }
                try { tmp3 = Convert.ToInt32(Label3.Text); }
                catch { tmp3 = 0; }
                try { tmp4 = Convert.ToInt32(Label4.Text); }
                catch { tmp4 = 0; }
                try { tmp5 = Convert.ToInt32(Label5.Text); }
                catch { tmp5 = 0; }
                try { tmp6 = Convert.ToInt32(Label6.Text); }
                catch { tmp6 = 0; }

                float hasil = tmp1 + tmp2 + tmp3 + tmp4 + tmp5 + tmp6 ;
                Label7.Text = hasil.ToString();
            }
            catch { }
        }
    }
}