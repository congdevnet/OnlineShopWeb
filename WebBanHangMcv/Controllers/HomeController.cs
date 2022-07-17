using System.Web.Mvc;
using WebBanHangMcv.Services.MenuServices;
using WebBanHangMcv.Services.ProductCategorySrevices;
using WebBanHangMcv.Services.ProductServices;
using WebBanHangMcv.Services.SlideServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Controllers
{
    public class HomeController : Controller
    {
        private IMenuServices _IMenuSrevices;
        private IProductCategorySrevices _IProductCategorySrevices;
        private ISlideServices _iSlideService;
        private IProducSrevices _IProducSrevices;

        public HomeController(IMenuServices _IMenuSrevices, IProductCategorySrevices _IProductCategorySrevices,
            ISlideServices _iSlideService, IProducSrevices _IProducSrevices)
        {
            this._IMenuSrevices = _IMenuSrevices;
            this._IProductCategorySrevices = _IProductCategorySrevices;
            this._iSlideService = _iSlideService;
            this._IProducSrevices = _IProducSrevices;
        }

        public ActionResult Index()
        {
            var Data = _IProducSrevices.All<ProductDto>();
            return View(Data);
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var Data = _IMenuSrevices.All<Menuview>();
            return PartialView(Data);
        }

        [ChildActionOnly]
        public ActionResult Danhmuc()
        {
            var Data = _IProductCategorySrevices.All<ProductCategoryDto>();
            return PartialView(Data);
        }

        [ChildActionOnly]
        public ActionResult Menutop()
        {
            var Data = _IMenuSrevices.All<Menuview>();
            return PartialView(Data);
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            var Data = _iSlideService.All<SlideDto>();
            return PartialView(Data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}