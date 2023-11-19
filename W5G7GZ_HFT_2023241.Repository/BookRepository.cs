using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public class BookRepository : IBookRepository
    {
        BookStoreDbContext ctx;

        public BookRepository(BookStoreDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void AddBook(Book book)
        {
            ctx.Add(book);
            ctx.SaveChanges();
        }

        public void ChangePrice(Book book)
        {
            var book1 = GetOne(book.BookID);
            book1.Price = book.Price;
            ctx.SaveChanges();
        }

        public void Delete(int ID)
        {
            var todelete = GetOne(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }

        public IQueryable<Book> GetAll()
        {
            return ctx.Books;
        }

        public Book GetOne(int ID)
        {
            return GetAll().FirstOrDefault(x => x.BookID == ID);
        }
    }
}
