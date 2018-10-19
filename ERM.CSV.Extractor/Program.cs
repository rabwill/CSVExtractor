using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ERM.CSV.Extractor.Classes;
using ERM.CSV.Extractor.Common;
using ERM.CSV.Extractor.Utils;


namespace ERM.CSV.Extractor
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static string FilePath { get; private set; }
        public static int Percentage { get; private set; }

        static void Main(string[] args)
        {
            /* Default Parameters:
             * FilePath - Folder path where the files are e.g   "D:\files"
             * Percentage - what percentage of the median above/below should the application print? e.g "20"
             */
            FilePath = ConfigurationManager.AppSettings["FilePath"];
            Percentage = Convert.ToInt16(ConfigurationManager.AppSettings["Percentage"]);
            /* 
             * Configure the log file for Log4net
             */
           
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            Log.Info($"Configured path for extracting the csv files is- {FilePath} and  Percentage is {Percentage} \n");
            Console.WriteLine($"Configured path for extracting the csv files is- {FilePath} \n");
            Console.WriteLine($"This tool provides functionality to extract LP and TOU files, find values that are {Percentage}% above or below the median, and print to the console  \n");
       
            SelectOptionToRun();
        }
        private static void SelectOptionToRun()
        {
            try
            {
                Console.WriteLine("Please Select");
                Console.WriteLine("\t 1 - Extract only LP files");
                Console.WriteLine("\t 2 - Extract only TOU files");
                Console.WriteLine("\t 3 - Extract all files");
                Console.WriteLine("\t x - Exit");

                ConsoleKeyInfo key;
                do
                {
                    key = Console.ReadKey(true);
                    Log.Info($"Run extraction");
                    switch (key.KeyChar)
                    {
                        case '1':
                            new Extractor().DoExtraction(new LPFileExtractor(), FilePath, Percentage);
                            break;
                        case '2':
                            new Extractor().DoExtraction(new TOUFileExtractor(), FilePath, Percentage);
                            break;
                        case '3':
                        {
                            new Extractor().DoExtraction(new LPFileExtractor(), FilePath, Percentage);
                            new Extractor().DoExtraction(new TOUFileExtractor(), FilePath, Percentage);
                            break;

                        }

                    }
                } while (key.KeyChar != 'x');
            }
            catch (Exception ex)
            {
                ConsolePrinter.RoutineTryCatchLog(ex);
            }
        }

      

        private static string ReadParamaeters(string promptMessage)
        {
            Console.Write(promptMessage);
            return Console.ReadLine();
        }

    }

}
