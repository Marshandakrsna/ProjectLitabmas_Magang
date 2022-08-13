using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SiLPPM_New_Version.DAO;
using System.Dynamic;

namespace SiLPPM_New_Version.Controllers
{
    public class KelolaPenelitianController : Controller
    {
        KelolaPenelitianDAO dao;
        dynamic myobj;
        public KelolaPenelitianController()
        {
            myobj = new ExpandoObject();
            dao= new KelolaPenelitianDAO();
        }
        public IActionResult KelolaReviewer()
        {
            var reviewer = dao.GetRefGetReviewer();
            var data= dao.GetPenelitianSetReviewer();
            myobj.reviewer = reviewer.data;
            myobj.data = data.data;
            return View(myobj);
        }
        public IActionResult IndexReviewerPeneliti()
        {
            var data = dao.GetPenelitianReviewer();
            myobj.data = data.data;
            return View(myobj);
        }
     
        //untuk menampilkan dan menentukan reviewer

        public JsonResult ajaxGetDetailKelolaReviewer(int id_proposal)
        {
            var data = dao.GetPenelitianSetReviewerByID(id_proposal);
            return Json(data);
        }

    
        public IActionResult AdminRevPenelitian(int id_proposal)
        {
            var data = dao.GetPenelitianReviewerByID(id_proposal);
            var kriteria = dao.GetRefKelolaReviewer();
            myobj.data = data.data;
            myobj.kriteria = kriteria.data;
            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult addKelolaReviewer(int id_proposal, string reviewer1, string reviewer2)
        {
            var cek = dao.UpdateSetReviewer(id_proposal, reviewer1, reviewer2);
            if (cek.status == true )
            {
                TempData["succ"] = "Berhasil menambahkan data Reviewer ";

            }
            else
            {
                TempData["err"] = "Gagal menambahkan data Reviewer, " + cek.pesan;
            }
            return RedirectToAction("KelolaReviewer");

        }
    }
}
