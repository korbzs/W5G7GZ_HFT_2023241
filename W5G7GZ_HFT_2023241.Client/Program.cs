using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using W5G7GZ_HFT_2023241.Logic.Logic;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository;
using W5G7GZ_HFT_2023241.Repository.Repositories;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Client
{
    public class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Author")
            {
                Console.WriteLine("Enter Author's Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Author's BirthYear: ");
                int birth = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Author's Nationality: ");
                string nationality = Console.ReadLine();
                rest.Post(new Author() { AuthorName = name, BirthYear = birth, Nationality = nationality }, "author");
            }
            else if (entity == "Book")
            {
                Console.WriteLine("Enter Book's Name: ");
                string title = Console.ReadLine();
                Console.WriteLine("Enter AuthorID of the Book: ");
                int authID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter PublisherID of the Book: ");
                int publID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book's Publication Year: ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book's Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book's Genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter Book's ISBN: ");
                string isbn = Console.ReadLine();

                rest.Post(new Book()
                {
                    AuthorID = authID,
                    PublisherID = publID,
                    Title = title,
                    PublicationYear = year,
                    Genre = genre,
                    ISBN = isbn,
                    Price = price
                }, "book");
            }
            else if (entity == "Publisher")
            {
                Console.WriteLine("Enter Publisher Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Publisher Headquarters: ");
                string hq = Console.ReadLine();
                Console.WriteLine("Enter Publisher's Foundation Year: ");
                int year = int.Parse(Console.ReadLine());
                rest.Post(new Publisher() { PublisherName = name, FoundatitonYear = year, Headquarters = hq }, "publisher");
            }
        }

        static void List(string entity)
        {
            if (entity == "Author")
            {
                List<Author> authors = rest.Get<Author>("author");
                foreach (var item in authors)
                {
                    item.ToString();
                    Console.WriteLine();
                }
            }
            else if (entity == "Book")
            {
                List<Book> books = rest.Get<Book>("book");
                foreach (var item in books)
                {
                    item.ToString();
                    Console.WriteLine();
                }
            }

            else if (entity == "Publisher")
            {
                List<Publisher> publishers = rest.Get<Publisher>("book");
                foreach (var item in publishers)
                {
                    item.ToString();
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Author")
            {
                Console.Write("Enter Author's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Author one = rest.Get<Author>(id, "author");

                Console.WriteLine("Enter Author's Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Author's BirthYear: ");
                int birth = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Author's Nationality: ");
                string nationality = Console.ReadLine();

                one.AuthorName = name;
                one.BirthYear = birth;
                one.Nationality = nationality;

                rest.Put(one, "author");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Publisher one = rest.Get<Publisher>(id, "publisher");

                Console.WriteLine("Enter Publisher Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Publisher Headquarters: ");
                string hq = Console.ReadLine();
                Console.WriteLine("Enter Publisher's Foundation Year: ");
                int year = int.Parse(Console.ReadLine());

                one.PublisherName = name;
                one.FoundatitonYear = year;
                one.Headquarters = hq;

                rest.Put(one, "publisher");
            }
            else if (entity == "Book")
            {
                Console.Write("Enter Book's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Book one = rest.Get<Book>(id, "book");

                Console.WriteLine("Enter Book's Name: ");
                string title = Console.ReadLine();
                Console.WriteLine("Enter AuthorID of the Book: ");
                int authID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter PublisherID of the Book: ");
                int publID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book's Publication Year: ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book's Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Book's Genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter Book's ISBN: ");
                string isbn = Console.ReadLine();

                one.AuthorID = authID;
                one.PublisherID = publID;
                one.Title = title;
                one.PublicationYear = year;
                one.Price = price;
                one.Genre = genre;
                one.ISBN = isbn;

                rest.Put(one, "author");
            }
        }


        static void Delete(string entity)
        {
            if (entity == "Author")
            {
                Console.Write("Enter Authors's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "author");
            }
            else if (entity == "Book")
            {
                Console.Write("Enter Book's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "book");
            }

            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "publisher");
            }
        }

        static void NonCrud(string entity)
        {
            //IEnumerable<KeyValuePair<string, int>> BookCountPerPublisher();
            //IEnumerable<string> AuthorsWithMultipleBooks();
            //KeyValuePair<string, int> AuthorWithTheMostBooks();
            //int PriceOfAllBooks();
            //IEnumerable<GenresForAuthorsClass> GenresForAuthors();

            if (entity == "BookCountPerPublisher")
            {
                IEnumerable<KeyValuePair<string, int>> BCPP = rest.GetSingle<IEnumerable<KeyValuePair<string, int>>>("/api/NonCrudField/BookCountPerPublisher");
                Console.WriteLine(BCPP);
                Console.ReadLine();
            }
            if (entity == "AuthorsWithMultipleBooks")
            {
                IEnumerable<string> AWMB = rest.GetSingle<IEnumerable<string>>("/api/NonCrudSeason/AuthorsWithMultipleBooks");
                Console.WriteLine(AWMB);
                Console.ReadLine();
            }
            if (entity == "AuthorWithTheMostBooks")
            {
                KeyValuePair<string, int> AWTMB = rest.GetSingle<KeyValuePair<string, int>>("/api/NonCrudSeason/AuthorWithTheMostBooks");
                
                Console.WriteLine($"{AWTMB.Key} has the most books: {AWTMB.Value} books");
                Console.ReadLine();
            }
            if (entity == "PriceOfAllBooks")
            {
                int sum = rest.GetSingle<int>("/api/NonCrudSeason/PriceOfAllBooks");
                Console.WriteLine($"Price of all books combined: {sum}");
                Console.ReadLine();
            }
            if (entity == "GenresForAuthors")
            {
                IEnumerable<GenresForAuthorsClass> GFAC = rest.GetSingle<IEnumerable<GenresForAuthorsClass>>("/api/NonCrudSeason/GenresForAuthors");
                foreach (var item in GFAC)
                {
                    Console.WriteLine($"{item.AuthorName}: {String.Join(", ", item.Genres)}");
                }
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:50638/", "bookstore");
            //rest = new RestService("http://localhost:5057/");

            var AuthorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Delete", () => Delete("Author"))
                 .Add("Update", () => Update("Author"))
                .Add("Exit", ConsoleMenu.Close);

            var PublisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Exit", ConsoleMenu.Close);

            var BookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
                .Add("Create", () => Create("Book"))
                .Add("Delete", () => Delete("Book"))
                .Add("Update", () => Update("Book"))
                .Add("Exit", ConsoleMenu.Close);


            var nonCrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Book Count Per Publisher", () => NonCrud("BookCountPerPublisher"))
                .Add("Authors With Multiple Books", () => NonCrud("AuthorsWithMultipleBooks"))
                .Add("Author With The Most Books", () => NonCrud("AuthorWithTheMostBooks"))
                .Add("Price Of All Books", () => NonCrud("PriceOfAllBooks"))
                .Add("Genres For Authors", () => NonCrud("GenresForAuthors"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                 .Add("Authors", () => AuthorSubMenu.Show())
                 .Add("Publishers", () => PublisherSubMenu.Show())
                 .Add("Books", () => BookSubMenu.Show())
                 .Add("Non CRUD", () => nonCrudSubMenu.Show())
                 .Add("Exit", ConsoleMenu.Close);

            Console.WriteLine("asd");
            menu.Show();
        }
    }
}