using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace ERM.CSV.Extractor.Classes
{
    class LoggerHelper
    {
        public static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogInfo(string message)
        {
            Log.Info(message);
        }
        public static void LogError(string message)
        {
            Log.Error(message);
        }
        public static void LogWarning(string message)
        {
            Log.Warn(message);
        }
    }
}
