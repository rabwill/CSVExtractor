using ERM.CSV.Extractor.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ERM.CSV.Extractor.Common;


namespace ERM.CSV.Extractor.Classes
{
    public class TouFileModel : BaseFileModel<TOUFile>
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
                foreach (var file in GetFiles(filePath, Constants.FileType.TOU))
                {
                    var currentFileValues = GetValuesFromFile(file, TOUFile.MapCsvLineItemsToTouList);
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
        public List<string> MapValuesFromFileAndPrintEligibleValues(int percentage, string filename, List<TOUFile> currentFileValues) => CheckAndPrintValuesThatFallWithinRange(currentFileValues, filename, percentage);
        /// <summary>
        /// Energy is the key column to compare
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected override double GetComparisonValue(TOUFile line) => line.Energy;
        /// <summary>
        /// Get data time for display purpose
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected override DateTime GetDateTimeValue(TOUFile line) => line.DateAndTime;
    }

}
