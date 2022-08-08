using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using SiLPPM_New_Version.DAO;
using SiLPPM_New_Version.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.IO;
using Azure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SiLPPM_New_Version.Controllers
{
    public class ProfileController : Controller
    {
        dynamic myobj;
        ProfileDAO dao;
        PenelitianDAO penelitianDAO;
        PengabdianDAO pengabdianDAO;

        public ProfileController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
            pengabdianDAO = new PengabdianDAO();
            dao = new ProfileDAO();
        }
        [HttpGet("PreviewFileProposal/{ID_PROPOSAL}")]
        public ActionResult PreviewFile(int ID_PROPOSAL)
        {
            var preview = penelitianDAO.GetDokumenProposal(ID_PROPOSAL);

            byte[] fileContent = preview;
            MemoryStream pdfStream = new MemoryStream();
            pdfStream.Write(fileContent, 0, fileContent.Length);
            pdfStream.Position = 0;

            return File(fileContent, "application/pdf", "Proposal Penelitian.pdf");
        }
        [HttpGet("PreviewFilePengesahan/{ID_PROPOSAL}")]
        public ActionResult PreviewLembarPengesahan(int ID_PROPOSAL)
        {
            var preview = penelitianDAO.GetDokumenPengesahan(ID_PROPOSAL);

            byte[] fileContent = preview;
            MemoryStream pdfStream = new MemoryStream();
            pdfStream.Write(fileContent, 0, fileContent.Length);
            pdfStream.Position = 0;

            return File(fileContent, "application/pdf", "Lembar Pengesahan.pdf");
        }
      
        public IActionResult Profile(int id_proposal, int tempPenelitianDiterima, int tempPenelitianDiajukan)
        {

            var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();
            var npp = User.Claims
                       .Where(c => c.Type == "npp")
                           .Select(c => c.Value).SingleOrDefault();
            var countDokumen = penelitianDAO.GetCountDokumenPenelitian(id_proposal);
            var data = dao.GetDataUser(username);
            var data2 = dao.GetPangkatByUsername(username);
            var data3 = dao.GetGolonganByUsername(username);
            var data4 = dao.GetFakByUsername(username);
            var data5 = dao.GetJurusanByUsername(username);
            var proposal = dao.GetDataPropo(username);
            var pengabdian = dao.GetDataPropoPengabdian(username);
            var pengabdianID = dao.GetDataPropoPengabdianByID(id_proposal);
            var refpropo = dao.GetListPenelitianByUsername(username);
            var refpropo2 = dao.GetListPengabdianByUsername(username);
            var pengabdianDiterima = dao.GetPengabdianDiterima(username);
            var penelitianDiterima = dao.GetPenelitianDiterima(username);
            var countPenelitianDiterima = dao.GetCountPenelitianDiterima(npp);
            var countPengabdianDiterima = dao.GetCountPengabdianDiterima(npp);
            var countPenelitianDiajukan = dao.GetCountPenelitianDiajukan(npp);
            var countPengabdianDiajukan = dao.GetCountPengabdianDiajukan(npp);
            myobj.countPenelitianDiterima = countPenelitianDiterima.data;
            myobj.countPengabdianDiterima = countPengabdianDiterima.data; 
            myobj.countPenelitianDiajukan = countPenelitianDiajukan.data;
            myobj.countPengabdianDiajukan = countPengabdianDiajukan.data;
            myobj.data = data.data;
            myobj.countDokumen = countDokumen.data;
            myobj.pengabdianID = pengabdianID.data;
            myobj.penelitianDiterima = penelitianDiterima.data;
            myobj.pengabdianDiterima = pengabdianDiterima.data;
            myobj.proposal = proposal.data;
            myobj.pengabdian = pengabdian.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;
            myobj.data4 = data4.data;
            myobj.data5 = data5.data;
            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;
         
            if (countPenelitianDiterima.data.JUMLAH == 0 || countPenelitianDiterima.data.JUMLAH == null)
            {
                tempPenelitianDiterima = 0;
            }
            if (countPenelitianDiajukan.data.JUMLAH == 0 || countPenelitianDiajukan.data.JUMLAH == null)
            {
                tempPenelitianDiajukan = 0;
            }

            return View(myobj);
        }
        public IActionResult LihatProposalPenelitian(int id_proposal)
        {
            var username = User.Claims
                    .Where(c => c.Type == "username")
                        .Select(c => c.Value).SingleOrDefault();
            var lihatReview = dao.GetDataReview(id_proposal);
            var lihatPropo = dao.GetDataPropoByID(id_proposal);
            var data = dao.GetFeedbackProdi(id_proposal);
            var feedbackProdi = penelitianDAO.CekSetujuProdi(id_proposal);
            var feedbackDekan= penelitianDAO.CekSetujuDekan(id_proposal);
            var feedbackLPPM = penelitianDAO.CekSetujuLPPM(id_proposal);
            var refpropo = dao.GetListPenelitianByUsername(username);
            var kriteria = penelitianDAO.GetKriteriaPenilaian();
            var countReviewer1 = dao.GetCountReviewer1(id_proposal);
            var countReviewer2 = dao.GetCountReviewer2(id_proposal);
            var count = dao.GetCountNilaiReview(id_proposal);
            var review = dao.GetDataReviewByID(id_proposal);
            var reviewer1= dao.GetDataNilaiReviewer1(id_proposal);
            var reviewer2 = dao.GetDataNilaiReviewer2(id_proposal);
            myobj.review = review.data;
            myobj.countReviewer2 = countReviewer2.data;
            myobj.countReviewer1 = countReviewer1.data;
            myobj.data = data.data;
            myobj.count = count.data;
            myobj.lihatReview = lihatReview.data;
            myobj.reviewer1 = reviewer1.data;
            myobj.reviewer2 = reviewer2.data;
            myobj.kriteria = kriteria.data;
            myobj.feedbackProdi = feedbackProdi.data;
            myobj.feedbackDekan = feedbackDekan.data;
            myobj.lihatPropo = lihatPropo.data;
            myobj.feedbackLPPM = feedbackLPPM.data;
            myobj.refpropo = refpropo.data;

            // untuk menampilkan justifikasi nilai ke-1 pada Reviewer 1
            int tempJustifRev1;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev1 = 0;
            }
            else
            {
                tempJustifRev1 = Convert.ToInt32(reviewer1.data.N1_JUSTIFIKASI1);
            }
            ViewBag.justifikasi1 = tempJustifRev1;

            // untuk menampilkan justifikasi nilai ke-2 pada Reviewer 1
            int tempJustifRev2;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev2 = 0;
            }
            else
            {
                tempJustifRev2 = Convert.ToInt32(reviewer1.data.N1_JUSTIFIKASI2);
            }
            ViewBag.justifikasi2 = tempJustifRev2;

            // untuk menampilkan justifikasi nilai ke-3  pada Reviewer 1
            int tempJustifRev3;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev3 = 0;
            }
            else
            {
                tempJustifRev3 = Convert.ToInt32(reviewer1.data.N1_JUSTIFIKASI3);
            }
            ViewBag.justifikasi3 = tempJustifRev3;

            // untuk menampilkan justifikasi  nilai ke-4 pada  Reviewer 1
            int tempJustifRev4;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev4 = 0;
            }
            else
            {
                tempJustifRev4 = Convert.ToInt32(reviewer1.data.N1_JUSTIFIKASI4);
            }
            ViewBag.justifikasi4 = tempJustifRev4;

            // untuk menampilkan justifikasi nilai ke-5 pada Reviewer 1
            int tempJustifRev5;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev5 = 0;
            }
            else
            {
                tempJustifRev5 = Convert.ToInt32(reviewer1.data.N1_JUSTIFIKASI5);
            }
            ViewBag.justifikasi5 = tempJustifRev5;

            // untuk menampilkan justifikasi nilai ke-6 pada Reviewer 1
            int tempJustifRev6;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev6 = 0;
            }
            else
            {
                tempJustifRev6 = Convert.ToInt32(reviewer1.data.N1_JUSTIFIKASI6);
            }
            ViewBag.justifikasi6 = tempJustifRev6;


            // untuk menampilkan justifikasi nilai ke-7 pada Reviewer 1
            int tempJustifRev7;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev7 = 0;
            }
            else
            {
                tempJustifRev7 = Convert.ToInt32(reviewer1.data.N1_JUSTIFIKASI7);
            }
            ViewBag.justifikasi7 = tempJustifRev7;
            
            

            // untuk menampilkan justifikasi nilai ke-1 pada Reviewer 2
            int tempJustif1;
            if(countReviewer2.data.JUMLAH == 0 || countReviewer2.data.JUMLAH == null)
            {
                tempJustif1 = 0;
            }
            else
            {
                tempJustif1 = Convert.ToInt32(reviewer2.data.N1_JUSTIFIKASI1);
               
            }
            ViewBag.justifikasi1Rev2 = tempJustif1;

            // untuk menampilkan justifikasi nilai ke-2 pada Reviewer 2
            int tempJustif2;
            if(countReviewer2.data.JUMLAH == 0 || countReviewer2.data.JUMLAH == null)
            {
                tempJustif2 = 0;
            }
            else
            {
                tempJustif2 = Convert.ToInt32(reviewer2.data.N1_JUSTIFIKASI2);
            }
            ViewBag.justifikasi2Rev2 = tempJustif2;

            // untuk menampilkan justifikasi nilai ke-3  pada Reviewer 2
            int tempJustif3;
            if (countReviewer2.data.JUMLAH == 0 || countReviewer2.data.JUMLAH == null)
            {
                tempJustif3 = 0;
            }
            else
            {
                tempJustif3 = Convert.ToInt32(reviewer2.data.N1_JUSTIFIKASI3);
            }
            ViewBag.justifikasi3Rev2 = tempJustif3;

            // untuk menampilkan justifikasi  nilai ke-4 pada  Reviewer 2
            int tempJustif4;
            if (countReviewer2.data.JUMLAH == 0 || countReviewer2.data.JUMLAH == null)
            {
                tempJustif4 = 0;
            }
            else
            {
                tempJustif4 = Convert.ToInt32(reviewer2.data.N1_JUSTIFIKASI4);
            }
            ViewBag.justifikasi4Rev2 = tempJustif4;

            // untuk menampilkan justifikasi nilai ke-5 pada Reviewer 2
            int tempJustif5;
            if (countReviewer2.data.JUMLAH == 0 || countReviewer2.data.JUMLAH == null)
            {
                tempJustif5 = 0;
            }
            else
            {
                tempJustif5 = Convert.ToInt32(reviewer2.data.N1_JUSTIFIKASI5);
            }
            ViewBag.justifikasi5Rev2 = tempJustif5;

            // untuk menampilkan justifikasi nilai ke-6 pada Reviewer 2
            int tempJustif6;
            if (countReviewer2.data.JUMLAH == 0 || countReviewer2.data.JUMLAH == null)
            {
                tempJustif6 = 0;
            }
            else
            {
                tempJustif6 = Convert.ToInt32(reviewer2.data.N1_JUSTIFIKASI6);
            }
            ViewBag.justifikasi6Rev2 = tempJustif6;


            // untuk menampilkan justifikasi nilai ke-7 pada Reviewer 2
            int tempJustif7;
            if (countReviewer2.data.JUMLAH == 0 || countReviewer2.data.JUMLAH == null)
            {
                tempJustif7 = 0;
            }
            else
            {
                tempJustif7 = Convert.ToInt32(reviewer2.data.N1_JUSTIFIKASI7);
            }
           
            ViewBag.justifikasi7Rev2 = tempJustif7;

            return View(myobj);
        }

        [HttpGet("prodiSetuju/{IS_SETUJU_PRODI}")]

        public IActionResult prodiSetuju(int id_proposal)
        {
            dynamic prodiSetujuCek = new ExpandoObject();
            var cekSetujuProdi = penelitianDAO.CekSetujuProdi(id_proposal);
            return prodiSetujuCek;
        }
        public IActionResult LihatProposalPengabdian(int id_proposal)
        {
            var username = User.Claims
                   .Where(c => c.Type == "username")
                       .Select(c => c.Value).SingleOrDefault();

            var feedbackProdi = penelitianDAO.CekSetujuProdiPengabdian(id_proposal);
            var feedbackDekan = penelitianDAO.CekSetujuDekanPengabdian(id_proposal);
            var feedbackLPPM = penelitianDAO.CekSetujuLPPMPengabdian(id_proposal);
            var refpropo = dao.GetListPengabdianByUsername(username);
            var kriteria = penelitianDAO.GetKriteriaPenilaianPengabdian();
            var countReviewer1 = dao.GetCountReviewer1Pengabdian(id_proposal);
            var reviewer1 = dao.GetDataNilaiReviewer1Pengabdian(id_proposal);
            myobj.reviewer1 = reviewer1.data;
            myobj.countReviewer1 = countReviewer1.data;
            myobj.kriteria = kriteria.data;
            myobj.feedbackProdi = feedbackProdi.data;
            myobj.feedbackDekan = feedbackDekan.data;
            myobj.feedbackLPPM = feedbackLPPM.data;
            myobj.refpropo = refpropo.data;


            // untuk menampilkan justifikasi nilai ke-1 pada Reviewer 1
            int tempJustifRev1;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev1 = 0;
            }
            else
            {
                tempJustifRev1 = Convert.ToInt32(reviewer1.data.JUSTIFIKASI1);
            }
            ViewBag.justifikasi1 = tempJustifRev1;

            // untuk menampilkan justifikasi nilai ke-2 pada Reviewer 1
            int tempJustifRev2;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev2 = 0;
            }
            else
            {
                tempJustifRev2 = Convert.ToInt32(reviewer1.data.JUSTIFIKASI2);
            }
            ViewBag.justifikasi2 = tempJustifRev2;

            // untuk menampilkan justifikasi nilai ke-3  pada Reviewer 1
            int tempJustifRev3;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev3 = 0;
            }
            else
            {
                tempJustifRev3 = Convert.ToInt32(reviewer1.data.JUSTIFIKASI3);
            }
            ViewBag.justifikasi3 = tempJustifRev3;

            // untuk menampilkan justifikasi  nilai ke-4 pada  Reviewer 1
            int tempJustifRev4;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev4 = 0;
            }
            else
            {
                tempJustifRev4 = Convert.ToInt32(reviewer1.data.JUSTIFIKASI4);
            }
            ViewBag.justifikasi4 = tempJustifRev4;

            // untuk menampilkan justifikasi nilai ke-5 pada Reviewer 1
            int tempJustifRev5;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev5 = 0;
            }
            else
            {
                tempJustifRev5 = Convert.ToInt32(reviewer1.data.JUSTIFIKASI5);
            }
            ViewBag.justifikasi5 = tempJustifRev5;

            // untuk menampilkan justifikasi nilai ke-6 pada Reviewer 1
            int tempJustifRev6;
            if (countReviewer1.data.JUMLAH == 0 || countReviewer1.data.JUMLAH == null)
            {
                tempJustifRev6 = 0;
            }
            else
            {
                tempJustifRev6 = Convert.ToInt32(reviewer1.data.JUSTIFIKASI6);
            }
            ViewBag.justifikasi6 = tempJustifRev6;

            return View(myobj);
        }
        public IActionResult EditDetailPenelitian(int id_proposal)
        {
            var username = User.Claims
                        .Where(c => c.Type == "username")
                            .Select(c => c.Value).SingleOrDefault();
            var npp = User.Claims
                           .Where(c => c.Type == "npp")
                           .Select(c => c.Value).SingleOrDefault();
            var lihatPropo = dao.GetDataPropoByID(id_proposal);
            var history = dao.GetHistoryPenelitianByNPP(username);
            var refpropo = dao.GetListPenelitianByUsername(username);
            var refpropo2 = dao.GetListPengabdianByUsername(username);
            //var anggota = dao.GetDataAnggotaPenelitian(id_proposal);
            var pengabdianID = dao.GetDataPropoPengabdianByID(id_proposal);
            var data = dao.GetDataUser(username);
            var data2 = dao.GetPangkatByUsername(username);
            var data3 = dao.GetGolonganByUsername(username);
            var cekUser = penelitianDAO.GetUserByUsername(username);
            var data4 = dao.GetFakByUsername(username);
            var data5 = dao.GetJurusanByUsername(username);
            var data6 = penelitianDAO.GetJabatanAkaByUsername(username);
            var refjenis = penelitianDAO.GetRefGolongan();
            var dataAnggota = dao.GetAnggota();
            var dataAnggotaNPP = dao.GetAnggotaByNPP(npp);
            //TAMBAH PENELITIAN
            var refjenis1 = penelitianDAO.GetRefSkim();
            var refjenis2 = penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenis();
            var refjenis6 = penelitianDAO.GetRefTema();
            var refjenis7 = penelitianDAO.GetRefKategori();
            var refOutcome = penelitianDAO.GetOutcome();

            var dataPenelitian = penelitianDAO.GetDataPen(id_proposal);
            ViewBag.tempPenelitian = dataPenelitian.data;
            
            //PEMANGGILAN TAMBAH PENELITIAN
            myobj.cekUser = cekUser.data;
            myobj.history = history.data;
            myobj.refjenis1 = refjenis1.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.pengabdianID = pengabdianID.data;
            myobj.refjenis7 = refjenis7.data;
            myobj.refOutcome = refOutcome.data;
            myobj.lihatPropo = lihatPropo.data;
            myobj.dataPenelitian = dataPenelitian.data;
            myobj.dataAnggotaNPP = dataAnggotaNPP.data;

            //PEMANGGILAN IDENTITAS PENELITI
            //myobj.anggota = anggota.data;
            myobj.data = data.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;
            myobj.data4 = data4.data;
            myobj.data5 = data5.data;
            myobj.data6 = data6.data;
            myobj.refjenis = refjenis.data;
            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;
            myobj.dataAnggota = dataAnggota.data;

        

            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UbahPenelitian(int ID_TAHUN_ANGGARAN, int NO_SEMESTER, int ID_KATEGORI, int ID_ROAD_MAP_PENELITIAN, int ID_SKIM, int ID_TEMA_UNIVERSITAS, string JENIS, string JUDUL, string LOKASI,
          string NPP, string AWAL, string AKHIR, string NPP_REVIEWER, string REVIEWER1, string REVIEWER2, string IS_SETUJU_LPPM, int BEBAN_SKS, float DANA_USUL, float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY, float DANA_SETUJU, string KEYWORD,
           string OUTCOME, string LONGITUDE, string LATITUDE, string INSERT_DATE, string USER_ID, string KETERANGAN_DANA_EKSTERNAL, string ID_PROPOSAL)
        {


            var dana_usul = DANA_UAJY + DANA_PRIBADI + DANA_KERJASAMA + DANA_EKSTERNAL;
            DANA_SETUJU = dana_usul;

            var cek = dao.UbahPenelitian(ID_TAHUN_ANGGARAN, NO_SEMESTER, ID_KATEGORI, ID_ROAD_MAP_PENELITIAN, ID_SKIM, ID_TEMA_UNIVERSITAS, JENIS, JUDUL, LOKASI,
            NPP, AWAL, AKHIR, NPP_REVIEWER, REVIEWER1, REVIEWER2, IS_SETUJU_LPPM, BEBAN_SKS, dana_usul, DANA_PRIBADI, DANA_EKSTERNAL, DANA_KERJASAMA, DANA_UAJY, DANA_SETUJU, KEYWORD,
            OUTCOME, LONGITUDE, LATITUDE, INSERT_DATE, USER_ID, KETERANGAN_DANA_EKSTERNAL, ID_PROPOSAL);

            USER_ID = User.Claims
                          .Where(c => c.Type == "npp")
                          .Select(c => c.Value).SingleOrDefault();
            INSERT_DATE = DateTime.Now.ToString();
            if (cek.status)
            {
                TempData["succ"] = "Berhasil mengubah data";
            }
            else
            {
                TempData["err"] = "Gagal mengubah data" + cek.pesan;
            }
            return RedirectToAction("EditDetailPenelitian", "Profile");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UbahPengabdian(int ID_TAHUN_ANGGARAN, string REVIEWER1, string REVIEWER2, string JUDUL_KEGIATAN, string LANDASAN_PENELITIAN, string JENIS_PENGABDIAN, string ANGGOTA1,
             string ANGGOTA2, string MITRA, string MITRA_KEAHLIAN, string LOKASI, int JARAK_PT_LOKASI, string OUTPUT, string OUTCOME, int ID_ROAD_MAP, string AWAL, string AKHIR, string SASARAN,
             int SKS_KETUA, int SKS_ANGGOTA, string NPP, float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY,
             string INSERT_DATE, string USER_ID, int ID_SKIM, int ID_TEMA_UNIVERSITAS, int NO_SEMESTER, string ID_PROPOSAL)
        {

            var cek = dao.UbahPengabdian( ID_TAHUN_ANGGARAN, REVIEWER1,  REVIEWER2,  JUDUL_KEGIATAN,  LANDASAN_PENELITIAN, JENIS_PENGABDIAN,  ANGGOTA1,
             ANGGOTA2, MITRA,  MITRA_KEAHLIAN,  LOKASI,  JARAK_PT_LOKASI,  OUTPUT, OUTCOME,  ID_ROAD_MAP,  AWAL, AKHIR, SASARAN,
              SKS_KETUA,  SKS_ANGGOTA, NPP,  DANA_PRIBADI,  DANA_EKSTERNAL, DANA_KERJASAMA,  DANA_UAJY,
              INSERT_DATE,  USER_ID,  ID_SKIM, ID_TEMA_UNIVERSITAS,  NO_SEMESTER, ID_PROPOSAL);

            USER_ID = User.Claims
                          .Where(c => c.Type == "npp")
                          .Select(c => c.Value).SingleOrDefault();
            INSERT_DATE = DateTime.Now.ToString();
            if (cek.status)
            {
                TempData["succ"] = "Berhasil mengubah data";
            }
            else
            {
                TempData["err"] = "Gagal mengubah data" + cek.pesan;
            }
            return RedirectToAction("EditDetailPengabdian", "Profile");
        }

        public IActionResult EditDetailPengabdian(int id_proposal)
        {
            var username = User.Claims
                     .Where(c => c.Type == "username")
                         .Select(c => c.Value).SingleOrDefault();
            var npp = User.Claims
                           .Where(c => c.Type == "npp")
                           .Select(c => c.Value).SingleOrDefault();
            var lihatPropo = dao.GetDataPropoByID(id_proposal);
            var history = dao.GetHistoryPenelitianByNPP(username);
            var refpropo = dao.GetListPenelitianByUsername(username);
            var refpropo2 = dao.GetListPengabdianByUsername(username);
            //var anggota = dao.GetDataAnggotaPenelitian(id_proposal);
            var pengabdianID = dao.GetDataPropoPengabdianByID(id_proposal);
            var data = dao.GetDataUser(username);
            var data2 = dao.GetPangkatByUsername(username);
            var data3 = dao.GetGolonganByUsername(username);
            var cekUser = penelitianDAO.GetUserByUsername(username);

            var data4 = dao.GetFakByUsername(username);
            var data5 = dao.GetJurusanByUsername(username);
            var data6 = penelitianDAO.GetJabatanAkaByUsername(username);
            var refjenis = penelitianDAO.GetRefGolongan();
            var dataAnggota = dao.GetAnggota();
            var dataAnggotaNPP = dao.GetAnggotaByNPP(npp);
            //TAMBAH PENELITIAN
            var refjenis1 = penelitianDAO.GetRefSkim();
            var refjenis2 = penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenis();
            var refjenis6 = penelitianDAO.GetRefTema();
            var refjenis7 = penelitianDAO.GetRefKategori();
            var refOutcome = penelitianDAO.GetOutcome();
            var dataPengabdian = penelitianDAO.GetDataPengabdian(id_proposal);

            ViewBag.tempPengabdian = dataPengabdian.data;
            //PEMANGGILAN TAMBAH PENELITIAN
            myobj.cekUser = cekUser.data;
            myobj.history = history.data;
            myobj.refjenis1 = refjenis1.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.pengabdianID = pengabdianID.data;
            myobj.refjenis7 = refjenis7.data;
            myobj.refOutcome = refOutcome.data;
            myobj.lihatPropo = lihatPropo.data;
            myobj.dataPengabdian = dataPengabdian.data;
            myobj.dataAnggotaNPP = dataAnggotaNPP.data;

            //PEMANGGILAN IDENTITAS PENELITI
            //myobj.anggota = anggota.data;
            myobj.data = data.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;
            myobj.data4 = data4.data;
            myobj.data5 = data5.data;
            myobj.data6 = data6.data;
            myobj.refjenis = refjenis.data;
            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;
            myobj.dataAnggota = dataAnggota.data;
            return View(myobj);
        }

        public IActionResult AddProsidingProfile()
        {
            //var username = User.Claims
            //         .Where(c => c.Type == "username")
            //             .Select(c => c.Value).SingleOrDefault();

            var id_proposal = User.Claims
                    .Where(c => c.Type == "id_proposal")
                        .Select(c => c.Value).SingleOrDefault();

            //var data = penelitianDAO.GetHistoryProsiding(id_proposal);
            //var refpropo = dao.GetListPenelitianByUsername(username);
            //var dataLevel = penelitianDAO.GetRefLevelSeminar();

            //myobj.prosiding = data.data;
            //myobj.dataLevel = dataLevel.data;
            //myobj.refpropo = refpropo.data;
            //return View(myobj);
            var username = User.Claims
                     .Where(c => c.Type == "username")
                         .Select(c => c.Value).SingleOrDefault();

            var data = penelitianDAO.GetHistoryProsiding();
            var refpropo = dao.GetListPenelitianByUsername(username);
            var dataLevel = penelitianDAO.GetRefLevelSeminar();
            myobj.data = data.data;
            myobj.dataLevel = dataLevel.data;
            myobj.refpropo = refpropo.data;
            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProsidingProfile(string npp, int id_proposal, string judul, int id_level_seminar, string nama_jurnal, string issn, string doi)
        {


            var cek = penelitianDAO.AddPublikasi(npp, id_proposal, judul, id_level_seminar, nama_jurnal, issn, doi);
            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data, " + cek.pesan;
            }
            return RedirectToAction("AddProsiding", "Penelitian");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAnggotaUAJY( int id_proposal, string npp )
        {


            var cek = dao.AddAnggotaUAJY(id_proposal,npp);
            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data, " + cek.pesan;
            }
            return RedirectToAction("EditDetailPenelitian");
        }

        //INPUT DATA JURNAL PENELITIAN
        public IActionResult AddJurnalProfile()
        {
            //var username = User.Claims
            //        .Where(c => c.Type == "username")
            //            .Select(c => c.Value).SingleOrDefault();

            //var id_proposal = User.Claims
            //       .Where(c => c.Type == "username")
            //           .Select(c => c.Value).SingleOrDefault();

            //var data = penelitianDAO.GetHistoryJurnal(id_proposal);
            //var dataLevel = penelitianDAO.GetRefLevelJurnal();
            //var refpropo2 = dao.GetListPenelitianByUsername(username);
            //myobj.refpropo2 = refpropo2.data;
            //myobj.data = data.data;
            //myobj.dataLevel = dataLevel.data;
            //return View(myobj);
            var username = User.Claims
                    .Where(c => c.Type == "username")
                        .Select(c => c.Value).SingleOrDefault();

            var data = penelitianDAO.GetHistoryJurnal();
            var dataLevel = penelitianDAO.GetRefLevelJurnal();
            var refpropo2 = dao.GetListPenelitianByUsername(username);
            myobj.refpropo2 = refpropo2.data;
            myobj.data = data.data;
            myobj.dataLevel = dataLevel.data;
            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddJurnalProfile(string npp, int id_proposal, string judul, int id_level_jurnal, string nama_seminar, string issn, string doi)
        {

            var cek = penelitianDAO.AddJurnal(npp, id_proposal, judul, id_level_jurnal, nama_seminar, issn, doi);
            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data" + cek.pesan;
            }
            return RedirectToAction("AddJurnal", "Penelitian");
        }

        

        public JsonResult ajaxGetPeserta(int id_proposal)
        {
            var data = dao.GetDataAnggotaPenelitian(id_proposal);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addAnggPenelitianNonUAJY(string npp, string nama_lengkap_gelar, string email, string no_telpon_rumah, string no_telpon_hp,
            string npwp, string nip_pns, string nidn, string alamat_kota, string alamat, string alamat_provinsi, string alamat_kodepos, int id_proposal)
        {


            var cek = dao.AddAnggotaNonUAJY(npp, nama_lengkap_gelar, email,  no_telpon_rumah,  no_telpon_hp,
             npwp,  nip_pns,  nidn,  alamat_kota,  alamat,  alamat_provinsi,alamat_kodepos,  id_proposal);
            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data, " + cek.pesan;
            }
            return RedirectToAction("EditDetailPenelitian");
        }
    }
}
