using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using SiLPPM_New_Version.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;

namespace SiLPPM_New_Version.Controllers
{

    public class AccountController : Controller
    {
        AccountDAO dao = new AccountDAO();

        //public IActionResult IndexLihat()
        //{
          
        //        var username = User.Claims
        //            .Where(c => c.Type == "username")
        //                .Select(c => c.Value).SingleOrDefault();

        //    var data = dao.GetDataUser(username);

        //    return View(data);
        //}

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [Authorize]
        public JsonResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["err_message"] = "Berhasil Logout! Silahkan Login Ulang";
            return Json("success");

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult do_login(string username, string password)
        {
            TempData["username"] = username;
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            string strrole = "";
            string strnamalengkap = "";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData["err_message"] = "Gagal Login! Kolom username dan password tidak boleh kosong.";
            }
            else
            {
                var ul = dao.GetUser(username);

                if (ul != null)
                {
                    if (ul.password == password)
                    {
                        strrole = ul.role;
                        strnamalengkap = ul.nama_lengkap;
                     
                        isAuthenticated = true;
                        identity = new ClaimsIdentity(new[] {
                                    new Claim(ClaimTypes.Name, ul.username),
                                    new Claim(ClaimTypes.Role, strrole),
                                    new Claim("username", ul.username),
                                    new Claim("role", strrole),
                                    new Claim("nama_lengkap", strnamalengkap),
                                }, CookieAuthenticationDefaults.AuthenticationScheme);
                    }
                    else
                    {
                        // password tidak sesuai
                        TempData["err_message"] = "Gagal Login! Password anda salah.";
                    }
                }
                else
                {
                    // data dosen tidak ditemukan
                    TempData["err_message"] = "Gagal Login! Data tidak ditemukan.";
                }
            }

            if (isAuthenticated)
            {
                // berhasil login
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                TempData["err_message"] = "Login berhasil, selamat datang di Si LPPM";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // gagal login
                return RedirectToAction("Login");
            }
        }
        //[HttpGet("GetPangkatByUsername/{uname}")] //Buat Nampilin Pangkat
        //public JsonResult GetPangkat(string uname)
        //{
        //    dynamic getPangkatByUsername = dao.GetPangkatByUsername(uname);
        //    return Json(getPangkatByUsername);
            
        //}


    }


}