using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        BookStoreDbContext ctx;

        public PublisherRepository(BookStoreDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void AddPublisher(Publisher publisher)
        {
            ctx.Add(publisher);
            ctx.SaveChanges();
        }

        public void ChangeHeadquarters(Publisher publisher)
        {
            var publisher1 = GetOne(publisher.PublisherID);
            publisher1.Headquarters = publisher.Headquarters;
            ctx.SaveChanges();
        }

        public void Delete(int ID)
        {
            var todelete = GetOne(ID);
            ctx.Remove(todelete);
            ctx.SaveChanges();
        }

        public IQueryable<Publisher> GetAll()
        {
            return ctx.Publishers;
        }

        public Publisher GetOne(int ID)
        {
            return GetAll().FirstOrDefault(x => x.PublisherID == ID);
        }
    }
}
