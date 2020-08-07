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
        new readonly Users User = new Users();
        DBClass db = new DBClass();
        public ActionResult Index()
        {
            return View(User);
        }

        [HttpPost]
        public ActionResult Index(Users formUsers)
        {
            var GetName = db.GetUser(formUsers);
            if (GetName != null )
            {
                Session["UserName"] = GetName;
                return RedirectToAction("Index", "Exam");
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}