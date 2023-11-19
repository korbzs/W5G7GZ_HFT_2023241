using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        BookStoreDbContext ctx;
        public AuthorRepository(BookStoreDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void AddAuthor(Author author)
        {
            ctx.Add(author);
            ctx.SaveChanges();
        }

        public void ChangeName(Author author)
        {
            var author1 = GetOne(author.AuthorID);
            author1.AuthorName = author.AuthorName;
            author1.BirthDate = author.BirthDate;
            author1.Nationality = author.Nationality;
            ctx.SaveChanges();
        }

        public void Delete(int ID)
        {
            var todelete = GetOne(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }

        public IQueryable<Author> GetAll()
        {
            return ctx.Authors;
        }

        public Author GetOne(int ID)
        {
            return GetAll().FirstOrDefault(x => x.AuthorID == ID);
        }
    }
}
