using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

    }
}