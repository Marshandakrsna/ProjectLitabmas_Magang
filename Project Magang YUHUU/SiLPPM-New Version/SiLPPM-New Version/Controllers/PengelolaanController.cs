using Microsoft.AspNetCore.Mvc;
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
        public IActionResult IndexPengelolaan()
        {

            var data = dao.GetPengelolaanRole();

            myobj.data = data.data;

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UbahRolePengelolaan(string role,string npp)
        {
            
            var cek = dao.UbahRole(role,npp);
            if (cek.status == true)
            {
                TempData["suc"] = "Berhasil merubah data ";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data Role, " + cek.pesan;
            }
            return RedirectToAction("IndexPengelolaan");
        }

    }
}
