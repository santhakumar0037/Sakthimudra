using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.Models;
using Quiz.DBL;

namespace Quiz.Controllers
{
    public class LoginController : Controller
    {
        Users user = new Users();
        DBClass db = new DBClass();
        public ActionResult Index()
        {
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(Users formUsers)
        {
            var UserName = db.CheckLogin(formUsers);
            if (UserName != null)
            {
                return Redirect("/");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }

    }
}