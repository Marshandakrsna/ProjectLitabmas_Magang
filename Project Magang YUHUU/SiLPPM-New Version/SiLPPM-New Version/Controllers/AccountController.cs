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
using SiLPPM_New_Version.Models;

namespace SiLPPM_New_Version.Controllers
{

    public class AccountController : Controller
    {
        AccountDAO dao = new AccountDAO();

        public AccountController()
        {
            dao = new AccountDAO();
        }

        public IActionResult Login()
        {
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
        public IActionResult getRole(string username, string password)
        {
            DBOutput data = new DBOutput();

            var ul = dao.GetUser(username);

            if (ul != null)
            {
                if (ul.password == password)
                {
                    data.status = true;
                    data.pesan = "Login berhasil";
                    data.data = dao.getUserRole(ul.NPP);
                }
                else
                {
                    data.status = false;
                    data.pesan = "Password yang anda masukkan salah";
                }
            }
            else
            {
                data.status = false;
                data.pesan = "User tidak ditemukan";
            }

            return Json(data);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult do_login(string username, string password, string Role)
        {
        
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            var role = Role.Split(',');
            var ul = dao.GetUser(username);
            string strrole = "";
            string strnamalengkap = "";

                if (ul != null)
                {
                    if (ul.password == password)
                    {
                        strnamalengkap = ul.nama_lengkap;

                        isAuthenticated = true;
                        identity = new ClaimsIdentity(new[] {
                                        new Claim(ClaimTypes.Name, ul.username),
                                        new Claim(ClaimTypes.Role, role[1]),
                                        new Claim("username", ul.username),
                                        new Claim("IDRole", role[0]),
                                        new Claim("NPP", ul.NPP),
                                        new Claim("nama_lengkap", strnamalengkap),
                                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                        if (role[0] == "3")
                        {
                            identity.AddClaim(new Claim("IDUnit", "0"));
                            identity.AddClaim(new Claim("namaUnit", "-"));
                        }
                        else
                        {
                            identity.AddClaim(new Claim("IDUnit", Convert.ToString(ul.ID_UNIT)));
                            identity.AddClaim(new Claim("namaUnit", Convert.ToString(ul.NAMA_UNIT)));
                        }
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



    }


}