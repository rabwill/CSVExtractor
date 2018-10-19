using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor
{
     class Extractor
    {
        private IExtractor _extract;

        public void DoExtraction(IExtractor myFileExtract, string _filePath,int _percentage)
        {
            _extract = myFileExtract;
            _extract.Extract(_filePath, _percentage);
        }
    }
}
