using ERM.CSV.Extractor.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ERM.CSV.Extractor.Common;
using ERM.CSV.Extractor.Extensions;
using log4net;

namespace ERM.CSV.Extractor.Classes
{
    internal class LpFileModel : IFileModel
    {
       
        /// <summary>
        /// Extracts files based on the type and process the data to finally print the messages for items that satisfy the business logic
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="percentage"></param>
        public void ExtractAndProcessFiles(string filePath,int percentage)
        {
            LoggerHelper.LogInfo($"Processing the file to extract and print in {MethodBase.GetCurrentMethod()}");
            try
            {
                var files = Directory.EnumerateFiles(filePath)
                    .OrderByDescending(filename => filename).Where(w => w.Contains(Constants.FileType.LP)).ToList();
                var messages = new List<string>();
                foreach (var file in files)
                {
                    var currentFileValues = File.ReadAllLines(file).Skip(1).Select(LPFile.GetLpFileEntityByCsvDataRow)
                        .ToList();
                    string filename = StringHelper.GetFileNameFromPath(file);
                    messages = FileExtensions.CheckAndPrintValuesThatFallWithinRange(currentFileValues, filename,
                        Constants.ColumnName.DataValue, percentage);
                }

                ConsolePrinter.PrintOutput(messages);
            }
            catch (Exception ex)
            {
                ConsolePrinter.RoutineTryCatchLog(ex);
                throw;
            }
        }

       
    }
}
