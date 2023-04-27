using System;
using System.Collections.Generic;

class book
{
    public string tytuł { get; set; }
    public string autor { get; set; }
    public string rokwydania { get; set; }
    public string wydawca { get; set; }
    public string numerISBN { get; set; }
    public string gatunek { get; set; }
    public string dostepneEgzemplarze { get; set; }
    public string Status { get; set; }
    public string imię { get; set; }

}

class program
{
    static List<book> books = new List<book>();


    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. LoanBook");
            Console.WriteLine("6. ViewLoanedBooks");
            Console.WriteLine("7. Return book");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Addbook();
                    break;
                case "2":
                    ViewBooks();
                    break;
                case "3":
                    Updatebooks();
                    break;
                case "4":
                    DeleteBook();
                    break;
                case "5":
                    LoanBook();
                    break;
                case "6":
                    ViewLoanedBooks();
                    break;
                case "7":
                    ReturnBook();
                    break;
                case "8":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Wrong Choice, try again.");
                    break;

            }

        }

    }


    static void Addbook()
    {
        book book = new book();

        Console.WriteLine("Enter a title: ");
        book.tytuł = Console.ReadLine();
        ///////////////////////////////////////////
        Console.WriteLine("Enter the author: ");
        book.autor = Console.ReadLine();
        ///////////////////////////////////////////
        Console.WriteLine("Enter the year of publication ");
        book.rokwydania = Console.ReadLine();
        ///////////////////////////////////////////
        Console.WriteLine("Enter the publisher: ");
        book.wydawca = Console.ReadLine();
        ///////////////////////////////////////////
        Console.WriteLine("Enter the ISBN number ");
        book.numerISBN = Console.ReadLine();
        ///////////////////////////////////////////
        Console.WriteLine("Specify the genre ");
        book.gatunek = Console.ReadLine();
        ///////////////////////////////////////////
        Console.WriteLine("Enter the number of copies available ");
        book.dostepneEgzemplarze = Console.ReadLine();

        books.Add(book);
        Console.WriteLine("book added successfully!");




    }
    static void LoanBook()
    {
        Console.WriteLine("Enter the title of the book that you want to Loan: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the full name of the person that you want to Loan to: ");
        string name1 = Console.ReadLine();

        book book = books.Find(c => c.tytuł.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (book != null)
        {
            if (Convert.ToInt32(book.dostepneEgzemplarze) > 0)
            {
                int copies = Convert.ToInt32(book.dostepneEgzemplarze) - 1;
                book.dostepneEgzemplarze = copies.ToString();
                book.imię = name1;
                book.Status = "loaned";
                Console.WriteLine($"Book '{book.tytuł}' has been loaned.");

            }
            else
            {
                Console.WriteLine($"No copies of '{book.tytuł}' are available for loan.");
            }
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    static void ViewLoanedBooks()
    {
        bool loanedBooksFound = false;

        foreach (book book in books)
        {
            if (book.Status == "loaned")
            {
                Console.WriteLine($"Title: {book.tytuł}, Status: {book.Status}, Name: {book.imię}");
                loanedBooksFound = true;
            }
        }

        if (!loanedBooksFound)
        {
            Console.WriteLine("No loaned books found.");
        }
    }

    static void ReturnBook()
    {
        Console.WriteLine("Enter the ISBN number of the book that you want to return: ");
        string number = Console.ReadLine();

        book booktoreturn = books.Find(c => c.numerISBN.Equals(number, StringComparison.OrdinalIgnoreCase));

        bool ReturnedBooks = false;

        foreach (book book in books)
        {
            if (book.numerISBN == number && book.Status == "loaned")
            {
                int copies = Convert.ToInt32(book.dostepneEgzemplarze) + 1;
                book.dostepneEgzemplarze = copies.ToString();
                book.Status = "available";
                ReturnedBooks = true;
                break;
            }
        }
        if (!ReturnedBooks)
        {
            Console.WriteLine(" No books found.");
        }
    }
    static void ViewBooks()
    {
        Console.WriteLine(" ");
        Console.WriteLine("List Of Books :");

        if (books.Count == 0)
        {
            Console.WriteLine("No Books Found.");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.tytuł}, author: {book.autor}, Year: {book.rokwydania}, Publisher: {book.wydawca}" +
                    $"2, numer ISBN: {book.numerISBN}, Genre: {book.gatunek}, Copies available: {book.dostepneEgzemplarze}");
                Console.WriteLine(" ");
            }
        }
    }

    static void Updatebooks()
    {
        Console.WriteLine("Enter the title of the book that you want to update: ");
        string name = Console.ReadLine();

        book book = books.Find(c => c.tytuł.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (book == null)
        {
            Console.WriteLine("No books foud.");
        }
        else
        {
            Console.WriteLine("Enter new title:");
            string booktitle = Console.ReadLine();
            Console.WriteLine("Enter new autor:");
            string autorr = Console.ReadLine();
            Console.WriteLine("Enter the new year of publication:");
            string rok = Console.ReadLine();
            Console.WriteLine("Enter the new publisher:");
            string wydawcaa = Console.ReadLine();
            Console.WriteLine("Enter the new ISBN number:");
            string isbn = Console.ReadLine();
            Console.WriteLine("Enter the new genre:");
            string genres = Console.ReadLine();
            Console.WriteLine("Enter the new number of copies available:");
            string copies = Console.ReadLine();

            book.tytuł = booktitle;
            book.autor = autorr;
            book.rokwydania = rok;
            book.wydawca = wydawcaa;
            book.numerISBN = isbn;
            book.gatunek = genres;
            book.dostepneEgzemplarze = copies;
            Console.WriteLine("Book Updated Successfully!");
        }
    }

    static void DeleteBook()
    {
        Console.WriteLine("Enter the title of the book you want to delete: ");
        string name = Console.ReadLine();
        book book = books.Find(c => c.tytuł.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (book == null)
        {
            Console.WriteLine("No books foud.");
        }
        else
        {
            books.Remove(book);
            Console.WriteLine("Book deleted successfully!");
        }
    }



}