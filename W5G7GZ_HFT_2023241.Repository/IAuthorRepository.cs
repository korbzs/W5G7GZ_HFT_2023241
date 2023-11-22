using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        public void Update(Author author);
        Author GetOne(int ID);
        IQueryable<Author> GetAll();
        void Delete(int ID);
    }
}
