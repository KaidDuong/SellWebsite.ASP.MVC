using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SellWebsite.Ver1._0.Models;

namespace SellWebsite.Ver1._0.Controllers
{
    public class ProductController : Controller
    {
        SalesManagerEntities db = new SalesManagerEntities();
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
    }
}