using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void ChangePrice(Book book);
        IQueryable<Book> GetAll();
        Book GetOne(int ID);
        void Delete(int ID);
    }
}
