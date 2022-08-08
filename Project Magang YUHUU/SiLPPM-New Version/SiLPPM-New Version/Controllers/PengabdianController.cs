using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Dynamic;
using SiLPPM_New_Version.DAO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SiLPPM_New_Version.Controllers
{
    public class PengabdianController : Controller
    {
        PengabdianDAO dao;
        PenelitianDAO mydao;
        ProfileDAO myprofile;
        dynamic myobj;
        public PengabdianController()
        {
            myobj = new ExpandoObject();
            dao= new PengabdianDAO();
            myprofile = new ProfileDAO();
            mydao = new PenelitianDAO();
        }
        public IActionResult adminListPengabdian()
        {

            var data = dao.GetListPengabdian();

            myobj.data = data.data;

            return View(myobj);
        }

        [HttpGet("PreviewFileProposalPengabdian/{ID_PROPOSAL}")]
        public ActionResult PreviewFilePengabdian(int id_proposal)
        {
            var preview = dao.GetDokumenFilePengabdian(id_proposal);

            byte[] fileContent = preview;
            MemoryStream pdfStream = new MemoryStream();
            pdfStream.Write(fileContent, 0, fileContent.Length);
            pdfStream.Position = 0;

            return File(fileContent, "application/pdf", "Proposal Pengabdian.pdf");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UbahListPengabdian(int ID_TAHUN_ANGGARAN, string REVIEWER1, string REVIEWER2, string JUDUL_KEGIATAN, string LANDASAN_PENELITIAN, string JENIS_PENGABDIAN, string ANGGOTA1,
          string ANGGOTA2, string MITRA, string MITRA_KEAHLIAN, string LOKASI, int JARAK_PT_LOKASI, string OUTPUT, string OUTCOME, int ID_ROAD_MAP, string AWAL, string AKHIR, string SASARAN,
          int SKS_KETUA, int SKS_ANGGOTA, string NPP, float DANA_PRIBADI, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY,
          string INSERT_DATE, string USER_ID, int ID_SKIM, int ID_TEMA_UNIVERSITAS, int NO_SEMESTER, string ID_PROPOSAL)
        {

            var cek = dao.UbahPengabdian(ID_TAHUN_ANGGARAN, REVIEWER1, REVIEWER2, JUDUL_KEGIATAN, LANDASAN_PENELITIAN, JENIS_PENGABDIAN, ANGGOTA1,
             ANGGOTA2, MITRA, MITRA_KEAHLIAN, LOKASI, JARAK_PT_LOKASI, OUTPUT, OUTCOME, ID_ROAD_MAP, AWAL, AKHIR, SASARAN,
              SKS_KETUA, SKS_ANGGOTA, NPP, DANA_PRIBADI, DANA_EKSTERNAL, DANA_KERJASAMA, DANA_UAJY,
              INSERT_DATE, USER_ID, ID_SKIM, ID_TEMA_UNIVERSITAS, NO_SEMESTER, ID_PROPOSAL);

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
            return RedirectToAction("EditListPengabdian", "Pengabdian");
        }
        public IActionResult DekanAddFeedbackPengabdian()
        {
            return View();
        }
        public JsonResult UpdateStatusDekanDisetujui(int id_proposal)
        {
            var cek = dao.UpdateDisetujuiDekan(id_proposal);
            return Json(cek);
        }
        //public JsonResult AddFeedback(int id_proposal)
        //{
        //    var cek = dao.AddFeedback(id_proposal);
        //    return Json(cek);
        //}

        public JsonResult UpdateStatusDekanDitolak(int id_proposal)
        {
            var cek = dao.UpdateDitolakDekan(id_proposal);
            return Json(cek);
        }

        public IActionResult EditListPengabdian(int id_proposal, string npp)
        {
            var username = User.Claims
                   .Where(c => c.Type == "username")
                       .Select(c => c.Value).SingleOrDefault();
            var dataRAB = dao.GetRAB(id_proposal);
            var lihatPropo = myprofile.GetDataPropoByID(id_proposal);
            var historyPengabdian = myprofile.GetHistoryPengabdian(npp);
            var historyPengabdianByID = myprofile.GetHistoryPengabdianByID(id_proposal);
            var refpropo = myprofile.GetListPenelitianByUsername(username);
            var refpropo2 = myprofile.GetListPengabdianByUsername(username);
            //var anggota = dao.GetDataAnggotaPenelitian(id_proposal);
            var dataPengabdian = mydao.GetDataPengabdian(id_proposal);
            var pengabdianID = myprofile.GetDataPropoPengabdianByID(id_proposal);
            var data = myprofile.GetDataUserListPengabdian(npp);
            var data2 = myprofile.GetPangkatByUsername(username);
            var data3 = myprofile.GetGolonganByUsername(username);
            var cekUser = mydao.GetUserByUsername(username);

            var data4 = myprofile.GetFakByUsername(username);
            var data5 = myprofile.GetJurusanByUsername(username);
            var data6 = mydao.GetJabatanAkaByUsername(username);
            var refjenis = mydao.GetRefGolongan();
            var dataAnggota = myprofile.GetAnggota();
            var dataAnggotaNPP = myprofile.GetAnggotaByNPP(npp);
            //TAMBAH PENELITIAN
            var refjenis1 = mydao.GetRefSkim();
            var refjenis2 = mydao.GetRefTahunAka();
            var refjenis3 = mydao.GetRefSemester();
            var refjenis4 = mydao.GetRefOutput();
            var refjenis5 = mydao.GetRefJenis();
            var refjenis6 = mydao.GetRefTema();
            var refjenis7 = mydao.GetRefKategori();
            var refOutcome = mydao.GetOutcome();

            ViewBag.tempPengabdian = dataPengabdian.data;

            //PEMANGGILAN TAMBAH PENELITIAN
            myobj.cekUser = cekUser.data;
            myobj.historyPengabdianByID = historyPengabdianByID.data;
            myobj.historyPengabdian = historyPengabdian.data;
            myobj.refjenis1 = refjenis1.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.dataRAB = dataRAB.data;
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
        public IActionResult HomePengabdian()
        {
            var username = User.Claims
                     .Where(c => c.Type == "username")
                         .Select(c => c.Value).SingleOrDefault();


            var refjenis = mydao.GetRefSkim();
            var refjenis2 = mydao.GetRefTahunAka();
            var refjenis3 = mydao.GetRefSemester();
            var refjenis4 = mydao.GetRefOutput();
            var refjenis5 = mydao.GetRefJenis();
            var refjenis6 = mydao.GetRefTema();
            var refOutcome = mydao.GetOutcome();

            var refjenis7 = mydao.GetRefKategori();

             var refpropo = mydao.GetDataPenelitian(username);
            var cekUser = mydao.GetUserByUsername(username);
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.cekUser = cekUser.data;
            myobj.refOutcome = refOutcome.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refpropo = refpropo.data;
            myobj.refjenis7 = refjenis7.data;
            return View(myobj);
        }
        public IActionResult DekanListReviewPengabdian()
        {
            var pengesahan = dao.GetListPengesahanPengabdian();
            myobj.pengesahan = pengesahan.data;
            return View(myobj);
        }
        public IActionResult DekanApprovalProposalPengabdian(string id_proposal)
        {
            var data = dao.GetApprovalPengabdian(id_proposal);
            var nama = dao.GetNamaDosenByIDProposalPengabdian(id_proposal);
            var topikPenelitian = dao.GetTopikByIDProposalPengabdian(id_proposal);
            myobj.data = data.data;
            myobj.topikPenelitian = topikPenelitian.data;
            myobj.nama = nama.data;

            return View(myobj);
        }
        public IActionResult adminPengabdian()
        {
            var username = User.Claims
                  .Where(c => c.Type == "username")
                      .Select(c => c.Value).SingleOrDefault();


            var refjenis = mydao.GetRefSkim();
            var refjenis2 = mydao.GetRefTahunAka();
            var refjenis3 = mydao.GetRefSemester();
            var refjenis4 = mydao.GetRefOutput();
            var refjenis5 = mydao.GetRefJenis();
            var refjenis6 = mydao.GetRefTema();
            var refjenis7 = mydao.GetRefKategori();
            var refOutcome = mydao.GetOutcome();

            var refpropo = mydao.GetDataPenelitian(username);
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refOutcome = refOutcome.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refpropo = refpropo.data;
            myobj.refjenis7 = refjenis7.data;
            return View(myobj);
        }
        public IActionResult IndexIdentitasPengusul()
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

            

            //PEMANGGILAN IDENTITAS PENELITI
            myobj.data = data.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;
            myobj.data4 = data4.data;
            myobj.data5 = data5.data;

            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addFeedback(int ID_PROPOSAL, string NPP, string FEEDBACK, string TANGGAL, string STATUS)
        {


            var cek = dao.AddFeedback(ID_PROPOSAL, NPP,FEEDBACK, TANGGAL, STATUS);
            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data Feedback";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data Feedback, " + cek.pesan;
            }
            return RedirectToAction("DekanApprovalProposalPengabdian", "Pengabdian");
        }
        public IActionResult IndexRAB(int id_proposal)
        {
            var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();
            var countPengabdian = dao.GetCountPengabdian(username);

            var refpropo = myprofile.GetListPenelitianByUsername(username);
            var refpropo2 = myprofile.GetListPengabdianByUsername(username);
            myobj.countPengabdian = countPengabdian.data;
            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;

            int tempJustifRev1;
            if (countPengabdian.data.JUMLAH == 0 || countPengabdian.data.JUMLAH == null)
            {
                tempJustifRev1 = 0;
            }
            return View(myobj);
        }
        public byte[] _getByteArrayFromDokumenPengabdian(IFormFile DOKUMEN)
        {
            using (var target = new MemoryStream())
            {
                DOKUMEN.CopyTo(target);
                var cek = target.ToArray();
                return cek;
            }
        }

        // INPUT DATA PENELITIAN PADA HOME PENGABDIAN
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPengabdian(int ID_TAHUN_ANGGARAN, string REVIEWER1, string REVIEWER2, string JUDUL_KEGIATAN, string LANDASAN_PENELITIAN, string JENIS_PENGABDIAN, string ANGGOTA1,
             string ANGGOTA2, string MITRA, string MITRA_KEAHLIAN, string LOKASI, int JARAK_PT_LOKASI, string OUTPUT, string OUTCOME, int ID_ROAD_MAP, string AWAL, string AKHIR, string SASARAN,
             int SKS_KETUA, int SKS_ANGGOTA,string NPP,  float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY, float DANA_PRIBADI,
            IFormFile dokumenPengabdian, string INSERT_DATE, string IP_ADDRESS, string USER_ID, int ID_SKIM, int ID_TEMA_UNIVERSITAS, int NO_SEMESTER)
        {
            var propo = dao._getByteArrayFromDokumenPengabdian(dokumenPengabdian);
  


            var cek = dao.AddPengabdian(ID_TAHUN_ANGGARAN, REVIEWER1, REVIEWER2, JUDUL_KEGIATAN, LANDASAN_PENELITIAN, JENIS_PENGABDIAN, ANGGOTA1,
              ANGGOTA2, MITRA, MITRA_KEAHLIAN, LOKASI, JARAK_PT_LOKASI, OUTPUT, OUTCOME, ID_ROAD_MAP, AWAL, AKHIR, SASARAN,
              SKS_KETUA, SKS_ANGGOTA, NPP,  DANA_EKSTERNAL, DANA_KERJASAMA, DANA_UAJY, DANA_PRIBADI,
              propo, INSERT_DATE, IP_ADDRESS, USER_ID, ID_SKIM, ID_TEMA_UNIVERSITAS, NO_SEMESTER);


            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data " + cek.pesan;
            }
            return RedirectToAction("HomePengabdian", "Pengabdian");
        }

        // untuk halaman Tambah pengabdian (ADMIN)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPengabdianAdmin(int ID_TAHUN_ANGGARAN, string REVIEWER1, string REVIEWER2, string JUDUL_KEGIATAN, string LANDASAN_PENELITIAN, string JENIS_PENGABDIAN, string ANGGOTA1,
          string ANGGOTA2, string MITRA, string MITRA_KEAHLIAN, string LOKASI, int JARAK_PT_LOKASI, string OUTPUT, string OUTCOME, int ID_ROAD_MAP, string AWAL, string AKHIR, string SASARAN,
          int SKS_KETUA, int SKS_ANGGOTA, string NPP, float DANA_EKSTERNAL, float DANA_KERJASAMA, float DANA_UAJY, float DANA_PRIBADI,
         IFormFile dokumenPengabdian, string INSERT_DATE, string IP_ADDRESS, string USER_ID, int ID_SKIM, int ID_TEMA_UNIVERSITAS, int NO_SEMESTER)
        {
            var propo = dao._getByteArrayFromDokumenPengabdian(dokumenPengabdian);



            var cek = dao.AddPengabdian(ID_TAHUN_ANGGARAN, REVIEWER1, REVIEWER2, JUDUL_KEGIATAN, LANDASAN_PENELITIAN, JENIS_PENGABDIAN, ANGGOTA1,
              ANGGOTA2, MITRA, MITRA_KEAHLIAN, LOKASI, JARAK_PT_LOKASI, OUTPUT, OUTCOME, ID_ROAD_MAP, AWAL, AKHIR, SASARAN,
              SKS_KETUA, SKS_ANGGOTA, NPP, DANA_EKSTERNAL, DANA_KERJASAMA, DANA_UAJY, DANA_PRIBADI,
              propo, INSERT_DATE, IP_ADDRESS, USER_ID, ID_SKIM, ID_TEMA_UNIVERSITAS, NO_SEMESTER);


            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data " + cek.pesan;
            }
            return RedirectToAction("adminPengabdian", "Pengabdian");
        }

    }
}
