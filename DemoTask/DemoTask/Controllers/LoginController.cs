using DemoTask.DTOs;
using DemoTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTask.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DemoTaskEntities5 db=new DemoTaskEntities5();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid) 
            {
                var user=(from u in db.Users
                          where u.Email.Equals(l.Email) &&
                          u.Password.Equals(l.Password)
                          select u).SingleOrDefault();
                if (user == null) {
                    TempData["Msg"] = "User not found";
                    return RedirectToAction("Index");
                }
                Session["user"]=user;
                TempData["Msg"] = "Login successfull";
                return RedirectToAction("Index","Dashboard");
            }

            return View(l);
        }
        

    }
}