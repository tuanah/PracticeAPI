using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAPI.Models;

namespace Form.Controllers
{
    public class LoginController : Controller
    {
        string address = "api/Logins";
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Forget()
        {
            return View("Forget");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpGet]
        public ActionResult GetVerify(LoginViewModal l)
        {
            //bool check = false;
            //check = new HttpConnect().VerifyLogin(address, l);
            //return Json(check);
            var json = new JavaScriptSerializer().Serialize(l);
            var informations = new LoginConnectAPI().GetVerifyLogin(address, json);
            return Json(informations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetList()
        {
            //var informations = new HttpConnect().GetAccount(address);
            var logins = new LoginConnectAPI().GetAccount(address);
            if (logins == null)
            {
                logins = Enumerable.Empty<LoginViewModal>();
                return Json(new { status = "error", message = "Server error occured.", data = logins });
            }

            return Json(logins, JsonRequestBehavior.AllowGet);

        }
    }
}