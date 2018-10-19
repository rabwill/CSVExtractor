using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Utils
{
   public static class MathHelper
    {
        public static T GetMedian<T>(this IEnumerable<T> items)
        {
            var i = (int)Math.Ceiling((double)(items.Count() - 1) / 2);
            if (i >= 0)
            {
                var values = items.ToList();
                values.Sort();
                return values[i];
            }
            return default(T);
        }

        public static double GetPercentofValue(double value,int percentage)
        {
            double divideByHundred = value / 100;
                return (divideByHundred * percentage);
        }
    }
}
