namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    [Table("SanPham")]
    public partial class SanPham
    {
        [Required(ErrorMessage = "ID is required")]
        [StringLength(50, ErrorMessage = "Không được quá 50 kí tự ! ")]
        [Display(Name = "Mã Sản Phẩm")]
        public string ID { get; set; }        
        [Required( ErrorMessage = "Tên Sản phẩm không được để trống ! ")]
        [StringLength(100, ErrorMessage = "Không được quá 100 kí tự ! ")]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }
        [Required(ErrorMessage = "UnitCost is required")]
        [Column(TypeName = "money")]
        [Display(Name = "Giá Sản Phẩm")]
        public decimal UnitCost { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }
        [StringLength(100)]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        [StringLength(100, ErrorMessage = "Không được quá 100 kí tự  ! ")]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }
        [Display(Name = "Tình trạng")]
        public bool Status { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        public int categoryID { get; set; }      
    public virtual LoaiSanPham LoaiSanPham { get; set; }      
    }
}
