using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM.CSV.Extractor
{
     class FileExtractor
    {
        private IFileModel _extract;
        public void GetValuesFallingAboveBelowMedianPercentage(IFileModel myFileExtract, string filePath,int percentage)
        {
            _extract = myFileExtract;
            _extract.ExtractAndProcessFiles(filePath, percentage);
        }
    }
}
