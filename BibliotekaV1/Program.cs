using System;
using SampleLibrary;
using System.IO;
using System.Collections.Generic;

namespace BibliotekaV1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List < Book > listOfBooks = new List<Book>();

        }
        static void Choose(int choose)
        {
            if (choose > 4 || choose<1) return;
            switch(choose)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    RentBook();
                    break;
                case 3:
                    ViewInfo();
                    break;
                case 4:
                    ViewBook();
            }

        }
        static Book AddBook()
        {
            Console.WriteLine("Podaj tytuł");
            string title = Console.ReadLine();
            Console.WriteLine("Podaj imię autora");
            string authorFirstName = Console.ReadLine();
            Console.WriteLine("Podaj tytuł");
            string title = Console.ReadLine();
            Console.WriteLine("Podaj rok wydania");
            int year = int.Parse(Console.ReadLine());
            
        }
        static Book VievBook() { }
        static Rent RentBook() { }
        
    }
}
