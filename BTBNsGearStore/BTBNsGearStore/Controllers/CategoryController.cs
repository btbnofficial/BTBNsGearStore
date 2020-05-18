using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            List<Category> lstCategory = categoryBusiness.LayDanhSachCategory();

            return View(lstCategory);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(Category objCategory, HttpPostedFileBase fUpload)
        {
            if (objCategory != null)
            {
                string fileName = "";
                if (fUpload != null && fUpload.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload.FileName);

                    fUpload.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objCategory.Image = fileName;
                }

                //xu ly
                CategoryBusiness categoryBusiness = new CategoryBusiness();
                bool ketQua = categoryBusiness.ThemMoiCategory(objCategory);
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

        public ActionResult Xoa(int Id)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            bool ketQua = categoryBusiness.XoaCategory(Id);

            if(ketQua)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult CategoryMain()
        {
            HienThiCategory();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            List<Category> lstCategory = categoryBusiness.LayDanhSachCategory();
            return PartialView(lstCategory);
        }

        public void HienThiCategory()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            List<Category> lstCategory = categoryBusiness.LayDanhSachCategory();

            ViewBag.Category = new SelectList(lstCategory, "Id", "Name");
        }
    }
}