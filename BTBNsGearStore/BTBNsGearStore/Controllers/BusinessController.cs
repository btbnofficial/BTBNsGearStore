using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class BusinessController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            ViewBag.username = username;
            ViewBag.password = password;
            AccountBusiness accountBusiness = new AccountBusiness();

            bool ketQua = accountBusiness.Login(username, password);

            if (ketQua)
            {
                return RedirectToAction("LoginSuccess");
            }
            else
            {
                return RedirectToAction("LoginFalse");
            }
        }

        public ActionResult LoginFalse()
        {
            return View();
        }

        public ActionResult LoginSuccess()
        {
            return View();
        }
    }
}