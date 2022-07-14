using System.Web.Mvc;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class homeadminController : BaseController
    {
        // GET: admin/home
        public ActionResult Index()
        {
            return View();
        }
    }
}