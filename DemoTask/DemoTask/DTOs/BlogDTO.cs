using DemoTask.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoTask.DTOs
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Blog { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; }

        public BlogDTO() { 
            Comments = new List<CommentDTO>();
        }
    }
}