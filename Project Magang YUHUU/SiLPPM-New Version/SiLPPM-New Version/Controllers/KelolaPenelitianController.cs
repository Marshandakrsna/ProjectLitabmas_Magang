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
        public IActionResult IndexPengelolaan()
        {
            var data= dao.GetPenelitianSetReviewer();
            myobj.data = data.data;
            return View(myobj);
        }
        public IActionResult IndexReviewerPeneliti()
        {
            var data = dao.GetPenelitianReviewer();
            myobj.data = data.data;
            return View(myobj);
        }
    }
}
