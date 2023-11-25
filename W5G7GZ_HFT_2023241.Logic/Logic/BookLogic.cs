using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Logic.Interfaces;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository;

namespace W5G7GZ_HFT_2023241.Logic.Logic
{
    public class BookLogic : IBookLogic
    {

        IRepository<Book> repo;

        public BookLogic(IRepository<Book> repo)
        {
            this.repo = repo;
        }

        public void Create(Book item)
        {
            if (item.Title.Length < 1)
            {
                throw new ArgumentException("Book name is too short...");
            }
            this.repo.Create(item);
        }
        public Book Read(int id)
        {
            return this.repo.Read(id);
        }
        public void Update(Book item)
        {
            this.repo.Update(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public IQueryable<Book> ReadAll()
        {
            return this.repo.ReadAll();
        }

    }
}
