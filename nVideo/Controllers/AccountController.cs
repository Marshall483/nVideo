using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.Controllers
{
  public class AccountController : Controller
  {
    public IActionResult PersonalPage()
    {
      return View();
    }
    public IActionResult Registration()
    {
      return View();
    }
  }
}
