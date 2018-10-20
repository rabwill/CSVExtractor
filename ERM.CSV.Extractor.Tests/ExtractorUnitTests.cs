using System;
using System.Collections.Generic;
using System.Linq;
using ERM.CSV.Extractor.Classes;
using ERM.CSV.Extractor.Extensions;
using ERM.CSV.Extractor.Tests.Classes;
using ERM.CSV.Extractor.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERM.CSV.Extractor.Tests
{
    [TestClass]
    public class ExtractorUnitTests
    {
        internal static List<MockFile> Mockitems{ get;set; }
        public ExtractorUnitTests()
        {
             Mockitems = new List<MockFile>(){
                new MockFile() {
                    MockObject1 = "Object 11",
                    MockObject2 = "Object 11",
                },
                new MockFile() {
                    MockObject1 = "Object 21",
                    MockObject2 = "Object 22",
                }
            };
        }

        [TestMethod]
        public void check_fn_get_file_name_from_path()
        {
            string fileFullname = "D:\\files\\LP_210095893_20150901T011608049.csv";
            string filename = StringHelper.GetFileNameFromPath(fileFullname);
            Assert.AreEqual(filename, "LP_210095893_20150901T011608049");
        }
        [TestMethod]
        public void check_Get_Property_function_for_class()
        {
            var listAllDataValues = Mockitems.Select(a => a.GetPropertyValue("MockObject1")).ToList();
            Assert.IsNotNull(listAllDataValues);
          
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
        public void check_twenty_percent_increase_from_median()
        {
            double[] values = { 1, 2, 3, 2.5,4 };

            List<double> listvalues = values.Select(i => Convert.ToDouble(i)).ToList();
            var median = listvalues.GetMedian();
            var percentofMedian = MathHelper.CalculatePercentageValue(median, 20);
            var above = Math.Round((percentofMedian + median), 3);
            Assert.AreEqual(2.5, median);
            Assert.AreEqual(above,3);


        }
        [TestMethod]
        public void check_twenty_percent_decrease_from_median()
        {
            double[] values = { 1, 2, 3, 2.5, 4 };

            List<double> listvalues = values.Select(i => Convert.ToDouble(i)).ToList();
            var median = listvalues.GetMedian();
            var percentofMedian = MathHelper.CalculatePercentageValue(median, 20);
            var above = Math.Round((median - percentofMedian), 3);
            Assert.AreEqual(2.5, median);
            Assert.AreEqual(above, 2);


        }


    }
}
