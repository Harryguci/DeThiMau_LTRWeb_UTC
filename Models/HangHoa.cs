using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaiThiMau.Models
{
    public partial class HangHoa
    {
        [DisplayName("Mã hàng")]
        public int MaHang { get; set; }
        [DisplayName("Loại hàng")]
        public int MaLoai { get; set; }
        [DisplayName("Tên hàng")]
        public string TenHang { get; set; } = null!;
        [DisplayName("Giá")]
        public decimal? Gia { get; set; }
        [DisplayName("Ảnh")]
        public string? Anh { get; set; }

        public virtual LoaiHang? MaLoaiNavigation { get; set; } = null!;
    }
}
