using BTBNsGearStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTBNsGearStore.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();

            List<Customer> lstCustomer = customerBusiness.LayDanhSachCustomer();

            return View(lstCustomer);
        }

        public ActionResult Xoa(int Id)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            bool ketQua = customerBusiness.XoaCustomer(Id);
            if(ketQua)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Order(int Id)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            Product objProduct = productBusiness.ChiTietProductTheoId(Id);
            return View(objProduct);
        }

        public ActionResult OrderSuccess()
        {
            return View();
        }

    }
}