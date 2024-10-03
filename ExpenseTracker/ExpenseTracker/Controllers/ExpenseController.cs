using AutoMapper;
using ExpenseTracker.DTOs;
using ExpenseTracker.EF;
using ExpenseTracker.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExpenseTracker.Controllers
{
    [logged]
    public class ExpenseController : Controller
    {
        ExpTrackerEntities3 db =new ExpTrackerEntities3();
        // GET: Expense
        public ActionResult Index()
        {
            var data=db.Expenses.ToList();
            var mapper =getMapper();
            var data2 = mapper.Map<List<ExpenseDTO>>(data);

            return View(data2);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ExpenseDTO e)
        {
            if (ModelState.IsValid)
            {
                var mapper = getMapper();
                var pst = mapper.Map<Expens>(e);
                db.Expenses.Add(pst);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(e);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var exobj = db.Expenses.Find(id);
            var mapper = getMapper();
            var data = mapper.Map<ExpenseDTO>(exobj);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(ExpenseDTO obj)
        {
            var exobj = db.Expenses.Find(obj.Id);
            //db.Entry(exobj).CurrentValues.SetValues(obj);
            exobj.Amount = obj.Amount;
            exobj.Category = obj.Category;
            exobj.Date=obj.Date;
            exobj.Description = obj.Description;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.Expenses.Find(id);
            db.Expenses.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public static Mapper getMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Expens, ExpenseDTO>();
                cfg.CreateMap<ExpenseDTO,Expens>();
            });
            return new Mapper(config);
        }
    }
}