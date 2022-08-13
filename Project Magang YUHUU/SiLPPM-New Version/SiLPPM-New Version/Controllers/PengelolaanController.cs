﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SiLPPM_New_Version.DAO;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using SiLPPM_New_Version.Models;

namespace SiLPPM_New_Version.Controllers
{
    public class PengelolaanController : Controller
    {
        PengelolaanDAO dao;
        dynamic myobj;
        public PengelolaanController()
        {
            myobj = new ExpandoObject();
            dao = new PengelolaanDAO();
        }
        public IActionResult AdminKelolaUser(string NPP)
        {

            var data = dao.GetPengelolaanRole();
            var dataReview = dao.GetPengelolaanRoleByNPP(NPP);

            myobj.data = data.data;
            myobj.dataReview = dataReview.data;

            return View(myobj);
        }

        public IActionResult UbahRolePengelolaan(string npp)
        {
          
            var data = dao.GetDetailPengelolaan(npp);
            var data3 = dao.GetPengelolaanRole();
            var data2 = dao.GetPengelolaanRole2();
            myobj.data = data.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;

            return View(myobj);
        }
        public IActionResult TambahRolePengelolaan(string npp)
        {

            var data = dao.GetDetailPengelolaan(npp);
            var data3 = dao.GetPengelolaanRole();
            var data2 = dao.GetPengelolaanRole2();
            var reviewer = dao.addReviewer();
            myobj.reviewer = reviewer.data;
            myobj.data = data.data;
            myobj.data2 = data2.data;
            myobj.data3 = data3.data;

            return View(myobj);
        }
        //public JsonResult TambahDataReviewer(string npp)
        //{
        //    var cek = dao.addReviewerRole(npp);
        //    return Json(cek);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UbahRolePengelolaan(string npp, int id_role)
        {
            var cek = dao.UbahRole(npp, id_role);
            if (cek.status == true)
            {
                TempData["succ"] = "Berhasil merubah data ";
            }
            else
            {
                TempData["err"] = "Gagal merubah data Role, " + cek.pesan;
            }
            return RedirectToAction("AdminKelolaUser");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TambahRolePengelolaan(  string npp, int id_role)
        {
            var cek = dao.addReviewerRole( npp, id_role);
            if (cek.status == true)
            {
                TempData["succ"] = "Berhasil menambahkan data ";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data Role, " + cek.pesan;
            }
            return RedirectToAction("AdminKelolaUser");
        }

    }
}
