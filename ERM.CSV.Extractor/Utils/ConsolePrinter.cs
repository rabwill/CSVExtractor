using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor.Utils
{
    class ConsolePrinter
    {
        /// <summary>
        /// Prints messages to console window from a list of messages
        /// </summary>
        /// <param name="messages"></param>
        internal static void PrintMessages(List<string> messages)
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
    }
}
