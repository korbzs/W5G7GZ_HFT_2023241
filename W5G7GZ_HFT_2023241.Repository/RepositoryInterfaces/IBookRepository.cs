using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces
{
    public interface IBookRepository
    {
        public void Create(Book book);
        void Update(Book book);
        Book Read(int ID);
        IQueryable<Book> ReadAll();
        void Delete(int ID);
    }
}
