using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Classes
{
    internal class TOUEntity : TOUFile
    {
        public static TOUFile _TOUFileEntity { get; set; }
        public TOUEntity()
        {
            _TOUFileEntity = new TOUFile();
        }

        internal static TOUFile GetTOUFileEntityByCSVDataRow(string csvLine)
        {
           
                string[] values = csvLine.Split(',');
                _TOUFileEntity = new TOUFile
                {
                    MeterPointCode = Convert.ToDouble(values[0]),
                    SerialNumber = Convert.ToDouble(values[1]),
                    PlantCode = Convert.ToString(values[2]),
                    DateAndTime = Convert.ToDateTime(values[3]),
                    DataType = Convert.ToString(values[4]),
                    Energy = Convert.ToDecimal(values[5]),
                    MaximumDemand = Convert.ToDouble(values[6]),
                    TimeOfMaximumDemand = Convert.ToDateTime(values[7]),
                    Units = Convert.ToString(values[8]),
                    Status = Convert.ToString(values[9]),
                    Period = Convert.ToString(values[10]),
                    DLSActive = Convert.ToBoolean(values[11]),
                    BillingResetCount = Convert.ToDouble(values[12]),
                    BillingResetDateTime = Convert.ToDateTime(values[13]),
                    Rate = Convert.ToString(values[14]),
                };
                return _TOUFileEntity;


            
        }
    }
}
