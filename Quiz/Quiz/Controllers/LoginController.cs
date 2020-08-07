﻿using System;
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
            var UserName = db.CheckLogin(formUsers);
            return UserName != null ? RedirectToAction("") : null; 
        }
    }
}