using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ERM.CSV.Extractor.Classes;
using ERM.CSV.Extractor.Utils;

namespace ERM.CSV.Extractor.Tests.Classes
{
    
    class MockFile
    {
        public static List<LPFile> GetMockLpFileData()
        {
            return  new List<LPFile>
            {
                new LPFile
                {
                    DataValue = 2.0003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210095893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh"
                },
                new LPFile
                {
                    DataValue = 3.0003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210095873, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh"
                },
                new LPFile
                {
                    DataValue = 4.0003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210096893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh"
                },
                new LPFile
                {
                    DataValue = 2.50003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 215095893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh"
                },
                new LPFile
                {
                    DataValue = 5.50003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210055893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh"
                },
                new LPFile
                {
                    DataValue = 6.50003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210495893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh"
                }
            };
        }
        public static List<TOUFile> GetMockTouFileData()
        {
            return new List<TOUFile>
            {
                new TOUFile
                {
                    Energy = 2.0003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210095893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh",BillingResetCount = 222,BillingResetDateTime =  DateTime.Parse("31/08/2015 00:45:00"),
                    DLSActive = true,MaximumDemand = 2,Period = "",Rate = "",TimeOfMaximumDemand = DateTime.Parse("31/08/2015 00:45:00")
                },
                new TOUFile
                {
                    Energy = 3.0003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210095873, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh",BillingResetCount = 222,BillingResetDateTime =  DateTime.Parse("31/08/2015 00:45:00"),
                    DLSActive = true,MaximumDemand = 2,Period = "",Rate = "",TimeOfMaximumDemand = DateTime.Parse("31/08/2015 00:45:00")
                },
                new TOUFile
                {
                    Energy = 4.0003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210096893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh",BillingResetCount = 222,BillingResetDateTime =  DateTime.Parse("31/08/2015 00:45:00"),
                    DLSActive = true,MaximumDemand = 2,Period = "",Rate = "",TimeOfMaximumDemand = DateTime.Parse("31/08/2015 00:45:00")
                },
                new TOUFile
                {
                    Energy = 2.50003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 215095893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh",BillingResetCount = 222,BillingResetDateTime =  DateTime.Parse("31/08/2015 00:45:00"),
                    DLSActive = true,MaximumDemand = 2,Period = "",Rate = "",TimeOfMaximumDemand = DateTime.Parse("31/08/2015 00:45:00")
                },
                new TOUFile
                {
                    Energy = 5.50003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210055893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh",BillingResetCount = 222,BillingResetDateTime =  DateTime.Parse("31/08/2015 00:45:00"),
                    DLSActive = true,MaximumDemand = 2,Period = "",Rate = "",TimeOfMaximumDemand = DateTime.Parse("31/08/2015 00:45:00")
                },
                new TOUFile
                {
                    Energy = 6.50003, DateAndTime = DateTime.Parse("31/08/2015 00:45:00"), DataType = "Import Wh Total",
                    MeterPointCode = 210495893, PlantCode = "ED031000001", SerialNumber = 210095893, Status = "",
                    Units = "kwh",BillingResetCount = 222,BillingResetDateTime =  DateTime.Parse("31/08/2015 00:45:00"),
                    DLSActive = true,MaximumDemand = 2,Period = "",Rate = "",TimeOfMaximumDemand = DateTime.Parse("31/08/2015 00:45:00")
                }
            };
        }

    }
}
