using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
   public class DSSanPham
    {
        private LeVietLongContext db = null;
        public DSSanPham()
        {
            db = new LeVietLongContext();
        }
        //hiển thị sản phẩm và sắp xếp
        public IEnumerable<SanPham> ListAll()
        {         
            return db.SanPham.OrderBy(x=>x.Quantity).ThenByDescending(x=>x.UnitCost).ToList();
        }
        ////hiển thị (dropdownlist: đổ dữ liệu của bảng Loại sản phẩm vào)
        public List<LoaiSanPham> ListtAll()
        {
            return db.LoaiSanPham.ToList();
        }
        public string Insert(SanPham entitySanpham)
        {
            db.SanPham.Add(entitySanpham);
            db.SaveChanges();
            return entitySanpham.Name;
        }
        public bool Find(string ID)
        {
            int d = 0;
            var SP = db.SanPham.Where(x => x.ID.Contains(ID));
            foreach (var i in SP)
            {
                d = d + 1;
            }
            if (d > 0)
                return false;
            return true;
        }

        public SanPham FindById(string id)
        {
            return db.SanPham.Find(id);
        }
       
    }
}
