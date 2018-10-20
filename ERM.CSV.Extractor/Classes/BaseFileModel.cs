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

        protected List<T> GetValuesFromFile(string file, Func<string, T> creator)
        {
            return File.ReadAllLines(file)
                .Skip(1)
                .Select(creator)
                .ToList();
        }

        protected static string GetFileNameFromPath(string fullFilename) => Path.GetFileNameWithoutExtension(fullFilename);

        protected IEnumerable<string> GetFiles(string filePath, string fileType)
        {
            return Directory.EnumerateFiles(filePath)
                .OrderByDescending(filename => filename)
                .Where(w => w.Contains(fileType));
        }


        protected abstract double GetComparisonValue(T line);

        protected abstract DateTime GetDateTimeValue(T line);

        private IEnumerable<T> GetEligibleValuesTooPrint(IEnumerable<T> lines, double median, double percentofMedian)
        {
            return from a in lines.OrderBy(GetComparisonValue)
                where !MathHelper.CheckNearlyEquals(GetComparisonValue(a), 0) &&
                      MathHelper.CheckNearlyEquals(median - GetComparisonValue(a), percentofMedian)
                   select a;
        }

        public List<string> CheckAndPrintValuesThatFallWithinRange(List<T> currentFileValues, string file, int percentage)
        {
            var messages = new List<string>();
            try
            {
                //calculate median using math helper
                var median = currentFileValues.Select(GetComparisonValue).GetMedian();
                var percentofMedian = MathHelper.CalculatePercentageValue(median, percentage);

                //Find values that are x% above/below the median 
                messages.AddRange(GetEligibleValuesTooPrint(currentFileValues, median, percentofMedian)
                    .Select(values => $"For file {file} on datetime {GetDateTimeValue(values)} - the median is {median} and the {percentage}% above/below value is {GetComparisonValue(values)} \n"));

              }
            catch (Exception ex)
            {
                ConsolePrinter.RoutineTryCatchLog(ex, MethodBase.GetCurrentMethod().Name);
            }

            return messages;

        }

    }
}
