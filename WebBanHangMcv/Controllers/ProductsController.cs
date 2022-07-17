using System.Linq;
using System.Web.Mvc;
using WebBanHangMcv.Services.ProductServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Controllers
{
    public class ProductsController : Controller
    {
        private IProducSrevices _IProducSrevices;
        public ProductsController(IProducSrevices _IProducSrevices)
        {
            this._IProducSrevices = _IProducSrevices;
        }
        // GET: Products
        public ActionResult Index(int id)
        {
            var Data = _IProducSrevices.All<ProductDto>().Where(x => x.ID == id).FirstOrDefault(); ;
            return View(Data);
        }
    }
}