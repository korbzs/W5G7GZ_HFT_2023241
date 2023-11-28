using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Logic.Interfaces;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository;

namespace W5G7GZ_HFT_2023241.Logic.Logic
{
    public class PublisherLogic : IPublisherLogic
    {


        IRepository<Publisher> repo;

        public PublisherLogic(IRepository<Publisher> repo)
        {
            this.repo = repo;
        }

        public void Create(Publisher item)
        {
            if (item.PublisherName.Length < 1)
            {
                throw new ArgumentException("Publisher name is too short...");
            }
            this.repo.Create(item);
        }
        public Publisher Read(int id)
        {
            var publisher = this.repo.Read(id);
            if(publisher == null)
            {
                throw new ArgumentException("Publisher does not exist");
            }
            return publisher;
        }
        public void Update(Publisher item)
        {
            this.repo.Update(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return this.repo.ReadAll();
        }
    }
}
