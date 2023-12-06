using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Logic.Logic;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository.Repositories;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Logic.Interfaces
{
    public interface IBookLogic
    {
        //crud
        void Create(Book item);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book item);
        void Delete(int id);

        //non-crud

        IEnumerable<KeyValuePair<string, int>> BookCountPerPublisher(); // returns each publisher and the amount of books that they have

        IEnumerable<string> AuthorsWithMultipleBooks(); // returns authors who have more than 1 books
        KeyValuePair<string, int> AuthorWithTheMostBooks(); // returns the author with the most books
        int PriceOfAllBooks(); // returns the price of all books combined
        public List<Book> BooksByGenre(string genre); // returns books that is equals to the genre
        public List<Author> AuthorsBornInDecade(int startYear); // it returns authors who born in the interval of [starYear, startYear + 10]
                                                                // so if startYear = 1900, it will return every author that born from 1900 to 1910
    }
}
