using ModelEF.Dao;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class DanhSachSPController : baseController
    {
        LeVietLongContext db = new LeVietLongContext();
        // GET: Admin/DanhSachSP
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var sanpham = new DSSanPham();
            var model = sanpham.ListAll();         
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            setviewbag();
            return View();
        }
       // hiển thị(dropdownlist: đổ dữ liệu của bảng Loại sản phẩm vào)
        public void setviewbag(int? categoryID = null)
        {
            var dao = new DSSanPham();
            ViewBag.categoryID = new SelectList(dao.ListtAll(), "ID", "Name", categoryID);
        }
       // thực hiện chức năng thêm 1 sản phẩm
       [HttpPost]
        public ActionResult Create(SanPham model)
        {
            if (ModelState.IsValid)
            {
                var dao = new DSSanPham();
                if (dao.Find(model.ID) == false)
                {
                    SetAlert("Sản phẩm đã tồn tại", "warning");
                    return RedirectToAction("Create", "DanhSachSP");
                }
                string result = dao.Insert(model);

                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm Sản Phẩm thành công", "success");
                    return RedirectToAction("Index", "DanhSachSP");
                }
                else
                {
                    SetAlert("Thêm Sản Phẩm thất bại !", "error");               
                }
            }
            setviewbag();
            return View();
        }     
        [HttpGet]
        public ActionResult Detail()
        {
            String value = Request["idSanPham"];
            var dao = new DSSanPham();
            var model = dao.FindById(value);
            return View(model);
        }
    }
}