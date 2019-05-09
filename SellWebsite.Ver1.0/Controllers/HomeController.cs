using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellWebsite.Ver1._0.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace SellWebsite.Ver1._0.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanHang1Entities db = new QuanLyBanHang1Entities();
        // GET: Home
        public ActionResult Index()
        {//lan luot tao cac viewbag de lay cac list san pham tu csdl

            //lsit dien thoai moi nhat
            IEnumerable<SanPham> listNewPhone = db.SanPhams.Where(k => k.MaLoaiSP == 1 && k.Moi == 1 && k.DaXoa == false).ToList();
            //gan list vao viewbag de truyen qua view
            ViewBag.ListNewPhone = listNewPhone;

            //list laptop moi nhat
            var listNewLaptop = db.SanPhams.Where(k => k.MaLoaiSP == 3 && k.Moi == 1 && k.DaXoa == false);
            ViewBag.ListNewLaptop = listNewLaptop;

            //list Tablet moi nhat
            var listNewTablet = db.SanPhams.Where(k => k.MaLoaiSP == 2 && k.Moi == 1 && k.DaXoa == false);
            ViewBag.ListNewTablet = listNewTablet;
            return View();
        }
        /*
         *Built  menu for website
             */
        public ActionResult MenuPartial()
        {
            var listSp = db.SanPhams.ToList<SanPham>();
            return PartialView(listSp);
        }

        /*
         *Built register page
         */
         [HttpGet]
        public ActionResult Register()
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            return View();
        }
        [HttpPost]
        public   ActionResult Register(ThanhVien tv)
         {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            //Check captcha
            if(this.IsCaptchaValid("Captcha is not valid")){
                ViewBag.ThongBao = "Success register";
                // theem thanh vien vao database
                db.ThanhViens.Add(tv); // add 1 thanh vien vao dataset
                db.SaveChanges();// update database
                return View();
            }
            ViewBag.ThongBao = "Wrong captcha !!";
            return View();
        }
        public List<String> LoadCauHoi()
        {
            List<String> listCauHoi = new List<string>();
            listCauHoi.Add("Con vat ban yeu thich la gi");
            listCauHoi.Add("Bo ban la ai");
            listCauHoi.Add("Truong ban dang hoc o dau");
            return listCauHoi;

        }
        //[HttpPost]
        //public ActionResult Register(FormCollection formCollection)
        //{
        //    return View();
        //}
    }
}