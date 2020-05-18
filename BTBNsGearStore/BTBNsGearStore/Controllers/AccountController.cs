using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            AccountBusiness accountBusiness = new AccountBusiness();

            List<Account> lstAccount = accountBusiness.LayDanhSachAccount();

            return View(lstAccount);
        }

        public ActionResult Xoa(string Id)
        {
            AccountBusiness accountBusiness = new AccountBusiness();

            bool ketQua = accountBusiness.XoaAccount(Id);

            if(ketQua)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ChiTiet(string Id)
        {
            AccountBusiness accountBusiness = new AccountBusiness();

            Account objAccount = accountBusiness.ChiTietAccountTheoId(Id);

            return View(objAccount);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(Account objAccount)
        {
            if(objAccount!=null)
            {
                AccountBusiness accountBusiness = new AccountBusiness();

                bool ketQua = accountBusiness.ThemMoiAccount(objAccount);

                if (ketQua)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return HttpNotFound();
            }
            return View();
        }

        //Hien thi noi dung can sua
        public ActionResult Sua(string Id)
        {
            AccountBusiness accountBusiness = new AccountBusiness();

            Account objAccount = accountBusiness.ChiTietAccountTheoId(Id);

            return View(objAccount);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua(Account objAccount)
        {
            if(objAccount!=null)
            {
                AccountBusiness accountBusiness = new AccountBusiness();
                bool ketQua = accountBusiness.Sua(objAccount);
                if(ketQua)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return HttpNotFound();
            }

            return View();
        }

        
    }
}