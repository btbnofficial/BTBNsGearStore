using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TestView()
        {
            return View();
        }

        public ActionResult TrangChu()
        {
            ProductBusiness productBusiness = new ProductBusiness();

            List<Product> lstProduct = productBusiness.LayDanhSachProduct();

            return View(lstProduct);
        }

        public ActionResult ChiTiet(int Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            Product objProduct = productBusiness.ChiTietProductTheoId(Id);
            return View(objProduct);
        }

        public ActionResult ChiTiet2(int Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            Product objProduct = productBusiness.ChiTietProductTheoId(Id);
            return View(objProduct);
        }

        public ActionResult ChiTiet3(int Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            Product objProduct = productBusiness.ChiTietProductTheoId(Id);
            return View(objProduct);
        }

        public ActionResult ChiTiet4(int Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            Product objProduct = productBusiness.ChiTietProductTheoId(Id);
            return View(objProduct);
        }

        public ActionResult LayDanhSachProductTheoCategory(string Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            List<Product> lstProduct = productBusiness.LayDanhSachProductTheoCategory(Id);
            return View(lstProduct);
        }

        public ActionResult TimKiem(string tuKhoa, string brand, string category)
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

        public ActionResult GamingPC(string giaMin, string giaMax)
        {
            HienThiBrand();
            HienThiCategory();

            ProductBusiness productBusiness = new ProductBusiness();
            List<Product> lstProduct = productBusiness.LayDanhSachPCTheoGia(giaMin, giaMax);

            return View(lstProduct);
        }

        public ActionResult Line5(string categoryId)
        {
            ProductBusiness productBusiness = new ProductBusiness();

            List<Product> lstProduct = productBusiness.LayDanhSachProductTheoCategory(categoryId);

            return View(lstProduct);
        }

        public ActionResult Line5Products()
        {
            ProductBusiness productBusiness = new ProductBusiness();

            List<Product> lstProduct = productBusiness.LayDanhSachProduct();

            return View(lstProduct);
        }

        public ActionResult BaiViet(int Id)
        {
            PostBusiness postBusiness = new PostBusiness();
            Post objPost = postBusiness.ChiTietPostTheoId(Id);
            return View(objPost);
        }

        public ActionResult DanhSachBaiViet()
        {
            PostBusiness postBusiness = new PostBusiness();
            List<Post> lstPost = postBusiness.LayDanhSachPost();
            return View(lstPost);
        }

        public ActionResult DanhSachBrand()
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            List<Brand> lstBrand = brandBusiness.LayDanhSachBrand();
            return View(lstBrand);
        }

        public ActionResult LayDanhSachProductTheoBrand(string Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();

            List<Product> lstProduct = productBusiness.LayDanhSachProductTheoBrand(Id);

            return View(lstProduct);
        }
    }
}