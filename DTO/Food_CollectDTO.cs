using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zerohungy.DTO
{
    public class Food_CollectDTO
    {
        public int C_ID { get; set; }
        public Nullable< int> REST_ID { get; set; }
        public string PRESERVE_TIME { get; set; }
        public string LOCATION { get; set; }
        public string STATUS { get; set; }
    }
}