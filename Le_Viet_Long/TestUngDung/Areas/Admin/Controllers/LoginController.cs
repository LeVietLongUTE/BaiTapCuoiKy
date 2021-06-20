using ModelEF;
using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                var result = user.Login(login.username, commom.EncryptMD5(login.password));
                if (result == 1)
                {
                    // ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(constants.USER_SESSION, login);
                    return RedirectToAction("index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đã bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "mật khẩu không đúng");
                }            
                else
                {
                    ModelState.AddModelError("", "Đăng nhập Thất Bại");
                }
            }
            return View("index");
        }
    }
}