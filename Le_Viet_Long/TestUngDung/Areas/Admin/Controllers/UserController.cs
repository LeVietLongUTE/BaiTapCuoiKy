using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ModelEF.Dao;
using ModelEF;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : baseController
    {

        [HttpGet]
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new User();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new User();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var dao = new User();

                //kiểm tra check list tài khoản nếu false chưa có tài khoản thì insert
                if (dao.checktaikhoan(model.UserName)==false)
                {
                    var pass = commom.EncryptMD5(model.Password);
                    model.Password = pass;
                  
                    string result = dao.Insert(model);

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Tạo tài khoản thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Tạo người dùng không thành công", "error");                        
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }

            }
            return View();
        }
       
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new User().Delete(id);
            return RedirectToAction("Index");
        }
    }
}