using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using System.Dynamic;
using SiLPPM_New_Version.DAO;
using System.Linq;
using System.Threading.Tasks;

namespace SiLPPM_New_Version.Controllers
{
    public class PengabdianController : Controller
    {
        PengabdianDAO dao;
        PenelitianDAO mydao;
        dynamic myobj;
        public PengabdianController()
        {
            myobj = new ExpandoObject();
            dao= new PengabdianDAO();
            mydao = new PenelitianDAO();
        }
        public IActionResult IndexDaftar()
        {

            var data = dao.GetListPengabdian();

            myobj.data = data.data;

            return View(myobj);
        }
        public IActionResult IndexTambah()
        {

            var refjenis = mydao.GetRefSkim();
            var refjenis2 = mydao.GetRefTahunAka();
            var refjenis3 = mydao.GetRefSemester();
            var refjenis4 = mydao.GetRefOutput();
            var refjenis5 = mydao.GetRefJenis();
            var refjenis6 = mydao.GetRefTema();
            var refjenis7 = mydao.GetRefKategori();
            myobj.refjenis = refjenis.data;
            myobj.refjenis2 = refjenis2.data;
            myobj.refjenis3 = refjenis3.data;
            myobj.refjenis4 = refjenis4.data;
            myobj.refjenis5 = refjenis5.data;
            myobj.refjenis6 = refjenis6.data;
            myobj.refjenis7 = refjenis7.data;
            return View(myobj);
        }
    }
}
