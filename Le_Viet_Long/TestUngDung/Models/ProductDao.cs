using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Models
{
    public class ProductDao
    {
        private LeVietLongContext db = null;
        public ProductDao()
        {
            db = new LeVietLongContext();
        }
        public List<SanPham> listproduct()
        {
            return db.SanPham.ToList();
        }
    }
}