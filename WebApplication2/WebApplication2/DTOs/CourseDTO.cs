using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CreditHour { get; set; }

        public string Type { get; set; }
    }
}