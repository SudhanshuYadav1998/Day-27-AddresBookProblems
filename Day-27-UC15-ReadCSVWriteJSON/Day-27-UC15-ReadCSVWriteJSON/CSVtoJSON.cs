using CsvHelper;
using CSVHELPERandJson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_27_UC15_ReadCSVWriteJSON
{
    class ReadCSVWriteCSV
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = "C:\\RFP\\C_sharp\\Day-27-UC15-ReadCSVWriteJSON\\Day-27-UC15-ReadCSVWriteJSON\\Utility\\Addresses.csv";
            string exportFilePath = "C:\\RFP\\C_sharp\\Day-27-UC15-ReadCSVWriteJSON\\Day-27-UC15-ReadCSVWriteJSON\\Utility\\Export.csv";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses csv.");
                foreach (AddressData addressData in records)
                {
                    Console.Write("\t" + addressData.firstname);
                    Console.Write("\t" + addressData.lastname);
                    Console.Write("\t" + addressData.address);
                    Console.Write("\t" + addressData.city);
                    Console.Write("\t" + addressData.state);
                    Console.Write("\t" + addressData.code);
                    Console.WriteLine();
                }
                Console.WriteLine("**********************Reading fromcsv file and Write to json file **************************");

                //Writing json file
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }


}

