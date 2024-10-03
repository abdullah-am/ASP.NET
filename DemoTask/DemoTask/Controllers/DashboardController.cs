using AutoMapper;
using DemoTask.Auth;
using DemoTask.DTOs;
using DemoTask.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoTask.Controllers
{
    [UserA]
    public class DashboardController : Controller
    {
        DemoTaskEntities5 db=new DemoTaskEntities5();

        public ActionResult Index()
        { 
            var data=db.Blogdatas.ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Blogdata, BlogDTO>();
                cfg.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(config);
            var data2 = mapper.Map<List<BlogDTO>>(data);
            return View(data2);
        }
        
        //public ActionResult Comments(int id)
        //{
        //    var data = db.Blogdatas.Find(id);
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Comment, CommentDTO>();
        //        cfg.CreateMap<Blogdata, BlogDTO>();
        //    });
        //    var mapper = new Mapper(config);
        //    var bdata=mapper.Map<Blogdata>(data);
        //    return View(bdata);
        //}


        // GET: Dashboard
        //public ActionResult Index()
        //{
        //    DemoTaskEntities5 db = new DemoTaskEntities5();
        //    var data=db.Blogdatas.ToList();
        //    var converted=Convert(data);
        //    return View(converted);
        //}

        //public static BlogDTO Convert(Blogdata b)
        //{
        //    return new BlogDTO()
        //    {
        //        Blog=b.Blog,
        //        Id=b.Id,
        //    };
        //}

        //public static Blogdata Convert(BlogDTO b)
        //{
        //    return new Blogdata()
        //    {
        //        Blog=b.Blog,
        //        Id=b.Id,
        //    };
        //}

        //public static List<BlogDTO> Convert(List<Blogdata> blogs) {
        //    var list = new List<BlogDTO>();
        //    foreach (var b in blogs) { 
        //        list.Add(Convert(b));
        //    }
        //    return list;
        //}
    }
}