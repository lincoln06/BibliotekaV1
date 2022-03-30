using System;
using SampleLibrary;
using System.IO;
using System.Collections.Generic;

namespace BibliotekaV1
{
    class Program
    {
        static List<Book> listOfBooks = new List<Book>();
        static List<Rent> listOfRentedBooks = new List<Rent>();
        static void Main()
        {
            int choose = 0;
            while (choose < 6)
            {
                Console.WriteLine("Co chcesz zrobić?");
                Console.WriteLine("1\tDodaj książkę");
                Console.WriteLine("2\tWypożycz książkę");
                Console.WriteLine("3\tWyświetl książki");
                Console.WriteLine("4\tPodaj info o wypożyczeniu");
                Console.WriteLine("5\tObczaj książkę");
                Console.WriteLine("6\tWyjdź");
                choose = int.Parse(Console.ReadLine());
                Choose(choose);
            }
        }
        static void Choose(int choose)
        {
            if (choose > 5 || choose<1) return;
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
            
            //FOR DEBUG!!!!
            //Console.WriteLine(listOfBooks.Count);
            
        }
        static void ViewBook() 
        {
            Console.Clear();
            Console.WriteLine($"Lista książek zawiera {listOfBooks.Count}\nKtóry element chcesz wyśiwetlić?\n");
            int number = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Tytuł\tAutor\t\tRok wydania");
            Console.WriteLine($"{listOfBooks[number].Title}\t{listOfBooks[number].FirstName} {listOfBooks[number].LastName}\t{listOfBooks[number].Year}");
            Console.ReadKey();    
        }
        static void RentBook() 
        {
            ViewListOfBooks();
            Console.WriteLine("Którą książkę chcesz wypożyczyć? Podaj numer pozycji\n");
            int number = int.Parse(Console.ReadLine());
            number--;
            if (number < 0 || number > listOfBooks.Count+1)
            {
                Console.Clear();
                RentBook();
            }
            Console.WriteLine("Podaj imię wypożyczającego");
            string ownerFirstName = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko wypożyczającego");
            string ownerLastName = Console.ReadLine();
            DateTime wasTaken = DateTime.Today;
            DateTime mustGiveBack = wasTaken.AddDays(30);
            listOfRentedBooks.Add(Rent.RentBook(ownerFirstName, ownerLastName, listOfBooks[number].Title, listOfBooks[number].Year, listOfBooks[number].FirstName, listOfBooks[number].LastName, wasTaken, mustGiveBack));
            listOfBooks.RemoveAt(number);

        }
        static void ViewInfo() 
        {
            
            Console.WriteLine($"L.p.\t Imię i nazwisko\tTytuł\tAutor\t\tRok\tData wypoż.\tData oddania\n");
            foreach(Rent rent in listOfRentedBooks)
            {
                Console.WriteLine($"{listOfRentedBooks.IndexOf(rent)+1}\t{rent.OwnerFirstName} {rent.OwnerLastName}\t{rent.Title}\t{rent.FirstName} {rent.LastName}\t{rent.Year}\t{rent.WasTaken}\t{rent.MustGiveBack}");
            }
        }
        static void ViewListOfBooks() 
        {
            Console.Clear();
            foreach(Book book in listOfBooks)
            {
                Console.WriteLine("L.p.\tImię autora\tNazwisko autora\tTytuł\tRok");
                Console.WriteLine($"{listOfBooks.IndexOf(book)+1}\t{book.FirstName}\t{book.LastName}\t{book.Title}\t{book.Year}");
            }
            //FOR DEBUG
            Console.WriteLine(listOfBooks.Count);
        }
        
    }
}
