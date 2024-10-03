using introAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace introAPI.Controllers
{

    public class StudentController : ApiController
    {
        StudentsEntities db = new StudentsEntities();

        [HttpGet]
        [Route("api/student/allstudent")]

        public HttpResponseMessage AllStudents()
        {
            var data = db.Students.ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/student/{id}")]
        public HttpResponseMessage singleStudent(int id) 
        {
            var data = db.Students.Find(id);

            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
        [HttpPost]
        [Route("api/student/create")]
        public HttpResponseMessage createStudent(Student s)
        {

             db.Students.Add(s);
            db.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK,"created");
        }


        [HttpGet]
        [Route("api/student/delete/{id}")]
        public HttpResponseMessage deleteStudent(int id)
        {
            var data = db.Students.Find(id);
            db.Students.Remove(data);
            db.SaveChanges();


            return Request.CreateResponse(HttpStatusCode.OK,id+"is deleted");
        }

    }
}
