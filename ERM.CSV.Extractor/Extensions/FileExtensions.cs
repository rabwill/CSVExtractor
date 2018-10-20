using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ERM.CSV.Extractor.Common;
using ERM.CSV.Extractor.Utils;

namespace ERM.CSV.Extractor.Extensions
{
   public static class FileExtensions
    {
        /// <summary>
        /// Using Reflection!! don't be alarmed but it  Gets the property of a generic list based on the name passed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static dynamic GetPropertyValue<T>(this T obj, string name) where T : class
        {
            var t = typeof(T);
            return t.GetProperty(name)?.GetValue(obj, null);
        }

        /// <summary>
        /// Processes the list of extracted file items to calculate the business logic and create messages to be displayed in the console.
        /// For each file, calculate the median value using a) the "Data Value" column for the "LP" file type or
        /// b) or the "Energy" column for the "TOU" file type;Find values that are x% above or below the median, and print to the console 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentFileValues"></param>
        /// <param name="file"></param>
        /// <param name="compareColumn"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static List<string> CheckAndPrintValuesThatFallWithinRange<T>(List<T> currentFileValues, string file, string compareColumn,int percentage) where T : class
        {
            var messages = new List<string>();
            try
            {
                var listAllDataValues = currentFileValues.Select(a => a.GetPropertyValue(compareColumn)).ToList();

                //calculate median using math helper
                var median = listAllDataValues.GetMedian();
                var percentofMedian = MathHelper.CalculatePercentageValue(median, percentage);

                //Rounding to 3 to calculate the above and below margin values
                var above = (percentofMedian + median);
                var below = (median - percentofMedian);

                //Find values that are x% above the median 
               IEnumerable<T> aboveMedianList = (from a in currentFileValues.OrderBy(col => col.GetPropertyValue(compareColumn))
                                                 where (a.GetPropertyValue(compareColumn) != 0) &&
                          (a.GetPropertyValue(compareColumn) >= above)
                    select a).ToList();
            
                foreach (var values in aboveMedianList)
                    messages.Add(
                        $"For file {file} on datetime {values.GetPropertyValue(Constants.ColumnName.DateandTime)} - the median is {median} and the {percentage}% above value is {values.GetPropertyValue(compareColumn)} \n");
               
                //Find values that are x% below the median 
                IEnumerable<T> belowMedianList = (from a in currentFileValues.OrderBy(col=>col.GetPropertyValue(compareColumn))
                                                  where (a.GetPropertyValue(compareColumn) != 0) &&
                          (a.GetPropertyValue(compareColumn) <= below)
                    select a).ToList();

                foreach (var values in belowMedianList)
                    messages.Add(
                        $"For file {file} on datetime {values.GetPropertyValue(Constants.ColumnName.DateandTime)} - the median is {median} and the {percentage}%  below value is {values.GetPropertyValue(compareColumn)} \n");
            }
            catch (Exception ex)
            {
                ConsolePrinter.RoutineTryCatchLog(ex, nameof(CheckAndPrintValuesThatFallWithinRange));
            }

            return messages;

        }
    }
}
