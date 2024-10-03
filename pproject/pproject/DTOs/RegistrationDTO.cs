using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pproject.DTOs
{
    public class RegistrationDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string uname { get; set; }
        public string password { get; set; }
        public string dob { get; set; }
    }
}