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

namespace SiLPPM_New_Version.Controllers
{
    public class ProfileController : Controller
    {
        dynamic myobj;
        ProfileDAO dao;
        PenelitianDAO penelitianDAO;
   
    

        public ProfileController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
            dao = new ProfileDAO();
        }
        public IActionResult Index()
        {

            var username = User.Claims
                       .Where(c => c.Type == "username")
                           .Select(c => c.Value).SingleOrDefault();

            var data = dao.GetDataUser(username);
            var data2 = dao.GetPangkatByUsername(username);
            var data3 = dao.GetGolonganByUsername(username);
            var data4 = dao.GetFakByUsername(username);
            var data5 = dao.GetJurusanByUsername(username);
        
            var refpropo = dao.GetListPenelitianByUsername(username);
            var refpropo2 = dao.GetListPengabdianByUsername(username);
            myobj.data = data.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;
            myobj.data4 = data4.data;
            myobj.data5 = data5.data;
        
            myobj.refpropo = refpropo.data;
            myobj.refpropo2 = refpropo2.data;
            return View(myobj);
        }
        public IActionResult LihatProposalPenelitian(int id_proposal)
        {
            var username = User.Claims
                    .Where(c => c.Type == "username")
                        .Select(c => c.Value).SingleOrDefault();

            var data = dao.GetFeedbackProdi(id_proposal);
            var feedbackProdi = penelitianDAO.CekSetujuProdi(id_proposal);
            var feedbackDekan= penelitianDAO.CekSetujuDekan(id_proposal);
            var feedbackLPPM = penelitianDAO.CekSetujuLPPM(id_proposal);
            var refpropo = dao.GetListPenelitianByUsername(username);
            var kriteria = penelitianDAO.GetKriteriaPenilaian();
            myobj.data = data.data;
            myobj.kriteria = kriteria.data;
            myobj.feedbackProdi = feedbackProdi.data;
            myobj.feedbackDekan = feedbackDekan.data;
            myobj.feedbackLPPM = feedbackLPPM.data;
            myobj.refpropo = refpropo.data;

            return View(myobj);
        }

        [HttpGet("prodiSetuju/{IS_SETUJU_PRODI}")]

        public IActionResult prodiSetuju(int id_proposal)
        {
            dynamic prodiSetujuCek = new ExpandoObject();
            var cekSetujuProdi = penelitianDAO.CekSetujuProdi(id_proposal);
            return prodiSetujuCek;
        }
        public IActionResult LihatProposalPengabdian()
        {
            return View(myobj);
        }
    }
}
