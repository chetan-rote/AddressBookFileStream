using System;

namespace AddressBookFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the address book");
            Console.WriteLine("---------------------------");
            SelectChoice();
            Console.ReadKey();
        }
        public static void SelectChoice()
        {
            TextFileStream file = new TextFileStream();            
            Console.WriteLine("Select from the following options:");
            Console.WriteLine("1. Read file\n2. Write into the file");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    file.ReadFile();
                    break;
                case 2:
                    file.EnterData();
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
