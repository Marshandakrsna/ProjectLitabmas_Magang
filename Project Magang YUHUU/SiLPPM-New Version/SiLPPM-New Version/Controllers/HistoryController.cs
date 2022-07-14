using Microsoft.AspNetCore.Mvc;

using SiLPPM_New_Version.DAO;
using System.Linq;
using System.Security.Claims;
using System.Dynamic;

namespace SiLPPM_New_Version.Controllers
{

    public class HistoryController : Controller
    {
        PenelitianDAO penelitianDAO;
        dynamic myobj;


        public HistoryController()
        {
            myobj = new ExpandoObject();
            penelitianDAO = new PenelitianDAO();
        }

        public IActionResult AdminDisplayHistory()
        {
            var HistoryPenelitian = penelitianDAO.GetHistoryExec();
            myobj.HistoryPenelitian = HistoryPenelitian.data;
            return View(myobj);
        }
        public IActionResult AdminDisplayHistoryPengabdian()
        {
            var HistoryPengabdian = penelitianDAO.GetHistoryExecPengabdian();
            myobj.HistoryPengabdian = HistoryPengabdian.data;
            return View(myobj);
        }
    }
}
