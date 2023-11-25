using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;

namespace W5G7GZ_HFT_2023241.Logic
{
    public class AuthorLogic : IAuthorLogic
    {
        IAuthorRepository repo;
        public void Create(Author item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Author Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
