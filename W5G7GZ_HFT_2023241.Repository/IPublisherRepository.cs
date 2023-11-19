using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public interface IPublisherRepository
    {
        void AddPublisher(Publisher publisher);
        void ChangeHeadquarters(Publisher publisher);
        IQueryable<Publisher> GetAll();
        Publisher GetOne(int ID);
        void Delete(int ID);
    }
}
