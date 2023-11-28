using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W5G7GZ_HFT_2023241.Logic.Interfaces;
using W5G7GZ_HFT_2023241.Models;
using W5G7GZ_HFT_2023241.Repository.RepositoryInterfaces;
using W5G7GZ_HFT_2023241.Repository.Repositories;
using W5G7GZ_HFT_2023241.Repository;

namespace W5G7GZ_HFT_2023241.Logic.Logic
{
    public class AuthorLogic : IAuthorLogic
    {
        IRepository<Author> repo;

        public AuthorLogic(IRepository<Author> repo)
        {
            this.repo = repo;
        }

        public void Create(Author item)
        {
            if (item.AuthorName.Length < 1)
            {
                throw new ArgumentException("Author name is too short...");
            }
            this.repo.Create(item);
        }
        public Author Read(int id)
        {
            var author = this.repo.Read(id);
            if(author == null)
            {
                throw new ArgumentException("Author does not exist");
            }
            return author;
        }
        public void Update(Author item)
        {
            this.repo.Update(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public IQueryable<Author> ReadAll()
        {
            return this.repo.ReadAll();
        }

    }
}
