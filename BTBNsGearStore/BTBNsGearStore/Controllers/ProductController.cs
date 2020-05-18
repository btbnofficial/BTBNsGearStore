using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string tuKhoa, string brand, string category)
        {
            HienThiBrand();

            HienThiCategory();

            ProductBusiness productBusiness = new ProductBusiness();
            List<Product> lstProduct = new List<Product>();
            if (string.IsNullOrEmpty(category))
            {
                lstProduct = productBusiness.TimKiemProduct(tuKhoa, brand);
            }
            else
            {
                lstProduct = productBusiness.TimKiemProduct(tuKhoa, brand, category);
            }
            ViewBag.tuKhoa = tuKhoa;

            return View(lstProduct);
        }

        public void HienThiCategory()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            List<Category> lstCategory = categoryBusiness.LayDanhSachCategory();

            ViewBag.Category = new SelectList(lstCategory, "Id", "Name");
        }

        public void HienThiBrand()
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            List<Brand> lstBrand = brandBusiness.LayDanhSachBrand();

            ViewBag.Brand = new SelectList(lstBrand, "Id", "Name");
        }

        public ActionResult ThemMoi()
        {
            HienThiBrand();
            HienThiCategory();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(Product objProduct, HttpPostedFileBase fUpload1, HttpPostedFileBase fUpload2, HttpPostedFileBase fUpload3, HttpPostedFileBase fUpload4)
        {
            if(objProduct!=null)
            {
                string fileName = "";
                if (fUpload1 != null && fUpload1.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload1.FileName);

                    fUpload1.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image1 = fileName;
                }
                if (fUpload2 != null && fUpload2.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload2.FileName);

                    fUpload2.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image2 = fileName;
                }
                if (fUpload3 != null && fUpload3.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload3.FileName);

                    fUpload3.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image3 = fileName;
                }
                if (fUpload4 != null && fUpload4.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload4.FileName);

                    fUpload4.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image4 = fileName;
                }

                ProductBusiness productBusiness = new ProductBusiness();
                bool ketQua = productBusiness.ThemMoiProduct(objProduct);

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
        //End Thêm mới sản phẩm

        public ActionResult Xoa(int Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            bool ketQua = productBusiness.XoaProduc(Id);
            if(ketQua)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult ChiTiet(int Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();

            Product product = productBusiness.ChiTietProductTheoId(Id);

            return View(product);
        }

        public ActionResult Sua(int Id)
        {
            HienThiBrand();
            HienThiCategory();

            ProductBusiness productBusiness = new ProductBusiness();
            Product objProduct = productBusiness.ChiTietProductTheoId(Id);
            return View(objProduct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua(Product objProduct, int Id, HttpPostedFileBase fUpload1, HttpPostedFileBase fUpload2, HttpPostedFileBase fUpload3, HttpPostedFileBase fUpload4)
        {
            if(objProduct!=null)
            {
                string fileName = "";
                if (fUpload1 != null && fUpload1.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload1.FileName);

                    fUpload1.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image1 = fileName;
                }
                if (fUpload2 != null && fUpload2.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload2.FileName);

                    fUpload2.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image2 = fileName;
                }
                if (fUpload3 != null && fUpload3.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload3.FileName);

                    fUpload3.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image3 = fileName;
                }
                if (fUpload4 != null && fUpload4.ContentLength > 0)
                {
                    fileName = Path.GetFileName(fUpload4.FileName);

                    fUpload4.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                    //Lưu vào db
                    objProduct.Image4 = fileName;
                }

                ProductBusiness productBusiness = new ProductBusiness();
                bool ketQua = productBusiness.SuaProduct(objProduct);
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