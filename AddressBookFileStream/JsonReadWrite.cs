using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AddressBookFileStream
{
    class JsonReadWrite
    {
        /// <summary>
        /// Reads data from Json file.
        /// </summary>
        public void JsonReadData()
        {
            string jsonFilePath = @"C:\Users\Chetan\source\repos\AddressBookFileStream\AddressBookFileStream\Files\ContactData.json";
            ///Opens a text file and retruns a string containing the text files.
            JObject jsonObj = JObject.Parse(File.ReadAllText(jsonFilePath));
            ///creating a JToken file from the available filepath.
            using (StreamReader file = File.OpenText(jsonFilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                ///typecasting the JToken object to a JObject object and reading the values from it.
                JObject obj = (JObject)JToken.ReadFrom(reader);
                foreach (var element in obj)
                {
                    Console.WriteLine(element.Value);
                }
            }
        }
        /// <summary>
        /// Taking input from the user and writing data to a json file.
        /// </summary>
        public void JSonWriteData()
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
            AddressBook addressBookMain = new AddressBook(firstName, lastName, address, state, zip, phone, email);
            string jsonFilePath = @"C:\Users\Chetan\source\repos\AddressBookFileStream\AddressBookFileStream\Files\ContactData.json";
            JsonSerializer jsonSerializer = new JsonSerializer();
            var writer = new StreamWriter(jsonFilePath);
            jsonSerializer.Serialize(writer, addressBookMain);
            writer.Flush();
        }
    }
}
