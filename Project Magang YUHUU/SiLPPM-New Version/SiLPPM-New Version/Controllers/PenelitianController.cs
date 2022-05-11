using Microsoft.AspNetCore.Mvc;
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
     
            //TAMBAH PENELITI
            var refjenis = penelitianDAO.GetRefSkim();
            var refjenis2= penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenis();
            var refjenis6= penelitianDAO.GetRefTema();
            var refjenis7 = penelitianDAO.GetRefKategori();
       
            //PEMANGGILAN TAMBAH PENELITI
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3= refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refjenis7 = refjenis7.data;
          
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


            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;
            return View(myobj);

        }

        public IActionResult IndexDaftar()
        {
            var data = penelitianDAO.GetListPenelitian();

            myobj.data = data.data;

            return View(myobj);

        }

        public IActionResult AddProsiding(string npp, int id_proposal, string judul, int id_level_seminar, string nama_jurnal, string issn, string doi)
        {
            var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();
            var data = penelitianDAO.GetHistoryProsiding();
            myobj.data = data.data;

            var cek = penelitianDAO.AddPublikasi(npp, id_proposal, judul, id_level_seminar, nama_jurnal, issn, doi,username);
            if (cek.status)
            {
                TempData["suc"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data";
            }
            return View(myobj);
        }

        public IActionResult AddJurnal(string npp, int id_proposal, string judul, int id_level_jurnal, string nama_seminar, string issn, string doi)
        {
            var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();
            var data = penelitianDAO.GetHistoryJurnal();
            myobj.data = data.data;

            var cek = penelitianDAO.AddJurnal(npp, id_proposal, judul, id_level_jurnal, nama_seminar, issn, doi, username);
            if (cek.status)
            {
                TempData["suc"] = "Berhasil menambahkan data";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data";
            }
            return View(myobj);
        }


    }
}
