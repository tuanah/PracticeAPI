﻿using System;
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

        [HttpGet]
        public ActionResult GetList()
        {
            //var informations = new HttpConnect().GetAccount(address);
            var logins = new LoginConnectAPI().GetAccountTest();
            if (logins == null)
            {
                logins = Enumerable.Empty<LoginViewModal>();
                return Json(new { status = "error", message = "Server error occured.", data = logins });
            }

            return Json(logins, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PostNewAccount(LoginViewModal l)
        {
            //l.loginID = 4;
            var logins = new LoginConnectAPI().PostAccount(address, l);
            if (logins == null)
            {
                return Json(new { status = "error", message = "Server error occured.", data = logins });
            }
            return Json(new { status = "success", message = "Register successfully.", data = logins });
            //return GetList();
        }

    }
}