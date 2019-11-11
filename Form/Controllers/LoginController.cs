using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public ActionResult GetVerify(LoginViewModal l)
        {
            //bool check = false;
            //check = new HttpConnect().VerifyLogin(address, l);
            //return Json(check);
            var json = new JavaScriptSerializer().Serialize(l);
            var informations = new HttpConnect().GetVerifyLogin(address, json);
            return Json(informations, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetList()
        {
            var informations = new HttpConnect().GetAccount(address);
            if (informations == null)
            {
                informations = Enumerable.Empty<LoginViewModal>();
                return Json(new { status = "error", message = "Server error occured.", data = informations });
            }

            return Json(informations, JsonRequestBehavior.AllowGet);

        }

    }
}