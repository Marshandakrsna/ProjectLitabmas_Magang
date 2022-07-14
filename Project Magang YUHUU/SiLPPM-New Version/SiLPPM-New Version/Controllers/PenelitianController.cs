using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiLPPM_New_Version.DAO;
using System.Security.Claims;
using System.Dynamic;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SiLPPM_New_Version.Controllers
{
 
    public class PenelitianController : Controller
    {
        PenelitianDAO penelitianDAO;
        KelolaPenelitianDAO kelolaDAO;
        ProfileDAO myprofile;
        AccountDAO accountDAO;
        dynamic myobj;

        public PenelitianController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
            kelolaDAO = new KelolaPenelitianDAO();
            accountDAO = new AccountDAO();
            myprofile = new ProfileDAO();
        }
       
        public IActionResult HomePenelitian()
        {

            //TAMBAH PENELITIAN
            var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();
            var cekUser = penelitianDAO.GetUserByUsername(username);

            var refpropo = penelitianDAO.GetDataPenelitian(username);
            var refjenis = penelitianDAO.GetRefSkim();
            var refjenis2= penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenis();
            var refjenis6= penelitianDAO.GetRefTema();
            var refjenis7 = penelitianDAO.GetRefKategori();
            var refOutcome = penelitianDAO.GetOutcome();


            //PEMANGGILAN TAMBAH PENELITIAN
            myobj.cekUser = cekUser.data;
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3= refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refjenis7 = refjenis7.data;
            myobj.refOutcome= refOutcome.data;
            myobj.refpropo = refpropo.data;
            return View(myobj);
           
        }
 
        public IActionResult adminPenelitian()
        {
            //TAMBAH PENELITIAN
            var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();


            var refpropo = penelitianDAO.GetDataPenelitian(username);
            var refjenis = penelitianDAO.GetRefSkim();
            var refjenis2 = penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenis();
            var refjenis6 = penelitianDAO.GetRefTema();
            var refjenis7 = penelitianDAO.GetRefKategori();
            var refOutcome = penelitianDAO.GetOutcome();


            //PEMANGGILAN TAMBAH PENELITIAN
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refjenis7 = refjenis7.data;
            myobj.refOutcome = refOutcome.data;
            myobj.refpropo = refpropo.data;
            return View(myobj);
        }

        public IActionResult IndexTambahCV()
        {
            var username = User.Claims
                        .Where(c => c.Type == "username")
                            .Select(c => c.Value).SingleOrDefault();

            var history = myprofile.GetHistoryPenelitianByNPP(username);
            var data = myprofile.GetListPenelitianByUsername(username);
            var refpropo2 = myprofile.GetListPengabdianByUsername(username);
            myobj.status = (!data.status) ? data.pesan : "";
            myobj.history = history.data;
            myobj.refpropo = data.data;
            myobj.refpropo2 = refpropo2.data;
            return View(myobj);

        }

        public IActionResult IndexTambahPeneliti()
        {
            var username = User.Claims
             .Where(c => c.Type == "username")
                 .Select(c => c.Value).SingleOrDefault();

            // IDENTITAS PENELITI
            var data = myprofile.GetDataUser(username);
            var data2 = myprofile.GetPangkatByUsername(username);
            var data3 = myprofile.GetGolonganByUsername(username);
            var data4 = myprofile.GetFakByUsername(username);
            var data5 = myprofile.GetJurusanByUsername(username);
            var data6 = penelitianDAO.GetJabatanAkaByUsername(username);

            var refjenis = penelitianDAO.GetRefGolongan();

            //PEMANGGILAN IDENTITAS PENELITI
            myobj.data = data.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;
            myobj.data4 = data4.data;
            myobj.data5 = data5.data;
            myobj.data6 = data6.data;
            myobj.refjenis = refjenis.data;

            return View(myobj);

        }
        public IActionResult IndexTambahPublikasi()
        {
            var username = User.Claims
                        .Where(c => c.Type == "username")
                            .Select(c => c.Value).SingleOrDefault();

            var history = myprofile.GetHistoryPenelitianByNPP(username);
            var refpropo = myprofile.GetListPenelitianByUsername(username);
            var refpropo2 = myprofile.GetListPengabdianByUsername(username);
            var dataProsiding = penelitianDAO.GetListPenelitian();

            myobj.history = history.data;
            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;
            myobj.dataprosiding = dataProsiding.data;
            return View(myobj);

        }

        public IActionResult adminListPenelitian()
        {
            var data = penelitianDAO.GetPenelitianSetReviewer();
            var reviewer = penelitianDAO.GetRefGetReviewer();
            myobj.reviewer = reviewer.data;
            myobj.data = data.data;

            return View(myobj);

        }

        //INPUT DATA PROSIDING
        public IActionResult AddProsiding()
        {
            //var username = User.Claims
            //         .Where(c => c.Type == "username")
            //             .Select(c => c.Value).SingleOrDefault();
            //var id_proposal = User.Claims
            //         .Where(c => c.Type == "username")
            //             .Select(c => c.Value).SingleOrDefault();


            //var data = penelitianDAO.GetHistoryProsiding(id_proposal);

            //var refpropo = myprofile.GetListPenelitianByUsername(username);
            //var dataLevel = penelitianDAO.GetRefLevelSeminar();
            //myobj.prosiding= data.data;
            //myobj.dataLevel = dataLevel.data;
            //myobj.refpropo = refpropo.data;
            //return View(myobj);
           var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();
            //var id_proposal = User.Claims
            //         .Where(c => c.Type == "id_proposal")
            //             .Select(c => c.Value).ToString();
            var data = penelitianDAO.GetHistoryProsiding();
            var refpropo = myprofile.GetListPenelitianByUsername(username);
            var dataLevel = penelitianDAO.GetRefLevelSeminar();
            myobj.status = (!data.status) ? data.pesan : "";
            myobj.data = data.data;
            myobj.dataLevel = dataLevel.data;
            myobj.refpropo = refpropo.data;
            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProsiding(string npp, int id_proposal, string judul, int id_level_seminar, string nama_jurnal, string issn, string doi)
        {
           

            var cek = penelitianDAO.AddPublikasi(npp, id_proposal, judul, id_level_seminar, nama_jurnal, issn, doi);
            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data, " +cek.pesan; 
            }
            return RedirectToAction("AddProsiding", "Penelitian");
        }

        //INPUT DATA JURNAL PENELITIAN
        public IActionResult AddJurnal()
        {
            var username = User.Claims
                     .Where(c => c.Type == "username")
                         .Select(c => c.Value).SingleOrDefault();

            var data = penelitianDAO.GetHistoryJurnal();
            var dataLevel = penelitianDAO.GetRefLevelJurnal();
            var refpropo2 = myprofile.GetListPenelitianByUsername(username);
            myobj.refpropo2 = refpropo2.data;
            myobj.data = data.data;
            myobj.dataLevel = dataLevel.data;
            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddJurnal(string npp, int id_proposal, string judul, int id_level_jurnal, string nama_seminar, string issn, string doi)
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


       
        public JsonResult ConfirmDeleteProsiding(int id_outcome_prosiding)
        {
            var cek = penelitianDAO.DeleteProsiding(id_outcome_prosiding);
            return Json(cek);
        }
        public JsonResult ConfirmDeleteJurnal(int id_outcome_publikasi)
        {
            var cek = penelitianDAO.DeleteJurnal(id_outcome_publikasi);
            return Json(cek);
        }

        //Set Reviewer Daftar Penelitian
        public JsonResult ajaxGetReviewer(int id_proposal)
        {
            var data = penelitianDAO.GetPenelitianSetReviewerByID(id_proposal);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult addSetReviewer(int id_proposal, string reviewer1, string reviewer2)
        {
            var cek = penelitianDAO.UpdateSetReviewer(id_proposal, reviewer1, reviewer2);
            if (cek.status == true)
            {
                TempData["succ"] = "Berhasil menambahkan data Reviewer ";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data Reviewer, " + cek.pesan;
            }
            return RedirectToAction("adminListPenelitian");
        }

        public byte[] _getByteArrayFromImage(IFormFile LEMBAR_PENGESAHAN)
        {
            using (var target = new MemoryStream())
            {
                LEMBAR_PENGESAHAN.CopyTo(target);
                var dt = target.ToArray();
                return dt;
            }
        }
        public byte[] _getByteArrayFromImage2(IFormFile DOKUMEN)
        {
            using (var target = new MemoryStream())
            {
                DOKUMEN.CopyTo(target);
                var dt = target.ToArray();
                return dt;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPenelitian(int ID_TAHUN_ANGGARAN, int NO_SEMESTER, int ID_KATEGORI, int ID_ROAD_MAP_PENELITIAN, int ID_SKIM, 
            int ID_TEMA_UNIVERSITAS, string JENIS, string JUDUL, string LOKASI,
            string NPP, string AWAL, string AKHIR, string NPP_REVIEWER, string REVIEWER1, string REVIEWER2, string IS_SETUJU_LPPM, int BEBAN_SKS, int BEBAN_SKS_ANGGOTA,
            float DANA_USUL, float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY, float DANA_SETUJU,
            IFormFile dokumenProposal, IFormFile dokumenPengesahan, string KEYWORD,string JARAK_KAMPUS_KM, string JARAK_KAMPUS_JAM,
             string OUTCOME, string LONGITUDE, string LATITUDE, string INSERT_DATE, string IP_ADDRESS,  string USER_ID, string KETERANGAN_DANA_EKSTERNAL)
        {
            var proposal = penelitianDAO._getByteArrayFromDokumen(dokumenProposal);
            var pengesahan = penelitianDAO._getByteArrayFromPengesahan(dokumenPengesahan);
            var dana_usul = DANA_UAJY + DANA_PRIBADI + DANA_KERJASAMA + DANA_EKSTERNAL;
            DANA_SETUJU = dana_usul;

            var cek = penelitianDAO.AddPenelitian(ID_TAHUN_ANGGARAN, NO_SEMESTER, ID_KATEGORI, ID_ROAD_MAP_PENELITIAN, ID_SKIM, ID_TEMA_UNIVERSITAS,
                 JENIS, JUDUL, LOKASI, NPP, AWAL, AKHIR, NPP_REVIEWER, REVIEWER1, REVIEWER2, IS_SETUJU_LPPM, BEBAN_SKS, BEBAN_SKS_ANGGOTA, dana_usul, DANA_PRIBADI, DANA_EKSTERNAL, DANA_KERJASAMA, DANA_UAJY, DANA_SETUJU,
                proposal, pengesahan, KEYWORD, JARAK_KAMPUS_KM, JARAK_KAMPUS_JAM, OUTCOME, LONGITUDE, LATITUDE, INSERT_DATE, IP_ADDRESS, USER_ID, KETERANGAN_DANA_EKSTERNAL);


            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data " + cek.pesan;
            }
            return RedirectToAction("HomePenelitian", "Penelitian");
        }
        
        //untuk add data penelitian(admin)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPenelitianAdmin(int ID_TAHUN_ANGGARAN, int NO_SEMESTER, int ID_KATEGORI, int ID_ROAD_MAP_PENELITIAN, int ID_SKIM,
         int ID_TEMA_UNIVERSITAS, string JENIS, string JUDUL, string LOKASI,
         string NPP, string AWAL, string AKHIR, string NPP_REVIEWER, string REVIEWER1, string REVIEWER2, string IS_SETUJU_LPPM, int BEBAN_SKS, int BEBAN_SKS_ANGGOTA,
         float DANA_USUL, float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY, float DANA_SETUJU,
         IFormFile dokumenProposal, IFormFile dokumenPengesahan, string KEYWORD, string JARAK_KAMPUS_KM, string JARAK_KAMPUS_JAM,
          string OUTCOME, string LONGITUDE, string LATITUDE, string INSERT_DATE, string IP_ADDRESS, string USER_ID, string KETERANGAN_DANA_EKSTERNAL)
        {
            var proposal = penelitianDAO._getByteArrayFromDokumen(dokumenProposal);
            var pengesahan = penelitianDAO._getByteArrayFromPengesahan(dokumenPengesahan);
            var dana_usul = DANA_UAJY + DANA_PRIBADI + DANA_KERJASAMA + DANA_EKSTERNAL;
            DANA_SETUJU = dana_usul;

            var cek = penelitianDAO.AddPenelitian(ID_TAHUN_ANGGARAN, NO_SEMESTER, ID_KATEGORI, ID_ROAD_MAP_PENELITIAN, ID_SKIM, ID_TEMA_UNIVERSITAS,
                 JENIS, JUDUL, LOKASI, NPP, AWAL, AKHIR, NPP_REVIEWER, REVIEWER1, REVIEWER2, IS_SETUJU_LPPM, BEBAN_SKS, BEBAN_SKS_ANGGOTA, dana_usul, DANA_PRIBADI, DANA_EKSTERNAL, DANA_KERJASAMA, DANA_UAJY, DANA_SETUJU,
                proposal, pengesahan, KEYWORD, JARAK_KAMPUS_KM, JARAK_KAMPUS_JAM, OUTCOME, LONGITUDE, LATITUDE, INSERT_DATE, IP_ADDRESS, USER_ID, KETERANGAN_DANA_EKSTERNAL);


            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data " + cek.pesan;
            }
            return RedirectToAction("adminPenelitian", "Penelitian");
        }

        public IActionResult KelolaReviewer()
        {
            var reviewer = kelolaDAO.GetRefGetReviewer();
            var data = kelolaDAO.GetPenelitianSetReviewer();
            myobj.reviewer = reviewer.data;
            myobj.data = data.data;
            return View(myobj);
        }
        public IActionResult IndexReviewerPeneliti()
        {
            var data = kelolaDAO.GetPenelitianReviewer();
            myobj.data = data.data;
            return View(myobj);
        }

        //untuk menampilkan dan menentukan reviewer

        public JsonResult ajaxGetDetailKelolaReviewer(int id_proposal)
        {
            var data = kelolaDAO.GetPenelitianSetReviewerByID(id_proposal);
            return Json(data);
        }
        public IActionResult AdminRevPenelitian(int id_proposal)
        {
            var data = kelolaDAO.GetPenelitianReviewerByID(id_proposal);
            var kriteria = kelolaDAO.GetRefKelolaReviewer();
            myobj.data = data.data;
            myobj.kriteria = kriteria.data;
            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addKelolaReviewer(int id_proposal, string reviewer1, string reviewer2)
        {
            var cek = kelolaDAO.UpdateSetReviewer(id_proposal, reviewer1, reviewer2);
            if (cek.status == true)
            {
                TempData["succ"] = "Berhasil menambahkan data Reviewer ";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data Reviewer, " + cek.pesan;
            }
            return RedirectToAction("KelolaReviewer");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addNilaiReview(string ID_PROPOSAL, string ID_REVIEWER, int COUNT_REVISI, int N1_FIELD1, int N1_FIELD2, int N1_FIELD3, int N1_FIELD4, int N1_FIELD5, int N1_FIELD6, int N1_FIELD7,
              string N1_JUSTIFIKASI1, string N1_JUSTIFIKASI2, string N1_JUSTIFIKASI3, string N1_JUSTIFIKASI4, string N1_JUSTIFIKASI5, string N1_JUSTIFIKASI6, string N1_JUSTIFIKASI7)
        {
            var cek = penelitianDAO.AddNilaiReviewPenelitian(ID_PROPOSAL, ID_REVIEWER,  COUNT_REVISI,  N1_FIELD1,  N1_FIELD2, N1_FIELD3,  N1_FIELD4, N1_FIELD5,  N1_FIELD6, N1_FIELD7,
               N1_JUSTIFIKASI1, N1_JUSTIFIKASI2,  N1_JUSTIFIKASI3,  N1_JUSTIFIKASI4,  N1_JUSTIFIKASI5,  N1_JUSTIFIKASI6,  N1_JUSTIFIKASI7);
            if (cek.status == true)
            {
                TempData["succ"] = "Berhasil menambahkan Nilai Review Penelitian";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan Nilai Review Penelitian, " + cek.pesan;
            }
            return RedirectToAction("RevPenelitian","Review");
        }
    }
}
