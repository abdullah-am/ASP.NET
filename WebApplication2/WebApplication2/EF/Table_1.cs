//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_1
    {
        public int id { get; set; }
        public string name { get; set; }
        public int cid { get; set; }
    
        public virtual Table_1 Table_11 { get; set; }
        public virtual Table_1 Table_12 { get; set; }
    }
}
