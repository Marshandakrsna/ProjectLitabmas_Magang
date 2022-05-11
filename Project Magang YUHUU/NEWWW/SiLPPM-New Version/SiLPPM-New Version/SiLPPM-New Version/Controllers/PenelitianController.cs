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
        dynamic myobj;
        public PenelitianController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
        }
        public IActionResult IndexTambah()
        {
            var refjenis = penelitianDAO.GetRefSkim();
            var refjenis2= penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenisPenelitian();
            var refjenis6= penelitianDAO.GetRefTemaPenelitian();
            var refjenis7 = penelitianDAO.GetRefKategoriPenelitian();
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
            var refjenis = penelitianDAO.GetRefSkim();
            var refjenis2 = penelitianDAO.GetRefTahunAka();
            var refjenis3 = penelitianDAO.GetRefSemester();
            var refjenis4 = penelitianDAO.GetRefOutput();
            var refjenis5 = penelitianDAO.GetRefJenisPenelitian();
            var refjenis6 = penelitianDAO.GetRefTemaPenelitian();
            var refjenis7 = penelitianDAO.GetRefKategoriPenelitian();
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refjenis7 = refjenis7.data;
            return View(myobj);

        }

        public IActionResult IndexTambahPeneliti()
        {
            var refjenis = penelitianDAO.GetRefGolongan();

            myobj.refjenis = refjenis.data;

            return View(myobj);

        }


        public IActionResult IndexDaftar()
        {
            var data = penelitianDAO.GetListPenelitian();

            myobj.data = data.data;

            return View(myobj);

        }


    }
}
