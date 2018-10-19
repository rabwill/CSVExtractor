using ERM.CSV.Extractor.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERM.CSV.Extractor.Common;

namespace ERM.CSV.Extractor.Classes
{
    class LPFileExtractor : IExtractor
    {
        /// <summary>
        /// Extracts files based on the type and process the data to finally print the messages for items that satisfy the business logic
        /// </summary>
        /// <param name="_filePath"></param>
        /// <param name="_percentage"></param>
        public void Extract(string _filePath,int _percentage)
        {
          
            var files = Directory.EnumerateFiles(_filePath)
                .OrderByDescending(filename => filename).Where(w => w.Contains(Constants.FileType.LP)).ToList();
            List<string> messages=new List<string>();
            foreach (var file in files)
            {
                List<LPFile> currentFileValues = new List<LPFile>();
                currentFileValues = File.ReadAllLines(file).Skip(1).Select(v => LPFileEntity.GetLPFileEntityByCsvDataRow(v)).ToList();
                string filename = StringHelper.GetFileNameFromPath(file);
                messages = ListHelper.ListProcessor(currentFileValues, filename, Constants.ColumnName.DataValue, _percentage);
            }
            ConsolePrinter.PrintMessages(messages);
        }

       
    }
}
