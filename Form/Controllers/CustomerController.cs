using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebAPI.Models;

namespace Form.Controllers
{
    public class CustomerController : Controller
    {
        string address = "api/Customers";
        IEnumerable<CustomerViewModal> informations = null;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View("Table");
        }

        public ActionResult View404()
        {
            return View("View404");
        }

        public ActionResult Blank()
        {
            return View("Blank");
        }


        [HttpGet]
        public ActionResult GetList()
        {
            informations = new CustomerConnectAPI().GetData(address);
            if (informations == null)
            {
                informations = Enumerable.Empty<CustomerViewModal>();
                return Json(new { status = "error", message = "Server error occured.", data = informations });
            }

            return Json(informations, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetFindResult(CustomerViewModal t)
        {
            var json = new JavaScriptSerializer().Serialize(t);
            informations = new CustomerConnectAPI().GetData(address, json);
            return Json(informations, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult PostNewInfo(CustomerViewModal t)
        {
            CustomerViewModal check = new CustomerConnectAPI().PostNewInfor(address, t);
            if (check == null)
            {
                return Json(new { status = "error", message = "Error creating new Information" });
            }
            return GetList();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool check = new CustomerConnectAPI().DelData(address, id);
            return Json(check);
        }

        [HttpPost]
        public ActionResult PutInfor(CustomerViewModal t)
        {
            bool check = new CustomerConnectAPI().EditData(address, t);
            return Json(check);
        }
    }

}