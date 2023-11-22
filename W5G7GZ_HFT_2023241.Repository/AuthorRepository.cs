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
        public void Add(Author author)
        {
            ctx.Add(author);
            ctx.SaveChanges();
        }

        public void Update(Author author)
        {
            var old = GetOne(author.AuthorID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(author));
            }
            ctx.SaveChanges();
        }

        public Author GetOne(int ID)
        {
            return GetAll().FirstOrDefault(x => x.AuthorID == ID);
        }
        public IQueryable<Author> GetAll()
        {
            return ctx.Authors;
        }
        public void Delete(int ID)
        {
            var todelete = GetOne(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }


    }
}
