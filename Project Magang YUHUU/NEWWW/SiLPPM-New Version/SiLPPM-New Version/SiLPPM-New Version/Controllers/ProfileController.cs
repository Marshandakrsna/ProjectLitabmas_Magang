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

        public ProfileController()
        {
            myobj = new ExpandoObject();
            dao = new ProfileDAO();
        }
        public IActionResult Index(string username)
        {

            var data = dao.GetDataUser(username);
            myobj.data = data.data;
            return View(myobj);
        }
    }
}
