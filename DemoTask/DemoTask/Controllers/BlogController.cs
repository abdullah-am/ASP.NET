using AutoMapper;
using DemoTask.Auth;
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
    [UserA]
    public class BlogController : Controller
    {
           DemoTaskEntities5 db=new DemoTaskEntities5();
            public ActionResult Index()
            {
                //list of all posts
                var data = db.Blogdatas.ToList();
                var mapper = getMapper();
                var data2 = mapper.Map<List<BlogDTO>>(data);
                //map to DTO
                return View(data2);
            }
            [HttpGet]
            public ActionResult Create()
            {
                return View(new BlogDTO());
            }
            [HttpPost]
            public ActionResult Create(BlogDTO obj)
            {
                if (ModelState.IsValid)
                {
                    //convert postDTO to Post
                    var mapper = getMapper();
                    var post = mapper.Map<Blogdata>(obj);
                    db.Blogdatas.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
            [HttpGet]
            public ActionResult Edit(int id)
            {
                var exobj = db.Blogdatas.Find(id);
                var mapper = getMapper();
                var data = mapper.Map<BlogDTO>(exobj);
                return View(data);
            }
            [HttpPost]
            public ActionResult Edit(BlogDTO obj)
            {
                var exobj = db.Blogdatas.Find(obj.Id);
                //db.Entry(exobj).CurrentValues.SetValues(obj);
                exobj.Blog= obj.Blog;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            [HttpGet]
            public ActionResult Delete(int id)
            {
                var obj = db.Blogdatas.Find(id);
                db.Blogdatas.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            public static Mapper getMapper()
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Blogdata, BlogDTO>();
                    cfg.CreateMap<BlogDTO, Blogdata>();
                    cfg.CreateMap<Comment, CommentDTO>();
                    cfg.CreateMap<CommentDTO, Comment>();
                });
                return new Mapper(config);
            }
        
    }
}