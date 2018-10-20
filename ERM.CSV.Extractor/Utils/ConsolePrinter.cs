using log4net;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ERM.CSV.Extractor.Classes;

namespace ERM.CSV.Extractor.Utils
{
    class ConsolePrinter
    {
      
        /// <summary>
        /// Prints messages to console window from a list of messages
        /// </summary>
        /// <param name="messages"></param>
        internal static void PrintOutput(List<string> messages)
        {
           if(messages.Count>0)
           {
               foreach (var message in messages)
               {
                   Console.ForegroundColor = ConsoleColor.Yellow;
                   Console.Write(message);

                }
            }
           else
           {
               Console.ForegroundColor = ConsoleColor.Green;
               Console.Write("It's pretty lonely in here , get me some more data to process..");
            }
        }

        internal static void PrintRegularMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
        }
        internal static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Oh snap!-"+message);
        }
        internal static void RoutineTryCatchLog(Exception ex)
        {
            PrintError(ex.Message);
            LoggerHelper.LogError($"There has been an issue in {MethodBase.GetCurrentMethod()}- {ex.Message}");
            Console.ReadKey();
        }
        
    }
}
