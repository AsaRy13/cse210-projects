using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        TextInfo textInfo = new CultureInfo("en-US",false).TextInfo;
        Console.WriteLine("Which of the five standard works do you want to pick a scripture from to memorize?:");
        Console.WriteLine("Old Testament");
        Console.WriteLine("New Testament");
        Console.WriteLine("Book of Mormon");
        Console.WriteLine("Doctrine and Covenants");
        Console.WriteLine("Pearl of Great Price");
        string standardWork = Console.ReadLine();

        Console.Write($"Which book would you like from the {standardWork}?: ");
        string book = textInfo.ToTitleCase(Console.ReadLine());

        Console.Write($"Which chapter would you like from {book}?: ");
        int chapter = int.Parse(Console.ReadLine());
        
        Console.Write($"Which verse would you like to start on?: ");
        int startVerse = int.Parse(Console.ReadLine());

        Console.Write($"Which verse would you like to end on? (Set to 0 if you just need one verse): ");
        int endVerse = int.Parse(Console.ReadLine());

        if(endVerse == 0 || endVerse == startVerse) {
            Reference refer = new Reference(standardWork, book, chapter, startVerse);
            Console.WriteLine();
            Console.Write("Press Enter");
            string wait = Console.ReadLine();
            int quit = 0;
            while(quit == 0) {
                Console.Clear();
                Console.WriteLine("If you need to quit type q and press enter. Otherwise to continue just press enter");
                refer.PrintScripture();
                string input = Console.ReadLine();
                if(input.ToLower() == "q" || refer.Quit() == "Quit"){
                    quit = 1;
                }
            }
        }
        else{
            Reference refer = new Reference(standardWork, book, chapter, startVerse, endVerse);
            Console.WriteLine();
            Console.Write("Press Enter");
            string wait = Console.ReadLine();
            int quit = 0;
            while(quit == 0) {
                Console.Clear();
                Console.WriteLine("If you need to quit type q and press enter. Otherwise to continue just press enter");
                refer.PrintScripture();
                string input = Console.ReadLine();
                if(input.ToLower() == "q" || refer.Quit() == "Quit"){
                    quit = 1;
                }
            }
        }
    }
}