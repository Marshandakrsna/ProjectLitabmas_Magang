using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiLPPM_New_Version.DAO;
using System.Security.Claims;
using System.Dynamic;

namespace SiLPPM_New_Version.Controllers
{

    public class ReviewController : Controller
    {
        PenelitianDAO penelitianDAO;
        ProfileDAO profileDAO;
        dynamic myobj;

        public ReviewController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
            profileDAO = new ProfileDAO();
        }

        public IActionResult ListRevPenelitian()
        {
            var username = User.Claims
                     .Where(c => c.Type == "username")
                         .Select(c => c.Value).SingleOrDefault();
            var listReview = penelitianDAO.GetListReviewPenelitian(username);
            myobj.listReview = listReview.data;
            return View(myobj);

        }
        public IActionResult RevPenelitian(int id_proposal)
        {
            var username = User.Claims
                 .Where(c => c.Type == "username")
                     .Select(c => c.Value).SingleOrDefault();
            var listReview = penelitianDAO.GetListReviewPenelitian(username);
            var refpropo = profileDAO.GetListPenelitianByUsername(username);
            var cekUser = penelitianDAO.GetUserByUsername(username);

            var review = penelitianDAO.GetListReviewPenelitianByID(username, id_proposal);
            myobj.listReview = listReview.data;
            myobj.review = review.data;
            myobj.refpropo = refpropo.data;
            myobj.cekUser = cekUser.data;
            return View(myobj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addNilaiReview(string ID_PROPOSAL, string ID_REVIEWER, int COUNT_REVISI, int N1_FIELD1, int N1_FIELD2, int N1_FIELD3, int N1_FIELD4, int N1_FIELD5, int N1_FIELD6, int N1_FIELD7,
      string N1_JUSTIFIKASI1, string N1_JUSTIFIKASI2, string N1_JUSTIFIKASI3, string N1_JUSTIFIKASI4, string N1_JUSTIFIKASI5, string N1_JUSTIFIKASI6, string N1_JUSTIFIKASI7)
        {
            var cek = penelitianDAO.AddNilaiReviewPenelitian(ID_PROPOSAL, ID_REVIEWER, COUNT_REVISI, N1_FIELD1, N1_FIELD2, N1_FIELD3, N1_FIELD4, N1_FIELD5, N1_FIELD6, N1_FIELD7,
               N1_JUSTIFIKASI1, N1_JUSTIFIKASI2, N1_JUSTIFIKASI3, N1_JUSTIFIKASI4, N1_JUSTIFIKASI5, N1_JUSTIFIKASI6, N1_JUSTIFIKASI7);
            if (cek.status == true)
            {
                TempData["succ"] = "Berhasil menambahkan Nilai Review Penelitian";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan Nilai Review Penelitian, " + cek.pesan;
            }
            return RedirectToAction("RevPenelitian");
        }

    }
}
