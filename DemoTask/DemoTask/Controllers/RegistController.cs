using AutoMapper;
using DemoTask.DTOs;
using DemoTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace DemoTask.Controllers
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
        public ActionResult Index(RegistDTO r)
        {
            DemoTaskEntities5 db = new DemoTaskEntities5();
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u=>u.Email == r.Email);
                if(existingUser!=null)
                {
                    if (existingUser.Email == r.Email)
                    {
                        ModelState.AddModelError("Email", "already used");
                    }
                }
                else
                {
                    var rs = Convert(r);
                    db.Users.Add(rs);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");

                    //var mapper = getMapper();
                    //var rs = mapper.Map<User>(r);
                    //db.Users.Add(rs);
                    //db.SaveChanges();
                    //return RedirectToAction("Index","Login");
                }
               
            }
            return View(r);
        }

        public static RegistDTO Convert(User r)
        {
            var name = r.Name.Split(' ');
            return new RegistDTO()
            {
                FirstName = name[0],
                LastName = name[1],
                Email = r.Email,
                Gender = r.Gender,
                Password = r.Password,
                UserType = r.UserType,
                Id = r.Id
            };

        }
        public static User Convert(RegistDTO r)
        {
            return new User()
            {
                Name = r.FirstName.Trim() + " " + r.LastName.Trim(),
                Email = r.Email,
                Gender = r.Gender,
                Password = r.Password,
                UserType = r.UserType,
                Id = r.Id
            };


        }


        //public static Mapper getMapper()
        //{
        //    var config = new MapperConfiguration(cfg => {
        //        cfg.CreateMap<User, RegistDTO>();
        //        cfg.CreateMap<RegistDTO, User>();
        //    });
        //    return new Mapper(config);
        //}

    }
}