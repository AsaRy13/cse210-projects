using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        int quit = 0;
        Journal journal = new Journal();
        journal.AddToList();

        while(quit == 0) {
            Console.WriteLine("Journal");
            Console.Write("Would you like to [w]rite an entry, [r]ead past entries, or [q]uit?: ");
            string choice = Console.ReadLine();

            if(choice.ToLower() == "quit" || choice.ToLower() == "q") {
                quit = 1;
            }
            else if(choice.ToLower() == "write" || choice.ToLower() == "w") {
                Console.WriteLine();
                journal.NewEntry();
                Console.WriteLine();
            }
            else if(choice.ToLower() == "read" || choice.ToLower() == "r") {
                Console.WriteLine();
                Console.Write("Where is the file with the entries that you would like to read? (Leave blank to go back.): ");
                string import = Console.ReadLine();

                if(import != "") {
                    journal.Import(import);
                    journal.DisplayEntries();
                }
            }
            else {
                Console.WriteLine("I didn't understand that.\n");
            }
        }
    }
}