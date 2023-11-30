using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces
{
    public interface IPublisherRepository
    {
        void Create(Publisher publisher);
        public void Update(Publisher publisher);
        Publisher Read(int ID);
        IQueryable<Publisher> ReadAll();
        void Delete(int ID);
    }
}
