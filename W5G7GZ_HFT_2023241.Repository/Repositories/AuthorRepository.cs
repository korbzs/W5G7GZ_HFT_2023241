using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Repository.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        BookStoreDbContext ctx;
        public AuthorRepository(BookStoreDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(Author author)
        {
            ctx.Add(author);
            ctx.SaveChanges();
        }
        public Author Read(int ID)
        {
            return ctx.Set<Author>().FirstOrDefault(x => x.AuthorID == ID);
        }

        public void Update(Author author)
        {
            var old = Read(author.AuthorID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if(prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(author));
                }
            }
            ctx.SaveChanges();
        }

        public IQueryable<Author> GetAll()
        {
            return ctx.Authors;
        }
        public void Delete(int ID)
        {
            var todelete = Read(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }

        public IQueryable<Author> ReadAll()
        {
            return ctx.Set<Author>();
        }
    }
}
