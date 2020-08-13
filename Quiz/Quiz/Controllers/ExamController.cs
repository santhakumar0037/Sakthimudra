using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz.DBL;

namespace Quiz.Controllers
{
    public class ExamController : Controller
    {
        GetQuiz db = new GetQuiz();
        public ActionResult Index()
        {
            ViewData["UserName"] = Session["UserName"];
            return Session["UserName"] == null ? Redirect("/") : (ActionResult)View();
        }

        [HttpPost]
        public ActionResult Index(string submit)
        {
            switch (submit)
            {
                case "Intelligence": return Redirect("/");
                case "Aptitude": return Redirect("/");
                case "Skills": return Redirect("/");
                case "Values": return Redirect("/");
                case "Personality": return RedirectToAction("Personality");
                case "Interest": return RedirectToAction("Interest");
                default: return Redirect("Exam/Index");
            }
        }

        public ActionResult Interest()
        {
            var Question = db.GetInterestQuestions();
            return View(Question.ToList());
        }

        public ActionResult Personality()
        {
            var Question = db.GetPersonalityQuestions();
            return View(Question.ToList());
        }
    }
}