using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.DTOs;
using WebApplication2.EF;

namespace WebApplication2.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index()
        {
            DemoDatabaseEntities db = new DemoDatabaseEntities();
            var data = db.Couses.ToList();
            var converted = Convert(data);
            return View(converted);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseDTO c)
        {
            DemoDatabaseEntities db = new DemoDatabaseEntities();
            if (ModelState.IsValid)
            {
                var st = (Convert(c));
                db.Couses.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            DemoDatabaseEntities db = new DemoDatabaseEntities();
            var eobj = db.Couses.Find(id);
            return View(eobj);
        }
        [HttpPost]
        public ActionResult Edit(Cous c)
        {
            DemoDatabaseEntities db = new DemoDatabaseEntities();
            var eobj = db.Couses.Find(c.Id);
            eobj.Title = c.Title;
            eobj.CreditHour = c.CreditHour;
            eobj.Type = c.Type;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public static CourseDTO Convert(Cous c)
        {
            return new CourseDTO()
            {
                Id = c.Id,
                Title = c.Title,
                CreditHour = c.CreditHour,
                Type = c.Type

            };
        }
        public static Cous Convert(CourseDTO c)
        {
            return new Cous()
            {
                Title = c.Title,
                CreditHour = c.CreditHour,
                Type = c.Type
            };
        }

        public static List<CourseDTO> Convert(List<Cous> s)
        {
            var list = new List<CourseDTO>();
            foreach (var c in s)
            {
                var st = (Convert(c));
                list.Add(st);

            }
            return list;




        }
    }
}