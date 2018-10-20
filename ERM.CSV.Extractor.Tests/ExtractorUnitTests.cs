using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ERM.CSV.Extractor.Classes;

using ERM.CSV.Extractor.Tests.Classes;
using ERM.CSV.Extractor.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERM.CSV.Extractor.Tests
{
    
    [TestClass]
    public class ExtractorUnitTests
    {
        [TestMethod]
        public void Check_Eligible_Values_For_LP_Items()
        {
            LpFileModel lp=new LpFileModel();
            Assert.IsNotNull(lp.MapValuesFromFileAndPrintEligibleValues(20, "LPFile", MockFile.GetMockLpFileData()));
        }
        [TestMethod]
        public void Check_Eligible_Values_For_TOU_Items()
        {
            TouFileModel tou = new TouFileModel();
            Assert.IsNotNull(tou.MapValuesFromFileAndPrintEligibleValues(20, "TOUFile", MockFile.GetMockTouFileData()));
        }

        [TestMethod]
        public void check_fn_get_file_name_from_path()
        {
            string fileFullname = "D:\\files\\LP_210095893_20150901T011608049.csv";
            string filename = StringHelper.GetFileNameFromPath(fileFullname);
            Assert.AreEqual(filename, "LP_210095893_20150901T011608049");
        }
       
        [TestMethod]
        public void check_median_from_list()
        {
            double[] values = { 1, 3,2, 5,4 };

            List<double> listvalues = values.Select(i => Convert.ToDouble(i)).ToList();
            var median = listvalues.GetMedian();
            Assert.AreEqual(3,median);
        }

      
        [TestMethod]
        public void check_datavalue_in_lp_class()
        {
            var type = typeof(LPFile);
            var property = type.GetProperty("DataValue");
            Assert.IsNotNull(property);
        }
        [TestMethod]
        public void check_energy_in_tou_class()
        {
            var type = typeof(TOUFile);
            var property = type.GetProperty("Energy");
            Assert.IsNotNull(property);
        }
        [TestMethod]
        public void check_dateandtime_in_lp_class()
        {
            var type = typeof(LPFile);
            var property = type.GetProperty("DateAndTime");
            Assert.IsNotNull(property);
        }
        [TestMethod]
        public void check_dateandtime_in_tou_class()
        {
            var type = typeof(TOUFile);
            var property = type.GetProperty("DateAndTime");
            Assert.IsNotNull(property);
        }

        //todo: similarly do for all properties used in any other function to make sure these names are not changed- here 3 columns which are referred in processing functions CheckAndPrintValuesThatFallWithinRange


    }
}
