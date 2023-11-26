using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Logic.Interfaces
{
    public interface IBookLogic
    {
        //crud
        void Create(Book item);
        void Update(Book item);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Delete(int id);

        //non-crud

        IEnumerable<KeyValuePair<string, int>> BookCountPerPublisher();
        IEnumerable<string> AuthorsWithMultipleBooks();
        KeyValuePair<string, int> AuthorWithTheMostBooks();
        int PriceOfAllBooks();
        IEnumerable<dynamic> GenresForAuthors();
    }
}
