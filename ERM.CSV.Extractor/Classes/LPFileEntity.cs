using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Classes
{
    internal class LPFileEntity:LPFile
    {
        public static LPFile _LPFileEntity { get; set; }
        public LPFileEntity()
        {
            _LPFileEntity = new LPFile();
        }

        internal static LPFile GetLPFileEntityByCsvDataRow(string csvLine)
        {


            string[] values = csvLine.Split(',');

            _LPFileEntity = new LPFile
            {
                MeterPointCode = Convert.ToDouble(values[0]),
                SerialNumber = Convert.ToDouble(values[1]),
                PlantCode = Convert.ToString(values[2]),
                DateAndTime = Convert.ToDateTime(values[3]),
                DataType = Convert.ToString(values[4]),
                DataValue = Convert.ToDecimal(values[5]),
                Units = Convert.ToString(values[6]),
                Status = Convert.ToString(values[7]),
            };
            
            return _LPFileEntity;
        }

       


    }
}
