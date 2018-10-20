using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor
{
    interface IFileModel
    {
        void ExtractAndProcessFiles(string filePath,int percentage);
    }
}
