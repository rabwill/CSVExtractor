using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Utils
{
    static class StringHelper
    {
        internal static string GetFileNameFromPath(string fullFilename)
        {
           return System.IO.Path.GetFileNameWithoutExtension(fullFilename);
        }
    }
}
