//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zerohungy.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int Serial_no { get; set; }
        public Nullable<int> C_ID { get; set; }
        public Nullable<int> REST_ID { get; set; }
        public string PRESERVE_TIME { get; set; }
        public string LOCATION { get; set; }
        public Nullable<int> Approved_by { get; set; }
        public Nullable<int> Received_by { get; set; }
        public Nullable<System.DateTime> Approve_Date { get; set; }
        public string STATUS { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Resturant Resturant { get; set; }
        public virtual Moderator Moderator { get; set; }
        public virtual Resturant Resturant1 { get; set; }
    }
}
