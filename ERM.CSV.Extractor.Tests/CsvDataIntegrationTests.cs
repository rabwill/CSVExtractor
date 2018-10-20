using System;
using System.Collections.Generic;
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
            Assert.AreEqual("Data Value", values[5]);
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
        public void check_if_datavalue_is_double()
        {
            var file = Directory.EnumerateFiles(_filepath).OrderByDescending(filename => filename).First(w => w.Contains(Constants.FileType.LP));
            List<string> currentFileValue = File.ReadAllLines(file).Skip(1).ToList();
            Assert.IsNotNull(currentFileValue);
            foreach (var filevalue in currentFileValue)
            {
                string[] values = filevalue.Split(',');
                Assert.IsTrue(double.TryParse(values[5], out double number));
            }
           
        }
        [TestMethod]
        public void check_if_energy_is_decimal()
        {
            var files = Directory
                .EnumerateFiles(_filepath)
                .OrderByDescending(filename => filename).First(w => w.Contains(Constants.FileType.TOU));
            List<string> currentFileValue = File.ReadAllLines(files).Skip(1).ToList();
            Assert.IsNotNull(currentFileValue);
            foreach (var filevalue in currentFileValue)
            {
                string[] values = filevalue.Split(',');
                Assert.IsTrue(double.TryParse(values[5], out double number));
            }
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
