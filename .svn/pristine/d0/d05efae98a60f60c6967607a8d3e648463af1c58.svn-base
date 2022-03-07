using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using silppm_v1e2.Entity;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data;
using System.Net.Mail;

namespace silppm_v1e2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private UserDAO datauser = new UserDAO();
        private ProposalDAO prop = new ProposalDAO();
        private ProposalPengabdianDAO abdi = new ProposalPengabdianDAO();
        private PropPengab pengab = new PropPengab();
        private DataTable dtTema = new DataTable();
        private string tmpusername, tmpKategori,tmpnpp,tmpid;
        private int idprodi,tmptanggal;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            panelAnggota.Visible = false;
            panelSksAnggota.Visible = false;
            tmpKategori = Request.QueryString["Type"];
            
            if (Session["userdata"] != "null") {
            UserEntity ue = Session["userdata"] as UserEntity;
                tmpusername= ue.Username;
                tmpnpp = ue.NPP;
                lblPeriode.Text = prop.getNamaPeriode();
                lblNamaKetua.Text = datauser.getNamaByUsername(tmpusername);
                lblFakKetua.Text = datauser.getFakultasByUsername(tmpusername);
                lblGolonganKetua.Text = datauser.getGolByUsername(tmpusername);
                lblAlamatKetua.Text=datauser.getAlamatByUsername(tmpusername);
                lblNPPKetua.Text=datauser.getNPPByUsername(tmpusername);
                lblNIDNKetua.Text= Convert.ToString(datauser.getNIDNbyUsername(tmpusername));
                //lblTelpKetua.Text = datauser.getTelpByUsername(tmpusername);
                lblJurusanKetua.Text = datauser.getjurusanByUsername(tmpusername);

                idprodi = datauser.getProdiByNPP(ue.NPP);
                if (!Page.IsPostBack)
                {
                    dtTema.Clear();
                    dtTema = abdi.getTemaPengabdian(idprodi);
                    ddLRencanaUnit.DataSource = dtTema;
                    ddLRencanaUnit.DataValueField = "ID_ROAD_MAP_PENGABDIAN";
                    ddLRencanaUnit.DataTextField = "DESKRIPSI";
                    ddLRencanaUnit.DataBind();
                }

                if (tmpKategori == "Perorangan") {
                    lblJenisPengabdian.Text = "Individu";
                    panelAnggota.Visible = false;
                    panelSksAnggota.Visible = false;
                    //generateIDPerorangan();
                }
                else if (tmpKategori == "Kelompok") {
                    lblJenisPengabdian.Text = "Kelompok";
                    panelAnggota.Visible = true;
                    panelSksAnggota.Visible = true;
                    //generateIDKelompok();
                }
                

            }
        }
        public void generateIDPerorangan()
        {
            string idorder;
            int id = abdi.getCountPerorangan() +1;
            idorder = id.ToString();
            //tmpidproposal = "PgO" + idorder;
        }
        public void generateIDKelompok()
        {
            string idorder;
            int id = abdi.getCountKelompok() + 1; 
            idorder = id.ToString(); ;
            //tmpidproposal = "PgK" + idorder;
        }
        private PropPengab setDataPengab() {
            pengab.Id_proposal = abdi.getMaxCount()+1;
            tmpid = pengab.Id_proposal.ToString();
            pengab.Idkaryawan = lblNPPKetua.Text;
            pengab.Review1 = "kosong";
            pengab.Review2 = "kosong";
            pengab.Jenis = lblJenisPengabdian.Text;
            pengab.Judul = txtJudul.Text;
            pengab.Landasan = txtJudulPenelitian.Text;
            if (tmpKategori == "Kelompok")
            {
                pengab.Anggota1 = txtNama1.Text;
                pengab.Anggota2 = txtNama2.Text;
                pengab.Keahlian1 = txtBidang1.Text;
                pengab.Keahlian2 = txtBidang2.Text;
                pengab.SksAnggota = Convert.ToInt32(txtSksAnggota.Text);
            }
            pengab.Mitra = txtNamaMitra.Text;
            pengab.Keahlianmitra = txtKeahlianMitra.Text;
            pengab.Lokasi = txtLokasi.Text;
            pengab.Output = txtOutput.Text;
            if (CheckBox1.Checked == true)
            {
                pengab.Outcome = CheckBox1.Text + "," + CheckBox7.Text; 
            }
            if (CheckBox2.Checked == true)
            {
                pengab.Outcome += "," + CheckBox2.Text;
            }
            if (CheckBox3.Checked == true)
            {
                pengab.Outcome += "," + CheckBox3.Text;
            }
            if (CheckBox4.Checked == true)
            {
                pengab.Outcome += "," + CheckBox4.Text;
            }
            if (CheckBox5.Checked == true)
            {
                pengab.Outcome += "," + CheckBox5.Text;
            }
            if (CheckBox6.Checked == true)
            {
                pengab.Outcome += "," + txtTrackRecord.Text;
            }
            pengab.Waktu = Convert.ToDateTime(dateMulai.Text);
            if (dateSelesai.Text == "1 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 1;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/"+tmptanggal+"/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));


            }
            else if (dateSelesai.Text == "2 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 2;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            }
            else if (dateSelesai.Text == "3 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 3;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            }
            else if (dateSelesai.Text == "4 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 4;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            }
            else if (dateSelesai.Text == "5 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 5;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            }
            else if (dateSelesai.Text == "6 bulan")
            {
                int tmpdate, tmpyear2, tmpyear1;
                string tmp1;

                tmp1 = String.Format("{0:MM}", Convert.ToDateTime(dateMulai.Text));
                tmpyear1 = Convert.ToInt32(String.Format("{0:yyyy}", Convert.ToDateTime(dateMulai.Text)));
                tmpdate = Convert.ToInt32(tmp1) + 6;
                if (tmpdate > 12)
                {
                    tmpdate = tmpdate - 12;
                    tmpyear2 = Convert.ToInt32(tmpyear1) + 1;
                }
                else
                {
                    tmpyear2 = tmpyear1;
                }
                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", Convert.ToDateTime(dateMulai.Text)));
                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                {
                    if (tmpdate == 2)
                    {
                        tmptanggal = 28;
                    }
                    else if (tmpdate == 4 || tmpdate == 6 || tmpdate == 9 || tmpdate == 11)
                    {
                        tmptanggal = 30;
                    }
                }
                pengab.Durasi = Convert.ToDateTime(String.Format("{0:" + tmpdate + "/" + tmptanggal + "/" + tmpyear2 + "}", Convert.ToDateTime(dateMulai.Text)));

            }
            pengab.Sasaran = txtSasaran.Text;
            pengab.SesuaiUNIT = Convert.ToInt32(ddLRencanaUnit.SelectedValue);
            //pengab.SesuaiTRACK = txtTrackRecord.Text;
            //pengab.SesuaiAGENDA = txtKegiatanPribadi.Text;
            pengab.DanaUajy = Convert.ToInt32(TextBox4.Text);
            pengab.DanaPribadi = Convert.ToInt32(TextBox5.Text);
            pengab.Status = "1";
            //int
            pengab.Id_sumber = 0;
            pengab.Id_schedule = abdi.getIDPeriodeAktif();
            pengab.JarakPTlokasi = Convert.ToInt32(txtJarak.Text);
            pengab.SksKetua = Convert.ToInt32(txtSksKetua.Text);
            
            if (FileUpload1.HasFile)
            {
                Stream fs = default(Stream);
                fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br1 = new BinaryReader(fs);
                byte[] pdfbytes = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                pengab.Dokumen = pdfbytes;
            }
            pengab.Ip_address = HttpContext.Current.Request.UserHostAddress;
            pengab.Userid = tmpusername;
            pengab.Insert_date = DateTime.Now;

            return pengab;
        }
        protected void BtnSimpan_Click(object sender, EventArgs e)
        {
            string input = FileUpload1.FileName;
            Match match = Regex.Match(input, @"PENGABDIAN_\w{2}_\w{5}[.pdf]");
            if (!match.Success)
            {
               // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Nama File Anda Harus Sesuai!');", true);
            }
            else if (abdi.addProposal(setDataPengab()))
            {

                string email = datauser.getEmailProdiByNPPDosen(tmpnpp);
                string judul = prop.getjudulByID(tmpid);
                //string password = alumniMgr.getPassByUser(username);

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress(Email.emailAccount);
                mail.Subject = "[Pemberitahuan] Anda memiliki Permohonan Pengajuan Proposal :" + judul + " Untuk di setujui";

                string Body = @",<br/> Anda memiliki Permohonan proposal dengan judul :"
                    + "<br/>Judul : " + judul
                    + "  <br/>Untuk melakukan konfirmasi terhadap proposal pengabdian ini, silahkan kunjungi halaman SILPPM dan buka pada panel Pengesahan Proposal Pengabdian.<br/> Terimakasih.";
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
                    Response.Redirect("BerhasilPenelitian.aspx");
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
            else
            {
               // MessageBox.Show("", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert",
                                      "alert('Penambahan data gagal!');", true);
            }
        }
    }
}