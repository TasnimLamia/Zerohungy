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
    
    public partial class Food_Collect
    {
        public int C_ID { get; set; }
        public Nullable<int> REST_ID { get; set; }
        public string PRESERVE_TIME { get; set; }
        public string LOCATION { get; set; }
        public string STATUS { get; set; }
    
        public virtual Resturant Resturant { get; set; }
    }
}