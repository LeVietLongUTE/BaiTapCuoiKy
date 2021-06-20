using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Models;

namespace TestUngDung.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int page = 1, int pagesize = 6)
        {
            var sp = new ProductDao();
            var model = sp.listproduct();
            return View(model.ToPagedList(page, pagesize));
        }
    }
}