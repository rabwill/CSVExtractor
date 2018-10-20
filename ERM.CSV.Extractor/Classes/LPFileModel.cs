using ERM.CSV.Extractor.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ERM.CSV.Extractor.Common;

using log4net;

namespace ERM.CSV.Extractor.Classes
{
    internal class LpFileModel : BaseFileModel<LPFile>
    {
        /// <summary>
        /// Extracts files based on the type and process the data to finally print the messages for items that satisfy the business logic
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="percentage"></param>

        public override void ExtractAndProcessFiles(string filePath, int percentage)
        {
            LoggerHelper.LogInfo($"Processing the file in class LpFileModel to extract and print in {nameof(ExtractAndProcessFiles)}");
            try
            {
                foreach (var file in GetFiles(filePath, Constants.FileType.LP))
                {
                    var currentFileValues = GetValuesFromFile(file, LPFile.GetLpFileEntityByCsvDataRow);
                    ConsolePrinter.PrintOutput(CheckAndPrintValuesThatFallWithinRange(currentFileValues, StringHelper.GetFileNameFromPath(file), percentage));
                   }
            }
            catch (Exception ex)
            {
                ConsolePrinter.RoutineTryCatchLog(ex, MethodBase.GetCurrentMethod().Name);
            }
        }

        protected override double GetComparisonValue(LPFile line) => line.DataValue;
    
        protected override DateTime GetDateTimeValue(LPFile line)=>line.DateAndTime;

      
    }
}
