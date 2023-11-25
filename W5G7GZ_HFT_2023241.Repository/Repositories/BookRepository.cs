using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Repository.Repositories
{
    public class BookRepository : IBookRepository
    {
        BookStoreDbContext ctx;

        public BookRepository(BookStoreDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Add(Book book)
        {
            ctx.Add(book);
            ctx.SaveChanges();
        }

        public void Update(Book book)
        {
            var old = GetOne(book.BookID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(book));
            }
            ctx.SaveChanges();
        }
        public Book GetOne(int ID)
        {
            return GetAll().FirstOrDefault(x => x.BookID == ID);
        }
        public IQueryable<Book> GetAll()
        {
            return ctx.Books;
        }
        public void Delete(int ID)
        {
            var todelete = GetOne(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }
    }
}
