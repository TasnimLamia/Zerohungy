using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zerohungy.DTO
{
    public class HistoryDTO
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
    }
}