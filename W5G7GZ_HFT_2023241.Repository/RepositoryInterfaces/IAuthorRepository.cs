using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;

namespace W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        Author Read(int ID);
        IQueryable<Author> ReadAll();
        public void Update(Author author);
        void Delete(int ID);
    }
}
