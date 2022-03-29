using System;
using SampleLibrary;
using System.IO;
using System.Collections.Generic;

namespace BibliotekaV1
{
    class Program
    {
        static List<Book> listOfBooks = new List<Book>();
        static void Main()
        {
            Console.WriteLine("Co chcesz zrobić?");
            Console.WriteLine("1\tDodaj książkę");
            Console.WriteLine("2\tWypożycz książkę");
            Console.WriteLine("3\tWyświetl książki");
            Console.WriteLine("4\tPodaj info o wypożyczeniu");
            Console.WriteLine("5\tObczaj książkę");
            int choose = int.Parse(Console.ReadLine());
            Choose(choose);

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
                    ViewListOfBooks();
                    break;
                case 4:
                    ViewInfo();
                    break;
                case 5:
                    ViewBook();
                    break;
            }

        }
        static void AddBook()
        {
            
            Console.WriteLine("Podaj tytuł");
            string title = Console.ReadLine();
            Console.WriteLine("Podaj imię autora");
            string authorFirstName = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora");
            string authorLastName = Console.ReadLine();
            Console.WriteLine("Podaj rok wydania");
            int year = int.Parse(Console.ReadLine());
            
            listOfBooks.Add(Book.AddNewBook(authorFirstName, authorLastName, title, year));
            
        }
        static void ViewBook() { }
        static void RentBook() { }
        static void ViewInfo() { }
        static void ViewListOfBooks() 
        {
            Console.Clear();
            foreach(Book book in listOfBooks)
            {
                Console.WriteLine("Imię autora\tNazwisko autora\tTytuł\tRok");
                Console.WriteLine($"{book.FirstName}\t{book.LastName}\t{book.Title}\t{book.Year}");
            }
        }
        
    }
}
