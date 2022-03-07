using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using silppm_v1e2.Entity;
using System.Globalization;
using System.Threading;

namespace silppm_v1e2
{
    public partial class WebForm76 : System.Web.UI.Page
    {
        private DataSet dataset = new DataSet();
        private DateTime awal, akhir, toLabel, toLabel2, fin, log1, log2, log3, log4, log5, log6;
        //private DataTable dt = new DataTable();
        private ProposalPengabdianDAO prop = new ProposalPengabdianDAO();
        private string tmpid, tmp1;
        private int tmpmonth, dateakhir, tglakhir, bulanakhir, logYear1, logYear2, logMonthAwal, logMonthAkhir, logDayAwal, tmpSelisihmonth, maxInit, tmpyear, tmptanggal;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userdata"] != null)
            {
                InitializeCulture();
                tmpid = Request.QueryString["id"];
                UserEntity ue = Session["userdata"] as UserEntity;
                awal = prop.getAwalProposal(tmpid);
                akhir = prop.getAkhirProposal(tmpid);
                

                //logbook
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
                            tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                            if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                            {
                                if ((logMonthAwal + i) == 2)
                                {
                                    tmptanggal = 28;
                                }
                                else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                {
                                    tmptanggal = 30;
                                }
                            }
                            DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log1);
                            lblLog1.Text = log1.ToString().Substring(0, 11);
                        }
                        if (i == 2)
                        {
                            tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                            if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                            {
                                if ((logMonthAwal + i) == 2)
                                {
                                    tmptanggal = 28;
                                }
                                else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                {
                                    tmptanggal = 30;
                                }
                            }
                            DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log2);
                            lblLog2.Text = log2.ToString().Substring(0, 11);
                        }
                        if (i == 3)
                        {
                            tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                            if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                            {
                                if ((logMonthAwal + i) == 2)
                                {
                                    tmptanggal = 28;
                                }
                                else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                {
                                    tmptanggal = 30;
                                }
                            }
                            DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log3);
                            lblLog3.Text = log3.ToString().Substring(0, 11);
                        }
                        if (i == 4)
                        {
                            tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                            if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                            {
                                if ((logMonthAwal + i) == 2)
                                {
                                    tmptanggal = 28;
                                }
                                else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                {
                                    tmptanggal = 30;
                                }
                            }
                            DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log4);
                            lblLog4.Text = log4.ToString().Substring(0, 11);
                        }
                        if (i == 5)
                        {
                            tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                            if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                            {
                                if ((logMonthAwal + i) == 2)
                                {
                                    tmptanggal = 28;
                                }
                                else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                {
                                    tmptanggal = 30;
                                }
                            }
                            DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log5);
                            lblLog5.Text = log5.ToString().Substring(0, 11);
                        }
                        if (i == 6)
                        {
                            tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                            if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                            {
                                if ((logMonthAwal + i) == 2)
                                {
                                    tmptanggal = 28;
                                }
                                else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                {
                                    tmptanggal = 30;
                                }
                            }
                            DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log6);
                            lblLog6.Text = log6.ToString().Substring(0, 11);
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
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((logMonthAwal + i) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log1);
                                lblLog1.Text = log1.ToString().Substring(0, 11);
                            }
                            if (i == 2)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((logMonthAwal + i) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log2);
                                lblLog2.Text = log2.ToString().Substring(0, 11);
                            }
                            if (i == 3)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((logMonthAwal + i) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log3);
                                lblLog3.Text = log3.ToString().Substring(0, 11);
                            }
                            if (i == 4)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((logMonthAwal + i) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log4);
                                lblLog4.Text = log4.ToString().Substring(0, 11);
                            }
                            if (i == 5)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((logMonthAwal + i) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log5);
                                lblLog5.Text = log5.ToString().Substring(0, 11);
                            }
                            if (i == 6)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((logMonthAwal + i) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((logMonthAwal + i) == 4 || (logMonthAwal + i) == 6 || (logMonthAwal + i) == 9 || (logMonthAwal + i) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (logMonthAwal + i) + "/yyyy}", awal), out log6);
                                lblLog6.Text = log6.ToString().Substring(0, 11);
                            }
                            maxInit = i;
                        }
                        if (logMonthAwal + i > 12)
                        {
                            if (i == 1)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((i - maxInit) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log1);
                                lblLog1.Text = log1.ToString().Substring(0, 11);
                            }
                            if (i == 2)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((i - maxInit) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log2);
                                lblLog2.Text = log2.ToString().Substring(0, 11);
                            }
                            if (i == 3)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((i - maxInit) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log3);
                                lblLog3.Text = log3.ToString().Substring(0, 11);
                            }
                            if (i == 4)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((i - maxInit) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log4);
                                lblLog4.Text = log4.ToString().Substring(0, 11);
                            }
                            if (i == 5)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((i - maxInit) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log5);
                                lblLog5.Text = log5.ToString().Substring(0, 11);
                            }
                            if (i == 6)
                            {
                                tmptanggal = Convert.ToInt32(String.Format("{0:dd}", awal));
                                if (tmptanggal == 31 || tmptanggal == 30 || tmptanggal == 29)
                                {
                                    if ((i - maxInit) == 2)
                                    {
                                        tmptanggal = 28;
                                    }
                                    else if ((i - maxInit) == 4 || (i - maxInit) == 6 || (i - maxInit) == 9 || (i - maxInit) == 11)
                                    {
                                        tmptanggal = 30;
                                    }
                                }
                                DateTime.TryParse(String.Format("{0:" + tmptanggal + "/" + (i - maxInit) + "/yyyy}", akhir), out log6);
                                lblLog6.Text = log6.ToString().Substring(0, 11);
                            }
                        }

                    }


                }
                //labelpertama

                tmp1 = String.Format("{0:MM}", akhir);
                //string akh1 = akhir.ToString();
                tmpmonth = Convert.ToInt32(tmp1) - 1;
                int.TryParse(String.Format("{0:yyyy}", akhir), out tmpyear);
                if (tmpmonth == 0)
                {
                    tmpmonth = 12;
                    tmpyear = tmpyear - 1;
                }
                toLabel = Convert.ToDateTime(String.Format("{0:dd/" + tmpmonth + "/" + tmpyear + "}", akhir));
                //toLabel = Convert.ToDateTime(String.Format("{0:dd/" + tmpmonth + "/yyyy}", akhir));
                lblLaporanPertama.Text = toLabel.ToString().Substring(0, 11);
                //labelkedua
                generateJadwalPerpanjangan();
                //labelketiga
                DateTime.TryParse(String.Format("{0:dd/MM/yyyy}", akhir), out fin);
                lblLaporanFinal.Text = fin.ToString().Substring(0, 11);

                //labelkeempat
                lblPerpus.Text = toLabel.ToString().Substring(0, 11);
            }
            else
            {
                Response.Redirect("LoginExpired.aspx");
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
        private void generateJadwalPerpanjangan()
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
            lblPerpanjangan.Text = toLabel2.ToString().Substring(0, 11);

        }

    }
}