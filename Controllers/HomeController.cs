using BaiThiMau.Data;
using BaiThiMau.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BaiThiMau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLHangHoaContext _dbContext;
        private int pageSize = 5;

        public HomeController(ILogger<HomeController> logger,
            QLHangHoaContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int maloai = 0, int pageIndex = 1)
        {
            var query = (IQueryable<HangHoa>)_dbContext.HangHoas;
            query = query.Where(p => p.Gia >= 100);

            if (maloai != 0) query = query.Where(p => p.MaLoai == maloai);

            var hanghoa = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            int pageNum = (int)Math.Ceiling(query.Count() / (float)pageSize);
            ViewBag.PageNum = pageNum;
            ViewBag.PageIndex = pageIndex;
            ViewBag.MaLoai = maloai;

            return View(hanghoa);
        }

        public async Task<IActionResult> ListProductAsync(int maloai = 0, int pageIndex = 1)
        {
            var query = (IQueryable<HangHoa>)_dbContext.HangHoas;
            query = query.Where(p => p.Gia >= 100);

            if (maloai != 0) query = query.Where(p => p.MaLoai == maloai);

            var hanghoa = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            int pageNum = (int)Math.Ceiling(query.Count() / (float)pageSize);
            ViewBag.PageNum = pageNum;
            ViewBag.PageIndex = pageIndex;
            ViewBag.MaLoai = maloai;

            return View(hanghoa);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.LoaiHangs = await _dbContext.LoaiHangs.ToListAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}