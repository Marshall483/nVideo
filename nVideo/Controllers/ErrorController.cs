using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Status(string code)
        {
            ViewBag.Code = code;
            Response.StatusCode = Convert.ToInt32(code);
            return View();
        }
    }
}
