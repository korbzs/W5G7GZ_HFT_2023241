using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public interface IBookRepository
    {
        public void Add(Book book);
        void Update(Book book);
        Book GetOne(int ID);
        IQueryable<Book> GetAll();
        void Delete(int ID);
    }
}
