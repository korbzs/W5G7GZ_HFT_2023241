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

        IEnumerable<KeyValuePair<string, int>> BookCountPerPublisher();

        IEnumerable<string> AuthorsWithMultipleBooks();
        KeyValuePair<string, int> AuthorWithTheMostBooks();
        int PriceOfAllBooks();
        public List<Book> BooksByGenre(string genre);
        public List<Author> AuthorsBornInDecade(int startYear);
    }
}
