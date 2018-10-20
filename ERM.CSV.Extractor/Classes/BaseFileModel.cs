using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ERM.CSV.Extractor.Utils;

namespace ERM.CSV.Extractor.Classes
{
    public abstract class BaseFileModel<T> : IFileModel
    {
       
        public abstract void ExtractAndProcessFiles(string filePath, int percentage);

        /// <summary>
        /// The function parses the file to read the line items skipping the header
        /// </summary>
        /// <param name="file"></param>
        /// <param name="creator"></param>
        /// <returns></returns>
        protected List<T> GetValuesFromFile(string file, Func<string, T> creator)
        {
            return File.ReadAllLines(file)
                .Skip(1)
                .Select(creator)
                .ToList();
        }
       /// <summary>
       /// Gets file from path based on what type of file is to be considered for processing
       /// </summary>
       /// <param name="filePath"></param>
       /// <param name="fileType"></param>
       /// <returns></returns>
        protected IEnumerable<string> GetFiles(string filePath, string fileType)
        {
            return Directory.EnumerateFiles(filePath)
                .OrderByDescending(filename => filename)
                .Where(w => w.Contains(fileType));
        }

        /// <summary>
        /// abstract of function to get a particular property which is to be compared
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected abstract double GetComparisonValue(T line);
        /// <summary>
        /// Get dateTime value
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        protected abstract DateTime GetDateTimeValue(T line);
        /// <summary>
        /// Gets the list of all items above or below the range
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="median"></param>
        /// <param name="percentofMedian"></param>
        /// <returns></returns>
        private IEnumerable<T> GetEligibleValuesToPrint(IEnumerable<T> lines, double median, double percentofMedian)
        {
            //Checking the values which are not nearly zero and also falls in the range x% above or below
            return from a in lines.OrderBy(GetComparisonValue)
                where !MathHelper.CheckNearlyEquals(GetComparisonValue(a), 0) &&
                      MathHelper.CheckNearlyEquals(Math.Abs(median-GetComparisonValue(a)), percentofMedian)
                   select a;
        }
        /// <summary>
        ///
        /// Core function that gets the eligible range list and prints them
        /// </summary>
        /// <param name="currentFileValues"></param>
        /// <param name="file"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public List<string> CheckAndPrintValuesThatFallWithinRange(List<T> currentFileValues, string file, int percentage)
        {
            var messages = new List<string>();
            try
            {
                //calculate median using math helper
                var median = currentFileValues.Select(GetComparisonValue).GetMedian();
                var percentofMedian = MathHelper.CalculatePercentageValue(median, percentage);
                //Find values that are x% above/below the median 
                messages.AddRange(GetEligibleValuesToPrint(currentFileValues, median, percentofMedian)
                    .Select(values => $"{file}  {GetDateTimeValue(values)}  {GetComparisonValue(values)}   {median}   \n"));
            }
            catch (Exception ex)
            {
                ConsolePrinter.RoutineTryCatchLog(ex, MethodBase.GetCurrentMethod().Name);
            }

            return messages;

        }

    }
}
