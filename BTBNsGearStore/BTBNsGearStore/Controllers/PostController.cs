using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(string tuKhoa)
        {
            PostBusiness postBusiness = new PostBusiness();

            List<Post> lstPost = postBusiness.TimKiemPost(tuKhoa);

            ViewBag.tuKhoa = tuKhoa;

            return View(lstPost);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemMoi(Post objPost)
        {
            if(objPost!=null)
            {
                PostBusiness postBusiness = new PostBusiness();

                bool ketQua = postBusiness.ThemMoiPost(objPost);

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
            PostBusiness postBusiness = new PostBusiness();

            bool ketQua = postBusiness.XoaPost(Id);

            if(ketQua)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ChiTiet(int Id)
        {
            PostBusiness postBusiness = new PostBusiness();

            Post objPost = postBusiness.ChiTietPostTheoId(Id);

            return View(objPost);
        }

        public ActionResult Sua(int Id)
        {
            PostBusiness postBusiness = new PostBusiness();

            Post objPost = postBusiness.ChiTietPostTheoId(Id);

            return View(objPost);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sua(Post objPost)
        {
            PostBusiness postBusiness = new PostBusiness();

            if (objPost != null)
            {

                bool ketQua = postBusiness.SuaPost(objPost);

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

    }
}