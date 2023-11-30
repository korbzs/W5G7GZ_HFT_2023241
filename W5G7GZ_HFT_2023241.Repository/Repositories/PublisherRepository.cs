using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Repository.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        BookStoreDbContext ctx;

        public PublisherRepository(BookStoreDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(Publisher publisher)
        {
            ctx.Add(publisher);
            ctx.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            var old = Read(publisher.PublisherID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(publisher));
                }
            }
            ctx.SaveChanges();
        }
        public Publisher Read(int ID)
        {
            return ctx.Set<Publisher>().FirstOrDefault(x => x.PublisherID == ID);
        }
        public IQueryable<Publisher> ReadAll()
        {
            return ctx.Publishers;
        }

        public void Delete(int ID)
        {
            var todelete = Read(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }
    }
}
