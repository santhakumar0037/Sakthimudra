using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.Models;
using Quiz.DBL;

namespace Quiz.Controllers
{
    public class RegisterController : Controller
    {
        new readonly Users User = new Users();
        DBClass db = new DBClass();
        [HttpGet]
        public ActionResult Index()
        {
            return View(User);
        }
        [HttpPost]
        public ActionResult Index(Users user)
        {
            return db.RegisterUser(user) ? RedirectToAction("/") : null;
        }
    }
}