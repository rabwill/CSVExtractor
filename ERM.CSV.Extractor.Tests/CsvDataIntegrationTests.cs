using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using ERM.CSV.Extractor.Common;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ERM.CSV.Extractor.Tests
{
    [TestClass]
    public class CsvDataIntegrationTests
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _filepath;
        private readonly string _percentage;

        public  CsvDataIntegrationTests()
        {
            _filepath = ConfigurationManager.AppSettings["FilePath"];
            _percentage =ConfigurationManager.AppSettings["Percentage"];
        }

        [TestMethod]
        public void Check_if_appsetting_filepath_is_correct()
        {
            var reader = Directory.EnumerateFiles(_filepath);
            Assert.IsNotNull(reader);
        }
        [TestMethod]
        public void Check_if_appsetting_percentage_is_a_number()
        {
            Assert.IsTrue(int.TryParse(_percentage, out int number));
        }
        [TestMethod]
        public void check_if_lp_tou_files_are_present()
        {
            var files = Directory.EnumerateFiles(_filepath)
                .OrderByDescending(filename => filename).Where(w => w.Contains(Constants.FileType.LP)|| w.Contains(Constants.FileType.TOU)).ToList();
            Assert.IsTrue(files.Count>0);
        }
        [TestMethod]
        public void check_if_lp_file_header_has_datavalue()
        {
            var file = Directory
                .EnumerateFiles(_filepath)
                .OrderByDescending(filename => filename).First(w => w.Contains(Constants.FileType.LP));
            string currentFileValue = File.ReadAllLines(file).First();
            string[] values = currentFileValue.Split(',');
            Assert.AreEqual("Data Value",values[5]);
        }
        [TestMethod]
        public void check_if_tou_file_header_has_energy()
        {
            var file = Directory
                .EnumerateFiles(_filepath)
                .OrderByDescending(filename => filename).First(w => w.Contains(Constants.FileType.TOU));
            string currentFileValue = File.ReadAllLines(file).First();
            string[] values = currentFileValue.Split(',');
            Assert.AreEqual("Energy", values[5]);
        }
        [TestMethod]
        public void check_if_datavalue_is_decimal()
        {
            var file = Directory.EnumerateFiles(_filepath).OrderByDescending(filename => filename).First(w => w.Contains(Constants.FileType.LP));
            string currentFileValue = File.ReadAllLines(file).Skip(1).First();
            string[] values = currentFileValue.Split(',');
            
            Assert.IsTrue(decimal.TryParse(values[5], out decimal number));
        }
        [TestMethod]
        public void check_if_energy_is_decimal()
        {
            var file = Directory
                .EnumerateFiles(_filepath)
                .OrderByDescending(filename => filename).First(w => w.Contains(Constants.FileType.TOU));
            string currentFileValue = File.ReadAllLines(file).Skip(1).First();
            string[] values = currentFileValue.Split(',');
          
            Assert.IsTrue(decimal.TryParse(values[5], out decimal number));
        }
        [TestMethod]
        public void check_if_lp_tou_files_have_dateandtime()
        {
            var file = Directory
                .EnumerateFiles(_filepath).OrderByDescending(filename => filename).First(w => w.Contains(Constants.FileType.LP) || w.Contains(Constants.FileType.TOU));
            string currentFileValue = File.ReadAllLines(file).Skip(1).First();
            string[] values = currentFileValue.Split(',');
            Assert.IsTrue(DateTime.TryParse(values[3], out DateTime dt));

        }
        //todo:check all the other properties which are not string 



    }
}
