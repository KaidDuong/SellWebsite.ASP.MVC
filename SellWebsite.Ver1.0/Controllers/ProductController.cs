using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellWebsite.Ver1._0.Models;
using System.Net;

namespace SellWebsite.Ver1._0.Controllers
{
    public class ProductController : Controller
    {
        QuanLyBanHang1Entities db = new QuanLyBanHang1Entities();
        // GET: Product
        // tao 2 partial view 1 va 2 de show sp len website
        //use childActiononly de tranh nguoi dung get vao view nay
        [ChildActionOnly]
        public ActionResult ProductStylePartial1()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult ProductStylePartial2()
        {
            return PartialView();
        }

        /*
         * Built paticulars web-side
         */

        public ActionResult XemChiTiet(int id)
        {
            try
            {
                SanPham sanPham = db.SanPhams.SingleOrDefault(k => k.MaSP == id && k.DaXoa == false);
                if (sanPham == null)
                {
                    //thong bao neu nhu ko co san pham
                    return HttpNotFound();
                }
                return View(sanPham);
            }
            catch
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//badrRequest = error 400
            }
               
        }
        /*
         * Build 1 action to load products by maLoaisanpham and manhasanxuat
         */
        public ActionResult Product(int? maLoaiSP, int ? maNSX)
        {
            try
            {
                //lay danh sach san pham theo maLoaiSP va MaNSX
                var listProduct = db.SanPhams.Where
                    (k => k.MaLoaiSP == maLoaiSP && 
                    k.MaNSX == maNSX);

                //CHECK xem ket qua tra ve co san pham nao hay ko
                if (listProduct.Count() == 0)
                {
                    //thong bao ko co san pham
                    return HttpNotFound();
                }
                return View(listProduct);
            }
            catch
            {
                // neu tham so truyen vao ko hop le
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
        }


    }
}