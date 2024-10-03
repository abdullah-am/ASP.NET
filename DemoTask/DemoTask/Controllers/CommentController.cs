using AutoMapper;
using DemoTask.DTOs;
using DemoTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace DemoTask.Controllers
{
    public class CommentController : Controller
    {
        DemoTaskEntities5 db=new DemoTaskEntities5();
        // GET: Comment
        public ActionResult Comments(int id)
        {
            
            var data = db.Blogdatas.Find(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<Blogdata, BlogDTO>();
            });
            var mapper = new Mapper(config);
            var bdata = mapper.Map<Blogdata>(data);
            return View(bdata);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(CommentDTO c)
        {
            DemoTaskEntities5 db= new DemoTaskEntities5();

            if (ModelState.IsValid)
            {
                var cm = Convert(c);
                db.Comments.Add(cm);
                db.SaveChanges();
                return RedirectToAction("Comments");
            }

            return View(c);
        }

        public static CommentDTO Convert(Comment c)
        {
            return new CommentDTO
            {
                Comments = c.Comments,
                Id = c.Id
            };
        }

        public static Comment Convert(CommentDTO c)
        {

            return new Comment
            {
                Comments = c.Comments,
                Id = c.Id
            };

        }


    }
}