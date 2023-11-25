using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Logic.Interfaces
{
    public interface IPublisherLogic
    {
        //crud
        void Create(Publisher item);
        void Update(Publisher item);
        Publisher Read(int id);
        IQueryable<Publisher> ReadAll();
        void Delete(int id);
    }
}
