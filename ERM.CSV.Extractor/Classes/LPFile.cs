using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Classes
{
    internal class LPFile
    {
        public double MeterPointCode { get; set; }
        public double SerialNumber { get; set; }
        public string PlantCode { get; set; }
        public DateTime DateAndTime { get; set; }
        public string DataType { get; set; }
        public double DataValue { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }


        internal static LPFile GetLpFileEntityByCsvDataRow(string csvLine)
        {
            string[] values = csvLine.Split(',');
            var lpfileItem = new LPFile
            {
                MeterPointCode = double.Parse(values[0]),
                SerialNumber = double.Parse(values[1]),
                PlantCode = Convert.ToString(values[2]),
                DateAndTime = DateTime.Parse(values[3]),
                DataType = Convert.ToString(values[4]),
                DataValue = double.Parse(values[5]),
                Units = Convert.ToString(values[6]),
                Status = Convert.ToString(values[7]),
            };
            return lpfileItem;
        }

    }
}

