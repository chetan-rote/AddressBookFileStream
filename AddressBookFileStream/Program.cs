using System;

namespace AddressBookFileStream
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the address book");
            Console.WriteLine("---------------------------");
            SelectChoice();
            Console.ReadKey();
        }
        public static void SelectChoice()
        {
            CsvReadWrite csv = new CsvReadWrite();            
            Console.WriteLine("Select from the following options:");
            Console.WriteLine("1. Read file\n2. Write into the file");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    csv.CSVDataReading();
                    break;
                case 2:
                    csv.CSVDataWriting();
                    break;                    
                default:
                    Console.WriteLine("Enter valid choice");
                    break;
            }
            Console.WriteLine("Do you wish to go back to the main menu? Yes or No");
            string answer = Console.ReadLine();
            if (answer.ToLower().Equals("yes"))
            {
                SelectChoice();
            }
            else
            {
                Console.WriteLine("Thank you");
            }
        }
    }
}
