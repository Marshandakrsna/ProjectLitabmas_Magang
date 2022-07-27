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
