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
    public class LpFileModel : BaseFileModel<LPFile>
    {
       
        /// <summary>
        /// Extracts files based on the type and process it
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
                    var currentFileValues = GetValuesFromFile(file, LPFile.MapCsvLineItemsToLpList);
                    ConsolePrinter.PrintOutput(MapValuesFromFileAndPrintEligibleValues(percentage, StringHelper.GetFileNameFromPath(file), currentFileValues));
                }
                  
            }
            catch (Exception ex)
            {
                ConsolePrinter.RoutineTryCatchLog(ex, nameof(ExtractAndProcessFiles));
            }
        }

        /// <summary>
        /// Send processed data to be checked and printed- core logic, broken down for better testability
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="file"></param>
        /// <param name="currentFileValues"></param>
        public List<string> MapValuesFromFileAndPrintEligibleValues(int percentage, string filename,List<LPFile> currentFileValues)=>CheckAndPrintValuesThatFallWithinRange(currentFileValues, filename, percentage);
       
        /// <summary>
        /// Data Value is the key column to compare
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected override double GetComparisonValue(LPFile line) => line.DataValue;
        /// <summary>
        /// Get data time for display purpose
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected override DateTime GetDateTimeValue(LPFile line)=>line.DateAndTime;

      
    }
}
