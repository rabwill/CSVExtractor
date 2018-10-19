using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Utils
{
    public static class StringHelper
    {
       public static string GetFileNameFromPath(string fullFilename)
        {
           return System.IO.Path.GetFileNameWithoutExtension(fullFilename);
        }
    }
}
