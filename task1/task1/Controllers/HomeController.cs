using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task1.Models;

namespace task1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Profile myprof = new Profile()
            {
                Name="Abdullah Al Mamun",
                Email="aamabdullah0@gmail.com",
                Phone=01872222172,
                Degree="Bsc in CSE",
                Expertise="c,c++,c#,web.Tech"

            };

            ViewBag. Profile = new Profile[] { myprof };
            return View();
        }
        public ActionResult Education()
        {
            var e1 = new Education()
            {
                Title="HSC",
                year = 2019,
                group="science",
                inst="REBGSC"
            };
            var e2 = new Education()
            {
                Title="SSC",
                year = 2017,
                group="science",
                inst="AHIASC"
            };
            var e3 = new Education()
            {
                Title="BSC",
                year = 2025,
                group="BsC in CSE",
                inst="AIUB"
            };

            ViewBag.Education = new Education[] { e1, e2, e3 };

            return View();
        }
        public ActionResult Project()
        {

            Project myproject1 = new Project()
            {
                Title="metrimonial site",
                Description="using html,php,mysql",
                course="web tech"
            };
            Project myproject2 = new Project()
            {
                Title="e-ticket",
                Description="using node.js,next.js.,typescript",
                course="avd. web tech"
            };
            Project myproject3 = new Project()
            {
                Title="metrimonial site",
                Description="using html,php,mysql",
                course="web tech"
            };

            ViewBag.Projec
                
                t = new Project[] {myproject1,myproject2,myproject3 };
            return View();
        }
        public ActionResult Certification()
        {
            return View();
        }
        public ActionResult Refer()
        {
            return View();
        }

      
    }
}