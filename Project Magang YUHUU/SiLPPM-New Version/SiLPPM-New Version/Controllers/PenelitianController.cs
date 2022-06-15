﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiLPPM_New_Version.DAO;
using System.Dynamic;

namespace SiLPPM_New_Version.Controllers
{
 
    public class PenelitianController : Controller
    {
        PenelitianDAO penelitianDAO;
        ProfileDAO myprofile;
        dynamic myobj;

        public PenelitianController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
            myprofile = new ProfileDAO();
        }
        public IActionResult IndexTambah()
        {
     
            //TAMBAH PENELITIAN
            var refjenis = penelitianDAO.GetRefSkim();
            var refjenis2= penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenis();
            var refjenis6= penelitianDAO.GetRefTema();
            var refjenis7 = penelitianDAO.GetRefKategori();
            var refOutcome = penelitianDAO.GetOutcome();

       
            //PEMANGGILAN TAMBAH PENELITIAN
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3= refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refjenis7 = refjenis7.data;
            myobj.refOutcome= refOutcome.data;
          
            return View(myobj);
           
        }
        public IActionResult IndexTambahCV()
        {
            var username = User.Claims
                        .Where(c => c.Type == "username")
                            .Select(c => c.Value).SingleOrDefault();


            var refpropo = myprofile.GetListPenelitianByUsername(username);
            var refpropo2 = myprofile.GetListPengabdianByUsername(username);
   

            myobj.refpropo = refpropo.data;
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


            var refpropo = myprofile.GetListPenelitianByUsername(username);
            var refpropo2 = myprofile.GetListPengabdianByUsername(username);
            var dataProsiding = penelitianDAO.GetListPenelitian();


            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;
            myobj.dataprosiding = dataProsiding.data;
            return View(myobj);

        }

        public IActionResult IndexDaftar()
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
            var username = User.Claims
                     .Where(c => c.Type == "username")
                         .Select(c => c.Value).SingleOrDefault();

            var data = penelitianDAO.GetHistoryProsiding();
            var refpropo = myprofile.GetListPenelitianByUsername(username);
            var dataLevel = penelitianDAO.GetRefLevelSeminar();
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
            return RedirectToAction("IndexDaftar");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPenelitian(int ID_TAHUN_ANGGARAN, int NO_SEMESTER, int ID_KATEGORI, int ID_ROAD_MAP_PENELITIAN, int ID_SKIM, int ID_TEMA_UNIVERSITAS, int ID_STATUS_PENELITIAN, string JENIS, string JUDUL, string LOKASI,
            string NPP, string AWAL, string AKHIR, string IS_CHECKED, string NPP_REVIEWER, string REVIEWER1, string REVIEWER2, string IS_SETUJU_LPPM, int BEBAN_SKS, int BEBAN_SKS_ANGGOTA, string DOKUMEN, string LEMBAR_PENGESAHAN, string KEYWORD,
            int JARAK_KAMPUS_KM, int JARAK_KAMPUS_JAM, string OUTCOME, string LONGITUDE, string LATITUDE, string INSERT_DATE, string IP_ADDRESS, string USER_ID, string KETERANGAN_DANA_EKSTERNAL)
        {

            var cek = penelitianDAO.AddPenelitian(ID_TAHUN_ANGGARAN,  NO_SEMESTER,  ID_KATEGORI,  ID_ROAD_MAP_PENELITIAN,  ID_SKIM,  ID_TEMA_UNIVERSITAS,  ID_STATUS_PENELITIAN,  JENIS, JUDUL,  LOKASI,
            NPP, AWAL, AKHIR, IS_CHECKED,  NPP_REVIEWER,  REVIEWER1,  REVIEWER2, IS_SETUJU_LPPM,  BEBAN_SKS,  BEBAN_SKS_ANGGOTA,  DOKUMEN, LEMBAR_PENGESAHAN,  KEYWORD,
             JARAK_KAMPUS_KM,  JARAK_KAMPUS_JAM,  OUTCOME,  LONGITUDE,  LATITUDE,  INSERT_DATE,  IP_ADDRESS,  USER_ID, KETERANGAN_DANA_EKSTERNAL);
            if (cek.status)
            {
                TempData["succ"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data" + cek.pesan;
            }
            return RedirectToAction("IndexTambah", "Penelitian");
        }

    }
}
