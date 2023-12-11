using BaiThiMau.Data;
using BaiThiMau.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiThiMau.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        private QLHangHoaContext _dbContext;
        private List<LoaiHang> _loaihangs;

        public NavbarViewComponent(QLHangHoaContext dbContext)
        {
            _dbContext = dbContext;
            _loaihangs = dbContext.LoaiHangs.ToList();
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderNavbar", _loaihangs);
        }
    }
}
