//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebHotel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public int id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string description { get; set; }
        public string detail { get; set; }
        public string link { get; set; }
        public string meta { get; set; }
        public Nullable<bool> hide { get; set; }
        public Nullable<int> order { get; set; }
        public Nullable<System.DateTime> datebegin { get; set; }
    }
}
