using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult Index()
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            List<Brand> lstbrand = brandBusiness.LayDanhSachBrand();
            return View(lstbrand);
        }



        public ActionResult Xoa(string Id)
        {
            BrandBusiness brandBusiness = new BrandBusiness();

            bool ketQua = brandBusiness.XoaBrand(Id);

            if(ketQua)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ThemMoiBrand()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoiBrand(Brand objBrand, HttpPostedFileBase fUpload)
        {
            if(objBrand!= null)
            {
                string fileName = "";
                if (fUpload != null && fUpload.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload.FileName);

                    fUpload.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objBrand.Image = fileName;
                }

                //xu ly
                BrandBusiness brandBusiness = new BrandBusiness();
                bool ketQua = brandBusiness.ThemMoiBrand(objBrand);
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

        public ActionResult BrandMain()
        {
            HienThiBrand();
            BrandBusiness brandBusiness = new BrandBusiness();
            List<Brand> lstBrand = brandBusiness.LayDanhSachBrand();
            return View(lstBrand);
            
        }

        public void HienThiBrand()
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            List<Brand> lstBrand = brandBusiness.LayDanhSachBrand();

            ViewBag.Brand = new SelectList(lstBrand, "Id", "Name");
        }

        
    }
}