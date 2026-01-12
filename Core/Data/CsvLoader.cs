using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace Postal_Management_System.Core.Data
{
    public class CsvLoader
    {
        public static List<T> ReadCsv<T>(string filePath,ClassMap? map=null) where T:class{

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' was not found.");
            }
            Console.WriteLine("Loading CSV file...");

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
            };
            try
            {
                using var reader = new StreamReader(filePath); //open the csv file
                using var csv = new CsvReader(reader, config); //reads the csv file

                if(map != null)
                {
                    csv.Context.RegisterClassMap(map.GetType()); //maps fields to class fields
                }
                var records= new List<T>();
                foreach (var record in csv.GetRecords<T>()) {
                    // Find the primary key property dynamically
                    var keyProperty = typeof(T).GetProperties()
                                               .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null
                                                                 || p.GetCustomAttribute<DatabaseGeneratedAttribute>() != null);
                    if (keyProperty != null)
                    {
                        var keyValue = keyProperty.GetValue(record);
                        if (keyValue == null || string.IsNullOrWhiteSpace(keyValue.ToString()))
                        {
                            Console.WriteLine($"Skipping record with null primary key in {typeof(T).Name}");
                            continue;
                        }
                    }

                    records.Add(record);
                }
                return records;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                return new List<T>();  // Return empty list in case of failure
            }
           

           // csv.Read();  // Read first row (header)
            //csv.ReadHeader();  // Move past the header

           

        }
    }
}
