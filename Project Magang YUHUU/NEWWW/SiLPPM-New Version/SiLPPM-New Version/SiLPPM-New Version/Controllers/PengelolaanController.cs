using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SiLPPM_New_Version.DAO;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

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
   
            myobj.data = data.data;
            return View(myobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UbahRolePengelolaan()
        {
            var cek = dao.UbahRole(myobj);
            if (cek.status == true)
            {
                TempData["suc"] = "Berhasil merubah data ";
            }
            else
            {
                TempData["err"] = "Gagal menambahkan data event, " + cek.pesan;
            }
            return RedirectToAction("Index");
        }

    }
}
