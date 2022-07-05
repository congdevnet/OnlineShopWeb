using System.Linq;
using System.Web.Mvc;
using WebBanHangMcv.Services.AboutService;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class AboutController : Controller
    {
        private IAboutService _iaboutService;

        public AboutController(IAboutService _iaboutService)
        {
            this._iaboutService = _iaboutService;
        }

        // GET: admin/About
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _iaboutService.All<AboutDto>().ToList();
            foreach (var item in Data)
            {
                item.ID += Index++;
            }
            return View(Data);
        }

        public ActionResult DanhSach()
        {
            return View();
        }
    }
}