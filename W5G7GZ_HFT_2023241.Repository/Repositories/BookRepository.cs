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

        public void Create(Book book)
        {
            ctx.Add(book);
            ctx.SaveChanges();
        }

        public void Update(Book book)
        {
            var old = Read(book.BookID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(book));
                }
            }
            ctx.SaveChanges();
        }
        public Book Read(int ID)
        {
            return ctx.Set<Book>().FirstOrDefault(x => x.BookID == ID);
        }
        public IQueryable<Book> ReadAll()
        {
            return ctx.Books;
        }
        public void Delete(int ID)
        {
            var todelete = Read(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }
    }
}
