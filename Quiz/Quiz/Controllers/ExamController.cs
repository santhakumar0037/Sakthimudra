using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Controllers
{
    public class ExamController : Controller
    {
        // GET: Exam
        public ActionResult Index()
        {
            ViewData["UserName"] = Session["UserName"];
            return Session["UserName"] == null ? Redirect("/") : (ActionResult)View();
        }
    }
}