using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AddressBookFileStream
{
    class TextFileStream
    {
        ///List to store contact detail. 
        public List<string> addressBook = new List<string>();

        /// <summary>
        /// The method is used to read the files by giving the path of the file
        /// and reading each text using StreamReader class.
        /// </summary>
        /// <exception cref="Exception">File doesn't exist</exception>
        public void ReadFile()
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookFileStream\AddressBookFileStream\Files\AddressBookData.txt";
            bool flag = File.Exists(path);
            if (flag == true)
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    string s = " ";
                    while ((s = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            else
            {
                throw new Exception("File doesn't exist");
            }
        }
        /// <summary>
        ///Writes a string in the exisiting file
        ///with the help of StreamWriter class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <exception cref="Exception">File doesn't exist</exception>
        public void WriteIntoFile(string data)
        {
            string path = @"C:\Users\Chetan\source\repos\AddressBookFileStream\AddressBookFileStream\Files\AddressBookData.txt";
            bool flag = File.Exists(path);
            if (flag == true)
            {
                using (StreamWriter streamWriter = File.AppendText(path))
                {
                    streamWriter.WriteLine(data);
                    streamWriter.Close();
                }
            }
            else
            {
                throw new Exception("File doesn't exist");
            }
        }
        /// <summary>
        /// Takes input from the user and
        /// calls the WriteIntoFile method to enter the data.
        /// </summary>
        public void EnterData()
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
            AddToAddressBook(firstName, lastName, address, state, zip, phone, email);
            foreach (string data in addressBook)
            {
                WriteIntoFile(data);
            }
        }
        /// <summary>
        /// Adds data to the addressbook list.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="email">The email.</param>
        public void AddToAddressBook(string firstName, string lastName, string address, string state, string zip, string phone, string email)
        {
            AddressBook addressBookMain = new AddressBook(firstName, lastName, address, state, zip, phone, email);
            addressBook.Add(addressBookMain.firstName);
            addressBook.Add(addressBookMain.lastName);
            addressBook.Add(addressBookMain.address);
            addressBook.Add(addressBookMain.state);
            addressBook.Add(addressBookMain.zip);
            addressBook.Add(addressBookMain.phone);
            addressBook.Add(addressBookMain.email);
        }
    }
}
