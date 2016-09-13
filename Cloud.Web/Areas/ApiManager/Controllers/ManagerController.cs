using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cloud.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Cloud.Web.Areas.ApiManager.Controllers
{
    [Area("ApiManager")]
    public class ManagerController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }

    }
}