using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.UserSrevices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        private IUserSercies _iUserService;
        public LoginController(IUserSercies _iUserService)
        {
            this._iUserService = _iUserService;
        }
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Loginfrom(UserLogin userLogin)
        {
            var Data = _iUserService.Login(userLogin);
            if (Data.Name !=null)
            {
                // Lưu Session
                Session["UserName"] = userLogin.UserName;
                return Json(new JsonRespon(Mes: "Đăng nhập thành công", Status: 200), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JsonRespon(Mes: "Đăng nhập không thành công", Status: 500), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Loguot()
        {
            Session.Clear();
            Session.Abandon();
            return Json(new JsonRespon(Mes: "Đăng xuất thành công", Status: 200), JsonRequestBehavior.AllowGet);
        }
        
    }
}