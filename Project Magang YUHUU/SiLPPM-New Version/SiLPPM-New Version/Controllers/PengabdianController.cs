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
        ProfileDAO myprofile;
        dynamic myobj;
        public PengabdianController()
        {
            myobj = new ExpandoObject();
            dao= new PengabdianDAO();
            myprofile = new ProfileDAO();
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

        public IActionResult IndexRAB()
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



    }
}
