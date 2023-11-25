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

        public void Add(Publisher publisher)
        {
            ctx.Add(publisher);
            ctx.SaveChanges();
        }

        public void Update(Publisher publisher)
        {
            var old = GetOne(publisher.PublisherID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(publisher));
            }
            ctx.SaveChanges();
        }
        public Publisher GetOne(int ID)
        {
            return GetAll().FirstOrDefault(x => x.PublisherID == ID);
        }
        public IQueryable<Publisher> GetAll()
        {
            return ctx.Publishers;
        }

        public void Delete(int ID)
        {
            var todelete = GetOne(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }
    }
}
