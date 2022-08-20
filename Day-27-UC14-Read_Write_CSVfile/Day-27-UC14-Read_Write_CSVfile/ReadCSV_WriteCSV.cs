using CsvHelper;
using Day_27_UC14_Read_Write_CSVfile.CSVHELPERandJson;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVHELPERandJson
{
    class CSVHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"C:\RFP\C_sharp\Day-27-UC14-Read_Write_CSVfile\Day-27-UC14-Read_Write_CSVfile\Utility\AddressData.csv";
            string exportFilePath = @"C:\RFP\C_sharp\Day-27-UC14-Read_Write_CSVfile\Day-27-UC14-Read_Write_CSVfile\Utility\Export.csv";

            //reading csv file
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
                Console.WriteLine("**********************Reading fromcsv file and Write to csv file **************************");
                //Writing csv file

                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
                Console.WriteLine("Record inserted successfully in file in CSV format");
            }
        }


    }


}
