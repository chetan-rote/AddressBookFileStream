using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace AddressBookFileStream
{
    public class CsvReadWrite
    {
        public List<string> addressBook = new List<string>();
        /// <summary>
        /// Reads the data from CSV file.
        /// </summary>
        public void CSVDataReading()
        {
            string csvFilePath = @"C:\Users\Chetan\source\repos\AddressBookFileStream\AddressBookFileStream\Files\ContactData.csv";
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ",";
                var records = csv.GetRecords<AddressBook>();
                foreach (AddressBook address in records)
                {
                    Console.Write("\t" + address.firstName);
                    Console.Write("\t" + address.lastName);
                    Console.Write("\t" + address.address);
                    Console.Write("\t" + address.state);
                    Console.Write("\t" + address.zip);
                    Console.Write("\t" + address.phone);
                    Console.Write("\t" + address.email);
                    Console.WriteLine("\n");
                }
                reader.Close();
            }
        }
        /// <summary>
        /// Writes data to CSV file.
        /// </summary>
        public void CSVDataWriting()
        {
            Console.WriteLine("Enter the first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the city");
            string address = Console.ReadLine();
            Console.WriteLine("Enter state");
            string state = Console.ReadLine();
            Console.WriteLine("Enter the zip");
            string zip = Console.ReadLine();
            Console.WriteLine("Enter the phone number");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the email");
            string email = Console.ReadLine();
            AddressBook addressBook = new AddressBook(firstName, lastName, address, state, zip, phone, email);
            string csvFilePath = @"C:\Users\Chetan\source\repos\AddressBookFileStream\AddressBookFileStream\Files\ContactData.csv";
            using (var writer = new StreamWriter(csvFilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                string record = firstName + "," + lastName + "," + address + "," + state + "," + zip + "," + phone + "," + email;
                csv.WriteHeader<AddressBook>();
                csv.NextRecord();
                csv.WriteRecord<AddressBook>(addressBook);
                writer.Flush();
            }
        }
    }
}