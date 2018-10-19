using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Classes
{
    class TOUFile
    {
        public double MeterPointCode { get; set; }
        public double SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime DateAndTime { get; set; }
        public string DataType { get; set; }
        public decimal Energy { get; set; }
        public double MaximumDemand { get; set; }
        public DateTime TimeOfMaximumDemand { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
        public string Period { get; set; }
        public Boolean DLSActive { get; set; }
        public double BillingResetCount { get; set; }
        public DateTime BillingResetDateTime { get; set; }
        public string Rate { get; set; }


      

    }
}
