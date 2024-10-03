using AutoMapper;
using ExpenseTracker.DTOs;
using ExpenseTracker.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.Controllers
{
    public class RegistController : Controller
    {
        // GET: Regist
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(RegistDTO r) {
            ExpTrackerEntities3 db = new ExpTrackerEntities3();

            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == r.Email);
                if (existingUser != null)
                {
                    if (existingUser.Email == r.Email)
                    {
                        ModelState.AddModelError("Email", "already used");
                    }
                }
                else {

                    var mapper = getMapper();
                    var rs = mapper.Map<User>(r);
                    db.Users.Add(rs);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");

                }

                

            }

            return View(r);



        }

        public static Mapper getMapper() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, RegistDTO>();
                cfg.CreateMap<RegistDTO, User>();

            });
            return new Mapper(config);


        }



    }
}